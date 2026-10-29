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
        TextBox[] txtInput = new TextBox[64];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtInput[0] = textBox1;
            txtInput[1] = textBox2;
            txtInput[2] = textBox3;
            txtInput[3] = textBox4;
            txtInput[4] = textBox5;
            txtInput[5] = textBox6;
            txtInput[6] = textBox7;
            txtInput[7] = textBox8;
            txtInput[8] = textBox9;
            txtInput[9] = textBox10;
            txtInput[10] = textBox11;
            txtInput[11] = textBox12;
            txtInput[12] = textBox13;
            txtInput[13] = textBox14;
            txtInput[14] = textBox15;
            txtInput[15] = textBox16;
            txtInput[16] = textBox17;
            txtInput[17] = textBox18;
            txtInput[18] = textBox19;
            txtInput[19] = textBox20;
            txtInput[20] = textBox21;
            txtInput[21] = textBox22;
            txtInput[22] = textBox23;
            txtInput[23] = textBox24;
            txtInput[24] = textBox25;
            txtInput[25] = textBox26;
            txtInput[26] = textBox27;
            txtInput[27] = textBox28;
            txtInput[28] = textBox29;
            txtInput[29] = textBox30;
            txtInput[30] = textBox31;
            txtInput[31] = textBox32;
            txtInput[32] = textBox33;
            txtInput[33] = textBox34;
            txtInput[34] = textBox35;
            txtInput[35] = textBox36;
            txtInput[36] = textBox37;
            txtInput[37] = textBox38;
            txtInput[38] = textBox39;
            txtInput[39] = textBox40;
            txtInput[40] = textBox41;
            txtInput[41] = textBox42;
            txtInput[42] = textBox43;
            txtInput[43] = textBox44;
            txtInput[44] = textBox45;
            txtInput[45] = textBox46;
            txtInput[46] = textBox47;
            txtInput[47] = textBox48;
            txtInput[48] = textBox49;
            txtInput[49] = textBox50;
            txtInput[50] = textBox51;
            txtInput[51] = textBox52;
            txtInput[52] = textBox53;
            txtInput[53] = textBox54;
            txtInput[54] = textBox55;
            txtInput[55] = textBox56;
            txtInput[56] = textBox57;
            txtInput[57] = textBox58;
            txtInput[58] = textBox59;
            txtInput[59] = textBox60;
            txtInput[60] = textBox61;
            txtInput[61] = textBox62;
            txtInput[62] = textBox63;
            txtInput[63] = textBox64;
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
            int i=0,j=0;
            ushort input_value=0;
            if (chkTimer.Checked)
            {
                rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 0, ref input_value);
                for (i = 16; i >= 0; i--)
                {
                    if (input_value >= System.Math.Pow(2, i))
                    {
                        input_value = (ushort)(input_value - System.Math.Pow(2, i));
                        txtInput[i].BackColor = Color.Red;
                    }
                    else
                        txtInput[i].BackColor = Control.DefaultBackColor;
                }
                rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 1, ref input_value);
                for (i = 31; i > 15; i--)
                {
                    if (input_value >= System.Math.Pow(2, i-16))
                    {
                        input_value = (ushort)(input_value - System.Math.Pow(2, i-16));
                        txtInput[i].BackColor = Color.Red;
                    }
                    else
                        txtInput[i].BackColor = Control.DefaultBackColor;
                }
                if (gPorts == 4)
                {
                    rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 2, ref input_value);
                    for (i = 47; i > 31; i--)
                    {
                        if (input_value >= System.Math.Pow(2, i - 32))
                        {
                            input_value = (ushort)(input_value - System.Math.Pow(2, i - 32));
                            txtInput[i].BackColor = Color.Red;
                        }
                        else
                            txtInput[i].BackColor = Control.DefaultBackColor;
                    }
                    rc = CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, nodeid, SlotID, 3, ref input_value);
                    for (i = 63; i > 47; i--)
                    {
                        if (input_value >= System.Math.Pow(2, i - 48))
                        {
                            input_value = (ushort)(input_value - System.Math.Pow(2, i - 48));
                            txtInput[i].BackColor = Color.Red;
                        }
                        else
                            txtInput[i].BackColor = Control.DefaultBackColor;
                    }
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
                                case 0x4110191:     //32MN
                                    frmMN.Text = "ASD-DMC-RM32MN";
                                    gPorts = 2;
                                    p++;
                                    cmbNodeID.Items.Add(i + 1);
                                    for (j = 0; j <= 31; j++)
                                        txtInput[j].Enabled = true;
                                    for (j = 32; j <= 63; j++)
                                        txtInput[j].Enabled = false;
                                    break;
                                case 0x8110191:     //64MN
                                    frmMN.Text = "ASD-DMC-RM64MN";
                                    gPorts = 4;
                                    p++;
                                    cmbNodeID.Items.Add(i + 1);
                                    for (j = 0; j <= 63; j++)
                                        txtInput[j].Enabled = true;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                {
                    MessageBox.Show("No 32/64 MN Device found!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    chkTimer.Checked = false;
                    nodeid = ushort.Parse(cmbNodeID.Text);
                }
            }
        }
    }
}
