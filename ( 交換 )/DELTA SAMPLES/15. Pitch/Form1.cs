using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
        bool gIsServoOn, gbIsAbs, gbIsScurve;

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

            btnralm.Enabled = false;
            btnstop.Enabled = false;
            btnreset.Enabled = false;
            cmdNMove.Enabled = false;
            cmdPMove.Enabled = false;
            chksvon.Enabled = false;
            cmdPitch.Enabled = false;

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

            rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, nodeid, 0, 1);
            rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, nodeid, 0, 1);

            rc = CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo, nodeid, 0, (ushort)(gIsServoOn ? 1 : 0));
        }

        private void btnralm_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc = CPCI_DMC.CS_DMC_01_set_ralm(gCardNo, nodeid, 0);
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc = CPCI_DMC.CS_DMC_01_sd_stop(gCardNo, nodeid, 0, 0.1);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            nodeid = ushort.Parse(cmbNodeID.Text);

            rc=(short)CPCI_DMC.CS_DMC_01_set_position(gCardNo, nodeid, 0, 0);
            rc = (short)CPCI_DMC.CS_DMC_01_set_command(gCardNo, nodeid, 0, 0);
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

            //Motion status
            int cmd = 0, pos = 0;
            ushort MC_done = 0;
            int speed = 0;
            uint MC_status = 0, err = 0;

            nodeid = ushort.Parse(cmbNodeID.Text);

            if (chktimer.Checked)
            {
                //Status
                rc = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid, 0, ref cmd);             //Command
                if (rc == 0)
                {
                    txtcommand.Text = cmd.ToString();
                }
                rc = CPCI_DMC.CS_DMC_01_get_position(gCardNo, nodeid, 0, ref pos);            //Feedback
                if (rc == 0)
                {
                    txtfeedback.Text = pos.ToString();
                }
                rc = CPCI_DMC.CS_DMC_01_get_current_speed(gCardNo, nodeid, 0, ref speed);                 //Speed
                if (rc == 0)
                {
                    txtspeed.Text = speed.ToString();
                }
                rc = CPCI_DMC.CS_DMC_01_motion_status(gCardNo, nodeid, 0, ref MC_status);     //Motion status
                if (rc == 0)
                {
                    txtIO.Text = MC_status.ToString("X");
                }
                rc = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid, 0, ref MC_done);         //Motion done
                if (rc == 0)
                {
                    txtmotion.Text = MC_done.ToString();
                }

                rc = CPCI_DMC.CS_DMC_01_get_alm_code(gCardNo, nodeid, 0, ref err);      //Error
                if (rc == 0)
                {
                    txtERR.Text = err.ToString("X");
                }
            }
        }

        private void CmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardNo = Convert.ToUInt16(CmbCardNo.SelectedItem);

        }

        private void btnFindSlave_Click(object sender, EventArgs e)
        {
            ushort i, lMask = 0x1,p=0;
            uint DeviceType = 0, IdentityObject = 0;

            btnralm.Enabled = false;
            btnstop.Enabled = false;
            btnreset.Enabled = false;
            cmdNMove.Enabled = false;
            cmdPMove.Enabled = false;
            chksvon.Enabled = false;
            cmdPitch.Enabled = false;
            gNodeNum = 0;
            txtSlaveNum.Text = "0";
            cmbNodeID.Items.Clear();

            for (i = 0; i < 4; i++)
                SlaveTable[i] = 0;

            rc = CPCI_DMC.CS_DMC_01_start_ring(gCardNo, 0);                       //Start communication
            rc = CPCI_DMC.CS_DMC_01_get_device_table(gCardNo, ref DeviceInfo);    //Get Slave Node ID
            rc = CPCI_DMC.CS_DMC_01_get_node_table(gCardNo, ref SlaveTable[0]);

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
                if (gNodeNum == 0)
                {
                    MessageBox.Show("No A2 Servo/04PI/01PH Device Found!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID.SelectedIndex = 0;
                    timer1.Enabled = true;
                    btnralm.Enabled = true;
                    btnstop.Enabled = true;
                    btnreset.Enabled = true;
                    cmdNMove.Enabled = true;
                    cmdPMove.Enabled = true;
                    chksvon.Enabled = true;
                    chkAbs.Checked = false;
                    chkSCurve.Checked = false;
                    chkPitchERR.Checked = false;
                    chk1Dir.Checked = false;
                    cmdPitch.Enabled = true;
                }
            }
        }

        private void cmdPMove_Click(object sender, EventArgs e)
        {
            int Dist = Int32.Parse(txtDist.Text);
            int StrVel = Int32.Parse(txtStrVel.Text);
            int MaxVel = Int32.Parse(txtMaxVel.Text);
            double Acc = Double.Parse(txtAcc.Text);
            double Dec = Double.Parse(txtDec.Text);

            if (gbIsAbs)
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
            }
            else
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAbs.Checked)
                gbIsAbs = true;
            else
                gbIsAbs = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSCurve.Checked)
                gbIsScurve = true;
            else
                gbIsScurve = false;
        }

        private void cmdNMove_Click(object sender, EventArgs e)
        {
            int Dist = 0 - Int32.Parse(txtDist.Text);
            int StrVel = Int32.Parse(txtStrVel.Text);
            int MaxVel = Int32.Parse(txtMaxVel.Text);
            double Acc = Double.Parse(txtAcc.Text);
            double Dec = Double.Parse(txtDec.Text);

            if (gbIsAbs)
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_ta_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
            }
            else
            {
                if (gbIsScurve)
                    rc = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
                else
                    rc = CPCI_DMC.CS_DMC_01_start_tr_move(gCardNo, nodeid, 0, Dist, StrVel, MaxVel, Acc, Dec);
            }
        }

        private void cmdPitch_Click(object sender, EventArgs e)
        {
            int[] YCamTable = new int[10001];
            int i, j, pitch, cam_org;
            nodeid = ushort.Parse(cmbNodeID.Text);
            FileStream fs = File.Open(@"c:\pitchErrlog.txt",FileMode.Create,FileAccess.Write,FileShare.ReadWrite);
            StreamWriter FileWrite=new StreamWriter(fs);
            //FileWrite.WriteLine("Hahaha");
            if (chkPitchERR.Checked)
                rc = CPCI_DMC.CS_DMC_01_set_cam_enable(gCardNo, nodeid, 0, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_set_cam_enable(gCardNo, nodeid, 0, 0);

            if (chk1Dir.Checked)
                rc = CPCI_DMC.CS_DMC_01_set_cam_mode(gCardNo, nodeid, 0, 1);
            else
                rc = CPCI_DMC.CS_DMC_01_set_cam_mode(gCardNo, nodeid, 0, 0);

            pitch = Int32.Parse(txtPitch.Text);
            cam_org = -5000 * pitch;
            rc = CPCI_DMC.CS_DMC_01_set_cam_pitch(gCardNo, nodeid, 0, pitch);
            rc = CPCI_DMC.CS_DMC_01_set_cam_org(gCardNo, nodeid, 0, 0, cam_org);
            FileWrite.WriteLine("Pitch_Start:" + cam_org);

            for (i = 0; i <= 10000; i++)
            {
                switch (i % 5)
                {
                    case 0:
                        YCamTable[i] = cam_org + pitch * i;
                        break;
                    case 1:
                        YCamTable[i] = cam_org + pitch * i + 100;
                        break;
                    case 2:
                        YCamTable[i] = cam_org + pitch * i + 200;
                        break;
                    case 3:
                        YCamTable[i] = cam_org + pitch * i + 300;
                        break;
                    case 4:
                        YCamTable[i] = cam_org + pitch * i + 400;
                        break;
                }
                FileWrite.WriteLine("Table:" + YCamTable[i]);
            }
            rc = CPCI_DMC.CS_DMC_01_set_cam_table(gCardNo, nodeid, 0, 0, ref YCamTable[0]);

            cam_org = 5000 * pitch;
            FileWrite.WriteLine("Pitch_Start:" + cam_org);
            rc = CPCI_DMC.CS_DMC_01_set_cam_org(gCardNo, nodeid, 0, 1, cam_org);
            for (i = 0; i <= 10000; i++)
            {
                switch (i % 5)
                {
                    case 0:
                        YCamTable[i] = cam_org - pitch * i;
                        break;
                    case 1:
                        YCamTable[i] = cam_org - pitch * i + 10;
                        break;
                    case 2:
                        YCamTable[i] = cam_org - pitch * i + 20;
                        break;
                    case 3:
                        YCamTable[i] = cam_org - pitch * i + 30;
                        break;
                    case 4:
                        YCamTable[i] = cam_org - pitch * i + 40;
                        break;
                }
                FileWrite.WriteLine("Table:" + YCamTable[i]);
            }
            rc = CPCI_DMC.CS_DMC_01_set_cam_table(gCardNo, nodeid, 0, 1, ref YCamTable[0]);
            
            FileWrite.Dispose();
            fs.Dispose();
        }
    }
}