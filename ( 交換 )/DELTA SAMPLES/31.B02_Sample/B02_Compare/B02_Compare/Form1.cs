using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PCI_DMC_ERR;
using PCI_DMC_B02;
using PCI_DMC;

namespace B02_Compare
{
    public partial class B02_Compare : Form
    {

        short g_nDeviceNum;
        ushort l_nNodeId = 0;
        ushort[] g_nCardNoList = new ushort[16];
        ushort[] g_nCardNo = new ushort[16];
        ushort[] g_nModuleCount = new ushort[16];

        // RM-04PI Mode2
        ushort[] g_nRM04PIMode2Count = new ushort[16];
        ushort[][] g_nRM04PIMode2NodeId = new ushort[16][];

        // RM-32PT
        ushort[] g_nRM32PTCount = new ushort[16];
        ushort[][] g_nRM32PTNodeId = new ushort[16][];


        // IPCMP information
        Byte g_nIpcmpIndex = 0; //指定IPCompare接腳

        // QEP informaiton
        Byte g_nQepIndex = 0; //指定來源訊號

        // TPCMP information
        Byte g_nTpcmpIndex = 0; //指定

        //IPCMP_TAB_Information
        bool m_bInverse, m_bInterrupt, m_bLevel;
        UInt16 m_nOneshotTime;


        public B02_Compare()
        {
            InitializeComponent();
        }

        private void B02_Compare_Load(object sender, EventArgs e)
        {
            txt_one_shot_time.Text = "10";
            txt_start_pos.Text = "1000";
            txt_interval.Text = "10";
            txt_tirgger_count.Text = "1000";

            txt_cmd.Text = "0";
            txt_starval.Text = "0";
            txt_Maxval.Text = "0";
            txt_Tacc.Text = "0";
            txt_Tdec.Text = "0";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void bt_open_card_Click(object sender, EventArgs e)
        {
            ushort l_nRtCode = 0;
            bool scan_ = false;
            ushort l_nCardNo = 0;
            short[] rt = new short[3];
            ushort[] l_nQepIndex = new ushort[3] { 0, 1, 2 };

            CPCI_DMC.CS_DMC_01_open(ref g_nDeviceNum);

            if (g_nDeviceNum > 0)
            {
                for (ushort i = 0; i < g_nDeviceNum; ++i)
                {
                    CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref l_nCardNo);
                    ushort l_nCardVersion = 0;
                    CPCI_DMC.CS_DMC_01_get_card_version(l_nCardNo, ref l_nCardVersion);

                    CPCI_DMC.CS_DMC_01_pci_initial(l_nCardNo);
                    CPCI_DMC.CS_DMC_01_initial_bus(l_nCardNo);
                    CPCI_DMC.CS_DMC_01_start_ring(l_nCardNo, 0);

                    ushort l_nRunning = 0;
                    CPCI_DMC.CS_DMC_01_check_card_running(l_nCardNo, ref l_nRunning);

                    // Scan all active modules
                    ushort l_nDeviceTable = 0;
                    g_nModuleCount[l_nCardNo] = 0;
                    CPCI_DMC.CS_DMC_01_get_device_table(l_nCardNo, ref l_nDeviceTable);

                    ushort l_nNodeIdcount =0;

                    for (ushort j = 0; j < 16; ++j)
                    {
                        if (((l_nDeviceTable >> j) & 0x1) == 0)
                            continue;
                        l_nNodeIdcount = ++j;
                        uint l_nDeviceType = 0, l_nIdentityObject = 0;
                        CPCI_DMC.CS_DMC_01_get_devicetype(l_nCardNo, l_nNodeIdcount, 0, ref l_nDeviceType, ref l_nIdentityObject);

                        ushort l_nVersion = 0;
                        CPCI_DMC.CS_DMC_01_get_slave_version(l_nCardNo, l_nNodeIdcount, 0, ref l_nVersion);

                        if (l_nDeviceType == 0x14100191)
                        {

                            // RM-04PI Mode2
                            ushort l_nNodeCount = g_nRM04PIMode2Count[l_nCardNo];
                            g_nRM04PIMode2NodeId[l_nCardNo] = new ushort[15];
                            g_nRM04PIMode2NodeId[l_nCardNo][l_nNodeCount] = Convert.ToUInt16(l_nNodeIdcount);

                            //add node no		
                            ++g_nRM04PIMode2Count[l_nCardNo];

                            cbo_nodeID.Items.Add(l_nNodeIdcount);
                            cbo_nodeID.Text = l_nNodeIdcount.ToString();

                        }
                        if (l_nDeviceType == 0x04130191)
                        {
                            // RM-32PT
                            ushort l_nNodeCount = g_nRM32PTCount[l_nCardNo];
                            g_nRM32PTNodeId[l_nCardNo] = new ushort[15];
                            g_nRM32PTNodeId[l_nCardNo][l_nNodeCount] = Convert.ToUInt16(l_nNodeIdcount);

                            ++g_nRM32PTCount[l_nCardNo];

                            cbo_32PT_node.Items.Add(l_nNodeIdcount);
                            cbo_32PT_node.Text = l_nNodeIdcount.ToString(); 
                        }

                        ++g_nModuleCount[l_nCardNo];
                    }


                    //add card no
                    cbo_Card_NO.Items.Add(l_nCardNo);
                    cbo_Card_NO.Text = l_nCardNo.ToString(); ;
                    //find slave	
                    //Cbo_Slave_NO.Items.Add(g_nRM04PIMode2Count[l_nCardNo]);
                    Cbo_Slave_NO.Items.Add(g_nModuleCount[l_nCardNo]);

                    g_nCardNoList[i] = l_nCardNo;
                }

                //ADD Slave num
                g_nRM04PIMode2NodeId[l_nCardNo] = new ushort[12];
                Cbo_Slave_NO.Text = g_nRM04PIMode2NodeId[l_nCardNo][0].ToString();

                //20151005 
                //SET_FUN_TIME
                CPCI_DMC.CS_DMC_01_set_function_time(l_nCardNo, 400);

                if (cbo_Card_NO.Text != "")
                {
                    int carnum = 0;
                    g_nCardNo[carnum] = Convert.ToUInt16(cbo_Card_NO.Text);
                    carnum++;

                }
                //RESET QEP Count

                for (int i = 0; i < 3; i++)
                {
                    rt[i] = CPCI_DMC.CS_DMC_B02_qep_set_reload_counter(l_nCardNo, Convert.ToByte(l_nQepIndex[i]), 0);
                }

                //l_nNodeId = (ushort)GetDlgItemInt(IDC_CBO_NODE_ID, NULL, false);


            }
        }

        private void txt_CLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_initial_ipcmp_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            Byte l_nIpcmpIndex = g_nIpcmpIndex; //IPCMP_index
            Byte l_nQepIndex = 0, l_nGpioPin = 0; //訊號源 與 指定GPIO PIN腳位
            ushort l_nPulseWidth = Convert.ToUInt16(txt_one_shot_time.Text);//脈波間隔

            bool l_Linverse;

            if (chk_inverse.Checked)
            {
                l_Linverse = true;
            }
            else
            {
                l_Linverse = false;
            }
            rt = CPCI_DMC.CS_DMC_B02_ipcmp_oneshot_time(l_nCardNo, l_nIpcmpIndex, l_nPulseWidth);

            rt = CPCI_DMC.CS_DMC_B02_ipcmp_initial(l_nCardNo,
                 l_nIpcmpIndex,									//CMPINDEX: 0~3
                 l_nQepIndex,									//QEP: 0~2
                 l_nGpioPin,									//GPIO: 0 ~ 9
                 l_Linverse);									//脈波準位 Inverse 	
        }

        private void bt_ritht_set_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            Byte l_nIpcmpIndex = g_nIpcmpIndex;

            int l_nStartPosition = Convert.ToInt32(txt_start_pos.Text);
            ushort l_nInterval = Convert.ToUInt16(txt_interval.Text);
            uint l_nTriggerCount = Convert.ToUInt32(txt_tirgger_count.Text);

            rt = CPCI_DMC.CS_DMC_B02_ipcmp_compare_position(l_nCardNo, l_nIpcmpIndex, l_nStartPosition, l_nInterval, l_nTriggerCount, 0);
        }

        private void bt_left_set_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            Byte l_nIpcmpIndex = g_nIpcmpIndex;

            int l_nStartPosition = Convert.ToInt32(txt_start_pos.Text);
            ushort l_nInterval = Convert.ToUInt16(txt_interval.Text);
            uint l_nTriggerCount = Convert.ToUInt32(txt_tirgger_count.Text);

            rt = CPCI_DMC.CS_DMC_B02_ipcmp_compare_position(l_nCardNo, l_nIpcmpIndex, l_nStartPosition, l_nInterval, l_nTriggerCount, 1);
        }

        private void bt_reset_cmp_count_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            Byte l_nIpcmpIndex = g_nIpcmpIndex;

            rt = CPCI_DMC.CS_DMC_B02_ipcmp_compare_trigger_count_clear(l_nCardNo, l_nIpcmpIndex);
        }

        private void bt_qep_reset_Click(object sender, EventArgs e)
        {
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            Byte[] l_nQepIndex = new Byte[3] { 0, 1, 2 };
            short[] rt = new short[3];
            for (int i = 0; i < 3; i++)
            {
                rt[i] = CPCI_DMC.CS_DMC_B02_qep_set_reload_counter(l_nCardNo, l_nQepIndex[i], 0);
            }
        }

        private void chk_CWCCWorAB_CheckedChanged(object sender, EventArgs e)
        {
            short[] rt = new short[3];
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            Byte[] l_nQepIndex = new Byte[3] { 0, 1, 2 };
            Byte nMode = 0;
            //0：CW/CCW  1：AB Phase
            if (chk_CWCCWorAB.Checked)
            {
                nMode = 1;
            }
            else
            {
                nMode = 0;
            }
            for (int i = 0; i < 3; i++)
            {
                rt[i] = CPCI_DMC.CS_DMC_B02_qep_set_mode(l_nCardNo, l_nQepIndex[i], nMode);
            }
        }

        private void bt_soft_one_shot_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            Byte l_nIpcmpIndex = g_nIpcmpIndex;

            rt = CPCI_DMC.CS_DMC_B02_ipcmp_software_trigger(l_nCardNo, l_nIpcmpIndex);
        }

        private void bt_ServOn_Click(object sender, EventArgs e)
        {
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            short rt = 0;
            ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text);

            rt = CPCI_DMC.CS_DMC_01_ipo_set_svon(l_nCardNo, lNode_id, 0, 1);

        }

        private void bt_left_move_Click(object sender, EventArgs e)
        {
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text);

            short rt;


            int l_nCommand = Convert.ToInt32(txt_cmd.Text);
            int l_nStrVel = Convert.ToInt32(txt_starval.Text);
            int l_nMaxVel = Convert.ToInt32(txt_Maxval.Text);
            double l_lfTacc = Convert.ToDouble(txt_Tacc.Text);
            double l_lfTdec = Convert.ToDouble(txt_Tdec.Text);

            if (chk_abs.Checked)
            {

                rt = CPCI_DMC.CS_DMC_01_start_ta_move(l_nCardNo, lNode_id, 0, 0 - l_nCommand, l_nStrVel, l_nMaxVel, l_lfTacc, l_lfTdec);

            }
            else
            {

                rt = CPCI_DMC.CS_DMC_01_start_tr_move(l_nCardNo, lNode_id, 0, 0 - l_nCommand, l_nStrVel, l_nMaxVel, l_lfTacc, l_lfTdec);

            }
        }

        private void bt_right_move_Click(object sender, EventArgs e)
        {
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text);

            short rt;


            int l_nCommand = Convert.ToInt32(txt_cmd.Text);
            int l_nStrVel = Convert.ToInt32(txt_starval.Text);
            int l_nMaxVel = Convert.ToInt32(txt_Maxval.Text);
            double l_lfTacc = Convert.ToDouble(txt_Tacc.Text);
            double l_lfTdec = Convert.ToDouble(txt_Tdec.Text);

            if (chk_abs.Checked)
            {

                rt = CPCI_DMC.CS_DMC_01_start_ta_move(l_nCardNo, lNode_id, 0, l_nCommand, l_nStrVel, l_nMaxVel, l_lfTacc, l_lfTdec);

            }
            else
            {

                rt = CPCI_DMC.CS_DMC_01_start_tr_move(l_nCardNo, lNode_id, 0, l_nCommand, l_nStrVel, l_nMaxVel, l_lfTacc, l_lfTdec);

            }
        }

        private void bt_STOP_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text);
            rt = CPCI_DMC.CS_DMC_01_emg_stop(l_nCardNo, lNode_id, 0);
        }

        private void bt_ReSET_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text);
            rt = CPCI_DMC.CS_DMC_01_set_position(l_nCardNo, lNode_id, 0, 0);
            rt = CPCI_DMC.CS_DMC_01_set_command(l_nCardNo, lNode_id, 0, 0);

        }

        private void bt_ALAM_Click(object sender, EventArgs e)
        {
            short rt;
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text);
            rt = CPCI_DMC.CS_DMC_01_set_ralm(l_nCardNo, lNode_id, 0);
        }

        private void chk_ABorCWCCW_CheckedChanged(object sender, EventArgs e)
        {
            ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
            ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text);
	            short rti,rto;
	            ushort mode=0; //設置輸入相位為AB phase
             

		            //Mode:[0]AB phase  [1]CW/CCW
                if (chk_ABorCWCCW.Checked)
	              {
		              mode = 1;	//CW/CCW
	              }
	              else
	              {
		              mode = 0;	//AB Phase
	              }

                    rti = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(l_nCardNo, lNode_id, 0, mode);
		            rto =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(l_nCardNo, lNode_id, 0, mode);

        }

        private void chk_timer_CheckedChanged(object sender, EventArgs e)
        {
            	    short rt;
	                  ushort l_nCardNo = Convert.ToUInt16(cbo_Card_NO.Text);//卡號
                       ushort lNode_id = Convert.ToUInt16(cbo_nodeID.Text); //NODEID
                    Byte l_nModuleCount = 0;


                    uint l_nQepReloadCounter = 0;
                    int l_nQepCounter = 0;

                // IPCMP information
	                Byte l_nIpcmpIndex = 0;
	                uint l_nIpcmpCompareTriggerCount = 0;

	                int l_nCommand = 0, l_nFeedback = 0, l_nVelocity = 0;
                    uint l_nModuleSatus = g_nIpcmpIndex;
                    ushort l_nMcDone = 0;

                //32PT define
	                ushort _lNode_32PT_id =Convert.ToUInt16(cbo_32PT_node.Text);
	                ushort l_nRm32PtIo = 0;
                //B02 INPUT
	                Byte l_nIoState = 0;

	                  //Get IPCMP Counter
			                rt =CPCI_DMC.CS_DMC_B02_ipcmp_compare_trigger_count(l_nCardNo, l_nIpcmpIndex, ref l_nIpcmpCompareTriggerCount);
                        txt_CMP_COUNT_RESET.Text =l_nIpcmpCompareTriggerCount.ToString();
		                //SetDlgItemInt(IDC_ED_IPCMP_COUNT, l_nIpcmpCompareTriggerCount, false);


                        if (chk_timer.Checked)
                        {

                            // Command1
                            CPCI_DMC.CS_DMC_01_get_command(l_nCardNo, lNode_id, 0, ref l_nCommand);
                            txt_Command_view.Text = l_nCommand.ToString();
                            // SetDlgItemInt(IDC_ST_CMD_RECORD, l_nCommand, true);

                            // Feedback
                            CPCI_DMC.CS_DMC_01_get_position(l_nCardNo, lNode_id, 0, ref l_nFeedback);
                            txt_FBK_view.Text = l_nFeedback.ToString();
                            // SetDlgItemInt(IDC_ST_FEB, l_nFeedback, true);
                            // Velocity
                            CPCI_DMC.CS_DMC_01_get_current_speed(l_nCardNo, lNode_id, 0, ref l_nVelocity);

                            txt_VEL_view.Text = l_nVelocity.ToString();
                            // SetDlgItemInt(IDC_ST_VEL_RECORD, l_nVelocity, true);
                            // IO Status
                            CPCI_DMC.CS_DMC_01_motion_status(l_nCardNo, lNode_id, 0, ref l_nModuleSatus);

                            txt_IOSTATE_view.Text = l_nModuleSatus.ToString(String.Format("{0:0000.00}", l_nModuleSatus));
                            // XX.Format("%04X", l_nModuleSatus);
                            // SetDlgItemText(IDC_ST_IO_RECORD, XX);
                            // MC done
                            CPCI_DMC.CS_DMC_01_motion_done(l_nCardNo, lNode_id, 0, ref l_nMcDone);
                            txt_MC_view.Text = l_nMcDone.ToString(String.Format("{0:0000.00}", l_nMcDone));

                            // XX.Format("%04X", l_nMcDone);
                            // SetDlgItemText(IDC_ST_MC_RECORD, XX);



                            // QEP: Counter

                            CPCI_DMC.CS_DMC_B02_qep_get_counter(l_nCardNo, g_nQepIndex, ref l_nQepCounter);

                            //XX.Format("%08X", l_nQepCounter);
                            //SetDlgItemText(IDC_QEP_Counter, XX);

                            //32PT INFO 
                            //IO OUTPUT
                            CPCI_DMC.CS_DMC_01_get_rm_input_value(l_nCardNo, _lNode_32PT_id, 0, 0, ref l_nRm32PtIo);
                            for (Byte i = 0; i < 4; ++i)
                            {
                                //SetEditBkColor(g_RM32PTInputState, i, (l_nRm32PtIo&(0x1<<i))?1:0);
                                //SetDlgItemInt(IDC_EDT_IO_INPUT0+i, (l_nRm32PtIo&(0x1<<i))?1:0 , false);
                            }

                            //IO INPUT

                            CPCI_DMC.CS_DMC_B02_ext_io_get_input_value(l_nCardNo, ref l_nIoState);
                            txt_GPIO_IN.Text = l_nIoState.ToString(String.Format("{0:d}", l_nIoState));
                            //XX.Format("%04X", l_nIoState);
                            //SetDlgItemText(IDC_EDT_EXT_IO_INPUT_STATE, XX);

                        }//end chk_timer_enable


         }//end timer



    }
}
