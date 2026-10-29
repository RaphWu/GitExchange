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
        ushort gCardNo = 0, DeviceInfo = 0,nodeid=0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum = 0, gNTNodeNum = 0, gMNNodeNum = 0, gPTNodeNum = 0;
        ushort[] gpNTNode = new ushort[12], gpMNNode = new ushort[12], gpPTNode = new ushort[12];

        TextBox[] txtInput = new TextBox[64];
        CheckBox[] chkOutput = new CheckBox[64];

        public Form1()
        {
            InitializeComponent();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtInput[0] = txtInput0;
            txtInput[1] = txtInput1;
            txtInput[2] = txtInput2;
            txtInput[3] = txtInput3;
            txtInput[4] = txtInput4;
            txtInput[5] = txtInput5;
            txtInput[6] = txtInput6;
            txtInput[7] = txtInput7;
            txtInput[8] = txtInput8;
            txtInput[9] = txtInput9;
            txtInput[10] = txtInput10;
            txtInput[11] = txtInput11;
            txtInput[12] = txtInput12;
            txtInput[13] = txtInput13;
            txtInput[14] = txtInput14;
            txtInput[15] = txtInput15;
            txtInput[16] = txtInput16;
            txtInput[17] = txtInput17;
            txtInput[18] = txtInput18;
            txtInput[19] = txtInput19;
            txtInput[20] = txtInput20;
            txtInput[21] = txtInput21;
            txtInput[22] = txtInput22;
            txtInput[23] = txtInput23;
            txtInput[24] = txtInput24;
            txtInput[25] = txtInput25;
            txtInput[26] = txtInput26;
            txtInput[27] = txtInput27;
            txtInput[28] = txtInput28;
            txtInput[29] = txtInput29;
            txtInput[30] = txtInput30;
            txtInput[31] = txtInput31;
            txtInput[32] = txtInput32;
            txtInput[33] = txtInput33;
            txtInput[34] = txtInput34;
            txtInput[35] = txtInput35;
            txtInput[36] = txtInput36;
            txtInput[37] = txtInput37;
            txtInput[38] = txtInput38;
            txtInput[39] = txtInput39;
            txtInput[40] = txtInput40;
            txtInput[41] = txtInput41;
            txtInput[42] = txtInput42;
            txtInput[43] = txtInput43;
            txtInput[44] = txtInput44;
            txtInput[45] = txtInput45;
            txtInput[46] = txtInput46;
            txtInput[47] = txtInput47;
            txtInput[48] = txtInput48;
            txtInput[49] = txtInput49;
            txtInput[50] = txtInput50;
            txtInput[51] = txtInput51;
            txtInput[52] = txtInput52;
            txtInput[53] = txtInput53;
            txtInput[54] = txtInput54;
            txtInput[55] = txtInput55;
            txtInput[56] = txtInput56;
            txtInput[57] = txtInput57;
            txtInput[58] = txtInput58;
            txtInput[59] = txtInput59;
            txtInput[60] = txtInput60;
            txtInput[61] = txtInput61;
            txtInput[62] = txtInput62;
            txtInput[63] = txtInput63;

            chkOutput[0] = chkOutput0;
            chkOutput[1] = chkOutput1;
            chkOutput[2] = chkOutput2;
            chkOutput[3] = chkOutput3;
            chkOutput[4] = chkOutput4;
            chkOutput[5] = chkOutput5;
            chkOutput[6] = chkOutput6;
            chkOutput[7] = chkOutput7;
            chkOutput[8] = chkOutput8;
            chkOutput[9] = chkOutput9;
            chkOutput[10] = chkOutput10;
            chkOutput[11] = chkOutput11;
            chkOutput[12] = chkOutput12;
            chkOutput[13] = chkOutput13;
            chkOutput[14] = chkOutput14;
            chkOutput[15] = chkOutput15;
            chkOutput[16] = chkOutput16;
            chkOutput[17] = chkOutput17;
            chkOutput[18] = chkOutput18;
            chkOutput[19] = chkOutput19;
            chkOutput[20] = chkOutput20;
            chkOutput[21] = chkOutput21;
            chkOutput[22] = chkOutput22;
            chkOutput[23] = chkOutput23;
            chkOutput[24] = chkOutput24;
            chkOutput[25] = chkOutput25;
            chkOutput[26] = chkOutput26;
            chkOutput[27] = chkOutput27;
            chkOutput[28] = chkOutput28;
            chkOutput[29] = chkOutput29;
            chkOutput[30] = chkOutput30;
            chkOutput[31] = chkOutput31;
            chkOutput[32] = chkOutput32;
            chkOutput[33] = chkOutput33;
            chkOutput[34] = chkOutput34;
            chkOutput[35] = chkOutput35;
            chkOutput[36] = chkOutput36;
            chkOutput[37] = chkOutput37;
            chkOutput[38] = chkOutput38;
            chkOutput[39] = chkOutput39;
            chkOutput[40] = chkOutput40;
            chkOutput[41] = chkOutput41;
            chkOutput[42] = chkOutput42;
            chkOutput[43] = chkOutput43;
            chkOutput[44] = chkOutput44;
            chkOutput[45] = chkOutput45;
            chkOutput[46] = chkOutput46;
            chkOutput[47] = chkOutput47;
            chkOutput[48] = chkOutput48;
            chkOutput[49] = chkOutput49;
            chkOutput[50] = chkOutput50;
            chkOutput[51] = chkOutput51;
            chkOutput[52] = chkOutput52;
            chkOutput[53] = chkOutput53;
            chkOutput[54] = chkOutput54;
            chkOutput[55] = chkOutput55;
            chkOutput[56] = chkOutput56;
            chkOutput[57] = chkOutput57;
            chkOutput[58] = chkOutput58;
            chkOutput[59] = chkOutput59;
            chkOutput[60] = chkOutput60;
            chkOutput[61] = chkOutput61;
            chkOutput[62] = chkOutput62;
            chkOutput[63] = chkOutput63;
        }

        ushort Value;
        uint DeviceType, IdentityObject;
        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0;
            timer1.Enabled = false;

            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            btnFindSlave.Enabled = false;
            txtSlaveNum.Text = "0";
            CmbCardNo.Items.Clear();
            cmbNodeID.Items.Clear();
            chkErrorHandle.Enabled = false;
            chkActive.Enabled = false;

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

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc =CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

           CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        ushort[] input_value = new ushort[2] { 0, 0 };
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i,j;
            ushort SlotID = 0,  lMask, output_value = 0, output_value2 = 0,input_value1=0;
            nodeid = ushort.Parse(cmbNodeID.Text);

            if (chkTimer.Checked)
            {
                if ((gPTNodeNum > 0) & (gNTNodeNum == 0) & (gMNNodeNum == 0))                         //32PT
                    {
                        for (i = 0; i < gPTNodeNum; i++)
                        {
                            for (j = 0; j < 32; j++) txtInput[j].Text = " ";

                            /* 32PT Port0 */
                            rc =CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 0, ref input_value1);
                            lMask = 0x1;
                            for (j = 15; j >= 0; j--)
                            {
                                if(input_value1>=System.Math.Pow(2,j))
                                {
                                    txtInput[j].Text="1";
                                    input_value1=(ushort)(input_value1-System.Math.Pow(2,j));
                                }
                                else
                                    txtInput[j].Text="0";
                            }
                            /* 32PT Port1 */
                            for (i = 0; i < 16; i++)
                            {
                                if (chkOutput[i].Checked)
                                {
                                    output_value2 = (ushort)(output_value2 + System.Math.Pow(2, i));
                                }
                            }
                            rc =CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 1, output_value2);
                        }
                    }
                else if ((gPTNodeNum == 0) & (gNTNodeNum > 0) & (gMNNodeNum > 0))                     //16MN/NT
                {
                    rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 0, ref input_value1);
                    if (rc == 0)
                    {
                        for (j = 15; j >= 0; j--)
                        {
                            if (input_value1 >= System.Math.Pow(2, j))
                            {
                                txtInput[j].Text = "1";
                                input_value1 = (ushort)(input_value1 - System.Math.Pow(2, j));
                            }
                            else
                                txtInput[j].Text = "0";
                        }
                    }
                    rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 1, ref input_value1);
                    if (rc == 0)
                    {
                        for (j = 31; j >= 16; j--)
                        {
                            if (input_value1 >= System.Math.Pow(2, j-16))
                            {
                                txtInput[j].Text = "1";
                                input_value1 = (ushort)(input_value1 - System.Math.Pow(2, j-16));
                            }
                            else
                                txtInput[j].Text = "0";
                        }
                    }
                    rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 2, ref input_value1);
                    if (rc == 0)
                    {
                        for (j = 47; j >= 32; j--)
                        {
                            if (input_value1 >= System.Math.Pow(2, j-32))
                            {
                                txtInput[j].Text = "1";
                                input_value1 = (ushort)(input_value1 - System.Math.Pow(2, j-32));
                            }
                            else
                                txtInput[j].Text = "0";
                        }
                    }
                    rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 3, ref input_value1);
                    if (rc == 0)
                    {
                        for (j = 63; j >= 48; j--)
                        {
                            if (input_value1 >= System.Math.Pow(2, j-48))
                            {
                                txtInput[j].Text = "1";
                                input_value1 = (ushort)(input_value1 - System.Math.Pow(2, j-48));
                            }
                            else
                                txtInput[j].Text = "0";
                        }
                    }
                    
                    //
                    output_value2 = 0;
                    for (i = 0; i <= 15; i++)
                    {
                        if (chkOutput[i].Checked)
                            output_value2 = (ushort)(output_value2 + System.Math.Pow(2, i));
                    }
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 0, output_value2);

                    output_value2 = 0;
                    for (i = 16; i <= 31; i++)
                    {
                        if (chkOutput[i].Checked)
                            output_value2 = (ushort)(output_value2 + System.Math.Pow(2, i-16));
                    }
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 1, output_value2);

                    output_value2 = 0;
                    for (i = 32; i <= 47; i++)
                    {
                        if (chkOutput[i].Checked)
                            output_value2 = (ushort)(output_value2 + System.Math.Pow(2, i-32));
                    }
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 2, output_value2);

                    output_value2 = 0;
                    for (i = 48; i <= 63; i++)
                    {
                        if (chkOutput[i].Checked)
                            output_value2 = (ushort)(output_value2 + System.Math.Pow(2, i-48));
                    }
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 3, output_value2);





                    /*
                    for (i = 0; i < gNTNodeNum; i++)
                    {
                        for (j = 0; j < 32; j++) txtInput[j].Text = " ";

                        rc =CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 0, ref input_value[0]);
                        lMask = 0x1;
                        for (j = 0; j < 16; j++)
                        {
                            txtInput[j].Text = (input_value[0] & lMask).ToString();
                            lMask <<= 1;
                        }

                        rc =CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 1, ref input_value[1]);
                        lMask = 0x1;
                        for (j = 0; j < 16; j++)
                        {
                            txtInput[j + 16].Text = (input_value[1] & lMask).ToString();
                            lMask <<= 1;
                        }

                        txtInputVal.Text = input_value[0].ToString("x8") + Convert.ToString(" - ") + input_value[1].ToString("x8");

                        nodeid = gpNTNode[i];

                        for (i = 0; i < 16; i++)
                        {
                            lMask = (ushort)((chkOutput[i].Checked) ? 1 : 0);
                            lMask <<= i;
                            output_value |= lMask;
                        }
                        rc =CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 0, output_value);
                        for (i = 0; i < 16; i++)
                        {
                            lMask = (ushort)((chkOutput[i + 16].Checked) ? 1 : 0);
                            lMask <<= i;
                            output_value2 |= lMask;
                        }
                        rc =CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 1, output_value2);
                    }*/
                }
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            ushort i, nodeid, SlotID = 0, Enable;
            nodeid = ushort.Parse(cmbNodeID.Text);
            Enable = (ushort)((chkActive.Checked) ? 1 : 0);

            if ((gPTNodeNum > 0 ) & (gNTNodeNum == 0 ) & (gMNNodeNum == 0 ))                         //32PT
                {
               for (i = 0; i < gPTNodeNum; i++)
                    {
                    rc =CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, SlotID, Enable);
                    }
                }
            else if ((gPTNodeNum == 0) & (gNTNodeNum > 0) & (gMNNodeNum > 0))                     //16MN/NT
            {
                for (i = 0; i < gNTNodeNum; i++)
                {
                    rc =CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, SlotID, Enable);
                }
            }
        }

        private void chkErrorHandle_CheckedChanged(object sender, EventArgs e)
        {
            ushort i, SlotID = 0, Value;
            Value = (ushort)((chkErrorHandle.Checked) ? 1 : 0);

            if ((gPTNodeNum > 0) & (gNTNodeNum == 0) & (gMNNodeNum == 0))                         //32PT
                {
                for (i = 0; i < gPTNodeNum; i++)
                    {
                    rc =CPCI_DMC.CS_DMC_01_set_rm_output_value_error_handle(gCardNo, nodeid, SlotID, 1, Value);
                    }
                }
            else if ((gPTNodeNum == 0) & (gNTNodeNum > 0) & (gMNNodeNum > 0))                    //16MN/NT
                {
                for (i = 0; i < gNTNodeNum; i++)
                    {
                    rc =CPCI_DMC.CS_DMC_01_set_rm_output_value_error_handle(gCardNo, nodeid, SlotID, 0, Value);
                    rc =CPCI_DMC.CS_DMC_01_set_rm_output_value_error_handle(gCardNo, nodeid, SlotID, 1, Value);
                    }
                }

        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);
        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1, SlotID = 0, errhandle = 0;
            ushort cmd=0,COBID=0,Datatype=0;
            ushort[] value=new ushort[4];
            ushort[] vu=new ushort[4];
            int j,k;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            chkErrorHandle.Enabled = false;
            chkActive.Enabled = false;

            for (i = 0; i <= 63; i++)               //Initialization
            {
                chkOutput[i].Enabled = false;
                chkOutput[i].Checked = false;
                txtInput[i].Enabled = false;
                txtInput[i].Text = "";
            }

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

                        //Find device type
                        rc =CPCI_DMC.CS_DMC_01_get_devicetype(gCardNo, NodeID[gNodeNum], SlotID, ref DeviceType, ref IdentityObject);
                        switch (DeviceType)
                        {
                            case 0x04130191:	//RM-32PT
                                for (j = 0; j <= 15; j++)
                                {
                                    chkOutput[j].Enabled = true;
                                    txtInput[j].Enabled = true;
                                }
                                for (j = 16; j <= 63; j++)
                                {
                                    chkOutput[j].Enabled = false;
                                    txtInput[j].Enabled = false;
                                }
                                gPTNodeNum++;
                                nodeid = (ushort)(i + 1);
                                cmbNodeID.Items.Add(i + 1);
                                groupBox1.Text = "ASD-DMC-RM32PT(MN)";
                                groupBox2.Text = "ASD-DMC-RM32PT(NT)";
                                rc = CPCI_DMC.CS_DMC_01_get_rm_output_value_error_handle(gCardNo, (ushort)(i+1), SlotID, 1, ref errhandle);
                                if (errhandle == 1)
                                {
                                    chkErrorHandle.Checked = true;
                                    rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 1, ref Value);
                                    for (j = 15; j >= 0; j--)
                                    {
                                        if (Value >= System.Math.Pow(2, j))
                                        {
                                            Value = (ushort)(Value - System.Math.Pow(2, j));
                                            chkOutput[j].Checked = true;
                                        }
                                    }
                                }
                                else
                                {
                                    chkErrorHandle.Checked = false;
                                    for (j = 15; j >= 0; j--)
                                        chkOutput[j].Checked = false;
                                }
                                break;
                            case 0x8230191:     //GE16MN/NT
                                rc = CPCI_DMC.CS_DMC_01_send_message(gCardNo, (ushort)(i + 1), SlotID, 0x623F, 0, 0x40, 0, 0, 0, 0);
                                rc = CPCI_DMC.CS_DMC_01_get_message(gCardNo, (ushort)(i + 1), SlotID, 0x623F, 0, ref cmd, ref COBID, ref Datatype, ref value[0], ref value[1], ref value[2], ref value[3]);
                                rc = CPCI_DMC.CS_DMC_01_send_message(gCardNo,(ushort)( i + 1), SlotID, 0x623D, 0, 0x40, 0, 0, 0, 0);
                                rc = CPCI_DMC.CS_DMC_01_get_message(gCardNo, (ushort)(i + 1), SlotID, 0x623D, 0, ref cmd, ref COBID, ref Datatype, ref vu[0], ref vu[1], ref vu[2],ref vu[3]);
                                gNTNodeNum = vu[0];
                                gMNNodeNum = vu[2];
                                for (j = 1; j <= (gNTNodeNum*16); j++)
                                {
                                    chkOutput[j-1].Enabled = true;
                                }
                                for (j = 1; j <= (gMNNodeNum*16); j++)
                                {
                                    txtInput[j-1].Enabled = true;
                                }

                                nodeid = (ushort)(i + 1);
                                cmbNodeID.Items.Add(i + 1);
                                groupBox1.Text = "ASD-DMC-GE16PT(MN)";
                                groupBox2.Text = "ASD-DMC-GE16PT(NT)";
                                rc = CPCI_DMC.CS_DMC_01_get_rm_output_value_error_handle(gCardNo, (ushort)(i + 1), SlotID, 0, ref errhandle);
                                if (errhandle == 1)
                                {
                                    chkErrorHandle.Checked = true;
                                    if (gNTNodeNum > 0)
                                    {
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 0, ref Value);
                                        for (j = 15; j >= 0; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j));
                                                chkOutput[j].Checked = true;
                                            }
                                        }
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 1, ref Value);
                                        for (j = 31; j >= 16; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j-16))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j-16));
                                                chkOutput[j].Checked = true;
                                            }
                                        }
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 2, ref Value);
                                        for (j = 47; j >= 32; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j-32))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j-32));
                                                chkOutput[j].Checked = true;
                                            }
                                        }
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 3, ref Value);
                                        for (j = 63; j >= 48; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j-48))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j-48));
                                                chkOutput[j].Checked = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    chkErrorHandle.Checked = false;
                                    for (j = 63; j >= 0; j--)
                                        chkOutput[j].Checked = false;
                                }
                                break;
                            default:
                                break;
                        }
                        gNodeNum++;
                    }
                    lMask <<= 1;
                }
                if ((gPTNodeNum == 0) && (gMNNodeNum == 0) && (gNTNodeNum == 0))
                    MessageBox.Show("No RM32PT or GE16MN/NT found!");
                else
                {
                    cmbNodeID.SelectedIndex = 0;
                    txtSlaveNum.Text = gNodeNum.ToString();
                    timer1.Enabled = true;
                    chkErrorHandle.Enabled = true;
                    chkActive.Enabled = true;
                    chkActive.Checked = false;
                    chkTimer.Checked = false;
                }
            }
        }
    }
}
