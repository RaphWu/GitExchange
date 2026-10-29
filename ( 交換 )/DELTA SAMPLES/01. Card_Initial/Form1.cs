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

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

           CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {

            txtslavenum.Text = "0";
            CmbCardNo.Items.Clear();

            rc =CPCI_DMC.CS_DMC_01_open(ref existcard);

            if (existcard <= 0)
                MessageBox.Show("No DMC-NET card can be found!");
            else
                txtcardnum.Text = existcard.ToString();

            btninitial.Enabled = true;
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, running = 0, card_no = 0;

            txtslavenum.Text = "0";
            CmbCardNo.Items.Clear();

            for (i = 0; i < existcard; i++)
            {
                rc =CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref card_no);
                gCardNoList[i] = card_no;

                CmbCardNo.Items.Insert(i,card_no);

                rc =CPCI_DMC.CS_DMC_01_pci_initial(gCardNoList[i]);
                if (rc != 0)
                    MessageBox.Show("Can't boot PCI_DMC Master Card!");

                rc =CPCI_DMC.CS_DMC_01_initial_bus(gCardNoList[i]);
            }
            if (existcard != 0)
            {
                CmbCardNo.SelectedIndex = 0;
                gCardNo = gCardNoList[0];
            }
            btnfindslave.Enabled = true;
        }

        private void btnfindslave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1;

            gNodeNum = 0;
            txtslavenum.Text = "0";
            for (i = 0; i < 4; i++)
                SlaveTable[i] = 0;

            rc =CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0);                      //Start communication
            rc =CPCI_DMC.CS_DMC_01_get_device_table(gCardNo, ref DeviceInfo);   //Get Slave Node ID   
            rc =CPCI_DMC.CS_DMC_01_get_node_table(gCardNo, ref SlaveTable[0]);

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
                    }
                    lMask <<= 1;
                }
            }
            txtslavenum.Text = gNodeNum.ToString();
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);
        }

    }
}
