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
        ushort gCardNo = 0, DeviceInfo = 0, nodeid = 0, SlotID = 0;
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
        ushort PLimit, NLimit;
        ushort gAxis =0;

        TextBox[] txtMotion = new TextBox[24];
        TextBox[] txtIOSts = new TextBox[40];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMotion[0] = txtcommand;
            txtMotion[1] = txtfeedback;
            txtMotion[2] = txtspeed;
            txtMotion[3] = txtIO;
            txtMotion[4] = txtmotion;
            txtMotion[5] = txtERR;
            txtMotion[6] = txtcommand1;
            txtMotion[7] = txtfeedback1;
            txtMotion[8] = txtspeed1;
            txtMotion[9] = txtIO1;
            txtMotion[10] = txtmotion1;
            txtMotion[11] = txtERR1;
            txtMotion[12] = txtcommand2;
            txtMotion[13] = txtfeedback2;
            txtMotion[14] = txtspeed2;
            txtMotion[15] = txtIO2;
            txtMotion[16] = txtmotion2;
            txtMotion[17] = txtERR2;
            txtMotion[18] = txtcommand3;
            txtMotion[19] = txtfeedback3;
            txtMotion[20] = txtspeed3;
            txtMotion[21] = txtIO3;
            txtMotion[22] = txtmotion3;
            txtMotion[23] = txtERR3;

            txtIOSts[0] = txtIOSts0;
            txtIOSts[1] = txtIOSts1;
            txtIOSts[2] = txtIOSts2;
            txtIOSts[3] = txtIOSts3;
            txtIOSts[4] = txtIOSts4;
            txtIOSts[5] = txtIOSts5;
            txtIOSts[6] = txtIOSts6;
            txtIOSts[7] = txtIOSts7;
            txtIOSts[8] = txtIOSts8;
            txtIOSts[9] = txtIOSts9;
            txtIOSts[10] = txtIOSts10;
            txtIOSts[11] = txtIOSts11;
            txtIOSts[12] = txtIOSts12;
            txtIOSts[13] = txtIOSts13;
            txtIOSts[14] = txtIOSts14;
            txtIOSts[15] = txtIOSts15;
            txtIOSts[16] = txtIOSts16;
            txtIOSts[17] = txtIOSts17;
            txtIOSts[18] = txtIOSts18;
            txtIOSts[19] = txtIOSts19;
            txtIOSts[20] = txtIOSts20;
            txtIOSts[21] = txtIOSts21;
            txtIOSts[22] = txtIOSts22;
            txtIOSts[23] = txtIOSts23;
            txtIOSts[24] = txtIOSts24;
            txtIOSts[25] = txtIOSts25;
            txtIOSts[26] = txtIOSts26;
            txtIOSts[27] = txtIOSts27;
            txtIOSts[28] = txtIOSts28;
            txtIOSts[29] = txtIOSts29;
            txtIOSts[30] = txtIOSts30;
            txtIOSts[31] = txtIOSts31;
            txtIOSts[32] = txtIOSts32;
            txtIOSts[33] = txtIOSts33;
            txtIOSts[34] = txtIOSts34;
            txtIOSts[35] = txtIOSts35;
            txtIOSts[36] = txtIOSts36;
            txtIOSts[37] = txtIOSts37;
            txtIOSts[38] = txtIOSts38;
            txtIOSts[39] = txtIOSts39;
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
        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1, p = 0;
            uint DeviceType = 0, IdentityObject = 0;

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
                                case 0x1C100191:			//Remote Module 04PI
                                    cmbNodeID.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }

                if (p == 0)
                    MessageBox.Show("Please use 04PI Mode1");
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;

                    timer1.Enabled = true;
                }
            }
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);
        }

        private void cmbNodeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            ushort i = 0;
            for (i = 0; i < 4; i++)
                rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, i, 0.1);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            ushort i;
            timer1.Enabled = false;
            for (i = 0; i < existcard; i++)
                rc = CPCI_DMC.CS_DMC_01_reset_card(gCardNoList[i]);
            CPCI_DMC.CS_DMC_01_close();
            Application.Exit();
        }

        private void btnPmove_Click(object sender, EventArgs e)
        {
            ushort slot = 0;
            int StrVel = int.Parse(txtStrVel.Text);
            int MaxVel = int.Parse(txtMaxVel.Text);
            double TAcc = double.Parse(txtTAcc.Text);
            double TDec = double.Parse(txtTDec.Text);
            int Dist = int.Parse(txtdist.Text);
            if (chkContinue.Checked)
                if(chkSCurve.Checked)
                    rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_v_move(gCardNo, nodeid, gAxis, StrVel, MaxVel, TAcc, 0, 2);
                else
                    rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_v_move(gCardNo, nodeid, gAxis, StrVel, MaxVel, TAcc, 0, 1);
            else
                if (chkAbs.Checked)
                {
                    if (chkSCurve.Checked)
                        rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo, nodeid, gAxis, Dist, StrVel, MaxVel, TAcc, TDec, 2, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo, nodeid, gAxis, Dist, StrVel, MaxVel, TAcc, TDec, 1, 1);
                }
                else
                {
                    if (chkSCurve.Checked)
                        rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo, nodeid, gAxis, Dist, StrVel, MaxVel, TAcc, TDec, 2, 0);
                    else
                        rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo, nodeid, gAxis, Dist, StrVel, MaxVel, TAcc, TDec, 1, 0);
                }
        }

        private void btnNmove_Click(object sender, EventArgs e)
        {
            ushort slot=0;
            int StrVel=int.Parse(txtStrVel.Text);
            int MaxVel = int.Parse(txtMaxVel.Text);
            double TAcc = double.Parse(txtTAcc.Text);
            double TDec=double.Parse(txtTDec.Text);
            int Dist = 0 - int.Parse(txtdist.Text);
            if (chkContinue.Checked)
                if (chkSCurve.Checked)
                    rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_v_move(gCardNo, nodeid, gAxis, StrVel, MaxVel, TAcc, 1, 2);
                else
                    rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_v_move(gCardNo, nodeid, gAxis, StrVel, MaxVel, TAcc, 1, 1);
            else
                if(chkAbs.Checked)
                {
                    if(chkSCurve.Checked)
                        rc=CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo,nodeid,gAxis,Dist,StrVel,MaxVel,TAcc,TDec,2,1);
                    else
                        rc=CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo,nodeid,gAxis,Dist,StrVel,MaxVel,TAcc,TDec,1,1);
                }
                else
                {
                    if(chkSCurve.Checked)
                        rc=CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo,nodeid,gAxis,Dist,StrVel,MaxVel,TAcc,TDec,2,0);
                    else
                        rc=CPCI_DMC.CS_DMC_01_rm_04pi_md1_start_move(gCardNo,nodeid,gAxis,Dist,StrVel,MaxVel,TAcc,TDec,1,0);
                }
        }

        private void chksvon_CheckedChanged(object sender, EventArgs e)
        {
            ushort chk = 0;
            switch (((CheckBox)(sender)).Name)
            {
                case "chksvon":
                    if (((CheckBox)(sender)).Checked)
                        chk = 1;
                    else
                        chk = 0;
                    CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, chk);
                    break;
                case "chksvon1":
                    if (((CheckBox)(sender)).Checked)
                        chk = 1;
                    else
                        chk = 0;
                    CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 1, chk);
                    break;
                case "chksvon2":
                    if (((CheckBox)(sender)).Checked)
                        chk = 1;
                    else
                        chk = 0;
                    CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 2, chk);
                    break;
                case "chksvon3":
                    if (((CheckBox)(sender)).Checked)
                        chk = 1;
                    else
                        chk = 0;
                    CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 3, chk);
                    break;
            }
        }

        private void btnralm_Click(object sender, EventArgs e)
        {
            switch (((Button)(sender)).Name)
            {
                case "btnralm":
                    CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 0);
                    break;
                case "btnralm1":
                    CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 1);
                    break;
                case "btnralm2":
                    CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 2);
                    break;
                case "btnralm3":
                    CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 3);
                    break;
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            switch (((Button)(sender)).Name)
            {
                case "btnreset":
                    CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0,0);
                    CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
                    break;
                case "btnreset1":
                    CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 1, 0);
                    CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 1, 0);
                    break;
                case "btnreset2":
                    CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 2, 0);
                    CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 2, 0);
                    break;
                case "btnreset3":
                    CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 3, 0);
                    CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 3, 0);
                    break;
            }
        }

        private void chkDO_CheckedChanged(object sender, EventArgs e)
        {
            switch (((CheckBox)(sender)).Name)
            {
                case "chkDO":
                    if (chkDO.Checked)
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 0, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 0, 0);
                    break;
                case "chkDO1":
                    if (chkDO1.Checked)
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 1, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 1, 0);
                    break;
                case "chkDO2":
                    if (chkDO2.Checked)
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 2, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 2, 0);
                    break;
                case "chkDO3":
                    if (chkDO3.Checked)
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 3, 1);
                    else
                        rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_DO2(gCardNo, nodeid, 3, 0);
                    break;
            }
        }

        private void chkSoftlimit_CheckedChanged(object sender, EventArgs e)
        {
            ushort i = 0;
            int PLimit = Int32.Parse(txtPLimit.Text), NLimit = Int32.Parse(txtNLimit.Text);

            if (chkSoftlimit.Checked)
            {
                for (i = 0; i < 4; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_set_soft_limit(gCardNo, nodeid, i, PLimit, NLimit, 1);
                    System.Threading.Thread.Sleep(50);
                }
            }
            else
            {
                for (i = 0; i < 4; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_set_soft_limit(gCardNo, nodeid, i, PLimit, NLimit, 0);
                    System.Threading.Thread.Sleep(50);
                }
            }
        }

        private void btnVChange_Click(object sender, EventArgs e)
        {
            int NewSpeed = Int32.Parse(txtNewVel.Text);
            double sec = Double.Parse(txtSec.Text);

            if (radAxis0.Checked)
                SlotID = 0;
            else if (radAxis1.Checked)
                SlotID = 1;
            else if (radAxis2.Checked)
                SlotID = 2;
            else if (radAxis3.Checked)
                SlotID = 3;

            rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_v_change(gCardNo, nodeid, SlotID, NewSpeed, sec);
        }

        private void btnPChange_Click(object sender, EventArgs e)
        {
            int NewPos = Int32.Parse(txtNewPos.Text);

            if (radAxis0.Checked)
                SlotID = 0;
            else if (radAxis1.Checked)
                SlotID = 1;
            else if (radAxis2.Checked)
                SlotID = 2;
            else if (radAxis3.Checked)
                SlotID = 3;

            rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_p_change(gCardNo, nodeid, SlotID, NewPos);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ushort m_StrVel = ushort.Parse(txtStrVel.Text), m_MaxVel = ushort.Parse(txtMaxVel.Text);
            double m_Tacc = Double.Parse(txtTAcc.Text);
            ushort home_mode = ushort.Parse(txtMode.Text);
            int home_offset = Int32.Parse(txtOffset.Text);

            if (radAxis0.Checked)
                SlotID = 0;
            else if (radAxis1.Checked)
                SlotID = 1;
            else if (radAxis2.Checked)
                SlotID = 2;
            else if (radAxis3.Checked)
                SlotID = 3;

            rc = CPCI_DMC.CS_DMC_01_set_home_config(gCardNo, nodeid, SlotID, home_mode, home_offset, m_StrVel, m_MaxVel, m_Tacc);
            rc = CPCI_DMC.CS_DMC_01_set_home_move(gCardNo, nodeid, SlotID);
        }

        private void chkMEL0_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMEL0.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 0, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 0, 0);
        }

        private void chkMEL1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMEL1.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 1, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 1, 0);
        }

        private void chkMEL2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMEL2.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 2, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 2, 0);
        }

        private void chkMEL3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMEL3.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 3, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_MEL_polarity(gCardNo, nodeid, 3, 0);
        }

        private void chkPEL0_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPEL0.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 0, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 0, 0);
        }

        private void chkPEL1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPEL1.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 1, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 1, 0);
        }

        private void chkPEL2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPEL2.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 2, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 2, 0);
        }

        private void chkPEL3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPEL3.Checked)
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 3, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_set_PEL_polarity(gCardNo, nodeid, 3, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ushort i = 0;
            int cmd = 0, pos = 0, speed = 0;
            uint MC_status = 0, alm_code = 0, value = 0;
            ushort MC_done = 0, servo_DO = 0;

            if (chktimer.Checked)
            {
                for (i = 0; i < 4; i++)
                {
                    rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid, i, ref cmd);
                    rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid, i, ref pos);
                    rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, i, ref speed);
                    rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid, i, ref MC_status);
                    rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, i, ref MC_done);
                    rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid, i, ref alm_code);

                    txtMotion[i * 6].Text = cmd.ToString();
                    txtMotion[i * 6 + 1].Text = pos.ToString();
                    txtMotion[i * 6 + 2].Text = speed.ToString();
                    txtMotion[i * 6 + 3].Text = MC_status.ToString("X");
                    txtMotion[i * 6 + 4].Text = MC_done.ToString("X");
                    txtMotion[i * 6 + 5].Text = alm_code.ToString("X");

                    rc = CPCI_DMC.CS_DMC_01_set_monitor(gCardNo, nodeid, i, 0x27);
                    rc = CPCI_DMC.CS_DMC_01_get_monitor(gCardNo, nodeid, i, ref value);

                    if ((value & 0x4000000) != 0)
                        txtIOSts[i * 10].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10].BackColor = System.Drawing.Color.DarkRed;

                    if ((value & 0x40000000) != 0)
                        txtIOSts[i * 10 + 1].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 1].BackColor = System.Drawing.Color.DarkRed;

                    if ((value & 0x20000000) != 0)
                        txtIOSts[i * 10 + 2].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 2].BackColor = System.Drawing.Color.DarkRed;

                    if ((value & 0x10000000) != 0)
                        txtIOSts[i * 10 + 3].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 3].BackColor = System.Drawing.Color.DarkRed;

                    if ((value & 0x8000000) != 0)
                        txtIOSts[i * 10 + 4].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 4].BackColor = System.Drawing.Color.DarkRed;

                    if ((value & 0x1000000) != 0)
                        txtIOSts[i * 10 + 5].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 5].BackColor = System.Drawing.Color.DarkRed;

                    if ((value & 0x2000000) != 0)
                        txtIOSts[i * 10 + 6].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 6].BackColor = System.Drawing.Color.DarkRed;

                    rc = CPCI_DMC.CS_DMC_01_get_servo_DO(gCardNo, nodeid, i, ref servo_DO);
                    if ((servo_DO & 0x1) != 0)
                        txtIOSts[i * 10 + 7].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 7].BackColor = System.Drawing.Color.DarkRed;

                    if ((servo_DO & 0x2) != 0)
                        txtIOSts[i * 10 + 8].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 8].BackColor = System.Drawing.Color.DarkRed;

                    if ((MC_status & (0x1 << 9)) != 0)
                        txtIOSts[i * 10 + 9].BackColor = System.Drawing.Color.Lime;
                    else
                        txtIOSts[i * 10 + 9].BackColor = System.Drawing.Color.DarkRed;
                }
                rc = CPCI_DMC.CS_DMC_01_rm_04pi_md1_get_soft_limit_status(gCardNo, nodeid, gAxis, ref NLimit, ref PLimit);
                if ((NLimit & (0x1 << gAxis)) == (0x1 << gAxis))
                    txtNStatus.BackColor = System.Drawing.Color.Lime;
                else
                    txtNStatus.BackColor = System.Drawing.Color.DarkRed;
                if ((PLimit & (0x1 << gAxis)) == (0x1 << gAxis))
                    txtPStatus.BackColor = System.Drawing.Color.Lime;
                else
                    txtPStatus.BackColor = System.Drawing.Color.DarkRed;
            }
        }

        private void radHighLow_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)(sender)).Name)
            {
                case "radHigh":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 0, 0);
                    break;
                case "radHigh1":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 1, 0);
                    break;
                case "radHigh2":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 2, 0);
                    break;
                case "radHigh3":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 3, 0);
                    break;
                case "radLow":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 0, 1);
                    break;
                case "radLow1":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 1, 1);
                    break;
                case "radLow2":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 2, 1);
                    break;
                case "radLow3":
                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_svon_polarity(gCardNo, nodeid, 3, 1);
                    break;
            }
        }

        private void radAxis_CheckedChanged(object sender, EventArgs e)
        {
            switch(((RadioButton)(sender)).Name)
            {
                case "radAxis0":
                    gAxis = 0;
                    break;
                case "radAxis1":
                    gAxis = 1;
                    break;
                case "radAxis2":
                    gAxis = 2;
                    break;
                case "radAxis3":
                    gAxis = 3;
                    break;
            }
        }

        private void cmdOutputMode_Click(object sender, EventArgs e)
        {
            rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, (ushort)cmbOutputMode.SelectedIndex);
        }

        private void cmdOutputMode1_Click(object sender, EventArgs e)
        {
            rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 1, (ushort)cmbOutputMode1.SelectedIndex);
        }

        private void cmdOutputMode2_Click(object sender, EventArgs e)
        {
            rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 2, (ushort)cmbOutputMode2.SelectedIndex);
        }

        private void cmdOutputMode3_Click(object sender, EventArgs e)
        {
            rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 3, (ushort)cmbOutputMode3.SelectedIndex);
        }
    }
}
