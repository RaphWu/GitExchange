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
        ushort gCardNo = 0, DeviceInfo = 0, nodeid1 = 0, nodeid2 = 0, nodeid3 = 0, nodeid4 = 0;
        ushort[] gnodeid = new ushort[4];
        ushort[] gslot = new ushort[4];
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        bool gIsServoOn=false,gbIsAbs=false,gbIsScurve=false,gbIsV3=false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0;

            chkSVON.Enabled = false;
            cmdNmove.Enabled = false;
            cmdPmove.Enabled = false;
            cmdSTOP.Enabled = false;
            cmdReset.Enabled = false;
            cmdRALM.Enabled = false;

            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            btnFindSlave.Enabled = false;
            txtSlaveNum.Text = "0";
            CmbCardNo.Items.Clear();
            cmbNodeID1.Items.Clear();
            cmbNodeID2.Items.Clear();
            cmbNodeID3.Items.Clear();

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            int cmd=0,pos=0,speed=0;
            uint MC_status = 0,err=0;
            ushort MC_done = 0;
            gslot[0] = 0;
            gslot[1] = 0;
            gslot[2] = 0;
            gslot[3] = 0;

            if (chkTimer.Checked)
            {
                gnodeid[0] = (ushort.Parse(cmbNodeID1.Text));
                gnodeid[1] = (ushort.Parse(cmbNodeID2.Text));
                gnodeid[2] = (ushort.Parse(cmbNodeID3.Text));
                gnodeid[3] = (ushort.Parse(cmbNodeID4.Text));
                nodeid1 = gnodeid[0];
                nodeid2 = gnodeid[1];
                nodeid3 = gnodeid[2];
                nodeid4 = gnodeid[3];

                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid1, 0, ref cmd);
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid1, 0, ref pos);
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid1, 0, ref speed);
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid1, 0, ref MC_status);
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid1, 0, ref MC_done);
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid1, 0, ref err);

                txtCMD.Text = cmd.ToString();
                txtFBK.Text = pos.ToString();
                txtSPD.Text = speed.ToString();
                txtIO.Text = MC_status.ToString("X");
                txtMotion.Text = MC_done.ToString();
                txtERR.Text = err.ToString("X");

                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid2, 0, ref cmd);
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid2, 0, ref pos);
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid2, 0, ref speed);
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid2, 0, ref MC_status);
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid2, 0, ref MC_done);
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid2, 0, ref err);

                txtCMD2.Text = cmd.ToString();
                txtFBK2.Text = pos.ToString();
                txtSPD2.Text = speed.ToString();
                txtIO2.Text = MC_status.ToString("X");
                txtMotion2.Text = MC_done.ToString();
                txtERR2.Text = err.ToString("X");

                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid3, 0, ref cmd);
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid3, 0, ref pos);
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid3, 0, ref speed);
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid3, 0, ref MC_status);
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid3, 0, ref MC_done);
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid3, 0, ref err);

                txtCMD3.Text = cmd.ToString();
                txtFBK3.Text = pos.ToString();
                txtSPD3.Text = speed.ToString();
                txtIO3.Text = MC_status.ToString("X");
                txtMotion3.Text = MC_done.ToString();
                txtERR3.Text = err.ToString("X");

                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid4, 0, ref cmd);
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid4, 0, ref pos);
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid4, 0, ref speed);
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid4, 0, ref MC_status);
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid4, 0, ref MC_done);
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid4, 0, ref err);

                txtCMD4.Text = cmd.ToString();
                txtFBK4.Text = pos.ToString();
                txtSPD4.Text = speed.ToString();
                txtIO4.Text = MC_status.ToString("X");
                txtMotion4.Text = MC_done.ToString();
                txtERR4.Text = err.ToString("X");
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

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID1.Items.Clear();
            cmbNodeID2.Items.Clear();
            cmbNodeID3.Items.Clear();
            cmbNodeID4.Items.Clear();

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
                        rc = CPCI_DMC.CS_DMC_01_get_devicetype(gCardNo, (ushort)(i + 1), (ushort)0, ref DeviceType, ref IdentityObject);
                        if (rc != 0)
                        {
                            MessageBox.Show("get_devicetype failed - code=" + rc);
                        }
                        else
                        {
                            switch (DeviceType)
                            {
                                case 0x4020192:				//Servo A2 series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    cmbNodeID4.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x6020192:				//Servo M series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    cmbNodeID4.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x8020192:				//Servo A2R series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    cmbNodeID4.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x9020192:				//Servo S series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    cmbNodeID4.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x14100191:			//Remote Module 04PI
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    cmbNodeID4.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                                case 0x11210191:			//GE01PH
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    cmbNodeID4.Items.Add(i + 1);
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
                    switch (p)
                    {
                        case 1:
                            cmbNodeID1.SelectedIndex = 0;
                            cmbNodeID2.SelectedIndex = 0;
                            cmbNodeID3.SelectedIndex = 0;
                            cmbNodeID4.SelectedIndex = 0;
                            txtDist1.Enabled = true;
                            txtDist2.Enabled = false;
                            txtDist3.Enabled = false;
                            txtDist4.Enabled = false;
                            break;
                        case 2:
                            cmbNodeID1.SelectedIndex = 0;
                            cmbNodeID2.SelectedIndex = 1;
                            cmbNodeID3.SelectedIndex = 1;
                            cmbNodeID4.SelectedIndex = 1;
                            txtDist1.Enabled = true;
                            txtDist2.Enabled = true;
                            txtDist3.Enabled = false;
                            txtDist4.Enabled = false;
                            break;
                        case 3:
                            cmbNodeID1.SelectedIndex = 0;
                            cmbNodeID2.SelectedIndex = 1;
                            cmbNodeID3.SelectedIndex = 2;
                            cmbNodeID4.SelectedIndex = 2;
                            txtDist1.Enabled = true;
                            txtDist2.Enabled = true;
                            txtDist3.Enabled = true;
                            txtDist4.Enabled = false;
                            break;
                        case 4:
                            cmbNodeID1.SelectedIndex = 0;
                            cmbNodeID2.SelectedIndex = 1;
                            cmbNodeID3.SelectedIndex = 2;
                            cmbNodeID4.SelectedIndex = 3;
                            txtDist1.Enabled = true;
                            txtDist2.Enabled = true;
                            txtDist3.Enabled = true;
                            txtDist4.Enabled = true;
                            break;
                    }
                    timer1.Enabled = true;
                    chkSVON.Enabled = true;
                    cmdNmove.Enabled = true;
                    cmdPmove.Enabled = true;
                    cmdSTOP.Enabled = true;
                    cmdReset.Enabled = true;
                    cmdRALM.Enabled = true;

                    chkAbs.Checked = false;
                    chkSCurve.Checked = false;
                    cmbLS.SelectedIndex = 0;
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

        private void chkSVON_CheckedChanged_1(object sender, EventArgs e)
        {
            ushort i = 0;
            if (chkSVON.Checked)
            {
                for (i = 1; i <= gNodeNum; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, i, 0, 1);
                }
            }
            else
            {
                for (i = 1; i <= gNodeNum; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, i, 0, 0);
                }
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ushort i = 0;
            for (i = 1; i <= gNodeNum; i++)
            {
                CPCI_DMC.CS_DMC_01_set_position(gCardNo, i, 0, 0);
                CPCI_DMC.CS_DMC_01_set_command(gCardNo, i, 0, 0);
            }
        }

        private void cmdRALM_Click(object sender, EventArgs e)
        {
            ushort i = 0;
            for (i = 1; i <= gNodeNum; i++)
            {
                rc = CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, i, 0);
            }
        }

        private void cmdPmove_Click(object sender, EventArgs e)
        {
            int StrVel=Int32.Parse(txtStrVel.Text);
            int EndVel=Int32.Parse(txtEndVel.Text);
            int MaxVel=Int32.Parse(txtMaxVel.Text);
            int[] DiskArray =new int[4];
            switch(gNodeNum)
            {
                case 1:
                    DiskArray[0]=Int32.Parse(txtDist1.Text);
                    break;
                case 2:
                    DiskArray[0]=Int32.Parse(txtDist1.Text);
                    DiskArray[1]=Int32.Parse(txtDist2.Text);
                    break;
                case 3:
                    DiskArray[0]=Int32.Parse(txtDist1.Text);
                    DiskArray[1]=Int32.Parse(txtDist2.Text);
                    DiskArray[2]=Int32.Parse(txtDist3.Text);
                    break;
                case 4:
                    DiskArray[0]=Int32.Parse(txtDist1.Text);
                    DiskArray[1]=Int32.Parse(txtDist2.Text);
                    DiskArray[2]=Int32.Parse(txtDist3.Text);
                    DiskArray[3]=Int32.Parse(txtDist4.Text);
                    break;
            }
            
            double Acc=Double.Parse(txtAcc.Text);
            double Dec=Double.Parse(txtDec.Text);
            int ConstVel = MaxVel;
            double TPhase1 = Acc;
            double TPhase2 = Dec;
            if (gbIsAbs)
            {
                if (gbIsScurve)
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 2, 1);
                }
                else
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 1, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 1, 1);
                }
            }
            else
                if (gbIsScurve)
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 0);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 2, 0);
                }
                else
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 0);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 1, 0);
                }
        }

        private void cmdSTOP_Click(object sender, EventArgs e)
        {
            ushort i = 0;
            for (i = 1; i <= gNodeNum; i++)
            {
                rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, i, 0, 0.1);
            }
        }

        private void cmdNmove_Click(object sender, EventArgs e)
        {
            int StrVel = Int32.Parse(txtStrVel.Text);
            int EndVel = Int32.Parse(txtEndVel.Text);
            int MaxVel = Int32.Parse(txtMaxVel.Text);
            int[] DiskArray = new int[4];
            switch (gNodeNum)
            {
                case 1:
                    DiskArray[0] = 0-Int32.Parse(txtDist1.Text);
                    break;
                case 2:
                    DiskArray[0] = 0-Int32.Parse(txtDist1.Text);
                    DiskArray[1] = 0-Int32.Parse(txtDist2.Text);
                    break;
                case 3:
                    DiskArray[0] = 0-Int32.Parse(txtDist1.Text);
                    DiskArray[1] = 0-Int32.Parse(txtDist2.Text);
                    DiskArray[2] = 0-Int32.Parse(txtDist3.Text);
                    break;
                case 4:
                    DiskArray[0] = 0-Int32.Parse(txtDist1.Text);
                    DiskArray[1] = 0-Int32.Parse(txtDist2.Text);
                    DiskArray[2] = 0-Int32.Parse(txtDist3.Text);
                    DiskArray[3] = 0-Int32.Parse(txtDist4.Text);
                    break;
            }

            double Acc = Double.Parse(txtAcc.Text);
            double Dec = Double.Parse(txtDec.Text);
            int ConstVel = MaxVel;
            double TPhase1 = Acc;
            double TPhase2 = Dec;
            if (gbIsAbs)
            {
                if (gbIsScurve)
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 2, 1);
                }
                else
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 1, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 1, 1);
                }
            }
            else
                if (gbIsScurve)
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 0);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 2, 0);
                }
                else
                {
                    if (gbIsV3)
                        rc = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, ConstVel, EndVel, TPhase1, TPhase2, 2, 0);
                    else
                        rc = CPCI_DMC.CS_DMC_01_multi_axes_move(gCardNo, gNodeNum, ref gnodeid[0], ref gslot[0], ref DiskArray[0], StrVel, MaxVel, Acc, Dec, 1, 0);
                }
        }

        private void chkAbs_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAbs.Checked)
                gbIsAbs = true;
            else
                gbIsAbs = false;
        }

        private void chkSCurve_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSCurve.Checked)
                gbIsScurve = true;
            else
                gbIsScurve = false;
        }

        private void chkV3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkV3.Checked)
            {
                gbIsV3 = true;
                lblMaxVel.Text = "ConstVel.";
                lblAcc.Text = "TPhase1.";
                lblDec.Text = "TPhase2.";
                txtEndVel.Enabled = true;
            }
            else
            {
                gbIsV3 = false;
                lblMaxVel.Text = "MaxVel.";
                lblAcc.Text = "Acc.";
                lblDec.Text = "Dec.";
                txtEndVel.Enabled = false;
            }
        }

        private void cmdLS_Click(object sender, EventArgs e)
        {
            rc = CPCI_DMC.CS_DMC_01_liner_speed_master(gCardNo, gnodeid[0], gslot[0], (ushort)cmbLS.SelectedIndex);
        }

    }
}
