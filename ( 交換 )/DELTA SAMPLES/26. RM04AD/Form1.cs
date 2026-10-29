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
        byte[] value = new byte[10];
        ushort gNodeNum;
        bool gIsServoOn;
        
        ushort ADChannel = 0;
        ushort ADMode = 0;
        double ADTransData = 0;
        double[] ModeLength = new double[16];
        double[] ModeOri = new double[6];
        ushort TCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModeLength[0] = 20;
            ModeLength[1] = 10;
            ModeLength[2] = 10;
            ModeLength[3] = 5;
            ModeLength[4] = 0;
            ModeLength[5] = 5;
            ModeOri[0] = -10;
            ModeOri[1] = 0;
            ModeOri[2] = -5;
            ModeOri[3] = 0;
            ModeOri[4] = 0;
            ModeOri[5] = 0;         
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
            ushort ADdata=0,value = 0;
            if (timer1.Enabled)
                nodeid = ushort.Parse(cmbNodeID.Text);

            rc = CPCI_DMC.CS_DMC_01_get_04ad_data(gCardNo, nodeid, 0, ADChannel, ref value);
            if (value < 0)
            {
                ADdata = value;
                ADdata = (ushort)(ADdata + 65536);
            }
            else
                ADdata = value;

            if (ADMode == 5)
                ADTransData = ADdata * ModeLength[ADMode] * 4;
            else
                ADTransData = ADdata * ModeLength[ADMode];

            ADTransData = ADTransData / 65536;
            ADTransData = ModeOri[ADMode] + ADTransData;

            if (TCount % 20 == 0)
                txtData.Text = ADTransData.ToString();
            TCount++;
            if (TCount == 241)
                TCount = 1;
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
                                case 0x8140191:				//RM04AD
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                {
                    MessageBox.Show("RM04AD required!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    cmbConversion.SelectedIndex = 3;
                    cmbChannel.SelectedIndex = 0;
                    cmbMode.SelectedIndex = 0;
                    cmbAverage.SelectedIndex = 0;
                }
            }
        }

        private void cmbConversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ushort mode;
            nodeid = ushort.Parse(cmbNodeID.Text);
            mode=(ushort)cmbConversion.SelectedIndex;
            rc=CPCI_DMC.CS_DMC_01_set_04ad_conversion_time(gCardNo,nodeid,0,mode);
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
            ushort range = 0;
            ushort mode = 0;
            timer1.Enabled = false;
            ADChannel = (ushort)cmbChannel.SelectedIndex;
            rc = CPCI_DMC.CS_DMC_01_set_04ad_input_enable(gCardNo, nodeid, 0, ADChannel, 1);
            rc = CPCI_DMC.CS_DMC_01_get_04ad_input_range(gCardNo, nodeid, 0, ADChannel, ref range);
            cmbMode.SelectedIndex = range;
            if (range == 5)
                lblUnit.Text = "mA";
            else
                lblUnit.Text = "V";
            rc = CPCI_DMC.CS_DMC_01_set_04ad_input_range(gCardNo, nodeid, 0, ADChannel, range);
            timer1.Enabled = true;
            rc = CPCI_DMC.CS_DMC_01_get_04ad_average_mode(gCardNo, nodeid, 0, ADChannel, ref mode);
            cmbAverage.SelectedIndex = mode;
            rc = CPCI_DMC.CS_DMC_01_get_04ad_conversion_time(gCardNo, nodeid, 0, ref mode);
            cmbConversion.SelectedIndex = mode;

            switch (ADChannel)
            {
                case 0:
                    frm04AD.Text = "RM04AD Channel 0 Status";
                    break;
                case 1:
                    frm04AD.Text = "RM04AD Channel 1 Status";
                    break;
                case 2:
                    frm04AD.Text = "RM04AD Channel 2 Status";
                    break;
                case 3:
                    frm04AD.Text = "RM04AD Channel 3 Status";
                    break;
            }
            timer1.Enabled = true;
        }

        private void cmbAverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ushort mode;
            timer1.Enabled = false;
            mode = (ushort)cmbAverage.SelectedIndex;
            rc = CPCI_DMC.CS_DMC_01_set_04ad_average_mode(gCardNo, nodeid, 0, ADChannel, mode);
            timer1.Enabled = true;
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ADMode = (ushort)cmbMode.SelectedIndex;
            if (ADMode == 5)
                lblUnit.Text = "mA";
            else
                lblUnit.Text = "V";

            rc=CPCI_DMC.CS_DMC_01_set_04ad_input_range(gCardNo,nodeid,0,ADChannel,ADMode);

            timer1.Enabled = true;
        }
    }
}
