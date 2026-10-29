using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PCI_DMC;

namespace DMC_MotionbufferSample
{
  public partial class Form1 : Form
  {
    const UInt32 AXIS_NUM = 3;
    ushort g_nESCExistCards = 0, g_nESCCardNo = 99;
    ushort[] g_nESCCardNoList = new ushort[32];
    ushort[] g_nNodeID = new ushort[12], g_nSlotID = new ushort[12];
    ushort g_nIONodeID, g_nIOSlotID;
    bool g_bInitialFlag = false;
    bool g_bSvonFlag = false;
    bool g_bFirsterRun = false;
    Double f64_StartTime = 0;
    Double f64_PassTime = 0;

    TextBox[] textCommand, textFeedback, textSpeed, textIOStatus, textBuffer, textMotion, textMoveMode;
    TextBox[] textMBStatus, textMBRemainSize, textMBBlockNum;

    //DMC
    short DMC_ExistCards = 0;
    ushort[] DMC_CardNoList = new ushort[32];
    ushort DMC_CardNo = 0;



    public Form1()
    {
      InitializeComponent();
      textCommand = new TextBox[] { text_CMD_1, text_CMD_2, text_CMD_3 };
      textFeedback = new TextBox[] { text_FBK_1, text_FBK_2, text_FBK_3 };
      textSpeed = new TextBox[] { text_SPD_1, text_SPD_2, text_SPD_3 };
      textIOStatus = new TextBox[] { text_IO_1, text_IO_2, text_IO_3 };
      textBuffer = new TextBox[] { text_Buffer_1, text_Buffer_2, text_Buffer_3 };
      textMotion = new TextBox[] { text_Motion_1, text_Motion_2, text_Motion_3 };
      textMoveMode = new TextBox[] { text_MoveMode_1, text_MoveMode_2, text_MoveMode_3 };

      textMBStatus = new TextBox[] { text_MB_Status_Fifo0, text_MB_Status_Fifo1 };
      textMBRemainSize = new TextBox[] { text_MB_RemainSize_Fifo0, text_MB_RemainSize_Fifo1 };
      textMBBlockNum = new TextBox[] { text_MB_BlockNum_Fifo0, text_MB_BlockNum_Fifo1 };

      for (UInt16 i = 0; i < 7; i++)
        combo_TableNo.Items.Add(i.ToString());

      for (UInt16 i = 0; i < 2; i++)
      {
        combo_MB_Stop_Mode.Items.Add(i.ToString());
        combo_FifoNo.Items.Add(i.ToString());
      }

      for (UInt16 i = 1; i < 9; i++)
        combo_SW_Test.Items.Add(i.ToString());

      combo_SW_Test.SelectedIndex = 0;
      combo_TableNo.SelectedIndex = 0;
      combo_FifoNo.SelectedIndex = 0;
      combo_MB_Stop_Mode.SelectedIndex = 0;
      text_MB_Stop_Dec.Text = "64000000";

      myScope1.CreateScope(0, 10, 0, 1, 6);
      myScope2.CreateScope(0, 1, 0, 1, 1);
    }

    private void btn_Initial_Click(object sender, EventArgs e)
    {
      short rt = 0;
      
      rt = CPCI_DMC.CS_DMC_01_open(ref  DMC_ExistCards);

      if (0 != rt)
          MessageBox.Show("CS_DMC_01_open, rt = " + rt.ToString());
      else
      {
        combo_CardNo.Items.Clear();
        text_CardNum.Text = Convert.ToString(DMC_ExistCards);

        for (ushort i = 0; i < DMC_ExistCards; i++)
        {
            rt = CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref  DMC_CardNoList[i]);

          if (0 != rt)
              MessageBox.Show("CS_DMC_01_get_CardNo_seq, rt = " + rt.ToString());
          else
          {
              combo_CardNo.Items.Add(DMC_CardNoList[i]);
            
            rt = CPCI_DMC.CS_DMC_01_pci_initial(DMC_CardNoList[i]);
            if (0 != rt)
                MessageBox.Show("CS_DMC_01_pci_initial, rt = " + rt.ToString());
          }
        }
        if (0 != DMC_ExistCards)
        {
          combo_CardNo.SelectedIndex = 0;
          btn_FindSlave.Enabled = true;
          timer1.Interval = 1;
          timer1.Enabled = true;
        }
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      short rt = 0;
    
      {
        if (true == chk_Timer.Checked)
        {
          Int32[] nCmd = new Int32[3], nFeedback = new Int32[3], nSpeed = new Int32[3];
          Int32[] nCurrentSpeed = new Int32[3], nXY_Pos = new Int32[3], nXY_Pos_Org = new Int32[3];
          Int32[] nReMainSize = new Int32[2], nBlockNum = new Int32[2], nUserSeg = new Int32[2];
          UInt16[] nStatusWord = new UInt16[3], nMCDone = new UInt16[3], nBufferLength = new UInt16[3], nMBStatus = new UInt16[2];
          UInt32[] Motion_Status = new UInt32[3];
          Byte[] nMoveMode = new Byte[3];
          Int32 nCombineVel = 0;

          for (UInt16 i = 0; i < 3; i++)
          {
          

            rt = CPCI_DMC.CS_DMC_01_get_command(DMC_CardNo, g_nNodeID[i], 0 ,ref nCmd[i]);
            rt = CPCI_DMC.CS_DMC_01_get_position(DMC_CardNo, g_nNodeID[i], 0, ref nFeedback[i]);
            rt = CPCI_DMC.CS_DMC_01_get_current_speed(DMC_CardNo, g_nNodeID[i], 0, ref  nCurrentSpeed[i]);
            rt = CPCI_DMC. CS_DMC_01_motion_status(DMC_CardNo, g_nNodeID[i], 0,  ref Motion_Status[i]);
            rt = CPCI_DMC.CS_DMC_01_motion_done(DMC_CardNo, g_nNodeID[i], 0, ref nMCDone[i]);
            rt = CPCI_DMC.CS_DMC_01_get_buffer_length(DMC_CardNo, g_nNodeID[i], 0, ref  nBufferLength[i]);

            textCommand[i].Text = Convert.ToString(nCmd[i]);
            textFeedback[i].Text = Convert.ToString(nFeedback[i]);
            textSpeed[i].Text = Convert.ToString(nCurrentSpeed[i]);
            textIOStatus[i].Text = Convert.ToString(nStatusWord[i]);
            textMotion[i].Text = Convert.ToString(nMCDone[i]);
            textBuffer[i].Text = Convert.ToString(nBufferLength[i]);
            textMoveMode[i].Text = Convert.ToString(nMoveMode[i]);
          }

    


          for (UInt16 i = 0; i < 2; i++)
          {
          
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Get_Motion_Status(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref nMBStatus[i], ref nBlockNum[i], i);
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Get_Remain_Buffer_Size(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref nReMainSize[i], i);
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_GetUserSegNum(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref nUserSeg[i], i);

            textMBStatus[i].Text = nMBStatus[i].ToString();
            textMBBlockNum[i].Text = nBlockNum[i].ToString();
            textMBRemainSize[i].Text = nReMainSize[i].ToString();
          }

       

          rt = CPCI_DMC.CS_DMC_01_MotionBuf_Get_Velocity(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref nCombineVel);
          rt = CPCI_DMC.CS_DMC_01_MotionBuf_Get_Position(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref nXY_Pos[0], ref nXY_Pos_Org[0]);


          if(true == chk_Drwing.Checked)
          {
            if(false == g_bFirsterRun)
            {
              f64_StartTime = myScope1.GetBaseTime();
              myScope1.SetPoint(1, f64_StartTime, 0);
             
                
              myScope1.Invalidate();
              g_bFirsterRun = true;
            }
            f64_PassTime = myScope1.GetPassTime(f64_StartTime);

            switch (Convert.ToInt32(combo_SW_Test.Text))
            {
              case 1:
              case 2:
              case 3:
                  myScope1.SetPoint(1, f64_PassTime, (Double)nCurrentSpeed[0]);
                  myScope1.SetPoint(2, f64_PassTime, (Double)nCurrentSpeed[1]);
                  myScope1.SetPoint(3, f64_PassTime, (Double)nCombineVel);
                  myScope2.SetPointXY(1, nCmd[0], nCmd[1]);
                break;
              case 4:
              case 5:
              case 6:

                myScope1.SetPoint(1, f64_PassTime, (double)nCurrentSpeed[0]);
                myScope1.SetPoint(2, f64_PassTime, (double)nCurrentSpeed[1]);
                myScope1.SetPoint(3, f64_PassTime, (double)nCombineVel);
                myScope1.SetPoint(4, f64_PassTime, (double)nCurrentSpeed[2]);
                myScope2.SetPointXY(1, nCmd[0], nCmd[1]);
                break;
              case 7://2018-05-07
              case 8://2018-05-07
                myScope1.SetPoint(1, f64_PassTime, (Double)nCurrentSpeed[0]);
                myScope1.SetPoint(2, f64_PassTime, (Double)nCurrentSpeed[1]);
                myScope1.SetPoint(3, f64_PassTime, (Double)nCurrentSpeed[2]);
                myScope1.SetPoint(4, f64_PassTime, (double)nCombineVel);
                myScope2.SetPointXY(1, nCmd[0], nCmd[1]);

                break;
              

            }
            if (f64_PassTime > 10)
            {
              f64_StartTime = myScope1.GetBaseTime();
            }
          }
          else
            g_bFirsterRun = false;
        }
      }
    }

    private void combo_CardNo_SelectedIndexChanged(object sender, EventArgs e)
    {
      g_nESCCardNo = g_nESCCardNoList[combo_CardNo.SelectedIndex];
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      
        CPCI_DMC.CS_DMC_01_close();

    }

    private void btn_FindSlave_Click(object sender, EventArgs e)
    {
      short rt = 0;
      ushort i = 0;

      ushort nSlaveNum = 0; 
 
      ushort NodeNum = 0;  

      uint DeviceType = 0;
      uint IdentityObject = 0;

      rt = CPCI_DMC.CS_DMC_01_initial_bus2();
      if (rt > 0)
      {
          MessageBox.Show("CS_DMC_01_initial_bus2, rt = " + rt.ToString());
      }

      rt = CPCI_DMC.CS_DMC_01_start_ring(DMC_CardNo, 0);
      if (rt > 0)
      {
          MessageBox.Show("CS_DMC_01_start_ring, rt = " + rt.ToString());
      }

      rt = CPCI_DMC.CS_DMC_01_get_device_table(DMC_CardNo, ref nSlaveNum);

     
      if (rt>0)
      {
          MessageBox.Show("CS_DMC_01_get_device_table, rt = " + rt.ToString());
      }
      else
      {
          ushort nAxisCut = 0, nIOCut = 0;
         
          if (0 != nSlaveNum)
          {
              combo_X_NodeID.Items.Clear();
              combo_Y_NodeID.Items.Clear();
              combo_Axis_NodeID.Items.Clear();
              combo_DO_NodeID.Items.Clear();

              for (i = 0; i < 12; i++)
              {
                  if((nSlaveNum & (0x01 << i))>0)
                  {
                      NodeNum++;

                  }
              }
               text_SlaveNum.Text = Convert.ToString(NodeNum);

              for (i = 1; i <= NodeNum; i++)
              {
                  string strMsg;
                  ushort nReMapNodeID = 0;
                  uint nVendorID = 0, nProductCode = 0, nRevisionNo = 0, nSlaveDCTime = 0;
                  
                  rt = CPCI_DMC.CS_DMC_01_get_devicetype(DMC_CardNo, i, 0, ref  DeviceType, ref  IdentityObject);

                if((DeviceType & 0x192)==0x192)
                {
                    strMsg = "NodeID:" + i + " - SlotID:" + 0 + "-A2F";
                    combo_X_NodeID.Items.Add(strMsg);
                    combo_Y_NodeID.Items.Add(strMsg);
                    combo_Axis_NodeID.Items.Add(strMsg);
                    nAxisCut++;
                }
                else if((DeviceType & 0x191) == 0x191)
                {
                    strMsg = "NodeID:" + i + " - SlotID:" + 0 + "-DO";
                    combo_DO_NodeID.Items.Add(strMsg);
                    nIOCut++;
                }
                
              }

              if (nAxisCut > 0)
              {
                  combo_X_NodeID.SelectedIndex = 0;
                  combo_Y_NodeID.SelectedIndex = 1;
                  combo_Axis_NodeID.SelectedIndex = 2;
              }
              if (nIOCut > 0)
                  combo_DO_NodeID.SelectedIndex = 0;
          }
      }
    }

    private void combo_X_NodeID_SelectedIndexChanged(object sender, EventArgs e)
    {
      String[] Remove_str = new String[] { "NodeID:", "SlotID:", "-", ",", " " };
      var parts = combo_X_NodeID.Text.Split(Remove_str, StringSplitOptions.RemoveEmptyEntries);
      g_nNodeID[0] = Convert.ToUInt16(parts[0]);
      g_nSlotID[0] = Convert.ToUInt16(parts[1]);
    }

    private void combo_Y_NodeID_SelectedIndexChanged(object sender, EventArgs e)
    {
      String[] Remove_str = new String[] { "NodeID:", "SlotID:", "-", ",", " " };
      var parts = combo_Y_NodeID.Text.Split(Remove_str, StringSplitOptions.RemoveEmptyEntries);
      g_nNodeID[1] = Convert.ToUInt16(parts[0]);
      g_nSlotID[1] = Convert.ToUInt16(parts[1]);
    }

    private void combo_Axis_NodeID_SelectedIndexChanged(object sender, EventArgs e)
    {
      String[] Remove_str = new String[] { "NodeID:", "SlotID:", "-", ",", " " };
      var parts = combo_Axis_NodeID.Text.Split(Remove_str, StringSplitOptions.RemoveEmptyEntries);
      g_nNodeID[2] = Convert.ToUInt16(parts[0]);
      g_nSlotID[2] = Convert.ToUInt16(parts[1]);
    }

    private void combo_DO_NodeID_SelectedIndexChanged(object sender, EventArgs e)
    {
      String[] Remove_str = new String[] { "NodeID:", "SlotID:", "-", ",", " " };
      var parts = combo_DO_NodeID.Text.Split(Remove_str, StringSplitOptions.RemoveEmptyEntries);
      g_nIONodeID = Convert.ToUInt16(parts[0]);
      g_nIOSlotID = Convert.ToUInt16(parts[1]);
    }

    private void but_SVON_Click(object sender, EventArgs e)
    {

      short rt = 0;

  

      if (false == g_bSvonFlag)
      {
        g_bSvonFlag = true;
        for (UInt16 i = 0; i < 3; i++)
        {
          
            rt = CPCI_DMC.CS_DMC_01_ipo_set_svon(DMC_CardNo, g_nNodeID[i], 0, 1);
          if (0 != rt)
              MessageBox.Show("CS_DMC_01_ipo_set_svon, rt = " + rt.ToString());
        }
        btn_SVON.Text = "SVON OFF";
      }
      else
      {
        g_bSvonFlag = false;
        for (UInt16 i = 0; i < 3; i++)
        {
          
            rt = CPCI_DMC.CS_DMC_01_ipo_set_svon(DMC_CardNo, g_nNodeID[i], 0, 1);
          if (0 != rt)
              MessageBox.Show("CS_DMC_01_ipo_set_svon, rt = " + rt.ToString());
        }
        btn_SVON.Text = "SVON";
      }
    }

    private void btn_RALM_Click(object sender, EventArgs e)
    {
      short rt = 0;
      for (UInt16 i = 0; i < 5; i++)
      {
        
          rt = CPCI_DMC.CS_DMC_01_set_ralm(DMC_CardNo, g_nNodeID[i], g_nSlotID[i]);
         
        if (0 != rt)
          MessageBox.Show("CS_ECAT_Slave_Motion_Ralm, rt = " + rt.ToString());
      }
    }

    private void btn_RESET_Click(object sender, EventArgs e)
    {
      short rt = 0;
      for (UInt16 i = 0; i <3; i++)
      {
        
           rt = CPCI_DMC.CS_DMC_01_set_position(DMC_CardNo, g_nNodeID[i],0, 0);
        if (0 != rt)
            MessageBox.Show("CS_DMC_01_set_position, rt = " + rt.ToString());

        
        rt = CPCI_DMC.CS_DMC_01_set_command(DMC_CardNo, g_nNodeID[i], 0, 0);

        if (0 != rt)
            MessageBox.Show("CS_DMC_01_set_command, rt = " + rt.ToString());
      }
    }

    private void TestCase1()
    {

	    Int32 i32_SynMaxVel = 6400000;
	    Int32 i32_SynMaxAcc = 12800000;
	    UInt16 u16_Scurve_Time = 20;
	    Int32[] pi32_OrgPos = new Int32[] {0, 0};

        //2018-04-09
        UInt16 i = 0;
        CPCI_DMC.IO_Set[] IO_Array = new CPCI_DMC.IO_Set[32];

        //


	    short rt = 0;
           
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 2, ref g_nNodeID[0],i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);

	  UInt16[] pu16_ArcAxis = new UInt16[]{0, 1};
      Int32[] pi32_TargetPos = new Int32[] { 4000000, 0 };
      rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //2018-04-09
      if (IOControlcheckBox.Checked)
      {
          for (i = 0; i < 32; i++)
          {
              IO_Array[i].IO_Info.NodeID = g_nIONodeID;
              IO_Array[i].IO_Info.SlotID = 0;
              IO_Array[i].IO_Info.BitNo = (UInt16)(i);
              IO_Array[i].Value = 1;	 

          }

      }
      rt = CPCI_DMC.CS_DMC_01_set_rm_output_active(DMC_CardNo, g_nIONodeID, 0, 1);//active Remote IO
      for (i = 0; i < 4; i++)
      {
          rt = CPCI_DMC.CS_DMC_01_set_rm_output_value(DMC_CardNo, g_nIONodeID, 0, i, 0); //Initial RM64NT IO status
      }


      
        //


	    // arc
	    pi32_TargetPos[0] = 5000000;
	    pi32_TargetPos[1] = 1000000;
     
      rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_Radius(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], 1000000, 1, i32_SynMaxVel,
                  0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


	    pi32_TargetPos[0] = 5000000;
	    pi32_TargetPos[1] = 4000000;
    
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
              0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        //2018-04-09
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[i], Convert.ToUInt16(combo_FifoNo.Text));
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

            }    
        }

        //2018-04-19  64NT bit 31~63  ON
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i+32);
                IO_Array[i].Value = 1;

            }

        }
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[i], Convert.ToUInt16(combo_FifoNo.Text));
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

            }
        }

        //2018-04-19  64NT bit 0~31  OFF
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 0;

            }

        }
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[i], Convert.ToUInt16(combo_FifoNo.Text));
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

            }
        }

        //2018-04-19  64NT bit 31~63  OFF
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i+32);
                IO_Array[i].Value = 0;

            }

        }
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[i], Convert.ToUInt16(combo_FifoNo.Text));
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

            }
        }

        //

        //2018-04-11
        //rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        //2018-04-09
        //if (IOControlcheckBox.Checked)
        //{

        //    for (i = 0; i < 32; i++)
        //    {    if((i%2)>0)
        //         {
        //            IO_Array[i].Value = 0;
        //            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[i], Convert.ToUInt16(combo_FifoNo.Text));
        //         }
        //            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        //    }
        //}




	    // arc
	    pi32_TargetPos[0] = 4000000;
	    pi32_TargetPos[1] = 5000000;
      


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_Radius(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], 1000000, 1, i32_SynMaxVel,
              0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 5000000;
    



        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 4000000;
     

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_Radius(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], 1000000, 1, i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 1000000;
      
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
           0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 0;
     
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_Radius(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], 1000000, 1, i32_SynMaxVel,
           0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

      

       rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                  i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));
   

    }

    private void TestCase2()
    {
	    Int32 i32_SynMaxVel = 6400000;
	    Int32 i32_SynMaxAcc = 12800000;
	    UInt16 u16_Scurve_Time = 20;
	    Int32[] pi32_OrgPos = new Int32[2] {0, 0};
        short rt = 0;

        //2018-04-20
        UInt16 i = 0;
        CPCI_DMC.IO_Set[] IO_Array = new CPCI_DMC.IO_Set[32];

        //

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 2, ref g_nNodeID[0], i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);

        UInt16[] pu16_ArcAxis = new UInt16[2] { 0, 1 };
	    Int32[] pi32_TargetPos = new Int32[2] {4000000, 0};
	    Int32[] pi32_CenterPos = new Int32[2] {0, 1000000};
     
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
		    0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        //2018-04-11
        //rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        rt = CPCI_DMC.CS_DMC_01_set_rm_output_active(DMC_CardNo, g_nIONodeID, 0, 1);//active Remote IO
        for (i = 0; i < 4; i++)
        {
            rt = CPCI_DMC.CS_DMC_01_set_rm_output_value(DMC_CardNo, g_nIONodeID, 0, i, 0); //Initial RM64NT IO status
        }


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 1;

            }

        }

        if (IOControlcheckBox.Checked)
        {
           
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[0], Convert.ToUInt16(combo_FifoNo.Text));
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i <32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 0;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[0], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }  




	    // arc
	    pi32_TargetPos[0] = 5000000;
	    pi32_TargetPos[1] = 1000000;
     
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
		   0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));
        
          //2018-04-11
         rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


         if (IOControlcheckBox.Checked)
         {
             for (i = 0; i < 32; i++)
             {
                 IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                 IO_Array[i].IO_Info.SlotID = 0;
                 IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                 IO_Array[i].Value = 1;

             }

         }

         if (IOControlcheckBox.Checked)
         {

             rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[1], Convert.ToUInt16(combo_FifoNo.Text));
             rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

         }


         if (IOControlcheckBox.Checked)
         {
             for (i = 0; i < 32; i++)
             {
                 IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                 IO_Array[i].IO_Info.SlotID = 0;
                 IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                 IO_Array[i].Value = 0;

             }

         }

         if (IOControlcheckBox.Checked)
         {

             rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[1], Convert.ToUInt16(combo_FifoNo.Text));
             rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

         }  







	     pi32_TargetPos[0] = 5000000;
	    pi32_TargetPos[1] = 4000000;
      
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
          0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //2018-04-11
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 1;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[2], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 0;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[2], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }  


	    // arc
	    pi32_TargetPos[0] = 4000000;
	    pi32_TargetPos[1] = 5000000;
	    pi32_CenterPos[0] = -1000000;
	    pi32_CenterPos[1] = 0;
      
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
                    0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        //2018-04-11
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));



        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 1;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[3], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 0;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[3], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }  


	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 5000000;
      
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                    0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        //2018-04-11
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 1;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[4], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 0;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[4], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }  



	    // arc
	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 4000000;
	    pi32_CenterPos[0] = 0;
	    pi32_CenterPos[1] = -1000000;
      
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
                    0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));




        //2018-04-11
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));



        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 1;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[5], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 0;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[5], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }  


	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 1000000;
      
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                    0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //2018-04-11
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));




	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 0;
	    pi32_CenterPos[0] = 1000000;
	    pi32_CenterPos[1] = 0;
     
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
                 0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //2018-04-11
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 1;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[6], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }


        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 0;

            }

        }

        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[6], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

        }  
  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));


    }

    private void TestCase3()
    {
	    Int32 i32_SynMaxVel = 22000000;
	    Int32 i32_SynMaxAcc = 73333333;
	    UInt16 u16_Scurve_Time = 20;
	    Int32[] pi32_OrgPos = new Int32[] {0, 0};
	    short rt=0;

        g_nNodeID[0] = 1;
        g_nNodeID[1] = 2;
        g_nNodeID[2] = 3;
        g_nNodeID[3] = 4;
        g_nNodeID[4] = 5;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 5, ref g_nNodeID[0], i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);

	


	    UInt16[] pu16_ArcAxis = new UInt16[2] { 0, 1 };
	    Int32[] pi32_TargetPos = new Int32[5]{0,0,0,0,0};
	    Int32[] pi32_CenterPos = new Int32[2] {0, 1000000};

        pi32_TargetPos[0] = 38376847;
        pi32_TargetPos[1] = 9556244;	
        pi32_TargetPos[2] =864688;	
        pi32_TargetPos[3] =55253726;
        pi32_TargetPos[4] = 0;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                 0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 38376847;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 55253726;
        pi32_TargetPos[4] = 0;
   


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 864688;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 10859047;
        pi32_TargetPos[2] = 864688;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

      


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

        //40014656.2	9556244.359	0	56891535.38	0


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

        //40014656.2	9556244.359	0	56891535.38	0


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
        i32_SynMaxVel, 0, 0, 100, Convert.ToUInt16(combo_FifoNo.Text));    



          /*
	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 1000000;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
                 0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 3000000;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = 1000000;
	    pi32_CenterPos[0] = -1000000;
	    pi32_CenterPos[1] = 0;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
                 0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));




	    pi32_TargetPos[0] = -3000000;
	    pi32_TargetPos[1] = 0;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));




	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 0;
	    pi32_CenterPos[1] = -1000000;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = -3000000;
	    
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 1000000;
	    pi32_CenterPos[1] = 0;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));
          

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                  i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));
                                                                                           */


    }

    // =======================================================
    // case4
    // =======================================================
    void TestCase4()
    {

        Int32 i32_SynMaxVel = 22000000;
        Int32 i32_SynMaxAcc = 73333333;
        UInt16 u16_Scurve_Time = 20;
        Int32[] pi32_OrgPos = new Int32[] { 0, 0 ,0, 0, 0};
        short rt = 0;

        g_nNodeID[0] = 1;
        g_nNodeID[1] = 2;
        g_nNodeID[2] = 3;
        g_nNodeID[3] = 4;
        g_nNodeID[4] = 7;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 5, ref g_nNodeID[0], i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);




        UInt16[] pu16_ArcAxis = new UInt16[2] { 0, 1 };
        Int32[] pi32_TargetPos = new Int32[5] { 0, 0, 0, 0, 0 };
        Int32[] pi32_CenterPos = new Int32[2] { 0, 1000000 };

        pi32_TargetPos[0] = 38376847;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 864688;
        pi32_TargetPos[3] = 55253726;
        pi32_TargetPos[4] = 0;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                 0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 38376847;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 55253726;
        pi32_TargetPos[4] = 0;



        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
                0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 864688;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 10859047;
        pi32_TargetPos[2] = 864688;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;




        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

        //40014656.2	9556244.359	0	56891535.38	0


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

        //40014656.2	9556244.359	0	56891535.38	0


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 10859047;
        pi32_TargetPos[2] = 864688;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;




        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        pi32_TargetPos[0] = 40014656;
        pi32_TargetPos[1] = 9556244;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 56891535;
        pi32_TargetPos[4] = 0;

        //40014656.2	9556244.359	0	56891535.38	0


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



        pi32_TargetPos[0] = 32473289;
        pi32_TargetPos[1] = 25897113;
        pi32_TargetPos[2] = 0;
        pi32_TargetPos[3] = 49335279;
        pi32_TargetPos[4] = 0;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //32473289.37	25897113.26	0	49335279.37	0



        //32473289.37	25897113.26	2805492.686	49335279.37	0
        pi32_TargetPos[0] = 32473289;
        pi32_TargetPos[1] = 25897113;
        pi32_TargetPos[2] = 2805492;
        pi32_TargetPos[3] = 49335279;
        pi32_TargetPos[4] = 0;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //32473289.37	25897113.26	1005019.272	49335279.37	0
        pi32_TargetPos[0] = 32473289;
        pi32_TargetPos[1] = 25897113;
        pi32_TargetPos[2] = 1005019;
        pi32_TargetPos[3] = 49335279;
        pi32_TargetPos[4] = 0;

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));








       /* rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
        i32_SynMaxVel, 0, 0, 100, Convert.ToUInt16(combo_FifoNo.Text)); */   


	   /* Int32 i32_SynMaxVel = 6400000;
	    Int32 i32_SynMaxAcc = 12800000;
	    UInt16 u16_Scurve_Time = 0;
	    Int32[] pi32_OrgPos = new Int32[] {0, 0};
        short rt = 0; 
            
        

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 2, ref g_nNodeID[0], i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);



	    UInt16[] pu16_ArcAxis = new UInt16[2] { 0, 1 };
	    Int32[] pi32_TargetPos = new Int32[2]{4000000, 0};
	    Int32[] pi32_CenterPos = new Int32[2] {0, 1000000};
	    
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // buffer gear
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufGear(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
            2000000, Convert.ToUInt16(combo_FifoNo.Text));


	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 1000000;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
              0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 3000000;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
             0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // buffer gear
	 
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufGear(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
         2000000, Convert.ToUInt16(combo_FifoNo.Text));


	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = 1000000;
	    pi32_CenterPos[0] = -1000000;
	    pi32_CenterPos[1] = 0;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
               0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    pi32_TargetPos[0] = -3000000;
	    pi32_TargetPos[1] = 0;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
             0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // buffer gear
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufGear(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
         2000000, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 0;
	    pi32_CenterPos[1] = -1000000;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
              0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = -3000000;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
             0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // buffer gear
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufGear(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
          2000000, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 1000000;
	    pi32_CenterPos[1] = 0;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
              0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                 i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));

              */
    }

    // =======================================================
    // case5
    // =======================================================
    void TestCase5()
    {
	    Int32 i32_SynMaxVel = 6400000;
	    Int32 i32_SynMaxAcc = 12800000;
	    UInt16 u16_Scurve_Time = 0;
	    Int32[] pi32_OrgPos = new Int32[] {0, 0};
        short rt = 0; 
         
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 2, ref g_nNodeID[0], i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);



	    UInt16[] pu16_ArcAxis = new UInt16[2] { 0, 1 };
	    Int32[] pi32_TargetPos = new Int32[2]{4000000, 0};
	    Int32[] pi32_CenterPos = new Int32[2] {0, 1000000};
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
           0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));




	    // buffer move
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2], 
		    1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 0, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 1000000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
          0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 3000000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
      0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // buffer move
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
            1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 0, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = 1000000;
	    pi32_CenterPos[0] = -1000000;
	    pi32_CenterPos[1] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    pi32_TargetPos[0] = -3000000;
	    pi32_TargetPos[1] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
       0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // buffer move
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
            1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 0, Convert.ToUInt16(combo_FifoNo.Text));




	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 0;
	    pi32_CenterPos[1] = -1000000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));





	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = -3000000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
      0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));




	    // buffer move
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
            1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 0, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 1000000;
	    pi32_CenterPos[1] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));



        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));

    }

    // =======================================================
    // case6
    // =======================================================
    void TestCase6()
    {
	    Int32 i32_SynMaxVel = 6400000;
	    Int32 i32_SynMaxAcc = 12800000;
	    UInt16 u16_Scurve_Time = 0;
	    Int32[] pi32_OrgPos = new Int32[] {0, 0};
        short rt = 0; 
        
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 2, ref g_nNodeID[0], 
            i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);




	    UInt16[] pu16_ArcAxis = new UInt16[2] { 0, 1 };
	    Int32[] pi32_TargetPos = new Int32[2]{4000000, 0};
	    Int32[] pi32_CenterPos = new Int32[2] {0, 1000000};
	    
        
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
		    0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));


	    // buffer move
	   
         rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2], 
		    1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 1, Convert.ToUInt16(combo_FifoNo.Text));


	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = 1000000;
	  
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
		   0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));




	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = 3000000;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
		    0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));



	    // buffer move
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
           1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 1, Convert.ToUInt16(combo_FifoNo.Text));



	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = 1000000;
	    pi32_CenterPos[0] = -1000000;
	    pi32_CenterPos[1] = 0;
	    
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
		    0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));


	    pi32_TargetPos[0] = -3000000;
	    pi32_TargetPos[1] = 0;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
		    0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));


	    // buffer move
	    
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
          1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 1, Convert.ToUInt16(combo_FifoNo.Text));


	    // arc
	    pi32_TargetPos[0] = -1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 0;
	    pi32_CenterPos[1] = -1000000;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
         0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));


	    pi32_TargetPos[0] = 0;
	    pi32_TargetPos[1] = -3000000;
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
        0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));


	    // buffer move
	   
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_BufMove(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), g_nNodeID[2],
          1000000, i32_SynMaxVel, i32_SynMaxAcc, 0, 1, Convert.ToUInt16(combo_FifoNo.Text));


	    // arc
	    pi32_TargetPos[0] = 1000000;
	    pi32_TargetPos[1] = -1000000;
	    pi32_CenterPos[0] = 1000000;
	    pi32_CenterPos[1] = 0;
	    
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref pi32_CenterPos[0], 1, i32_SynMaxVel,
         0, i32_SynMaxAcc, 0, Convert.ToUInt16(combo_FifoNo.Text));


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                 i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));



    }
    
      
    void TestCase7()
    {
        Int32 i32_SynMaxVel = 128000 * 4;
        Int32 i32_SynMaxAcc = 1280000;
        UInt16 u16_Scurve_Time = 1;
        Int32[] pi32_OrgPos = new Int32[] { 0, 0, 0 };
        short rt = 0;

         //Helix parameter
         //CS_DMC_01_MotionBuf_Helix(ushort CardNo, ushort TableNo, ref ushort Helix_Axis, ref int CenterPos, int Depth, int Pitch, short HelixDir, int SynTargetVel, int SynEndVel, int SynAcc, ushort AbsMode, ushort FifoNo); 
        ushort[] Helix_Axis = new ushort[3] { 0, 1, 2 };
        int[] CenterPos = new int[2] { 0, 0 };
        int Depth = 0;
        int Pitch = 0;
        short HelixDir = 0;
        int SynTargetVel = 128000 * 2;
        int SynEndVel = 0;
        int SynAcc = 128000;
        ushort AbsMode = 0;

        //

        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 3, ref g_nNodeID[0],
            i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);


        Int32[] pi32_TargetPos = new Int32[3] { 100000, 0, 0 };
        
        // Step 1 : 設置多軸線性插補
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        // Step 2 : 設置三軸螺旋插補
        CenterPos[0] = 0; // 此為與起始點的相對位置
        CenterPos[1] = 20000; // 此為與起始點的相對位置
        Depth = 100000; // 此為與起始點的相對位置
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);



        CenterPos[0] = 0; // 此為與起始點的相對位置
        CenterPos[1] = 20000; // 此為與起始點的相對位置
        Depth = -100000; // 此為與起始點的相對位置
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);


        pi32_TargetPos[0] = 100000;
        pi32_TargetPos[1] = 100000;
        pi32_TargetPos[2] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
          0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        Depth = -100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);

        // Step 3 : 設置多軸線性插補
        pi32_TargetPos[0] = 100000;
        pi32_TargetPos[1] = 100000;
        pi32_TargetPos[2] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        // Step 4 : 設置三軸螺旋插補
        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        Depth = 100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);


        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        Depth = -100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);

        // Step 5 : 設置多軸線性插補
        pi32_TargetPos[0] = 0;
        pi32_TargetPos[1] = 100000;
        pi32_TargetPos[2] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        // Step 6 : 設置三軸螺旋插補
        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        Depth = 100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);

        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        Depth = -100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);

        // Step 7 : 設置多軸線性插補
        pi32_TargetPos[0] = 0;
        pi32_TargetPos[1] = 0;
        pi32_TargetPos[2] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

        // Step 8 : 設置三軸螺旋插補
        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        Depth = 100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);


        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        Depth = -100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);



        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                 i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));



    }

    void TestCase8()
    {
        Int32 i32_SynMaxVel = 128000 * 4;
        Int32 i32_SynMaxAcc = 1280000;
        UInt16 u16_Scurve_Time = 1;
        Int32[] pi32_OrgPos = new Int32[] { 0, 0, 0 };
        short rt = 0;

        //Helix parameter
        //CS_DMC_01_MotionBuf_Helix(ushort CardNo, ushort TableNo, ref ushort Helix_Axis, ref int CenterPos, int Depth, int Pitch, short HelixDir, int SynTargetVel, int SynEndVel, int SynAcc, ushort AbsMode, ushort FifoNo); 
        ushort[] Helix_Axis = new ushort[3] { 0, 1, 2 };
        int[] CenterPos = new int[2] { 0, 0 };
        int Depth = 0;
        int Pitch = 0;
        short HelixDir = 0;
        int SynTargetVel = 128000 * 3;
        int SynEndVel = 0;
        int SynAcc = 128000;
        ushort AbsMode = 0;

        //


        //Arc Axis
        UInt16[] pu16_ArcAxis = new UInt16[2] { 0, 1 };
      

        //

        //IO Control   
        UInt16 i = 0;
        CPCI_DMC.IO_Set[] IO_Array = new CPCI_DMC.IO_Set[32];
        //


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Crd_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 3, ref g_nNodeID[0],
            i32_SynMaxVel, i32_SynMaxAcc, u16_Scurve_Time, 0, 0, ref pi32_OrgPos[0]);


        //IO Control   
        if (IOControlcheckBox.Checked)
        {
            for (i = 0; i < 32; i++)
            {
                IO_Array[i].IO_Info.NodeID = g_nIONodeID;
                IO_Array[i].IO_Info.SlotID = 0;
                IO_Array[i].IO_Info.BitNo = (UInt16)(i);
                IO_Array[i].Value = 1;

            }

        }
        rt = CPCI_DMC.CS_DMC_01_set_rm_output_active(DMC_CardNo, g_nIONodeID, 0, 1);//active Remote IO
        for (i = 0; i < 4; i++)
        {
            rt = CPCI_DMC.CS_DMC_01_set_rm_output_value(DMC_CardNo, g_nIONodeID, 0, i, 0); //Initial RM64NT IO status
        }



        Int32[] pi32_TargetPos = new Int32[3] { 100000, 0, 0 };

        // Step 1 : 設置多軸線性插補
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        // Step 2 : 設置三軸螺旋插補
        CenterPos[0] = 0; // 此為與起始點的相對位置
        CenterPos[1] = 20000; // 此為與起始點的相對位置
        Depth = 100000; // 此為與起始點的相對位置
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);


        // Step 3 : 設置平面圓弧插補
        CenterPos[0] = 0;
        CenterPos[1] = 20000;
        pi32_TargetPos[0] = 120000;
        pi32_TargetPos[1] = 20000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(DMC_CardNo, 0, ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref CenterPos[0], 1, SynTargetVel, 0, SynAcc, 1, 0);


        pi32_TargetPos[0] = 120000;
        pi32_TargetPos[1] = 100000;
        pi32_TargetPos[2] = 100000;

        // Step 1 : 設置多軸線性插補
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));

       
         //IO Control      bit 0 ON
        if (IOControlcheckBox.Checked)
        {
           
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[0], Convert.ToUInt16(combo_FifoNo.Text));
                rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));

          
        }
         //



        CenterPos[0] = -20000; // 此為與起始點的相對位置
        CenterPos[1] = 0; // 此為與起始點的相對位置
        Depth = -100000; // 此為與起始點的相對位置
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);

        CenterPos[0] = -20000;
        CenterPos[1] = 0;
        pi32_TargetPos[0] = 100000;
        pi32_TargetPos[1] = 120000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(0, 0, ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref CenterPos[0], 1, SynTargetVel, 0, SynAcc, 1, 0);



        pi32_TargetPos[0] = 20000;
        pi32_TargetPos[1] = 120000;
        pi32_TargetPos[2] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
          0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //IO Control      bit 2 ON
        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[2], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        }
        //




        CenterPos[0] = 0;
        CenterPos[1] = -20000;
        Depth = 100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);


        CenterPos[0] = 0;
        CenterPos[1] = -20000;
        pi32_TargetPos[0] = 0;
        pi32_TargetPos[1] = 100000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(0, 0, ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref CenterPos[0], 1, SynTargetVel, 0, SynAcc, 1, 0);



        
        pi32_TargetPos[0] = 0;
        pi32_TargetPos[1] = 20000;
        pi32_TargetPos[2] = 100000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Line_MultiAxis(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref pi32_TargetPos[0], i32_SynMaxVel,
            0, i32_SynMaxAcc, 1, Convert.ToUInt16(combo_FifoNo.Text));


        //IO Control      bit 4 ON
        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[4], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        }
        //
       
        CenterPos[0] = 20000;
        CenterPos[1] = 0;
        Depth = -100000;
        Pitch = 50000;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Helix(0, 0, ref Helix_Axis[0], ref CenterPos[0], Depth, Pitch, HelixDir, SynTargetVel, SynEndVel, SynAcc, 1, 0);

        CenterPos[0] = 20000;
        CenterPos[1] = 0;
        pi32_TargetPos[0] = 20000;
        pi32_TargetPos[1] = 0;
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Arc_CenterPos(0, 0, ref pu16_ArcAxis[0], ref pi32_TargetPos[0], ref CenterPos[0], 1, SynTargetVel, 0, SynAcc, 1, 0);


        //IO Control      bit 6 ON
        if (IOControlcheckBox.Checked)
        {

            rt = CPCI_DMC.CS_DMC_01_MotionBuf_IOControl(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), 1, ref IO_Array[6], Convert.ToUInt16(combo_FifoNo.Text));
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Delay(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToDouble(DelaytextBox.Text), Convert.ToUInt16(combo_FifoNo.Text));


        }
        //


        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_LookAhead_Parameters(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text),
                 i32_SynMaxVel, 0, 100, 100, Convert.ToUInt16(combo_FifoNo.Text));



    }
    private void btn_MB_SetData_Click(object sender, EventArgs e)
    {
      switch (Convert.ToInt32(combo_SW_Test.Text))
      {
        case 1:
          TestCase1();
          break;

        case 2:
          TestCase2();
          break;

        case 3:
          TestCase3();
          break;

        case 4:
          TestCase4();
          break;

        case 5:
          TestCase5();
          break;

        case 6:
          TestCase6();
          break;

        case 7:
          TestCase7();
          break;

        case 8:
          TestCase8();
          break;
      }
    }

    private void btn_MB_Start_Click(object sender, EventArgs e)
    {
      short rt = 0;

      switch (combo_SW_Test.SelectedIndex)
      {
        default:
          rt = CPCI_DMC.CS_DMC_01_MotionBuf_Start(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToUInt16(combo_FifoNo.Text));
          
          break;
      }

      if (0 != rt)
          MessageBox.Show("CS_DMC_01_MotionBuf_Start, rt = " + rt.ToString());
    }

    private void btn_MB_Clear_Click(object sender, EventArgs e)
    {
        short rt = 0; 
          
          rt = CPCI_DMC.CS_DMC_01_MotionBuf_Clear_Buffer(DMC_CardNo,  Convert.ToUInt16(combo_TableNo.Text), Convert.ToUInt16(combo_FifoNo.Text));

      if (0 != rt)
          MessageBox.Show("CS_DMC_01_MotionBuf_Clear_Buffer, rt = " + rt.ToString());
    }

    private void btn_MB_Stop_Click(object sender, EventArgs e)
    {
        short rt = 0;  
          
            rt = CPCI_DMC.CS_DMC_01_MotionBuf_Stop(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToUInt16(combo_FifoNo.Text), Convert.ToByte(combo_MB_Stop_Mode.Text));
      if (0 != rt)
        MessageBox.Show("CS_DMC_01_MotionBuf_Stop, rt = " + rt.ToString());
    }

    private void btn_MB_Set_Stop_Dec_Click(object sender, EventArgs e)
    {
        short rt = 0;   
         
        rt = CPCI_DMC.CS_DMC_01_MotionBuf_Set_Stop_Deceleration(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), Convert.ToInt32(text_MB_Stop_Dec.Text), 0);
      if (0 != rt)
          MessageBox.Show("CS_DMC_01_MotionBuf_Set_Stop_Deceleration, rt = " + rt.ToString());
    }

    private void btn_MB_Get_Stop_Dec_Click(object sender, EventArgs e)
    {
      Int32 i32_DecSmoothStop = 0, i32_DecAbruptStop = 0;
      short rt = 0;   
          
      rt = CPCI_DMC.CS_DMC_01_MotionBuf_Get_Stop_Deceleration(DMC_CardNo, Convert.ToUInt16(combo_TableNo.Text), ref i32_DecSmoothStop, ref i32_DecAbruptStop);

      if (0 != rt)
          MessageBox.Show("CS_DMC_01_MotionBuf_Get_Stop_Deceleration, rt = " + rt.ToString());
      else
        text_MB_Stop_Dec.Text = i32_DecSmoothStop.ToString();

    }

    private void ClearScope_button_Click(object sender, EventArgs e)
    {
        uint i = 0;
       
        myScope1.ClearPointXY(1);
        myScope2.ClearPointXY(1);
       
    }



  }
}
