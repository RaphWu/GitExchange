using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PCI_DMC;
using PCI_DMC_ERR;

namespace DMC_NET
{
    public partial class Form1 : Form
    {
        short existcard = 0, rc;
        ushort gCardNo = 0, DeviceInfo = 0, nodeid = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        bool gIsServoOn;
        int gMoveMode = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, running = 0, card_no = 0;

            chkSVON.Enabled = false;
            cmdNmove.Enabled = false;
            cmdPmove.Enabled = false;
            cmdSTOP.Enabled = false;
            cmdReset.Enabled = false;
            cmdRALM.Enabled = false;

            cmdPchange.Enabled = false;
            cmdVchange.Enabled = false;
            cmdFO.Enabled = false;

            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            btnFindSlave.Enabled = false;
            txtSlaveNum.Text = "0";
            CmbCardNo.Items.Clear();
            cmbNodeID.Items.Clear();

            rc = CPCI_DMC.CS_DMC_01_open(ref existcard);

            if (existcard <= 0)
                MessageBox.Show("No DMC-NET card can be found!");
            else
            {

                for (i = 0; i < existcard; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref card_no);
                    gCardNoList[i] = card_no;

                    CmbCardNo.Items.Insert(i, card_no);

                }

                btnFindSlave.Enabled = true;        //2011.08.05
                CmbCardNo.SelectedIndex = 0;
                gCardNo = gCardNoList[0];

                for (i = 0; i < existcard; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_pci_initial(gCardNoList[i]);
                    if (rc != 0)
                        MessageBox.Show("Can't boot PCI_DMC Master Card!");

                    rc = CPCI_DMC.CS_DMC_01_initial_bus(gCardNoList[i]);
                    if (rc != 0)
                    {
                        MessageBox.Show("Initial Failed!");
                    }
                    else
                    {
                        rc = CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0);                      //Start communication                      
                        rc = CPCI_DMC.CS_DMC_01_get_device_table(gCardNo, ref DeviceInfo);   //Get Slave Node ID 
                        rc = CPCI_DMC.CS_DMC_01_get_node_table(gCardNo, ref SlaveTable[0]);
                    }
                }
            }


        }

        private void chksvon_CheckedChanged(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, nodeid, 0, 1);
            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 1);

            rc =CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, (ushort)(gIsServoOn ? 1 : 0));
        }

        private void btnralm_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 0);
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
           nodeid = ushort.Parse(cmbNodeID.Text);

           CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
           CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int cmd=0,pos=0,speed=0;
            uint MC_status = 0,err=0;
            ushort MC_done = 0;
            nodeid = ushort.Parse(cmbNodeID.Text);

            if (chkTimer.Checked)
            {
                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid, 0, ref cmd);
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid, 0, ref pos);
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, 0, ref speed);
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid, 0, ref MC_status);
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid, 0, ref err);

                txtCMD.Text = cmd.ToString();
                txtFBK.Text = pos.ToString();
                txtSPD.Text = speed.ToString();
                txtIO.Text = MC_status.ToString("X2");
                txtMotion.Text = MC_done.ToString();
                txtERR.Text = err.ToString();
            }
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0;
            uint DeviceType = 0, IdentityObject = 0;

            chkSVON.Enabled = false;
            cmdNmove.Enabled = false;
            cmdPmove.Enabled = false;
            cmdSTOP.Enabled = false;
            cmdReset.Enabled = false;
            cmdRALM.Enabled = false;

            cmdPchange.Enabled = false;
            cmdVchange.Enabled = false;
            cmdFO.Enabled = false;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID.Items.Clear();

            for (i = 0; i < 1; i++) NodeID[i] = 0;

            if (SlaveTable[0] == 0)
                MessageBox.Show("CardNo: " + gCardNo.ToString() + " No slave found!");      
            else
            {
                for (i = 0; i < 32; i++)
                {
                    if ((SlaveTable[0] & lMask) != 0)
                    {
                        NodeID[gNodeNum] = (ushort)(i + 1);
                        gNodeNum++;
                        rc = CPCI_DMC.CS_DMC_01_get_devicetype(CardNo, (ushort)(i + 1), (ushort)0, ref DeviceType, ref IdentityObject);
                        if (rc != 0)
                        {
                            MessageBox.Show("get_devicetype failed - code=" + rc);
                        }
                        else
                        {
                            switch (DeviceType)
                            {
                                case 0x4020192:				//Servo A2 series
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x6020192:				//Servo M series
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x8020192:				//Servo A2R series
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x9020192:				//Servo S series
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x14100191:			//Remote Module 04PI
                                    cmbNodeID.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                                case 0x11210191:			//GE01PH
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                {
                    MessageBox.Show("No A2 Servo/04PI/01PH Device Found!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    chkSVON.Enabled = true;
                    cmdNmove.Enabled = true;
                    cmdPmove.Enabled = true;
                    cmdSTOP.Enabled = true;
                    cmdReset.Enabled = true;
                    cmdRALM.Enabled = true;

                    cmdPchange.Enabled = true;
                    cmdVchange.Enabled = true;
                    cmdFO.Enabled = true;

                    chkAbs.Checked = false;
                    chkSCurve.Checked = false;

                    func0.Checked = true;

                    cmbFO.SelectedIndex = 2;
                }
            }

        }


        private void cmdExit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

            CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void func0_CheckedChanged(object sender, EventArgs e)
        {
            gMoveMode = 0;
            lblMaxVel.Text = "MaxVel.";
            lblAcc.Text = "Acc.";
            lblDec.Text = "Dec.";
            txtEndVel.Enabled = false;
            txtTsec.Enabled = false;
            txtDec.Enabled = true;
            txtDist.Enabled = true;
            txt2Dist.Enabled = false;
            txt2Vel.Enabled = false;
            cmdPchange.Enabled = true;
            cmdVchange.Enabled = true;
            cmdFO.Enabled = true;
            chkAbs.Enabled = true;
        }

        private void func1_CheckedChanged(object sender, EventArgs e)
        {
            gMoveMode = 1;
            lblMaxVel.Text = "MaxVel.";
            lblAcc.Text = "Acc.";
            lblDec.Text = "Dec.";
            txtEndVel.Enabled = false;
            txtTsec.Enabled = true;
            txtDec.Enabled = true;
            txtDist.Enabled = true;
            txt2Dist.Enabled = true;
            txt2Vel.Enabled = true;
            cmdPchange.Enabled = false;
            cmdVchange.Enabled = false;
            cmdFO.Enabled = false;
            chkAbs.Enabled = true;
        }

        private void func2_CheckedChanged(object sender, EventArgs e)
        {
            gMoveMode = 2;
            lblMaxVel.Text = "MaxVel.";
            lblAcc.Text = "Acc.";
            lblDec.Text = "Dec.";
            txtEndVel.Enabled = false;
            txtTsec.Enabled = true;
            txtDec.Enabled = true;
            txtDist.Enabled = true;
            txt2Dist.Enabled = true;
            txt2Vel.Enabled = true;
            cmdPchange.Enabled = false;
            cmdVchange.Enabled = false;
            cmdFO.Enabled = false;
            chkAbs.Enabled = true;
        }

        private void func3_CheckedChanged(object sender, EventArgs e)
        {
            gMoveMode = 3;
            lblMaxVel.Text = "MaxVel.";
            lblAcc.Text = "Acc.";
            lblDec.Text = "Dec.";
            txtEndVel.Enabled = false;
            txtTsec.Enabled = false;
            txtDec.Enabled = false;
            txtDist.Enabled = false;
            txt2Dist.Enabled = false;
            txt2Vel.Enabled = false;
            cmdPchange.Enabled = false;
            cmdVchange.Enabled = false;
            cmdFO.Enabled = false;
            chkAbs.Enabled = false;
        }

        private void func4_CheckedChanged(object sender, EventArgs e)
        {
            gMoveMode = 4;
            lblMaxVel.Text = "ConstVel.";
            lblAcc.Text = "TPhase1.";
            lblDec.Text = "TPhase2.";
            txtEndVel.Enabled = true;
            txtTsec.Enabled = false;
            txtDec.Enabled = true;
            txtDist.Enabled = true;
            txt2Dist.Enabled = false;
            txt2Vel.Enabled = false;
            cmdPchange.Enabled = false;
            cmdVchange.Enabled = false;
            cmdFO.Enabled = false;
            chkAbs.Enabled = true;
        }

        private void chkTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdPchange_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            int NewPos = Int32.Parse(txtNewP.Text);

            rc = CPCI_DMC.CS_DMC_01_p_change(gCardNo, nodeid, 0, NewPos);
        }

        private void chkSVON_CheckedChanged_1(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            if (chkSVON.Checked)
            {
                rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, 1);
            }
            else
            {
                rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, 0);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
            CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        }

        private void cmdRALM_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            rc = CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 0);
        }

        private void cmdPmove_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            int StrVel=Int32.Parse(txtStrVel.Text);
            int MaxVel=Int32.Parse(txtMaxVel.Text);
            int EndVel=Int32.Parse(txtEndVel.Text);
            double Acc=Double.Parse(txtAcc.Text);
            double Tsec=Double.Parse(txtTsec.Text);
            double Dec=Double.Parse(txtDec.Text);
            int Dist=Int32.Parse(txtDist.Text);
            int Dist2=Int32.Parse(txt2Dist.Text);
            int Vel2=Int32.Parse(txt2Vel.Text);
            int ConstVel = MaxVel;
            double TPhase1 = Acc;
            double TPhase2 = Dec;

            switch (gMoveMode)
            {
                case 0:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                    }
                    else
                    {
                        if (chkSCurve.Checked)
                            rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                    }
                    break;
                case 1:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sa_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_ta_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    else
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sr_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_tr_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    break;
                case 2:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sa_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_ta_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    else
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sr_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_tr_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    break;
                case 3:
                    if (chkSCurve.Checked == true)
                        rc = CPCI_DMC.CS_DMC_01_sv_move(gCardNo, nodeid, 0, StrVel, MaxVel, Acc, 0);
                    else
                        rc = CPCI_DMC.CS_DMC_01_tv_move(gCardNo, nodeid, 0, StrVel, MaxVel, Acc, 0);
                    break;
                case 4:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 1);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 1, 1);
                    }
                    else
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 0);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 1, 0);
                    }
                    break;
            }
        }

        private void cmdSTOP_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
        }

        private void cmdNmove_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            int StrVel = Int32.Parse(txtStrVel.Text);
            int MaxVel = Int32.Parse(txtMaxVel.Text);
            int EndVel = Int32.Parse(txtEndVel.Text);
            double Acc = Double.Parse(txtAcc.Text);
            double Tsec = Double.Parse(txtTsec.Text);
            double Dec = Double.Parse(txtDec.Text);
            int Dist = 0-Int32.Parse(txtDist.Text);
            int Dist2 = 0-Int32.Parse(txt2Dist.Text);
            int Vel2 = Int32.Parse(txt2Vel.Text);
            int ConstVel = MaxVel;
            double TPhase1 = Acc;
            double TPhase2 = Dec;

            switch (gMoveMode)
            {
                case 0:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                    }
                    else
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                    }
                    break;
                case 1:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sa_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_ta_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    else
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sr_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_tr_move_2seg(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    break;
                case 2:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sa_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_ta_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    else
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_sr_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_tr_move_2seg2(gCardNo, nodeid, 0, Dist, Dist2, StrVel, MaxVel, Vel2, Acc, Tsec, Dec);
                    }
                    break;
                case 3:
                    if (chkSCurve.Checked == true)
                        rc = CPCI_DMC.CS_DMC_01_sv_move(gCardNo, nodeid, 0, StrVel, MaxVel, Acc, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_tv_move(gCardNo, nodeid, 0, StrVel, MaxVel, Acc, 1);
                    break;
                case 4:
                    if (chkAbs.Checked == true)
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 1);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 1, 1);
                    }
                    else
                    {
                        if (chkSCurve.Checked == true)
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 0);
                        else
                            rc = CPCI_DMC.CS_DMC_01_start_v3_move(gCardNo, nodeid, 0, Dist, StrVel, ConstVel, EndVel, TPhase1, TPhase2, 1, 0);
                    }
                    break;
            }
        }

        private void cmdVchange_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            int NewVel = Int32.Parse(txtNewV.Text);
            double NewAccDec=Double.Parse(txtDec.Text);

            rc = CPCI_DMC.CS_DMC_01_v_change(gCardNo, nodeid, 0, NewVel,NewAccDec);
        }

        private void cmbFO_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFO.SelectedIndex)
            {
                case 0:
                    txtFOnewV.Enabled = true;
                    txtFOnewAccDec.Enabled = true;
                    txtFOrate.Enabled = false;
                    break;
                case 1:
                    txtFOnewV.Enabled = true;
                    txtFOnewAccDec.Enabled = true;
                    txtFOrate.Enabled = false;
                    break;
                case 2:
                    txtFOnewV.Enabled = false;
                    txtFOnewAccDec.Enabled = false;
                    txtFOrate.Enabled = true;
                    break;
            }
        }

        private void cmdFO_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            int newV = 0;
            double newAccDec=Double.Parse(txtFOnewAccDec.Text);
            switch (cmbFO.SelectedIndex)
            {
                case 0:
                    newV = Int32.Parse(txtFOnewV.Text);
                    rc = CPCI_DMC.CS_DMC_01_feedrate_overwrite(gCardNo, nodeid, 0, 0, newV, newAccDec);
                    break;
                case 1:
                    newV = Int32.Parse(txtFOnewV.Text);
                    rc = CPCI_DMC.CS_DMC_01_feedrate_overwrite(gCardNo, nodeid, 0, 1, newV, newAccDec);
                    break;
                case 2:
                    newV = Int32.Parse(txtFOrate.Text);
                    rc = CPCI_DMC.CS_DMC_01_feedrate_overwrite(gCardNo, nodeid, 0, 2, newV, newAccDec);                    
                    break;
            }
        }
    }
}
