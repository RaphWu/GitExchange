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
        uint data;

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
            cmbNodeID.Items.Clear();
            btnread.Enabled = false;
            btnwrite.Enabled = false;

            rc =CPCI_DMC.CS_DMC_01_open(ref existcard);

            if (existcard <= 0)
                MessageBox.Show("No DMC-NET card can be found!");
            else
            {

                for (i = 0; i < existcard; i++)
                {
                    rc =CPCI_DMC.CS_DMC_01_get_CardNo_seq(i, ref card_no);
                    gCardNoList[i] = card_no;

                    CmbCardNo.Items.Insert(i, card_no);     

                }

                btnFindSlave.Enabled = true;        //2011.08.05
                CmbCardNo.SelectedIndex = 0;
                gCardNo = gCardNoList[0];

                for (i = 0; i < existcard; i++)
                {
                    rc =CPCI_DMC.CS_DMC_01_pci_initial(gCardNoList[i]);
                    if (rc != 0)
                        MessageBox.Show("Can't boot PCI_DMC Master Card!");

                    rc =CPCI_DMC.CS_DMC_01_initial_bus(gCardNoList[i]);
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

        private void btnread_Click(object sender, EventArgs e)
        {
            ushort m_nodeid = ushort.Parse(cmbNodeID.Text), m_slotid = ushort.Parse(txtslotid.Text);
            ushort m_group = ushort.Parse(txtgroup.Text), m_index = ushort.Parse(txtindex.Text);

            rc =CPCI_DMC.CS_DMC_01_read_servo_parameter(gCardNo, m_nodeid, m_slotid, m_group, m_index,  ref data);

            txtR.Text = data.ToString();
            txtRrt.Text = rc.ToString();
        }

        private void btnwrite_Click(object sender, EventArgs e)
        {
            ushort m_nodeid = ushort.Parse(cmbNodeID.Text), m_slotid = ushort.Parse(txtslotid.Text);
            ushort m_group = ushort.Parse(txtgroup.Text), m_index = ushort.Parse(txtindex.Text);

            data = UInt32.Parse(txtW.Text);

            rc =CPCI_DMC.CS_DMC_01_write_servo_parameter(gCardNo, m_nodeid, m_slotid, m_group, m_index, data);

            txtWrt.Text = rc.ToString();
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0;
            uint DeviceType=0, IdentityObject=0;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID.Items.Clear();
            btnread.Enabled = false;
            btnwrite.Enabled = false;

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
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x6020192:				//Servo M series
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x8020192:				//Servo A2R series
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x9020192:				//Servo S series
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                    MessageBox.Show("No Servo Found!");
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    btnread.Enabled = true;
                    btnwrite.Enabled = true;
                }
            }
        }
    }
}
