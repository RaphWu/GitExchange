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
        bool gIsSCurve, gIsAbs, gIsServoOn;
        TextBox[] txtIoSts = new TextBox[16];
        ushort PLimit_sts, NLimit_sts;

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

            btnreset.Enabled = false;
            btnstop.Enabled = false;
            btnralm.Enabled = false;
            btnPmove.Enabled = false;
            btnNmove.Enabled = false;
            chktimer.Enabled = false;
            chksvon.Enabled = false;

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

        private void chksvon_CheckedChanged(object sender, EventArgs e)
        {
            gIsServoOn = chksvon.Checked;
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, nodeid, 0, 1);
            rc =CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 1);

            rc =CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, (ushort)(gIsServoOn ? 1 : 0));
        }

        private void btnralm_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 0);
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc =CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

           CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
           CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
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
            if (chktimer.Checked)
            {
                //Motion status
                int cmd = 0, pos = 0, spd = 0;
                ushort i, MC_done = 0,count=0;
                uint MC_status = 0, err = 0;

                nodeid = ushort.Parse(cmbNodeID.Text);
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
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid, 0, ref MC_status);     //Motion status
                if (rc == 0)
                {
                    txtIO.Text = MC_status.ToString("X");
                }
                rc =CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);         //Motion done
                if (rc == 0)
                {
                    txtmotion.Text = MC_done.ToString();
                }
                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid, 0, ref err);
                if (rc == 0)
                {
                    txtERR.Text = err.ToString();
                }
                rc = CPCI_DMC.CS_DMC_01_get_int_count(gCardNo, nodeid, ref count);
                if (rc == 0)
                {
                    txtInt.Text = count.ToString();
                }
            }
        }

        private void btnPmove_Click(object sender, EventArgs e)
        {
            int m_StrVel = Int32.Parse(txtStrVel.Text), m_MaxVel = Int32.Parse(txtMaxVel.Text);
            double m_Tacc = Double.Parse(txtTAcc.Text), m_Tdec = Double.Parse(txtTDec.Text);
            int m_Dist = Int32.Parse(txtdist.Text);

            nodeid = ushort.Parse(cmbNodeID.Text);

            if (gIsSCurve)
            {
                if(gIsAbs)
                    rc =CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
                else
                    rc =CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
            }
            else
            {
                if(gIsAbs)
                    rc =CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
                else
                    rc =CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);  
            }
            
        }

        private void chkSCurve_CheckedChanged(object sender, EventArgs e)
        {
            gIsSCurve = chkSCurve.Checked;
        }

        private void btnNmove_Click(object sender, EventArgs e)
        {
            int m_StrVel = Int32.Parse(txtStrVel.Text), m_MaxVel = Int32.Parse(txtMaxVel.Text);
            double m_Tacc = Double.Parse(txtTAcc.Text), m_Tdec = Double.Parse(txtTDec.Text);
            int m_Dist = Int32.Parse(txtdist.Text);

            nodeid = ushort.Parse(cmbNodeID.Text);

            if (gIsSCurve)
            {
                if (gIsAbs)
                    rc =CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
                else
                    rc =CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
            }
            else
            {
                if (gIsAbs)
                    rc =CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
                else
                    rc =CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, 0-m_Dist, m_StrVel, m_MaxVel, m_Tacc, m_Tdec);
            }
        }

        private void chkAbs_CheckedChanged(object sender, EventArgs e)
        {
            gIsAbs = chkAbs.Checked;
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0;
            uint DeviceType=0, IdentityObject = 0;
            gNodeNum = 0;               
            txtSlaveNum.Text = "0";
            cmbNodeID.Items.Clear();
            btnreset.Enabled = false;
            btnstop.Enabled = false;
            btnralm.Enabled = false;
            btnPmove.Enabled = false;
            btnNmove.Enabled = false;
            chktimer.Enabled = false;
            chksvon.Enabled = false;

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
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p == 0)
                    MessageBox.Show("No A2 Servo/04PI/GE01PH Found!");
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    btnreset.Enabled = true;
                    btnstop.Enabled = true;
                    btnralm.Enabled = true;
                    btnPmove.Enabled = true;
                    btnNmove.Enabled = true;
                    chktimer.Enabled = true;
                    chksvon.Enabled = true;
                }
            }
        }

        private void chkInt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInt.Checked)
            {
                rc = CPCI_DMC.CS_DMC_01_int_enable(gCardNo, nodeid);
                rc = CPCI_DMC.CS_DMC_01_set_int_factor(gCardNo, nodeid, 1);
            }
            else
                rc = CPCI_DMC.CS_DMC_01_int_disable(gCardNo, nodeid);
        }
    }
}
