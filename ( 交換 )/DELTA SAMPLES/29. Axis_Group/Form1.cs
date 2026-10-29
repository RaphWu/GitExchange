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
        ushort gCardNo = 0, DeviceInfo = 0, nodeid = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        ushort[] gpNodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        bool gIsServoOn;
        CheckBox[] chkNode = new CheckBox[12];
        ushort[] Slot = new ushort[12];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            for(i=0;i<32;i++)
                gpNodeID[i] = 0;
            chkNode[0] = checkBox1;
            chkNode[1] = checkBox2;
            chkNode[2] = checkBox3;
            chkNode[3] = checkBox4;
            chkNode[4] = checkBox5;
            chkNode[5] = checkBox6;
            chkNode[6] = checkBox7;
            chkNode[7] = checkBox8;
            chkNode[8] = checkBox9;
            chkNode[9] = checkBox10;
            chkNode[10] = checkBox11;
            chkNode[11] = checkBox12;         
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
            for (i = 0; i < existcard; i++) rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

            CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,j=0;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";

            for (i = 0; i < 1; i++) NodeID[i] = 0;

            if (SlaveTable[0] == 0)
                MessageBox.Show("CardNo: " + gCardNo.ToString() + " No slave found!");      
            else
            {
                j = 0;
                for (i = 0; i < 32; i++)
                {
                    if ((SlaveTable[0] & lMask) != 0)
                    {
                        NodeID[gNodeNum] = (ushort)(i + 1);
                        chkNode[i].Enabled = true;
                        gNodeNum++;
                        gpNodeID[j] = (ushort)(i + 1);
                        j++;
                    }
                    lMask <<= 1;
                }
                txtSlaveNum.Text = gNodeNum.ToString();
                for (i = 0; i < 12; i++)
                {
                    chkNode[i].Checked = false;
                    Slot[i] = 0;
                }
            }
        }

        private void cmdSetGroup_Click(object sender, EventArgs e)
        {
            ushort GNum = 0,i=0;
            ushort[] Node = new ushort[12];
            
            for (i = 0; i < 12; i++)
            {
                if (chkNode[i].Checked)
                {
                    Node[GNum] = (ushort)(i + 1);
                    GNum++;
                    chkNode[i].Checked = false;
                }
            }

            if (GNum > 0)
                rc = CPCI_DMC.CS_DMC_01_set_group(gCardNo, ref Node[0], ref Slot[0], GNum, 1);

            if ((rc != 0) && (rc == 36))
                MessageBox.Show("Set Group Number More than Six");
            else if (rc != 0)
                MessageBox.Show("Error");
            else
            {
                for (i = 0; i < GNum; i++)
                {
                    chkNode[Node[i]-1].Enabled = false;
                }
            }

            for (i = 0; i < 12; i++)
                chkNode[i].Checked = false;
        }

        private void cmdClearGroup_Click(object sender, EventArgs e)
        {
            int i = 0;
            rc = CPCI_DMC.CS_DMC_01_set_group(gCardNo, ref NodeID[0],ref Slot[0] , 1, 0);
            for (i = 0; i < gNodeNum; i++)
            {
                chkNode[gpNodeID[i] - 1].Enabled = true;
            }
        }
    }
}
