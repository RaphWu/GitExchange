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
        ushort gCardNo = 0, DeviceInfo = 0, nodeid1 = 0,nodeid2=0,nodeid3=0;
        ushort[] gnodeid = new ushort[3];
        ushort[] gslot = new ushort[3];
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        bool gIsServoOn=false;
      

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboPulseRatio.Items.Add(1);
            ComboPulseRatio.Items.Add(4);
            ComboJogMode.Items.Add(0);
            ComboJogMode.Items.Add(1);
            ComboPulseRatio.SelectedIndex = 0;
            ComboJogMode.SelectedIndex = 0;
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0;

            chkSVON.Enabled = false;

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

            uint MPGPos=0;
            byte FSM_state=0, EN_state=0, Axis_NO=0, Ratio=0;
            ushort JOGIO=0;

            if (chkTimer.Checked)
            {

                gnodeid[0] = (ushort.Parse(cmbNodeID1.Text));
                gnodeid[1] = (ushort.Parse(cmbNodeID2.Text));
                gnodeid[2] = (ushort.Parse(cmbNodeID3.Text));
                nodeid1 = gnodeid[0];
                nodeid2 = gnodeid[1];
                nodeid3 = gnodeid[2];

                //取得MPG position
                rc = CPCI_DMC.CS_DMC_A02_mpg_get_poisition(gCardNo, ref MPGPos);
                txtMPGPos.Text = MPGPos.ToString();


                //取得啟動狀態
                rc = CPCI_DMC.CS_DMC_A02_mpg_fsm_get_lock_state(gCardNo, ref FSM_state);

                if(FSM_state!= 0 )
                {
                    txtFSM.Text = "FSM ON";
                }
                else
                {
                    txtFSM.Text = "FSM OFF";
                }
  

                //MPG IO ENALE
                rc = CPCI_DMC.CS_DMC_A02_mpg_get_io_state_enable(gCardNo, ref EN_state);
                if(EN_state==1)
                {
                    txtEnable.Text = "EN ON";
                }
                else
                {
                    txtEnable.Text = "EN OFF";
                }
          

                //Axis No
                rc = CPCI_DMC.CS_DMC_A02_mpg_axis_get_io_state(gCardNo, ref Axis_NO);
                if(Axis_NO!=0)
                {
                    txtAxisNo.Text = Axis_NO.ToString();
                }
                else
                {
                    txtAxisNo.Text = Axis_NO.ToString();
                }


                //Ratio
                rc = CPCI_DMC.CS_DMC_A02_mpg_axis_get_ratio_state(gCardNo, ref Ratio);
                if(Ratio==1) 
                {
                    txtRatio.Text = "1";
                }
                else if(Ratio==2)
                {
                    txtRatio.Text = "10";
                }
                else if(Ratio==3)
                {
                    txtRatio.Text = "100";
                }
                else
                {
                    txtRatio.Text = "0";
                }



                //JOGIO
                rc = CPCI_DMC.CS_DMC_A02_get_jog_io_state(gCardNo, ref JOGIO);
                if(JOGIO>=0) 
                {
                    txtJogio.Text = JOGIO.ToString();
                }
         

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
            cmdReset.Enabled = false;
            cmdRALM.Enabled = false;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID1.Items.Clear();
            cmbNodeID2.Items.Clear();
            cmbNodeID3.Items.Clear();

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
                                    ComboAxis1No.Items.Add(i + 1);
                                    ComboAxis2No.Items.Add(i + 1);
                                    ComboAxis3No.Items.Add(i + 1);
                                    ComboAxis4No.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x6020192:				//Servo M series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    ComboAxis1No.Items.Add(i + 1);
                                    ComboAxis2No.Items.Add(i + 1);
                                    ComboAxis3No.Items.Add(i + 1);
                                    ComboAxis4No.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x8020192:				//Servo A2R series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    ComboAxis1No.Items.Add(i + 1);
                                    ComboAxis2No.Items.Add(i + 1);
                                    ComboAxis3No.Items.Add(i + 1);
                                    ComboAxis4No.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x9020192:				//Servo S series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    ComboAxis1No.Items.Add(i + 1);
                                    ComboAxis2No.Items.Add(i + 1);
                                    ComboAxis3No.Items.Add(i + 1);
                                    ComboAxis4No.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x14100191:			//Remote Module 04PI
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    ComboAxis1No.Items.Add(i + 1);
                                    ComboAxis2No.Items.Add(i + 1);
                                    ComboAxis3No.Items.Add(i + 1);
                                    ComboAxis4No.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                                case 0x11210191:			//GE01PH
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    ComboAxis1No.Items.Add(i + 1);
                                    ComboAxis2No.Items.Add(i + 1);
                                    ComboAxis3No.Items.Add(i + 1);
                                    ComboAxis4No.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x8110191:              //64MN
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    ComboAxis1No.Items.Add(i + 1);
                                    ComboAxis2No.Items.Add(i + 1);
                                    ComboAxis3No.Items.Add(i + 1);
                                    ComboAxis4No.Items.Add(i + 1);
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
                    cmbNodeID1.SelectedIndex = 0;
                    cmbNodeID2.SelectedIndex = 1;
                    cmbNodeID3.SelectedIndex = 2;
                    ComboAxis1No.SelectedIndex = 0;
                    ComboAxis2No.SelectedIndex = 1;
                    ComboAxis3No.SelectedIndex = 2;
                    ComboAxis4No.SelectedIndex = 3;
                    timer1.Enabled = true;
                    chkSVON.Enabled = true;
                    cmdReset.Enabled = true;
                    cmdRALM.Enabled = true;


                
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

       

        private void cmbNodeID1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbNodeID1.SelectedIndex == cmbNodeID2.SelectedIndex) || (cmbNodeID1.SelectedIndex == cmbNodeID3.SelectedIndex) || (cmbNodeID2.SelectedIndex == cmbNodeID3.SelectedIndex))
            {
                chkSVON.Enabled = false;
                cmdReset.Enabled = false;
                cmdRALM.Enabled = false;
            }
            else
            {
                chkSVON.Enabled = true;
                cmdReset.Enabled = true;
                cmdRALM.Enabled = true;
            }
        }

        private void cmbNodeID2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbNodeID1.SelectedIndex == cmbNodeID2.SelectedIndex) || (cmbNodeID1.SelectedIndex == cmbNodeID3.SelectedIndex) || (cmbNodeID2.SelectedIndex == cmbNodeID3.SelectedIndex))
            {
                chkSVON.Enabled = false;
                cmdReset.Enabled = false;
                cmdRALM.Enabled = false;
            }
            else
            {
                chkSVON.Enabled = true;
                cmdReset.Enabled = true;
                cmdRALM.Enabled = true;
            }
        }

        private void cmbNodeID3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbNodeID1.SelectedIndex == cmbNodeID2.SelectedIndex) || (cmbNodeID1.SelectedIndex == cmbNodeID3.SelectedIndex) || (cmbNodeID2.SelectedIndex == cmbNodeID3.SelectedIndex))
            {
                chkSVON.Enabled = false;
                cmdReset.Enabled = false;
                cmdRALM.Enabled = false;
            }
            else
            {
                chkSVON.Enabled = true;
                cmdReset.Enabled = true;
                cmdRALM.Enabled = true;
            }
        }

        private void chkEnableMPG_CheckedChanged(object sender, EventArgs e)
        {
            short i;
            uint[] Ratio = new uint[4];
            uint[] Slop = new uint[4];
            ushort[] denominator = new ushort[4];
            ushort[] slot = new ushort[4];

            ushort PulseRatio;
            ushort[] MPG_USE_gbNODE = new ushort[4];

            slot[0] = 0;
            slot[1] = 0;
            slot[2] = 0;
            slot[3] = 0;

            PulseRatio = Convert.ToUInt16(ComboPulseRatio.Text);
            Ratio[0] = Convert.ToUInt32(Ratio1.Text);
            Ratio[1] = Convert.ToUInt32(Ratio2.Text);
            Ratio[2] = Convert.ToUInt32(Ratio3.Text);
            Ratio[3] = Convert.ToUInt32(Ratio4.Text);

            Slop[0] = Convert.ToUInt32(Slop1.Text);
            Slop[1] = Convert.ToUInt32(Slop2.Text);
            Slop[2] = Convert.ToUInt32(Slop3.Text);
            Slop[3] = Convert.ToUInt32(Slop4.Text);

            denominator[0] = Convert.ToUInt16(Demo1.Text);
            denominator[1] = Convert.ToUInt16(Demo2.Text);
            denominator[2] = Convert.ToUInt16(Demo3.Text);
            denominator[3] = Convert.ToUInt16(Demo4.Text);

            MPG_USE_gbNODE[0] = Convert.ToUInt16(ComboAxis1No.Text);
            MPG_USE_gbNODE[1] = Convert.ToUInt16(ComboAxis2No.Text);
            MPG_USE_gbNODE[2] = Convert.ToUInt16(ComboAxis3No.Text);
            MPG_USE_gbNODE[3] = Convert.ToUInt16(ComboAxis4No.Text);

            if (chkEnableJog.Checked)
            {
                MessageBox.Show("A02 手輪JOG已致能,請關閉後再選擇MPG!!");
                chkEnableMPG.CheckState = 0;
            }
            else
            {
                if (chkEnableMPG.Checked)
                {
                    rc = CPCI_DMC.CS_DMC_A02_set_mpg_axes_enable(gCardNo, ref MPG_USE_gbNODE[0], ref slot[0], 1, PulseRatio, ref Ratio[0], ref Slop[0], ref denominator[0]);
                    if (rc != 0)
                    {
                        switch (rc)
                        {
                            case 102:
                                MessageBox.Show("A02 手輪已致能,無法重覆致能!!");
                                break;
                            case 103:
                                MessageBox.Show("A02 JOG 已致能,無法重覆致能!!");
                                break;
                            default:
                                MessageBox.Show("請確認先將伺服啟動，Axis or Ratio or Slop 參數設定完成!!");
                                break;
                        }

                    }
                }

                else
                {


                    rc = CPCI_DMC.CS_DMC_A02_set_mpg_axes_enable(gCardNo, ref MPG_USE_gbNODE[0], ref slot[0], 0, PulseRatio, ref Ratio[0], ref Slop[0], ref denominator[0]);
                    if (rc != 0)
                    {
                        switch (rc)
                        {
                            case 102:
                                MessageBox.Show("A02 手輪已致能,無法重覆致能!!");
                                break;
                            case 103:
                                MessageBox.Show("A02 JOG 已致能,無法重覆致能!!");
                                break;
                            default:
                                MessageBox.Show("請確認先將伺服啟動，Axis or Ratio or Slop 參數設定完成!!");
                                break;
                        }

                    }
                }

            }
        }

        private void chkEnableJog_CheckedChanged(object sender, EventArgs e)
        {
            short i;
            ushort[] slot = new ushort[4];
            ushort jog_mode;
            int[] jog_speed = new int[4];
            double[] sec = new double[4];
            ushort[] JOG_USE_gbNODE = new ushort[4];

            slot[0] = 0;
            slot[1] = 0;
            slot[2] = 0;
            slot[3] = 0;

            jog_mode = Convert.ToUInt16(ComboJogMode.Text);

            jog_speed[0] = Convert.ToInt32(Spd1.Text);
            jog_speed[1] = Convert.ToInt32(Spd2.Text);
            jog_speed[2] = Convert.ToInt32(Spd3.Text);
            jog_speed[3] = Convert.ToInt32(Spd4.Text);


            sec[0] = Convert.ToDouble(Sec1.Text);
            sec[1] = Convert.ToDouble(Sec2.Text);
            sec[2] = Convert.ToDouble(Sec3.Text);
            sec[3] = Convert.ToDouble(Sec4.Text);

            JOG_USE_gbNODE[0] = Convert.ToUInt16(ComboAxis1No.Text);
            JOG_USE_gbNODE[1] = Convert.ToUInt16(ComboAxis2No.Text);
            JOG_USE_gbNODE[2] = Convert.ToUInt16(ComboAxis3No.Text);
            JOG_USE_gbNODE[3] = Convert.ToUInt16(ComboAxis4No.Text);

            if (chkEnableMPG.Checked)
            {
                MessageBox.Show("A02 手輪MPG已致能,請關閉後再選擇JOG!!");
                chkEnableJog.CheckState = 0;
            }
            else
            {
                if (chkEnableJog.Checked)
                {
                    rc = CPCI_DMC.CS_DMC_A02_set_jog_axes_enable(gCardNo, ref JOG_USE_gbNODE[0], ref slot[0], 1, jog_mode, ref jog_speed[0], ref sec[0]);
                    if (rc != 0)
                    {
                        switch (rc)
                        {
                            case 102:
                                MessageBox.Show("A02 手輪已致能,無法重覆致能!!");
                                break;
                            case 103:
                                MessageBox.Show("A02 JOG 已致能,無法重覆致能!!");
                                break;
                            default:
                                MessageBox.Show("請確認先將伺服啟動，Axis or Ratio or Slop 參數設定完成!!");
                                break;
                        }

                    }
                }

                else
                {


                    rc = CPCI_DMC.CS_DMC_A02_set_jog_axes_enable(gCardNo, ref JOG_USE_gbNODE[0], ref slot[0], 0, jog_mode, ref jog_speed[0], ref sec[0]);
                    if (rc != 0)
                    {
                        switch (rc)
                        {
                            case 102:
                                MessageBox.Show("A02 手輪已致能,無法重覆致能!!");
                                break;
                            case 103:
                                MessageBox.Show("A02 JOG 已致能,無法重覆致能!!");
                                break;
                            default:
                                MessageBox.Show("請確認先將伺服啟動，Axis or Ratio or Slop 參數設定完成!!");
                                break;
                        }

                    }
                }

            }
        }
    }
}
