using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using PCI_DMC;
using PCI_DMC_ERR;

namespace DMC_NET
{
    public partial class Form1 : Form
    {
        short existcard = 0, rc;
        ushort gCardNo = 0, DeviceInfo = 0, nodeid = 0, nodeid_idx = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        ushort[] gpu16_04pi_mode = { 0, 0, 0, 0 }, gpu16_04pi_polarity = { 0, 0, 0, 0 }, gpu16_SVON = { 0, 0, 0, 0 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chktimer.Enabled = false;
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
            cmbnode.Items.Clear();

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
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            nodeid = NodeID[nodeid_idx]; ;
            gpu16_SVON[nodeid_idx] = (ushort)(chksvon.Checked ? 1 : 0);

            /* A2F Servo Power ON/Power OFF */
            rc =CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, gpu16_SVON[nodeid_idx]);
        }

        private void btnralm_Click(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            nodeid = NodeID[nodeid_idx];

            rc =CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 0);
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            nodeid = NodeID[nodeid_idx];

            rc =CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            nodeid = NodeID[nodeid_idx];

           CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
           CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++) rc =CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);

           CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        uint u32_val;
        private void timer1_Tick(object sender, EventArgs e)
        {

            //Motion status
            int cmd = 0, pos = 0, spd = 0;
            ushort MC_done = 0;
            uint MC_status = 0, err = 0 ; 

            if (chktimer.Checked)
            {
                nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
                nodeid = NodeID[nodeid_idx];

                //Status
                rc =CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid, 0, ref cmd);             //Command
                if (rc == 0)
                {
                    txtcommand.Text = cmd.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid, 0, ref pos);            //Feedback
                if (rc == 0)
                {
                    txtfeedback.Text = pos.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, 0, ref spd);       //Speed
                if (rc == 0)
                {
                    txtspeed.Text = spd.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);         //Motion done
                if (rc == 0)
                {
                    txtmotion.Text = MC_done.ToString();
                }
                rc =CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid, 0, ref MC_status);     //Motion status
                if (rc == 0)
                {
                    txtIO.Text = MC_status.ToString("X2");
                }
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid, 0, ref err);          //Error
                if (rc == 0)
                {
                    txtERR.Text = err.ToString("X");
                }
                //Get Servo DI status
                rc =CPCI_DMC.CS_DMC_01_set_monitor(gCardNo, nodeid, 0, 39); //Read DI
                Thread.Sleep(20);
                rc =CPCI_DMC.CS_DMC_01_get_monitor(gCardNo, nodeid, 0, ref u32_val);
                //QZ
                txtIOsts0.BackColor = ((u32_val & 0x0004) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                //MEL
                txtIOsts1.BackColor = ((u32_val & 0x0040) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                //PEL
                txtIOsts2.BackColor = ((u32_val & 0x0020) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                //ORG
                txtIOsts3.BackColor = ((u32_val & 0x0010) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                //SLD
                txtIOsts4.BackColor = ((u32_val & 0x0008) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                //DI1
                txtIOsts5.BackColor = ((u32_val & 0x0001) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                //DI2
                txtIOsts6.BackColor = ((u32_val & 0x0002) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;

                //DO Status
                rc =CPCI_DMC.CS_DMC_01_set_monitor(gCardNo, nodeid, 0, 40); //Read DO
                Thread.Sleep(20);
                rc =CPCI_DMC.CS_DMC_01_get_monitor(gCardNo, nodeid, 0, ref u32_val);
                txtDO1.BackColor = ((u32_val & 0x0001) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
                txtDO2.BackColor = ((u32_val & 0x0002) != 0) ? System.Drawing.Color.Lime : System.Drawing.Color.DarkRed;
            }
        }

        private void btnPmove_Click(object sender, EventArgs e)
        {
            int m_StrVel = Int32.Parse(txtStrVel.Text), m_MaxVel = Int32.Parse(txtMaxVel.Text);
            double m_Tacc = Double.Parse(txtTAcc.Text), m_Tdec = Double.Parse(txtTDec.Text);
            int m_Dist = Int32.Parse(txtdist.Text);

            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            nodeid = NodeID[nodeid_idx];

            if (chkSCurve.Checked)
            {
                if (chkAbs.Checked)
                    rc =CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
                else
                    rc =CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
            }
            else
            {
                if (chkAbs.Checked)
                    rc =CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
                else
                    rc =CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
            }
            
        }

        private void btnNmove_Click(object sender, EventArgs e)
        {
            int m_StrVel = Int32.Parse(txtStrVel.Text), m_MaxVel = Int32.Parse(txtMaxVel.Text);
            double m_Tacc = Double.Parse(txtTAcc.Text), m_Tdec = Double.Parse(txtTDec.Text);
            int m_Dist = Int32.Parse(txtdist.Text);

            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            nodeid = NodeID[nodeid_idx];

            if (chkSCurve.Checked)
            {
                if (chkAbs.Checked)
                    rc =CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
                else
                    rc =CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
            }
            else
            {
                if (chkAbs.Checked)
                    rc =CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
                else
                    rc =CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
            }
        }

        uint DeviceType, IdentityObject;
        private void btnSet_Click(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            nodeid = NodeID[nodeid_idx];
            
            rc =CPCI_DMC.CS_DMC_01_get_devicetype(gCardNo, nodeid, 0, ref DeviceType, ref IdentityObject);

            switch (DeviceType)
            {
                case 0x14100191:
                case 0x1C100191:
                    if(radAB.Checked)
                        rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 0);
                    else if(radCW.Checked)
                        rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 1);
                    else if(radPDL.Checked)
                        rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 2);
                    else if(radPDH.Checked)
                        rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 3);

                    rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 0, gpu16_04pi_polarity[nodeid_idx]);
                    break;

                default:
                    break;
            }
        }

        private void radAB_CheckedChanged(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            gpu16_04pi_mode[nodeid_idx] = 0;
        }

        private void radCW_CheckedChanged(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            gpu16_04pi_mode[nodeid_idx] = 1;
        }

        private void radHigh_CheckedChanged(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            gpu16_04pi_polarity[nodeid_idx] = 0;
        }

        private void radLow_CheckedChanged(object sender, EventArgs e)
        {
            nodeid_idx = Convert.ToUInt16(cmbnode.SelectedIndex);
            gpu16_04pi_polarity[nodeid_idx] = 1;
        }

        private void chkDO2_CheckedChanged(object sender, EventArgs e)
        {
            ushort servo_DO = (ushort)(chkDO2.Checked ? 1 : 0);

            rc =CPCI_DMC.CS_DMC_01_send_message(gCardNo, nodeid, 0, 0x620E, 0, 0x2F, servo_DO, 0, 0, 0);
        }

        private void cmbnode_SelectedIndexChanged(object sender, EventArgs e)
        {
            chktimer.Enabled = true;
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0;
            uint DeviceType = 0, IdentityObject = 0;

            gNodeNum = 0;               
            txtSlaveNum.Text = "0";     
            cmbnode.Items.Clear();      
            timer1.Enabled = false;     

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
                                case 0x14100191:			//Remote Module 04PI
                                    cmbnode.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                {
                    MessageBox.Show("No 04PI Mode 2 Found!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbnode.Enabled = true;
                    cmbnode.SelectedIndex = 0;

                    timer1.Enabled = true;
                }
            }
        }

        private void chkMEL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMEL.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 0, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 0, 0);
        }

        private void chkPEL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPEL.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 0, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 0, 0);
        }
    }
}
