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
      //  short rt=0;
        ushort[] nodeid =new ushort[3];
        ushort[] slot = new ushort[3];
        ushort[] gCardNoList = new ushort[16];
        uint[] SlaveTable = new uint[4];
        ushort[] NodeID = new ushort[32];
        byte[] value = new byte[10];
        ushort gNodeNum;
       // bool gIsServoOn;
        int MotionStep=0;
        int MaxVel = 0;
        double gRatio = 0;
        int OriginX=0,OriginY=0;
        double[] AxisDataX=new double[2];
        double[] AxisDataY=new double[2];
        int TempSave = 0;

        int[,] Table1= new int[7,12]{ 
{40000,		 0,		0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
{40000,	 20000,	-9000,	0,	0,	0,	0,	0,	0,	0,	0,	0},
{40000,	 40000,	-9000,	0,	0,	0,	0,	0,	0,	0,	0,	0},
{20000,	 40000,-18000,	0,	0,	0,	0,	0,	0,	0,	0,	0},
{00000,	 40000,-18000,	0,	0,	0,	0,	0,	0,	0,	0,	0},
{00000,	 20000,-27000,	0,	0,	0,	0,	0,	0,	0,	0,	0},
{00000,	 00000,-27000,	0,	0,	0,	0,	0,	0,	0,	0,	0}
};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            APic_Back(1);
            APic_Back(2);
        }

        private void btninitial_Click(object sender, EventArgs e)
        {
            ushort i, card_no = 0;

            cmdStart.Enabled = false;
            cmdStop.Enabled = false;

            AxisDataX[0] = 0;
            AxisDataY[0] = 0;
            AxisDataX[1] = 0;
            AxisDataY[1] = 0;

            for (i = 0; i < 4; i++)
            {
                SlaveTable[i] = 0;
            }

            btnFindSlave.Enabled = false;
            txtSlaveNum.Text = "0";
            CmbCardNo.Items.Clear();
            cmbNodeID1.Items.Clear();

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

        public void APic_Draw(int p)
        {
            Graphics gra2 = pictureBox2.CreateGraphics();
            System.Drawing.Pen penRed = Pens.Red;
            gra2.PageScale = 0.1F;
            
            if (p == 1)
                gra2.DrawLine(penRed, (float)AxisDataX[0]/2, (float)AxisDataY[0]/2, (float)AxisDataX[1]/2, (float)AxisDataY[1]/2);
        }
        public void APic_Back(int p)    //Drawing grids
        {
            int i = 0, j = 0;
            Graphics gra1 = pictureBox1.CreateGraphics();
            Graphics gra2 = pictureBox2.CreateGraphics();
            System.Drawing.Pen penGray = Pens.DarkGray;
            System.Drawing.Pen penRed = Pens.Red;
            if (p == 1)
            {
                for (i = 0; i < pictureBox1.Width; i = i + (pictureBox1.Width / 10))
                {
                    gra1.DrawLine(penGray, i, 0, i, pictureBox1.Height);
                }
                for (j = 0; j < pictureBox1.Height; j = j + (pictureBox1.Height / 10))
                {
                    gra1.DrawLine(penGray, 0, j, pictureBox1.Width, j);
                }
            }
            else if (p == 2)
            {
                for (i = 0; i < pictureBox2.Width; i = i + (pictureBox2.Width / 10))
                {
                    gra2.DrawLine(penGray, i, 0, i, pictureBox2.Height);
                }
                for (j = 0; j < pictureBox2.Height; j = j + (pictureBox2.Height / 10))
                {
                    gra2.DrawLine(penGray, 0, j, pictureBox2.Width, j);
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
            short i = 0;
            int[]cmd=new int[3];
            int OneCircle = 36000;
            int[]rt=new int[4];
            nodeid[0] = (ushort)Int32.Parse(cmbNodeID1.Text);
            nodeid[1] = (ushort)Int32.Parse(cmbNodeID2.Text);
            nodeid[2] = (ushort)Int32.Parse(cmbNodeID3.Text);
            slot[0] = 0;
            slot[1] = 0;
            slot[2] = 0;

            Graphics gra1=pictureBox1.CreateGraphics();
            System.Drawing.Pen penRed=Pens.Red;

            if (MotionStep == 1)
            {
                if (cmbFollow.SelectedIndex == 0)
                {
                    rt[2] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[2], slot[2], -13500, 0, MaxVel, 0.1, 0.1);
                    TempSave = -13500;
                }
                else
                {
                    rt[2] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[2], slot[2], -4500, 0, MaxVel, 0.1, 0.1);
                    
                    TempSave = -4500;
                }
                rt[0] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[0], slot[0], 0, 0, MaxVel, 0.1, 0.1);
                rt[1] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[1], slot[0], 0, 0, MaxVel, 0.1, 0.1);

                if ((rt[0] + rt[1] + rt[2]) == 0)
                    MotionStep = 2;
            }
            else if (MotionStep == 2)
            {
                for (i = 0; i <= 2; i++)
                    rt[i]=CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid[i], slot[i], ref cmd[i]);
                if (((rt[0] + rt[1] + rt[2]) == 0) && (cmd[0] == 0) && (cmd[1] == 0) && (cmd[2] == TempSave))
                    MotionStep = 3;
            }
            else if (MotionStep == 3)
            {
                rt[0] = CPCI_DMC.CS_DMC_01_start_sr_move_xy(gCardNo, ref nodeid[0], ref slot[0], 40000, 40000, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
                rt[1] = CPCI_DMC.CS_DMC_01_start_sr_heli_xy(gCardNo, ref nodeid[0], ref slot[0], -10000, 10000, -OneCircle * 180 / 360, OneCircle, 1, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
                rt[2] = CPCI_DMC.CS_DMC_01_start_sr_move_xy(gCardNo, ref nodeid[0], ref slot[0], -40000, -40000, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
                rt[3] = CPCI_DMC.CS_DMC_01_start_sr_heli_xy(gCardNo, ref nodeid[0], ref slot[0], 10000, -10000, -OneCircle * 180 / 360, OneCircle, 1, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
                if ((rt[0] + rt[1] + rt[2] + rt[3]) == 0)
                    MotionStep = 0;
            }
            else if (MotionStep == 4)
            {
                if (cmbFollow.SelectedIndex == 0)
                {
                    rt[2] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[2], slot[2], -9000, 0, (int)MaxVel, 0.1, 0.1);
                    TempSave = -9000;
                }
                else
                {
                    rt[2] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[2], slot[2], 0, 0, (int)MaxVel, 0.1, 0.1);
                    TempSave = 0;
                }
                rt[0] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[0], slot[0], 0, 0, (int)MaxVel, 0.1, 0.1);
                rt[1] = CPCI_DMC.CS_DMC_01_start_sa_move(gCardNo, nodeid[1], slot[0], 0, 0, (int)MaxVel, 0.1, 0.1);
                if ((rt[0] + rt[1] + rt[2]) == 0)
                    MotionStep = 5;
            }
            else if (MotionStep == 5)
            {
                for (i = 0; i <= 2; i++)
                    rt[i] = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid[i], slot[i], ref cmd[i]);
                if (((rt[0] + rt[1] + rt[2]) == 0) && (cmd[0] == 0) && (cmd[1] == 0) && (cmd[2] == TempSave))
                    MotionStep = 6;
            }
            else if (MotionStep == 6)
            {
                rt[0] = CPCI_DMC.CS_DMC_01_start_sa_move_xy(gCardNo, ref nodeid[0], ref slot[0], 30000, 0, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
                if (rt[0] == 0)
                    MotionStep = 7;
            }
            else if (MotionStep == 7)
            {
                for (i = 0; i <= 1; i++)
                    rt[i] = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid[i], slot[i], ref cmd[i]);
                if ((rt[0] + rt[1] == 0) && (cmd[0] == 30000) && (cmd[1] == 0))
                    MotionStep = 8;
            }
            else if (MotionStep == 8)
            {
                rt[2] = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid[2], slot[2], -OneCircle * 90 / 360, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
                TempSave = TempSave - OneCircle * 90 / 360;
                if (rt[2] == 0)
                    MotionStep = 9;
            }
            else if (MotionStep == 9)
            {
                rt[2] = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid[2], slot[2], ref cmd[2]);
                if ((rt[2] == 0) && (cmd[2] == TempSave))
                    MotionStep = 10;
            }
            else if (MotionStep == 10)
            {
                rt[0] = CPCI_DMC.CS_DMC_01_start_sa_move_xy(gCardNo, ref nodeid[0], ref slot[0], 30000, 30000, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
			    if (rt[0] == 0)
				    MotionStep = 11;
            }
            else if (MotionStep == 11)
            {
                for(i=0;i<=1;i++)
				{
                    rt[i] = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid[i], slot[i], ref cmd[i]);
                }
			    if ((rt[0] + rt[1] == 0) && (cmd[0] == 30000) && (cmd[1] == 30000))
				    MotionStep = 12;
            }
            else if (MotionStep==12)
            {
                rt[2] = CPCI_DMC.CS_DMC_01_start_sr_move(gCardNo, nodeid[2],slot[2], -OneCircle * 90 / 360, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
			    TempSave = TempSave - OneCircle * 90 / 360;
			    if (rt[2] == 0)
				    MotionStep = 13;
            }
            else if(MotionStep==13)
            {
                rt[2] = CPCI_DMC.CS_DMC_01_get_command(gCardNo, nodeid[2],slot[2],ref cmd[2]);
    			if ((rt[2] == 0) && (cmd[2] == TempSave))
	    			MotionStep = 14;
            }
            else if(MotionStep==14)
            {
                rt[0] = CPCI_DMC.CS_DMC_01_start_tr_heli_xy(gCardNo, ref nodeid[0],ref slot[0], 0, -10000, -OneCircle * 90 / 360, OneCircle, 1, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
			    rt[1] = CPCI_DMC.CS_DMC_01_start_tr_heli_xy(gCardNo, ref nodeid[0],ref slot[0], -10000, 0, OneCircle * 90 / 360, OneCircle, 0, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
    			rt[2] = CPCI_DMC.CS_DMC_01_start_tr_heli_xy(gCardNo, ref nodeid[0],ref slot[0], 0, -10000, -OneCircle * 90 / 360, OneCircle, 1, (int)MaxVel / 2, (int)MaxVel, 0.1, 0.1);
	    		if (rt[0] + rt[1] + rt[2] == 0)
                    MotionStep = 0;
            }

            else if (MotionStep == 20)
            {
                double parameter;

                if (cmbFollow.SelectedIndex == 0)
                {
                    parameter = 5000;
                }
                else
                {
                    parameter = 0;
                }

                rt[0] = CPCI_DMC.CS_DMC_01_start_v3_msbrline_move(      gCardNo,              3,     ref nodeid[0],       ref slot[0],                 0,  ref Table1[0, 0],   ref Table1[1, 0],           0,        parameter,               1,             0,             0,          0,  (int)MaxVel,(int)MaxVel,              1,              0,              2,            1);
                rt[0] = CPCI_DMC.CS_DMC_01_start_v3_msbrline_move(gCardNo, 3, ref nodeid[0], ref slot[0], 0, ref Table1[2, 0], ref Table1[3, 0], 0, parameter, 1, 0, 0, (int)MaxVel, (int)MaxVel, (int)MaxVel, 1, 0, 2, 1);
                rt[0] = CPCI_DMC.CS_DMC_01_start_v3_msbrline_move(gCardNo, 3, ref nodeid[0], ref slot[0], 0, ref Table1[4, 0], ref Table1[5, 0], 0, parameter, 1, 0, 0, (int)MaxVel, (int)MaxVel, (int)MaxVel, 1, 0, 2, 1);
                // CS_DMC_01_start_v3_msbrline_move(ushort CardNo, ushort AxisNum, ref ushort NodeID, ref ushort SlotID, ushort ArcNodeBit, ref int DistArray, ref int DistArray2, ushort Mode, double Parameter, double SpdRatio, double Angle1, double Angle2, int StrVel, int ConstVel, int EndVel, double Tphase1, double Tphase2, ushort m_curve, ushort m_r_a);
                rt[0] = CPCI_DMC.CS_DMC_01_start_v3_multi_axes(      gCardNo,              3,     ref nodeid[0],       ref slot[0],   ref Table1[6, 0],     MaxVel,       MaxVel,          0,              0,              1,              1,           1);
                             //  CS_DMC_01_start_v3_multi_axes(ushort CardNo, ushort AxisNum, ref ushort NodeID, ref ushort SlotID, ref int DistArrary, int StrVel, int ConstVel, int EndVel, double Tphase1, double Tphase2, ushort m_curve, ushort m_r_a);

                if (rt[0] == 0)
                {
                    MotionStep = 21;
                }
            }
            else if (MotionStep == 21)
            {
                ushort Length =0;
                ushort motion_done=0;

                rt[0] = CPCI_DMC.CS_DMC_01_get_buffer_length(gCardNo, nodeid[0], slot[0], ref Length);

                if (Length == 0)
                {
                    rt[0] = CPCI_DMC.CS_DMC_01_motion_done(gCardNo, nodeid[0], slot[0], ref motion_done);
                    if (i == 0)
                    {
                        MotionStep = 22;
                    }
                }
            }
            else if (MotionStep ==22)
            {

                    MotionStep = 0;
            }

            for(i=0;i<=2;i++)
                CPCI_DMC.CS_DMC_01_get_command(gCardNo,nodeid[i],slot[i],ref cmd[i]);

            double PicZ;
            double PI=3.14159265358979;
            if(cmd[2]==0)
                PicZ=0;
            else
                PicZ=2 * PI * (cmd[2] / System.Math.Abs(cmd[2])) * (System.Math.Abs(cmd[2]) % OneCircle) / OneCircle;            

            AxisDataX[1] = 500 + (cmd[0] - OriginX) / gRatio * 50;
		    AxisDataY[1] = 500 - (cmd[1] - OriginY) / gRatio * 50;
		    APic_Draw(1);
		    AxisDataX[0] = AxisDataX[1];
            AxisDataY[0] = AxisDataY[1];

            gra1.TranslateTransform(100, 100);

            gra1.Clear(Color.Black);
            APic_Back(1);
            gra1.DrawLine(penRed, (int)(-90 * System.Math.Cos(PicZ)), (int)(-90 * System.Math.Sin(PicZ)), (int)(90 * System.Math.Cos(PicZ)), (int)(90 * System.Math.Sin(PicZ)));
            gra1.DrawLine(penRed, (int)(90 * System.Math.Cos(PicZ)), (int)(90 * System.Math.Sin(PicZ)), (int)(75 * System.Math.Cos(PicZ + PI / 32)), (int)(75 * System.Math.Sin(PicZ + PI / 32)));
            gra1.DrawLine(penRed, (int)(90 * System.Math.Cos(PicZ)), (int)(90 * System.Math.Sin(PicZ)), (int)(75 * System.Math.Cos(PicZ - PI / 32)), (int)(75 * System.Math.Sin(PicZ - PI / 32)));
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
            cmbNodeID1.Items.Clear();
            cmbNodeID2.Items.Clear();
            cmbNodeID3.Items.Clear();
            cmdStart.Enabled = false;
            cmdStop.Enabled = false;

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
                        rc=CPCI_DMC.CS_DMC_01_ipo_set_svon(gCardNo,(ushort)( i + 1), 0, 1);
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
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x6020192:				//Servo M series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x8020192:				//Servo A2R series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x9020192:				//Servo S series
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    p++;
                                    break;
                                case 0x14100191:			//Remote Module 04PI
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_ipulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    rc = CPCI_DMC.CS_DMC_01_set_rm_04pi_opulser_mode(gCardNo, (ushort)(i + 1), (ushort)0, (ushort)1);
                                    p++;
                                    break;
                                case 0x11210191:			//GE01PH
                                    cmbNodeID1.Items.Add(i + 1);
                                    cmbNodeID2.Items.Add(i + 1);
                                    cmbNodeID3.Items.Add(i + 1);
                                    p++;
                                    break;
                            }
                        }
                    }
                    lMask <<= 1;
                }
                if (p < 3)
                {
                    MessageBox.Show("This sample need at least three axis!");
                }
                else
                {
                    txtSlaveNum.Text = gNodeNum.ToString();
                    cmbNodeID1.SelectedIndex = 0;
                    cmbNodeID2.SelectedIndex = 1;
                    cmbNodeID3.SelectedIndex = 2;
                    cmbSample.SelectedIndex = 0;
                    cmbFollow.SelectedIndex = 0;
                    cmbSpeed.SelectedIndex = 3;
                    cmdStart.Enabled = true;
                    cmdStop.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short i;
            MaxVel=10000;
            Graphics gra2 = pictureBox2.CreateGraphics();
            nodeid[0] = ushort.Parse(cmbNodeID1.Text);
            nodeid[1] = ushort.Parse(cmbNodeID2.Text);
            nodeid[2] = ushort.Parse(cmbNodeID3.Text);

            if(MotionStep ==0)
            {
                gra2.Clear(Color.Black);
                for(i=0;i<=2;i++)
                {
                    rc=(short)CPCI_DMC.CS_DMC_01_set_position(gCardNo,nodeid[i],0,0);
                    rc=CPCI_DMC.CS_DMC_01_set_command(gCardNo,nodeid[i],0,0);
                }
                switch(cmbSpeed.SelectedIndex)
                {
                    case 0:
                        MaxVel=(int)(MaxVel*0.1);
                        break;
                    case 1:
                        MaxVel=(int)(MaxVel*0.25);
                        break;
                    case 2:
                        MaxVel=(int)(MaxVel*0.5);
                        break;
                    case 3:
                        MaxVel=MaxVel*1;
                        break;
                    case 4:
                        MaxVel=MaxVel*2;
                        break;
                    case 5:
                        MaxVel=MaxVel*3;
                        break;
                }
                APic_Back(1);
                APic_Back(2);
                if(cmbSample.SelectedIndex==0)
                {
                    MotionStep=1;
                    gRatio=4000;
                    OriginX = 10000;
                    OriginY = 30000;
                }
                else if (cmbSample.SelectedIndex == 1)
                {
                    MotionStep=4;
                    gRatio = 3000;
                    OriginX = 15000;
                    OriginY = 15000;
                }
                else
                {
                    MotionStep=20;
                    gRatio=3000;
                    OriginX = 15000;
                    OriginY = 15000;
                }
                AxisDataX[0]=500+(0-OriginX)/gRatio*50;
                AxisDataY[0]=500-(0-OriginY)/gRatio*50;
            }
            else
            {
                for(i=0;i<=2;i++)
                    CPCI_DMC.CS_DMC_01_emg_stop(gCardNo,nodeid[i],0);
                MotionStep=0;
            }
            timer1.Enabled=true;
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            int i;
            for(i=0;i<=2;i++)
                rc=CPCI_DMC.CS_DMC_01_emg_stop(gCardNo,nodeid[i],0);
            MotionStep = 0;
            timer1.Enabled = false;
        }
    }
}
