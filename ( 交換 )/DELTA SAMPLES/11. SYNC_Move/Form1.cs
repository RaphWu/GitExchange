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
        ushort gCardNo = 0, DeviceInfo = 0, nodeid1 = 0,nodeid2=0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        ushort gActNode;
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
            cmdSync.Enabled = false;

            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            btnFindSlave.Enabled = false;
            txtSlaveNum.Text = "0";
            CmbCardNo.Items.Clear();
            cmbNodeID1.Items.Clear();
            cmbNodeID2.Items.Clear();

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
            ushort MC_done = 0,buffer=0;

            if (chkTimer.Checked)
            {
                nodeid1 = (ushort)(Int32.Parse(cmbNodeID1.Text));
                nodeid2 = (ushort)(Int32.Parse(cmbNodeID2.Text));
                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid1, 0, ref cmd);
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid1, 0, ref pos);
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid1, 0, ref speed);
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid1, 0, ref MC_status);
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid1, 0, ref MC_done);
                rc = CPCI_DMC.CS_DMC_01_get_buffer_length(gCardNo, nodeid1, 0, ref buffer);
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid1, 0, ref err);

                txtCMD.Text = cmd.ToString();
                txtFBK.Text = pos.ToString();
                txtSPD.Text = speed.ToString();
                txtIO.Text = MC_status.ToString("X");
                txtMotion.Text = MC_done.ToString();
                txtBuff.Text = buffer.ToString();
                txtERR.Text = err.ToString("X");

                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid2, 0, ref cmd);
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid2, 0, ref pos);
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid2, 0, ref speed);
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid2, 0, ref MC_status);
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid2, 0, ref MC_done);
                rc = CPCI_DMC.CS_DMC_01_get_buffer_length(gCardNo, nodeid2, 0, ref buffer);
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid2, 0, ref err);

                txtCMD2.Text = cmd.ToString();
                txtFBK2.Text = pos.ToString();
                txtSPD2.Text = speed.ToString();
                txtIO2.Text = MC_status.ToString("X");
                txtMotion2.Text = MC_done.ToString();
                txtBuff2.Text = buffer.ToString();
                txtERR2.Text = err.ToString("X");
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
            cmdSync.Enabled = false;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID1.Items.Clear();
            cmbNodeID2.Items.Clear();

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
                                    p++;
                                    break;
                                case 0x6020192:				//Servo M series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x8020192:				//Servo A2R series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x9020192:				//Servo S series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x14100191:			//Remote Module 04PI
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                                case 0x11210191:			//GE01PH
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p <2)
                {
                    MessageBox.Show("Required 2 Servo/04PI/01PH Device at least!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID1.SelectedIndex = 0;
                    cmbNodeID2.SelectedIndex = 1;
                    timer1.Enabled = true;
                    chkSVON.Enabled = true;
                    cmdNmove.Enabled = true;
                    cmdPmove.Enabled = true;
                    cmdSTOP.Enabled = true;
                    cmdReset.Enabled = true;
                    cmdRALM.Enabled = true;
                    cmdSync.Enabled = true;

                    chkAbs.Checked = false;
                    chkSCurve.Checked = false;
                    chkSVON.Checked = false;
                    rNode1.Checked = true;
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
            int MaxVel=Int32.Parse(txtMaxVel.Text);
            
            double Acc=Double.Parse(txtAcc.Text);
            double Dec=Double.Parse(txtDec.Text);

            int Dist = Int32.Parse(txtDist.Text);
            if (gbIsAbs)
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
            }
            else
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
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
            int MaxVel = Int32.Parse(txtMaxVel.Text);

            double Acc = Double.Parse(txtAcc.Text);
            double Dec = Double.Parse(txtDec.Text);

            int Dist = 0-Int32.Parse(txtDist.Text);
            if (gbIsAbs)
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
            }
            else
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, gActNode, 0, Dist, StrVel, MaxVel, Acc, Dec);
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

        private void cmbNodeID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rNode1.Text = "Node " + cmbNodeID1.Text;
            if ((cmbNodeID1.SelectedIndex) == (cmbNodeID2.SelectedIndex))
            {
                chkSVON.Enabled = false;
                cmdNmove.Enabled = false;
                cmdPmove.Enabled = false;
                cmdSTOP.Enabled = false;
                cmdReset.Enabled = false;
                cmdRALM.Enabled = false;
                cmdSync.Enabled = false;
            }
            else
            {
                chkSVON.Enabled = true;
                cmdNmove.Enabled = true;
                cmdPmove.Enabled = true;
                cmdSTOP.Enabled = true;
                cmdReset.Enabled = true;
                cmdRALM.Enabled = true;
                cmdSync.Enabled = true;
            }
        }

        private void cmbNodeID2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rNode2.Text = "Node " + cmbNodeID2.Text;
            if ((cmbNodeID1.SelectedIndex) == (cmbNodeID2.SelectedIndex))
            {
                chkSVON.Enabled = false;
                cmdNmove.Enabled = false;
                cmdPmove.Enabled = false;
                cmdSTOP.Enabled = false;
                cmdReset.Enabled = false;
                cmdRALM.Enabled = false;
                cmdSync.Enabled = false;
            }
            else
            {
                chkSVON.Enabled = true;
                cmdNmove.Enabled = true;
                cmdPmove.Enabled = true;
                cmdSTOP.Enabled = true;
                cmdReset.Enabled = true;
                cmdRALM.Enabled = true;
                cmdSync.Enabled = true;
            }
        }

        private void cmdSync_Click(object sender, EventArgs e)
        {
            rc = CPCI_DMC.CS_DMC_01_sync_move(gCardNo);
            chkSync.Checked = false;
        }

        private void chkSync_CheckedChanged(object sender, EventArgs e)
        {
            ushort SyncNode1, SyncNode2;
            SyncNode1 = (ushort)Int32.Parse(cmbNodeID1.Text);
            SyncNode2 = (ushort)Int32.Parse(cmbNodeID2.Text);
            if (chkSync.Checked)
            {
                rc = CPCI_DMC.CS_DMC_01_sync_move_config(gCardNo, SyncNode1, 0, 1);
                rc = CPCI_DMC.CS_DMC_01_sync_move_config(gCardNo, SyncNode2, 0, 1);
            }
            else
            {
                rc = CPCI_DMC.CS_DMC_01_sync_move_config(gCardNo, SyncNode1, 0, 0);
                rc = CPCI_DMC.CS_DMC_01_sync_move_config(gCardNo, SyncNode2, 0, 0);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gActNode = (ushort)Int32.Parse(cmbNodeID1.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gActNode = (ushort)Int32.Parse(cmbNodeID2.Text);
        }
    }
}
