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
        ushort gCardNo = 0, DeviceInfo = 0, nodeid = 0,SlotID=0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        ushort gPorts = 0;
        bool gIsServoOn;
        CheckBox[] chkOutput = new CheckBox[64];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkOutput[0] = checkBox1;
            chkOutput[1] = checkBox2;
            chkOutput[2] = checkBox3;
            chkOutput[3] = checkBox4;
            chkOutput[4] = checkBox5;
            chkOutput[5] = checkBox6;
            chkOutput[6] = checkBox7;
            chkOutput[7] = checkBox8;
            chkOutput[8] = checkBox9;
            chkOutput[9] = checkBox10;
            chkOutput[10] = checkBox11;
            chkOutput[11] = checkBox12;
            chkOutput[12] = checkBox13;
            chkOutput[13] = checkBox14;
            chkOutput[14] = checkBox15;
            chkOutput[15] = checkBox16;
            chkOutput[16] = checkBox17;
            chkOutput[17] = checkBox18;
            chkOutput[18] = checkBox19;
            chkOutput[19] = checkBox20;
            chkOutput[20] = checkBox21;
            chkOutput[21] = checkBox22;
            chkOutput[22] = checkBox23;
            chkOutput[23] = checkBox24;
            chkOutput[24] = checkBox25;
            chkOutput[25] = checkBox26;
            chkOutput[26] = checkBox27;
            chkOutput[27] = checkBox28;
            chkOutput[28] = checkBox29;
            chkOutput[29] = checkBox30;
            chkOutput[30] = checkBox31;
            chkOutput[31] = checkBox32;
            chkOutput[32] = checkBox33;
            chkOutput[33] = checkBox34;
            chkOutput[34] = checkBox35;
            chkOutput[35] = checkBox36;
            chkOutput[36] = checkBox37;
            chkOutput[37] = checkBox38;
            chkOutput[38] = checkBox39;
            chkOutput[39] = checkBox40;
            chkOutput[40] = checkBox41;
            chkOutput[41] = checkBox42;
            chkOutput[42] = checkBox43;
            chkOutput[43] = checkBox44;
            chkOutput[44] = checkBox45;
            chkOutput[45] = checkBox46;
            chkOutput[46] = checkBox47;
            chkOutput[47] = checkBox48;
            chkOutput[48] = checkBox49;
            chkOutput[49] = checkBox50;
            chkOutput[50] = checkBox51;
            chkOutput[51] = checkBox52;
            chkOutput[52] = checkBox53;
            chkOutput[53] = checkBox54;
            chkOutput[54] = checkBox55;
            chkOutput[55] = checkBox56;
            chkOutput[56] = checkBox57;
            chkOutput[57] = checkBox58;
            chkOutput[58] = checkBox59;
            chkOutput[59] = checkBox60;
            chkOutput[60] = checkBox61;
            chkOutput[61] = checkBox62;
            chkOutput[62] = checkBox63;
            chkOutput[63] = checkBox64;
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0;

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
            ushort i = 0;
            ushort output_value=0;
            //32NT
            output_value=0;
            for (i = 0; i <= 15; i++)
            {
                if (chkOutput[i].Checked)
                    output_value = (ushort)(output_value + System.Math.Pow(2, i));
                rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 0, output_value);
            }
            output_value = 0;
            for (i = 16; i <= 31; i++)
            {
                if (chkOutput[i].Checked)
                    output_value = (ushort)(output_value + System.Math.Pow(2, i-16));
                rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 1, output_value);
            }
            if (gPorts == 4)        //64NT
            {
                output_value=0;
                for (i = 32; i <= 47; i++)
                {
                    if (chkOutput[i].Checked)
                        output_value = (ushort)(output_value + System.Math.Pow(2, i-32));
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 2, output_value);
                }
                output_value=0;
                for (i = 48; i <= 63; i++)
                {
                    if (chkOutput[i].Checked)
                        output_value = (ushort)(output_value + System.Math.Pow(2, i-48));
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value(gCardNo, nodeid, SlotID, 3, output_value);
                }
            }            
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);
        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0,Value=0,errhandle=0;
            uint DeviceType = 0, IdentityObject = 0;
            int j = 0;

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
                        rc = CPCI_DMC.CS_DMC_01_get_devicetype(gCardNo, (ushort)(i + 1), (ushort)0, ref DeviceType, ref IdentityObject);
                        if (rc != 0)
                        {
                            MessageBox.Show("get_devicetype failed - code=" + rc);
                        }
                        else
                        {
                            switch (DeviceType)
                            {
                                case 0x8120191:				//64NT
                                    for (j = 0; j <= 63; j++)
                                        chkOutput[j].Enabled = true;
                                    frmNT.Text = "ASD-DMC-RM64NT";
                                    gPorts = 4;
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    rc = CPCI_DMC.CS_DMC_01_get_rm_output_value_error_handle(gCardNo, (ushort)(i + 1), SlotID, 0, ref errhandle);
                                    if (errhandle == 1)
                                    {
                                        chkErrorHandle.Checked = true;

                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 0, ref Value);
                                        for (j = 16; j >0;j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j));
                                                chkOutput[j-1].Checked = true;
                                            }
                                            else
                                                chkOutput[j-1].Checked = false;
                                        }
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 1, ref Value);
                                        for (j = 32; j > 16; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j-16))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j-16));
                                                chkOutput[j-1].Checked = true;
                                            }
                                            else
                                                chkOutput[j-1].Checked = false;
                                        }
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 2, ref Value);
                                        for (j = 48; j > 32; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j-32))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j-32));
                                                chkOutput[j-1].Checked = true;
                                            }
                                            else
                                                chkOutput[j-1].Checked = false;
                                        }
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 3, ref Value);
                                        for (j = 64; j > 48; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j-48))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j-48));
                                                chkOutput[j-1].Checked = true;
                                            }
                                            else
                                                chkOutput[j-1].Checked = false;
                                        }
                                    }
                                    else
                                    {
                                        chkErrorHandle.Checked = false;
                                        for (i = 0; i <= 63; i++)
                                            chkOutput[i].Checked = false;
                                    }
                                    break;
                                case 0x4120191: 			//32NT
                                    for (j = 0; j <= 31; j++)
                                        chkOutput[j].Enabled = true;
                                    for (j = 32; j <= 63; j++)
                                        chkOutput[j].Enabled = false;
                                    frmNT.Text = "ASD-DMC-RM32NT";
                                    gPorts = 2;
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    rc = CPCI_DMC.CS_DMC_01_get_rm_output_value_error_handle(gCardNo, (ushort)(i + 1), SlotID, 0, ref errhandle);
                                    if (errhandle == 1)
                                    {
                                        chkErrorHandle.Checked = true;

                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 0, ref Value);
                                        for (j = 16; j > 0; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j-1))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j-1));
                                                chkOutput[j-1].Checked = true;
                                            }
                                            else
                                                chkOutput[j-1].Checked = false;
                                        }
                                        rc = CPCI_DMC.CS_DMC_01_get_rm_output_value(gCardNo, (ushort)(i + 1), SlotID, 1, ref Value);
                                        for (j = 32; j > 16; j--)
                                        {
                                            if (Value >= System.Math.Pow(2, j - 17))
                                            {
                                                Value = (ushort)(Value - System.Math.Pow(2, j - 17));
                                                chkOutput[j-1].Checked = true;
                                            }
                                            else
                                                chkOutput[j-1].Checked = false;
                                        }
                                    }
                                    else
                                    {
                                        chkErrorHandle.Checked = false;
                                        for (i = 0; i <= 31; i++)
                                            chkOutput[i].Checked = false;
                                    }
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                {
                    MessageBox.Show("No 32/64 NT Device found!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    nodeid = ushort.Parse(cmbNodeID.Text);
                    chkActive.Checked = false;
                }
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked)
                rc = CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, SlotID, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_set_rm_output_active(gCardNo, nodeid, SlotID, 0);
        }

        private void chkErrorHandle_CheckedChanged(object sender, EventArgs e)
        {
            ushort i=0;
            if (chkErrorHandle.Checked)
            {
                for (i = 0; i < gPorts; i++)
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value_error_handle(gCardNo, nodeid, SlotID, i, 1);
            }
            else
                for (i = 0; i < gPorts; i++)
                    rc = CPCI_DMC.CS_DMC_01_set_rm_output_value_error_handle(gCardNo, nodeid, SlotID, i, 0);
        }
    }
}
