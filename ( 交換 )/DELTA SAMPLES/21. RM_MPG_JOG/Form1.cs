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
        ushort gCardNo = 0, DeviceInfo = 0, gnodeid = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        ushort[] gpServoNode = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum = 0, gServoNum = 0;
        bool gIsServoOn;
        TextBox[] txtIoSts = new TextBox[16];

        public Form1()
        {
            InitializeComponent();
        }

        public class cboDataList
        {
            public string cbo_Name { get; set; }
            public string cbo_Value { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtIoSts[0] = txtStatus0;
            txtIoSts[1] = txtStatus1;
            txtIoSts[2] = txtStatus2;
            txtIoSts[3] = txtStatus3;
            txtIoSts[4] = txtStatus4;
            txtIoSts[5] = txtStatus5;
            txtIoSts[6] = txtStatus6;
            txtIoSts[7] = txtStatus7;
            txtIoSts[8] = txtStatus8;
            txtIoSts[9] = txtStatus9;
            txtIoSts[10] = txtStatus10;
            txtIoSts[11] = txtStatus11;
            txtIoSts[12] = txtStatus12;
            txtIoSts[13] = txtStatus13;
            txtIoSts[14] = txtStatus14;
            txtIoSts[15] = txtStatus15;

            cmbplsratio.SelectedIndex = 1;

            cmbJogMode.SelectedIndex = 0;
        }

        uint DeviceType, IdentityObject;
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
            chkMPG.Enabled = false;
            chkJog.Enabled = false;

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

        private void chksvon_CheckedChanged(object sender, EventArgs e)
        {
            gIsServoOn = chksvon.Checked;
            gnodeid = Convert.ToUInt16(cmbNodeID.SelectedIndex + 1);

            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, gnodeid, 0, 1);
            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, gnodeid, 0, 1);

            rc =CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, gnodeid, 0, (ushort)(gIsServoOn ? 1 : 0));
        }

        private void btnralm_Click(object sender, EventArgs e)
        {
            gnodeid = Convert.ToUInt16(cmbNodeID.SelectedIndex + 1);

            rc =CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, gnodeid, 0);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            gnodeid = Convert.ToUInt16(cmbNodeID.SelectedIndex + 1);

           CPCI_DMC.CS_DMC_01_set_position(gCardNo, gnodeid, 0, 0);
           CPCI_DMC.CS_DMC_01_set_command(gCardNo, gnodeid, 0, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc =CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

           CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        ushort u16_val;
        private void timer1_Tick(object sender, EventArgs e)
        {

            //Motion status
            int i, cmd = 0, pos = 0, spd = 0;
            ushort MC_done = 0, nodeid_idx;
            uint MC_status = 0, err = 0;
         
            if (chktimer.Checked)
            {
                gnodeid = Convert.ToUInt16(cmbNodeID.SelectedIndex+1);
                //Status
                rc =CPCI_DMC.CS_DMC_01_get_command(gCardNo, gnodeid, 0, ref cmd);             //Command
                if (rc == 0)
                {
                    txtcommand.Text = cmd.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_get_position(gCardNo, gnodeid, 0, ref pos);            //Feedback
                if (rc == 0)
                {
                    txtfeedback.Text = pos.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, gnodeid, 0, ref spd);       //Speed
                if (rc == 0)
                {
                    txtspeed.Text = spd.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_motion_done(gCardNo, gnodeid, 0, ref MC_done);         //Motion done
                if (rc == 0)
                {
                    txtmotion.Text = MC_done.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_motion_status(gCardNo, gnodeid, 0, ref MC_status);     //Motion status
                if (rc == 0)
                {
                    txtIO.Text = MC_status.ToString("X2");
                }
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, gnodeid, 0, ref err);         //Error
                if (rc == 0)
                {
                    txtERR.Text = err.ToString("X");
                }
                if (chkMPG.Checked || chkJog.Checked)
                {
                    nodeid_idx = Convert.ToUInt16(cmbNodeID.SelectedIndex + 1);
                    gnodeid = NodeID[nodeid_idx];
                    rc =CPCI_DMC.CS_DMC_01_get_rm_input_value(gCardNo, gnodeid, 0, 3, ref u16_val);
                    for (i = 0; i < 16; i++)
                        txtIoSts[i].BackColor = ((u16_val & (0x1 << i)) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                }
            }
        }

        private void chkMPG_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            uint[] ratio = new uint[4], slop = new uint[4];
            ushort[] SlotID = { 0, 0, 0, 0 };
            ushort MNNodeID = Convert.ToUInt16(cmbMNID.Text);
            ushort pulser_ratio = Convert.ToUInt16((cmbplsratio.SelectedIndex == 0) ? 1 : 4);
            ushort[] den = new ushort[4];

            gnodeid = Convert.ToUInt16(cmbNodeID.SelectedIndex + 1);

            if (chkMPG.Checked && chkJog.Checked)
            {
                chkJog.Checked = false;
                chkJog_CheckedChanged(sender, e);
            }

            for (i = 0; i < 4; i++)
            {
                ratio[i] = UInt32.Parse(txtRatio.Text);
                slop[i] = UInt32.Parse(txtSlope.Text);
                den[i] = ushort.Parse(txtDen.Text);
            }

            rc =CPCI_DMC.CS_DMC_01_set_rm_mpg_axes_enable2(gCardNo, MNNodeID, 0, ref NodeID[0], ref SlotID[0], (ushort)(chkMPG.Checked ? 1 : 0), pulser_ratio, ref ratio[0], ref slop[0],ref den[0]);
        }

        private void chkJog_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            int[] jog_speed = new int[4];
            double[] sec = new double[4];
            ushort[] SlotID = { 0, 0, 0, 0 };
            ushort MNNodeID = Convert.ToUInt16(cmbMNID.Text);
            ushort jog_mode = Convert.ToUInt16(cmbJogMode.SelectedIndex);

            if (chkMPG.Checked && chkJog.Checked)
            {
                chkMPG.Checked = false;
                chkMPG_CheckedChanged(sender, e);
            }

            for (i = 0; i < 4; i++)
            {
                jog_speed[i] = Int32.Parse(txtJogspeed.Text);
                sec[i] = 0.1;
            }

            rc =CPCI_DMC.CS_DMC_01_set_rm_jog_axes_enable(gCardNo, MNNodeID, 0, ref NodeID[0], ref SlotID[0], (ushort)(chkJog.Checked ? 1 : 0), jog_mode, ref jog_speed[0], ref sec[0]);
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0,q=0;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";     
            cmbNodeID.Items.Clear();      
            cmbMNID.Items.Clear();
            chkMPG.Enabled = false;
            chkJog.Enabled = false;

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
                                case 0x14100191:			//Remote Module 04PI
                                    cmbNodeID.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                                case 0x11210191:			//GE01PH
                                    cmbNodeID.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x08110191: //64MN
                                    cmbMNID.Items.Add(i + 1);
                                    q++;
                                    chkMPG.Enabled = true;
                                    break;
                            }
                            gNodeNum++;
                        }
                    }
                    lMask <<= 1;
                }

                if ((p == 0) || (q == 0))
                    MessageBox.Show("Required 1*[64MN] and 1*[A2 Servo/04PI/01PH] at least!");
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();

                    cmbNodeID.Enabled = true;
                    cmbNodeID.SelectedIndex = 0;
                    cmbMNID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    chkMPG.Enabled = true;
                    chkJog.Enabled = true;
                }
            }
        }
    }
}
