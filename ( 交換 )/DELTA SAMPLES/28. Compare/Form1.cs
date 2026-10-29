using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using PCI_DMC;
using PCI_DMC_ERR;

namespace DMC_NET
{
    public partial class Form1 : Form
    {
        short existcard = 0, rc, CpNodeNo=0, CpCardNo=0, CpSlotNo=0;
        ushort gCardNo = 0, DeviceInfo = 0, nodeid = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        short[] CpCardSeq = new short[32];
        short[] CpNodeSeq = new short[32];
        ushort gMoveMode = 0, gbAbsValue = 0, gbLevelValue = 0;
        int gTestCounter = 0;
        byte[] value = new byte[10];
        ushort gNodeNum = 0, B01Num = 0, CpQEP = 0;
        bool gIsServoOn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, running = 0, card_no = 0,VerType = 0;
            B01Num = 0;
            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            cmdFindSlave.Enabled = false;
            cboCardNum.Items.Clear();
            cboNodeID.Items.Clear();

            rc = CPCI_DMC.CS_DMC_01_open(ref existcard);

            if (existcard <= 0)
                MessageBox.Show("No DMC-NET card can be found!");
            else
            {

                for (i = 0; i < existcard; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref card_no);
                    gCardNoList[i] = card_no;
                }

                cmdFindSlave.Enabled = true;        //2011.08.05
                

                for (i = 0; i < existcard; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_pci_initial(gCardNoList[i]);
                    if (rc != 0)
                        MessageBox.Show("Can't boot PCI_DMC Master Card!");

                    rc = CPCI_DMC.CS_DMC_01_initial_bus(gCardNoList[i]);
                    if (rc != 0)
                    {
                        MessageBox.Show("Initial Bus Failed!");
                    }
                }
                for (i = 0; i < existcard; i++)
                {
                    do
                    {
                        rc = CPCI_DMC.CS_DMC_01_get_card_version(gCardNoList[i], ref VerType);
                    }while(rc!=0);
                    VerType = (ushort)(VerType / 16);
                    if (VerType == 7)
                    {
                        cboCardNum.Items.Insert(B01Num, gCardNoList[i]);
                        CpCardSeq[B01Num] = (short)gCardNoList[i];
                        B01Num = (ushort)(B01Num + 1);
                    }
                }
                if (B01Num != 0)
                {
                    cboCardNum.SelectedIndex = 0;
                    gCardNo = (ushort)(CpCardSeq[0]);
                }
                else
                {
                    MessageBox.Show("No PCI_DMC_B01 Card find.");
                }
            }


        }

        private void chksvon_CheckedChanged(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cboNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, nodeid, 0, 1);
            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 1);

            rc =CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, (ushort)(gIsServoOn ? 1 : 0));
        }

        private void btnralm_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cboNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 0);
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cboNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
           nodeid = ushort.Parse(cboNodeID.Text);

           CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
           CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

           CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short MCs=0, i, rt=0, ErrorEvent=0;
		    int pos=0, data32=0;
            uint count=0;
            Label[] lblQEPCount = new Label[]{_lblQEPCount_0,_lblQEPCount_1};
		
		for(i=0;i<=1;i++)
        {
			rt = CPCI_DMC.CS_DMC_01_get_compare_channel_position((ushort)CpCardNo,(ushort) i,ref pos);
            lblQEPCount[i].Text = Convert.ToString(pos);
        }
		
		rt = CPCI_DMC.CS_DMC_01_channel1_position_compare_table_cnt((ushort)CpCardNo,ref count);
        lbl_tablecount.Text = Convert.ToString((int)count);

        rt = CPCI_DMC.CS_DMC_01_get_command((ushort)CpCardNo, (ushort)CpNodeNo, (ushort)0, ref data32);
        if (rt == 0)
            lbCmd.Text = Convert.ToString(data32);
        }

        private void btnmove_Click(object sender, EventArgs e)
        {
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(cboCardNum.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i=0,j=0, lMask = 0x1;
            uint DeviceType=0, IdentityObject=0;
            gNodeNum = 0;               
            cboNodeID.Items.Clear();

            for (i = 0; i < 4; i++)     
                SlaveTable[i] = 0;

            rc = CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0); 
            rc =CPCI_DMC.CS_DMC_01_get_device_table(gCardNo, ref DeviceInfo);    //Get Slave Node ID
            rc =CPCI_DMC.CS_DMC_01_get_node_table(gCardNo, ref SlaveTable[0]);

            for (i = 0; i < 1; i++) NodeID[i] = 0;

            if (SlaveTable[0] == 0)
                MessageBox.Show("CardNo: " + gCardNo.ToString() + " No slave found!");      
            else
            {
                for (i = 0; i < 32; i++)
                {
                    if ((SlaveTable[0] & lMask) != 0)
                    {
                        rc = CPCI_DMC.CS_DMC_01_get_devicetype(gCardNo,(ushort)(i + 1), 0, ref DeviceType, ref IdentityObject);
                        if (rc == 0)
                        {
                            switch (DeviceType)
                            {
                                case 0x4020192 :
                                    CpNodeSeq[j] = (short)(i + 1);
                                    cboNodeID.Items.Insert(j, i + 1);
                                    j = (ushort)(j + 1);
                                    break;
                                case 0x6020192:
                                    CpNodeSeq[j] = (short)(i + 1);
                                    cboNodeID.Items.Insert(j, i + 1);
                                    j = (ushort)(j + 1);
                                    break;
                                case 0x8020192:
                                    CpNodeSeq[j] = (short)(i + 1);
                                    cboNodeID.Items.Insert(j, i + 1);
                                    j = (ushort)(j + 1);
                                    break;
                                case 0x9020192:
                                    CpNodeSeq[j] = (short)(i + 1);
                                    cboNodeID.Items.Insert(j, i + 1);
                                    j = (ushort)(j + 1);
                                    break;
                                case 0x14100191:
                                    CpNodeSeq[j] = (short)(i + 1);
                                    cboNodeID.Items.Insert(j, i + 1);
                                    j = (ushort)(j + 1);
                                    break;
                                case 0x11210191:
                                    CpNodeSeq[j] = (short)(i + 1);
                                    cboNodeID.Items.Insert(j, i + 1);
                                    j = (ushort)(j + 1);
                                    break;
                            }
                        }
                        NodeID[gNodeNum] = (ushort)(i + 1);
                        gNodeNum++;
                    }
                    lMask <<= 1;
                }
                if (j == 0)
                {
                    MessageBox.Show("No A2 Servo/04PI/01PH Device Found!");
                }
                else
                {
                    cboNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                }
            }
        //****************************************************************************************
		//Compare Form_Load
		//****************************************************************************************

            if (j == 1)
            {
                _op_QEPselect_1.Enabled = false;
            }

            if (B01Num != 0)
            {
                cboCardNum.SelectedIndex = 0;
                CpCardNo = CpCardSeq[0];
                _Op_MPC_0.Checked = true;
                _Op_CPtype_0.Checked = true;
                cbo_CompareType.Items.Clear();
                cbo_CompareType.Items.Insert(0, "CMP 0");
                cbo_CompareType.Items.Insert(1, "CMP 1");
                cbo_CompareType.SelectedIndex = 0;
                _op_QEPselect_0.Checked = true;
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gbAbsValue = (ushort)((chk_abs.Checked == false) ? 0 : 1); 
        }

        private void btnexit_Click_1(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

            CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void cboNodeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            CpNodeNo = CpNodeSeq[(short)(cboNodeID.SelectedIndex)];
        }

        private void CmdReset_Click(object sender, EventArgs e)
        {
            short rt=0;
            ushort rc = 0;
            rc = CPCI_DMC.CS_DMC_01_set_position((ushort)CpCardNo, (ushort)CpNodeNo, (ushort)0, 0);
            rt = CPCI_DMC.CS_DMC_01_set_command((ushort)CpCardNo, (ushort)CpNodeNo, (ushort)0, 0);
        }

        private void CmdNMove_Click(object sender, EventArgs e)
        {
            short rt;

            rt = CPCI_DMC.CS_DMC_01_ipo_set_svon((ushort)CpCardNo, (ushort)CpNodeNo, 0, 1);
            Thread.Sleep(5);
            rt = CPCI_DMC.CS_DMC_01_start_sr_move((ushort)CpCardNo, (ushort)CpNodeNo, 0, 0 - 300000, 1000, 20000, 0.1, 0.1);
        }

        private void CmdPMove_Click(object sender, EventArgs e)
        {
            short rt;

            rt = CPCI_DMC.CS_DMC_01_ipo_set_svon((ushort)CpCardNo, (ushort)CpNodeNo, 0, 1);
            Thread.Sleep(5);
            rt = CPCI_DMC.CS_DMC_01_start_sr_move((ushort)CpCardNo, (ushort)CpNodeNo, 0, 300000, 1000, 20000, 0.1, 0.1);
        }

        private void CmdStop_Click(object sender, EventArgs e)
        {
            short rt;

            rt = CPCI_DMC.CS_DMC_01_ipo_set_svon((ushort)CpCardNo, (ushort)CpNodeNo, 0, 1);
            Thread.Sleep(5);
            rt = CPCI_DMC.CS_DMC_01_sd_stop((ushort)CpCardNo, (ushort)CpNodeNo, 0, 0.1);
        }

        private void cboCardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            CpCardNo = CpCardSeq[cboCardNum.SelectedIndex];
        }

        private void cbo_CompareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_CompareType.SelectedIndex == 0)
            {
                chk_level.Enabled = false;
                Label_tc.Visible = false;
                lbl_tablecount.Visible = false;
            }
            else
            {
                chk_level.Enabled = true;
                Label_tc.Visible = true;
                lbl_tablecount.Visible = true;
            }
        }

        private void cmd_MPCreset_Click(object sender, EventArgs e)
        {
            short rt = 0;
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_position((ushort)CpCardNo, (ushort)CpNodeNo, 0);
            Thread.Sleep(2);
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_position((ushort)CpCardNo, (ushort)CpNodeNo,1);
        }

        private void btn_EN_Click(object sender, EventArgs e)
        {
            short rt;
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_enable((ushort)CpCardNo, 0, 1);
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_enable((ushort)CpCardNo, 1, 1);
        }

        private void btn_DE_Click(object sender, EventArgs e)
        {
            short rt;
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_enable((ushort)CpCardNo, 0, 0);
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_enable((ushort)CpCardNo, 1, 0);
        }

        private void _chkQEP_Inv_0_Click(object sender, EventArgs e)
        {
            
        }

        private void _chkQEP_Inv_0_CheckedChanged(object sender, EventArgs e)
        {
            short rt;
            ushort gbValus;
            gbValus = (ushort)((_chkQEP_Inv_0.Checked == false) ? 0 : 1);
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_direction((ushort)CpCardNo, (ushort)0, gbValus);
        }

        private void _chkQEP_Inv_1_CheckedChanged(object sender, EventArgs e)
        {
            short rt;
            ushort gbValus;
            gbValus = (ushort)((_chkQEP_Inv_1.Checked == false) ? 0 : 1);
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_direction((ushort)CpCardNo, (ushort)1, gbValus);
        }

        private void _Op_CPtype_0_CheckedChanged(object sender, EventArgs e)
        {
            short rt;
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_polarity((ushort)CpCardNo, (ushort)0);
        }

        private void _Op_CPtype_1_CheckedChanged(object sender, EventArgs e)
        {
            short rt;
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_polarity((ushort)CpCardNo, (ushort)1);
        }

        private void _Op_MPC_0_CheckedChanged(object sender, EventArgs e)
        {
            short rt;
            rt = CPCI_DMC.CS_DMC_01_set_compare_ipulser_mode((ushort)CpCardNo, 0);
            Thread.Sleep(2);
            rt = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode((ushort)CpCardNo, (ushort)CpNodeNo, 0,0);
            Thread.Sleep(2);
            rt = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode((ushort)CpCardNo, (ushort)CpNodeNo, 0,0);
        }

        private void _Op_MPC_1_CheckedChanged(object sender, EventArgs e)
        {
            short rt;
            rt = CPCI_DMC.CS_DMC_01_set_compare_ipulser_mode((ushort)CpCardNo, 1);
            Thread.Sleep(2);
            rt = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode((ushort)CpCardNo, (ushort)CpNodeNo, 0, 1);
            Thread.Sleep(2);
            rt = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode((ushort)CpCardNo, (ushort)CpNodeNo, 0, 1);
        }

        private void _op_QEPselect_0_CheckedChanged(object sender, EventArgs e)
        {
            short Compare_Channel = 0, rt;

            CpQEP = 0;
            cboNodeID.SelectedIndex = 0;
            CpNodeNo = CpCardSeq[0];

            if (cbo_CompareType.SelectedIndex == 0)
            {
                Compare_Channel = 0;
            }
            else
            {
                Compare_Channel = 1;
            }

            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_source((ushort)CpCardNo, (ushort)Compare_Channel, CpQEP);
        }

        private void _op_QEPselect_1_CheckedChanged(object sender, EventArgs e)
        {
            short Compare_Channel = 0, rt;

            CpQEP = 1;
            cboNodeID.SelectedIndex = 1;
            CpNodeNo = CpCardSeq[1];

            if (cbo_CompareType.SelectedIndex == 0)
            {
                Compare_Channel = 0;
            }
            else
            {
                Compare_Channel = 1;
            }

            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_source((ushort)CpCardNo, (ushort)Compare_Channel, CpQEP);
        }

        private void cmd_OneShot_Click(object sender, EventArgs e)
        {
            short rt;
            ushort CompareType;

            CompareType = (ushort)cbo_CompareType.SelectedIndex;
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_trigger_time((ushort)CpCardNo, CompareType, Convert.ToUInt32(txt_TgTime.Text));
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_one_shot((ushort)CpCardNo, CompareType);
        }

        private void _cmd_PlusCp_1_Click(object sender, EventArgs e)
        {
            uint PointT, LevelT;
            uint[] LevelTable = new uint[65535];
            int StartPoint, pos = 0;
            int[] PointTable = new int[65535];
            short i, rt;

            rt = CPCI_DMC.CS_DMC_01_get_compare_channel_position((ushort)CpCardNo, CpQEP, ref pos);
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_trigger_time((ushort)CpCardNo, (ushort)(cbo_CompareType.SelectedIndex), Convert.ToUInt32(txt_TCTimes.Text));
            if (cbo_CompareType.SelectedIndex == 0)    //Compare1
            {
                if (gbAbsValue == 1)
                    StartPoint = Convert.ToInt32(txt_start_pos.Text);
                else
                    StartPoint = Convert.ToInt32(txt_start_pos.Text) + pos;

                rt = CPCI_DMC.CS_DMC_01_channel0_position_cmp((ushort)CpCardNo, StartPoint, 0, Convert.ToUInt16(txt_interval.Text), Convert.ToUInt32(txt_TCTimes.Text));
                Thread.Sleep(1);
            }
            else                                    //Compare2
            {
                rt = CPCI_DMC.CS_DMC_01_channel1_output_enable((ushort)CpCardNo, 0);

                if (gbAbsValue == 0)
                {
                    for (i = 0; i < Convert.ToUInt32(txt_TCTimes.Text); i++)
                        PointTable[i] = pos + Convert.ToInt32(txt_start_pos.Text) + i * Convert.ToInt32(txt_interval.Text);
                }

                else
                {
                    for (i = 0; i < Convert.ToUInt32(txt_TCTimes.Text); i++)
                        PointTable[i] = Convert.ToInt32(txt_start_pos.Text) + i * Convert.ToInt32(txt_interval.Text);
                }

                if (gbLevelValue == 0)
                    rt = CPCI_DMC.CS_DMC_01_channel1_position_compare_table((ushort)CpCardNo, ref PointTable[0], Convert.ToUInt32(txt_TCTimes.Text));

                else
                {
                    for (i = 0; i < Convert.ToUInt32(txt_TCTimes.Text); i++)
                        if ((i % 32) == 0)
                            LevelTable[i / 32] = 0x55555555;  // &H55555555;   1431655765

                    rt = CPCI_DMC.CS_DMC_01_channel1_position_compare_table_level((ushort)CpCardNo, ref PointTable[0], ref LevelTable[0], Convert.ToUInt32(txt_TCTimes.Text));
                }
                rt = CPCI_DMC.CS_DMC_01_channel1_output_enable((ushort)CpCardNo, 1);
            }
        }

        private void chk_level_CheckedChanged(object sender, EventArgs e)
        {
            short rt;
            gbLevelValue = (ushort)((chk_level.Checked == false) ? 0 : 1);
            rt = CPCI_DMC.CS_DMC_01_channel1_output_mode((ushort)CpCardNo, gbLevelValue);
        }

        private void _cmd_MinusCp_0_Click(object sender, EventArgs e)
        {
            uint PointT, LevelT;
            uint[] LevelTable = new uint[65535];
            int StartPoint, pos = 0;
            int[] PointTable = new int[65535];
            short i, rt;

            rt = CPCI_DMC.CS_DMC_01_get_compare_channel_position((ushort)CpCardNo, CpQEP, ref pos);
            rt = CPCI_DMC.CS_DMC_01_set_compare_channel_trigger_time((ushort)CpCardNo, (ushort)(cbo_CompareType.SelectedIndex), Convert.ToUInt32(txt_TCTimes.Text));
            if (cbo_CompareType.SelectedIndex == 0)    //Compare1
            {
                if (gbAbsValue == 1)
                    StartPoint = Convert.ToInt32(txt_start_pos.Text);
                else
                    StartPoint = 0 - Convert.ToInt32(txt_start_pos.Text) + pos;

                rt = CPCI_DMC.CS_DMC_01_channel0_position_cmp((ushort)CpCardNo, StartPoint, 0, Convert.ToUInt16(txt_interval.Text), Convert.ToUInt32(txt_TCTimes.Text));
                Thread.Sleep(1);
            }
            else                                    //Compare2
            {
                rt = CPCI_DMC.CS_DMC_01_channel1_output_enable((ushort)CpCardNo, 0);

                if (gbAbsValue == 0)
                {
                    for (i = 0; i < Convert.ToUInt32(txt_TCTimes.Text); i++)
                        PointTable[i] = pos + Convert.ToInt32(txt_start_pos.Text) - i * Convert.ToInt32(txt_interval.Text);
                }

                else
                {
                    for (i = 0; i < Convert.ToUInt32(txt_TCTimes.Text); i++)
                        PointTable[i] = Convert.ToInt32(txt_start_pos.Text) - i * Convert.ToInt32(txt_interval.Text);
                }

                if (gbLevelValue == 0)
                    rt = CPCI_DMC.CS_DMC_01_channel1_position_compare_table((ushort)CpCardNo, ref PointTable[0], Convert.ToUInt32(txt_TCTimes.Text));

                else
                {
                    for (i = 0; i < Convert.ToUInt32(txt_TCTimes.Text); i++)
                        if ((i % 32) == 0)
                            LevelTable[i / 32] = 0x55555555;  // &H55555555;   1431655765

                    rt = CPCI_DMC.CS_DMC_01_channel1_position_compare_table_level((ushort)CpCardNo, ref PointTable[0], ref LevelTable[0], Convert.ToUInt32(txt_TCTimes.Text));
                }
                rt = CPCI_DMC.CS_DMC_01_channel1_output_enable((ushort)CpCardNo, 1);
            }
        }
    }
}
