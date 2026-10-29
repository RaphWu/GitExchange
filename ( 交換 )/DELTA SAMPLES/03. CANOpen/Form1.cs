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
        ushort gCardNo = 0, DeviceInfo = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;

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

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

           CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            ushort m_node = ushort.Parse(cmbNodeID1.Text), m_slot = ushort.Parse(txtslotid.Text);
            ushort m_index = ushort.Parse(txtindex.Text, System.Globalization.NumberStyles.HexNumber), m_subindex = ushort.Parse(txtsubidx.Text);
            ushort m_type = ushort.Parse(txttype.Text, System.Globalization.NumberStyles.HexNumber);
            ushort Value0 = ushort.Parse(txtD0.Text, System.Globalization.NumberStyles.HexNumber), Value1 = ushort.Parse(txtD1.Text, System.Globalization.NumberStyles.HexNumber);
            ushort Value2 = ushort.Parse(txtD2.Text, System.Globalization.NumberStyles.HexNumber), Value3 = ushort.Parse(txtD3.Text, System.Globalization.NumberStyles.HexNumber);
         
            /* Send SDO command */
            rc =CPCI_DMC.CS_DMC_01_send_message(gCardNo, m_node, m_slot, m_index, m_subindex, m_type, Value0, Value1, Value2, Value3);
            if((rc == 0) ? false:true)
                MessageBox.Show("%d", rc.ToString());
        }

        ushort Cmd, COBID, DataType, Value0, Value1, Value2, Value3;
        private void btnread_Click(object sender, EventArgs e)
        {
            /* Read SDO command from module to Card */
            rc =CPCI_DMC.CS_DMC_01_read_message(gCardNo, ref COBID, ref Cmd, ref DataType, ref Value0, ref Value1, ref Value2, ref Value3);

            txtsubidxR.Text = COBID.ToString("X2");
            txtidxR.Text = Cmd.ToString("X2");
            txttypeR.Text = DataType.ToString("X2");
            txtD0R.Text = Value0.ToString("X2");
            txtD1R.Text = Value1.ToString("X2");
            txtD2R.Text = Value2.ToString("X2");
            txtD3R.Text = Value3.ToString("X2"); 
        }

        private void btnget_Click(object sender, EventArgs e)
        {
            ushort m_node = ushort.Parse(cmbNodeID2.Text), m_slot = ushort.Parse(txtslotid2.Text);
            ushort m_index = ushort.Parse(txtindex2.Text, System.Globalization.NumberStyles.HexNumber), m_subindex = ushort.Parse(txtsubidx2.Text);

            /*  Get SDO command from card */
            rc =CPCI_DMC.CS_DMC_01_get_message(gCardNo, m_node, m_slot, m_index, m_subindex, ref COBID, ref Cmd, ref DataType, ref Value0, ref Value1, ref Value2, ref Value3);

            txtsubidxR2.Text = COBID.ToString("X2");
            txtidxR2.Text = Cmd.ToString("X2");
            txttype2.Text = DataType.ToString("X2");

            txtD4.Text = Value0.ToString("X2");
            txtD5.Text = Value1.ToString("X2");
            txtD6.Text = Value2.ToString("X2");
            txtD7.Text = Value3.ToString("X2");
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID1.Items.Clear();
            cmbNodeID2.Items.Clear();

            for (i = 0; i < 4; i++)     
                SlaveTable[i] = 0;

            rc =CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0);                       //Start communication
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
                        NodeID[gNodeNum] = (ushort)(i + 1);
                        gNodeNum++;
                        cmbNodeID1.Items.Add(i + 1);
                        cmbNodeID2.Items.Add(i + 1);
                    }
                    lMask <<= 1;
                }
                if (gNodeNum == 0)
                {
                    MessageBox.Show("No Device Found!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID1.SelectedIndex = 0;
                    cmbNodeID2.SelectedIndex = 0;
                    timer1.Enabled = true;
                }
            }


        }
    }
} 
