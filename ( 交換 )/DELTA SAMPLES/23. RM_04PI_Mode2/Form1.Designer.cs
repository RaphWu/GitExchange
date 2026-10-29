namespace DMC_NET
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btninitial = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnstop = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.chksvon = new System.Windows.Forms.CheckBox();
            this.chktimer = new System.Windows.Forms.CheckBox();
            this.btnralm = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtStrVel = new System.Windows.Forms.TextBox();
            this.txtMaxVel = new System.Windows.Forms.TextBox();
            this.txtTAcc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSCurve = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTDec = new System.Windows.Forms.TextBox();
            this.chkAbs = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtdist = new System.Windows.Forms.TextBox();
            this.txtcommand = new System.Windows.Forms.TextBox();
            this.txtfeedback = new System.Windows.Forms.TextBox();
            this.txtspeed = new System.Windows.Forms.TextBox();
            this.txtmotion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.txtIO = new System.Windows.Forms.TextBox();
            this.btnPmove = new System.Windows.Forms.Button();
            this.btnNmove = new System.Windows.Forms.Button();
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbnode = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radHigh = new System.Windows.Forms.RadioButton();
            this.radLow = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radCW = new System.Windows.Forms.RadioButton();
            this.radAB = new System.Windows.Forms.RadioButton();
            this.txtIOsts0 = new System.Windows.Forms.TextBox();
            this.txtIOsts1 = new System.Windows.Forms.TextBox();
            this.txtIOsts2 = new System.Windows.Forms.TextBox();
            this.txtIOsts3 = new System.Windows.Forms.TextBox();
            this.txtIOsts4 = new System.Windows.Forms.TextBox();
            this.txtIOsts5 = new System.Windows.Forms.TextBox();
            this.txtIOsts6 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtDO1 = new System.Windows.Forms.TextBox();
            this.txtDO2 = new System.Windows.Forms.TextBox();
            this.chkDO2 = new System.Windows.Forms.CheckBox();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.chkMEL = new System.Windows.Forms.CheckBox();
            this.chkPEL = new System.Windows.Forms.CheckBox();
            this.radPDL = new System.Windows.Forms.RadioButton();
            this.radPDH = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninitial
            // 
            this.btninitial.Location = new System.Drawing.Point(14, 0);
            this.btninitial.Name = "btninitial";
            this.btninitial.Size = new System.Drawing.Size(83, 28);
            this.btninitial.TabIndex = 0;
            this.btninitial.Text = "1-1 Open Card";
            this.btninitial.UseVisualStyleBackColor = true;
            this.btninitial.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(219, 348);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(171, 32);
            this.btnreset.TabIndex = 2;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnstop
            // 
            this.btnstop.Location = new System.Drawing.Point(265, 310);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(79, 32);
            this.btnstop.TabIndex = 3;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(248, 408);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(261, 31);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // chksvon
            // 
            this.chksvon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chksvon.Location = new System.Drawing.Point(219, 264);
            this.chksvon.Name = "chksvon";
            this.chksvon.Size = new System.Drawing.Size(79, 35);
            this.chksvon.TabIndex = 5;
            this.chksvon.Text = "SVON\r\n(DO1)";
            this.chksvon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chksvon.UseVisualStyleBackColor = true;
            this.chksvon.CheckedChanged += new System.EventHandler(this.chksvon_CheckedChanged);
            // 
            // chktimer
            // 
            this.chktimer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chktimer.Enabled = false;
            this.chktimer.Location = new System.Drawing.Point(107, 11);
            this.chktimer.Name = "chktimer";
            this.chktimer.Size = new System.Drawing.Size(63, 32);
            this.chktimer.TabIndex = 6;
            this.chktimer.Text = "Timer";
            this.chktimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chktimer.UseVisualStyleBackColor = true;
            // 
            // btnralm
            // 
            this.btnralm.Location = new System.Drawing.Point(312, 264);
            this.btnralm.Name = "btnralm";
            this.btnralm.Size = new System.Drawing.Size(78, 35);
            this.btnralm.TabIndex = 7;
            this.btnralm.Text = "RALM";
            this.btnralm.UseVisualStyleBackColor = true;
            this.btnralm.Click += new System.EventHandler(this.btnralm_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtStrVel
            // 
            this.txtStrVel.Location = new System.Drawing.Point(64, 20);
            this.txtStrVel.Name = "txtStrVel";
            this.txtStrVel.Size = new System.Drawing.Size(77, 22);
            this.txtStrVel.TabIndex = 10;
            this.txtStrVel.Text = "100";
            this.txtStrVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxVel
            // 
            this.txtMaxVel.Location = new System.Drawing.Point(64, 42);
            this.txtMaxVel.Name = "txtMaxVel";
            this.txtMaxVel.Size = new System.Drawing.Size(77, 22);
            this.txtMaxVel.TabIndex = 11;
            this.txtMaxVel.Text = "50000";
            this.txtMaxVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTAcc
            // 
            this.txtTAcc.Location = new System.Drawing.Point(64, 64);
            this.txtTAcc.Name = "txtTAcc";
            this.txtTAcc.Size = new System.Drawing.Size(77, 22);
            this.txtTAcc.TabIndex = 12;
            this.txtTAcc.Text = "0.1";
            this.txtTAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "StrVel.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "MaxVel.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Acc.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "pps.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "pps.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "sec.";
            // 
            // chkSCurve
            // 
            this.chkSCurve.AutoSize = true;
            this.chkSCurve.Location = new System.Drawing.Point(13, 136);
            this.chkSCurve.Name = "chkSCurve";
            this.chkSCurve.Size = new System.Drawing.Size(63, 16);
            this.chkSCurve.TabIndex = 19;
            this.chkSCurve.Text = "S-Curve";
            this.chkSCurve.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtTDec);
            this.groupBox1.Controls.Add(this.chkAbs);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtdist);
            this.groupBox1.Controls.Add(this.chkSCurve);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTAcc);
            this.groupBox1.Controls.Add(this.txtMaxVel);
            this.groupBox1.Controls.Add(this.txtStrVel);
            this.groupBox1.Location = new System.Drawing.Point(16, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 161);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Vel. Prof.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 88);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 12);
            this.label24.TabIndex = 26;
            this.label24.Text = "Dec.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(147, 88);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(22, 12);
            this.label23.TabIndex = 25;
            this.label23.Text = "sec.";
            // 
            // txtTDec
            // 
            this.txtTDec.Location = new System.Drawing.Point(64, 86);
            this.txtTDec.Name = "txtTDec";
            this.txtTDec.Size = new System.Drawing.Size(77, 22);
            this.txtTDec.TabIndex = 24;
            this.txtTDec.Text = "0.1";
            this.txtTDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkAbs
            // 
            this.chkAbs.AutoSize = true;
            this.chkAbs.Location = new System.Drawing.Point(84, 136);
            this.chkAbs.Name = "chkAbs";
            this.chkAbs.Size = new System.Drawing.Size(45, 16);
            this.chkAbs.TabIndex = 23;
            this.chkAbs.Text = "Abs.";
            this.chkAbs.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(147, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 12);
            this.label17.TabIndex = 22;
            this.label17.Text = "pls.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 12);
            this.label16.TabIndex = 21;
            this.label16.Text = "Dist.";
            // 
            // txtdist
            // 
            this.txtdist.Location = new System.Drawing.Point(64, 108);
            this.txtdist.Name = "txtdist";
            this.txtdist.Size = new System.Drawing.Size(77, 22);
            this.txtdist.TabIndex = 20;
            this.txtdist.Text = "100000";
            this.txtdist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(72, 18);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(84, 22);
            this.txtcommand.TabIndex = 21;
            this.txtcommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtfeedback
            // 
            this.txtfeedback.Location = new System.Drawing.Point(72, 40);
            this.txtfeedback.Name = "txtfeedback";
            this.txtfeedback.ReadOnly = true;
            this.txtfeedback.Size = new System.Drawing.Size(84, 22);
            this.txtfeedback.TabIndex = 22;
            this.txtfeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(72, 62);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.ReadOnly = true;
            this.txtspeed.Size = new System.Drawing.Size(84, 22);
            this.txtspeed.TabIndex = 23;
            this.txtspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmotion
            // 
            this.txtmotion.Location = new System.Drawing.Point(72, 106);
            this.txtmotion.Name = "txtmotion";
            this.txtmotion.ReadOnly = true;
            this.txtmotion.Size = new System.Drawing.Size(84, 22);
            this.txtmotion.TabIndex = 25;
            this.txtmotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Command";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Feedback";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Motion";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(160, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "pls.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "pls.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(160, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "pls.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.txtERR);
            this.groupBox2.Controls.Add(this.txt);
            this.groupBox2.Controls.Add(this.txtIO);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtmotion);
            this.groupBox2.Controls.Add(this.txtspeed);
            this.groupBox2.Controls.Add(this.txtfeedback);
            this.groupBox2.Controls.Add(this.txtcommand);
            this.groupBox2.Location = new System.Drawing.Point(203, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 158);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Motion";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(12, 131);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(30, 12);
            this.label31.TabIndex = 37;
            this.label31.Text = "Error";
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(72, 128);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(84, 22);
            this.txtERR.TabIndex = 36;
            this.txtERR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(12, 87);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(36, 12);
            this.txt.TabIndex = 35;
            this.txt.Text = "IO Sts.";
            // 
            // txtIO
            // 
            this.txtIO.Location = new System.Drawing.Point(72, 84);
            this.txtIO.Name = "txtIO";
            this.txtIO.ReadOnly = true;
            this.txtIO.Size = new System.Drawing.Size(84, 22);
            this.txtIO.TabIndex = 34;
            this.txtIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPmove
            // 
            this.btnPmove.Location = new System.Drawing.Point(350, 310);
            this.btnPmove.Name = "btnPmove";
            this.btnPmove.Size = new System.Drawing.Size(40, 32);
            this.btnPmove.TabIndex = 35;
            this.btnPmove.Text = "--->";
            this.btnPmove.UseVisualStyleBackColor = true;
            this.btnPmove.Click += new System.EventHandler(this.btnPmove_Click);
            // 
            // btnNmove
            // 
            this.btnNmove.Location = new System.Drawing.Point(219, 310);
            this.btnNmove.Name = "btnNmove";
            this.btnNmove.Size = new System.Drawing.Size(40, 32);
            this.btnNmove.TabIndex = 36;
            this.btnNmove.Text = "<---";
            this.btnNmove.UseVisualStyleBackColor = true;
            this.btnNmove.Click += new System.EventHandler(this.btnNmove_Click);
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(279, 19);
            this.txtSlaveNum.Name = "txtSlaveNum";
            this.txtSlaveNum.ReadOnly = true;
            this.txtSlaveNum.Size = new System.Drawing.Size(29, 22);
            this.txtSlaveNum.TabIndex = 55;
            this.txtSlaveNum.Text = "0";
            this.txtSlaveNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(108, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "Slave Num:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 12);
            this.label22.TabIndex = 70;
            this.label22.Text = "Node ID";
            // 
            // cmbnode
            // 
            this.cmbnode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnode.Enabled = false;
            this.cmbnode.FormattingEnabled = true;
            this.cmbnode.Location = new System.Drawing.Point(62, 17);
            this.cmbnode.Name = "cmbnode";
            this.cmbnode.Size = new System.Drawing.Size(39, 20);
            this.cmbnode.TabIndex = 71;
            this.cmbnode.SelectedIndexChanged += new System.EventHandler(this.cmbnode_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbnode);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.chktimer);
            this.groupBox3.Location = new System.Drawing.Point(14, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 52);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set node id";
            // 
            // radHigh
            // 
            this.radHigh.AutoSize = true;
            this.radHigh.Location = new System.Drawing.Point(53, 11);
            this.radHigh.Name = "radHigh";
            this.radHigh.Size = new System.Drawing.Size(76, 16);
            this.radHigh.TabIndex = 75;
            this.radHigh.Text = "High active";
            this.radHigh.UseVisualStyleBackColor = true;
            this.radHigh.CheckedChanged += new System.EventHandler(this.radHigh_CheckedChanged);
            // 
            // radLow
            // 
            this.radLow.AutoSize = true;
            this.radLow.Location = new System.Drawing.Point(53, 29);
            this.radLow.Name = "radLow";
            this.radLow.Size = new System.Drawing.Size(74, 16);
            this.radLow.TabIndex = 76;
            this.radLow.Text = "Low active";
            this.radLow.UseVisualStyleBackColor = true;
            this.radLow.CheckedChanged += new System.EventHandler(this.radLow_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 78;
            this.label19.Text = "SVON";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Location = new System.Drawing.Point(16, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 168);
            this.groupBox4.TabIndex = 79;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "04PI";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(80, 14);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(80, 28);
            this.btnSet.TabIndex = 79;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radHigh);
            this.groupBox7.Controls.Add(this.radLow);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Location = new System.Drawing.Point(7, 115);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(168, 47);
            this.groupBox7.TabIndex = 83;
            this.groupBox7.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radPDH);
            this.groupBox6.Controls.Add(this.radPDL);
            this.groupBox6.Controls.Add(this.btnSet);
            this.groupBox6.Controls.Add(this.radCW);
            this.groupBox6.Controls.Add(this.radAB);
            this.groupBox6.Location = new System.Drawing.Point(8, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(168, 100);
            this.groupBox6.TabIndex = 82;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Output Mode";
            // 
            // radCW
            // 
            this.radCW.AutoSize = true;
            this.radCW.Location = new System.Drawing.Point(4, 35);
            this.radCW.Name = "radCW";
            this.radCW.Size = new System.Drawing.Size(72, 16);
            this.radCW.TabIndex = 81;
            this.radCW.Text = "CW/CCW";
            this.radCW.UseVisualStyleBackColor = true;
            // 
            // radAB
            // 
            this.radAB.AutoSize = true;
            this.radAB.Location = new System.Drawing.Point(4, 14);
            this.radAB.Name = "radAB";
            this.radAB.Size = new System.Drawing.Size(68, 16);
            this.radAB.TabIndex = 80;
            this.radAB.Text = "AB Phase";
            this.radAB.UseVisualStyleBackColor = true;
            // 
            // txtIOsts0
            // 
            this.txtIOsts0.BackColor = System.Drawing.Color.DarkRed;
            this.txtIOsts0.Location = new System.Drawing.Point(53, 17);
            this.txtIOsts0.Name = "txtIOsts0";
            this.txtIOsts0.ReadOnly = true;
            this.txtIOsts0.Size = new System.Drawing.Size(34, 22);
            this.txtIOsts0.TabIndex = 81;
            // 
            // txtIOsts1
            // 
            this.txtIOsts1.BackColor = System.Drawing.Color.DarkRed;
            this.txtIOsts1.Location = new System.Drawing.Point(53, 39);
            this.txtIOsts1.Name = "txtIOsts1";
            this.txtIOsts1.ReadOnly = true;
            this.txtIOsts1.Size = new System.Drawing.Size(34, 22);
            this.txtIOsts1.TabIndex = 82;
            // 
            // txtIOsts2
            // 
            this.txtIOsts2.BackColor = System.Drawing.Color.DarkRed;
            this.txtIOsts2.Location = new System.Drawing.Point(53, 61);
            this.txtIOsts2.Name = "txtIOsts2";
            this.txtIOsts2.ReadOnly = true;
            this.txtIOsts2.Size = new System.Drawing.Size(34, 22);
            this.txtIOsts2.TabIndex = 83;
            // 
            // txtIOsts3
            // 
            this.txtIOsts3.BackColor = System.Drawing.Color.DarkRed;
            this.txtIOsts3.Location = new System.Drawing.Point(53, 83);
            this.txtIOsts3.Name = "txtIOsts3";
            this.txtIOsts3.ReadOnly = true;
            this.txtIOsts3.Size = new System.Drawing.Size(34, 22);
            this.txtIOsts3.TabIndex = 84;
            // 
            // txtIOsts4
            // 
            this.txtIOsts4.BackColor = System.Drawing.Color.DarkRed;
            this.txtIOsts4.Location = new System.Drawing.Point(53, 105);
            this.txtIOsts4.Name = "txtIOsts4";
            this.txtIOsts4.ReadOnly = true;
            this.txtIOsts4.Size = new System.Drawing.Size(34, 22);
            this.txtIOsts4.TabIndex = 85;
            // 
            // txtIOsts5
            // 
            this.txtIOsts5.BackColor = System.Drawing.Color.DarkRed;
            this.txtIOsts5.Location = new System.Drawing.Point(53, 127);
            this.txtIOsts5.Name = "txtIOsts5";
            this.txtIOsts5.ReadOnly = true;
            this.txtIOsts5.Size = new System.Drawing.Size(34, 22);
            this.txtIOsts5.TabIndex = 86;
            // 
            // txtIOsts6
            // 
            this.txtIOsts6.BackColor = System.Drawing.Color.DarkRed;
            this.txtIOsts6.Location = new System.Drawing.Point(53, 149);
            this.txtIOsts6.Name = "txtIOsts6";
            this.txtIOsts6.ReadOnly = true;
            this.txtIOsts6.Size = new System.Drawing.Size(34, 22);
            this.txtIOsts6.TabIndex = 87;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 12);
            this.label20.TabIndex = 88;
            this.label20.Text = "QZ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 89;
            this.label21.Text = "MEL";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(25, 12);
            this.label25.TabIndex = 90;
            this.label25.Text = "PEL";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 86);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 91;
            this.label26.Text = "ORG";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 108);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(26, 12);
            this.label27.TabIndex = 92;
            this.label27.Text = "SLD";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 130);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 12);
            this.label28.TabIndex = 93;
            this.label28.Text = "DI1";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 152);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 12);
            this.label29.TabIndex = 94;
            this.label29.Text = "DI2";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.txtIOsts6);
            this.groupBox5.Controls.Add(this.txtIOsts5);
            this.groupBox5.Controls.Add(this.txtIOsts4);
            this.groupBox5.Controls.Add(this.txtIOsts3);
            this.groupBox5.Controls.Add(this.txtIOsts2);
            this.groupBox5.Controls.Add(this.txtIOsts1);
            this.groupBox5.Controls.Add(this.txtIOsts0);
            this.groupBox5.Location = new System.Drawing.Point(406, 58);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(101, 186);
            this.groupBox5.TabIndex = 95;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "IO Status";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(411, 259);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(27, 12);
            this.label30.TabIndex = 96;
            this.label30.Text = "DO1";
            // 
            // txtDO1
            // 
            this.txtDO1.Location = new System.Drawing.Point(400, 286);
            this.txtDO1.Name = "txtDO1";
            this.txtDO1.ReadOnly = true;
            this.txtDO1.Size = new System.Drawing.Size(51, 22);
            this.txtDO1.TabIndex = 97;
            // 
            // txtDO2
            // 
            this.txtDO2.Location = new System.Drawing.Point(451, 286);
            this.txtDO2.Name = "txtDO2";
            this.txtDO2.ReadOnly = true;
            this.txtDO2.Size = new System.Drawing.Size(51, 22);
            this.txtDO2.TabIndex = 98;
            // 
            // chkDO2
            // 
            this.chkDO2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDO2.Location = new System.Drawing.Point(454, 250);
            this.chkDO2.Name = "chkDO2";
            this.chkDO2.Size = new System.Drawing.Size(40, 30);
            this.chkDO2.TabIndex = 99;
            this.chkDO2.Text = "DO2";
            this.chkDO2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDO2.UseVisualStyleBackColor = true;
            this.chkDO2.CheckedChanged += new System.EventHandler(this.chkDO2_CheckedChanged);
            // 
            // btnFindSlave
            // 
            this.btnFindSlave.Enabled = false;
            this.btnFindSlave.Location = new System.Drawing.Point(14, 28);
            this.btnFindSlave.Name = "btnFindSlave";
            this.btnFindSlave.Size = new System.Drawing.Size(83, 28);
            this.btnFindSlave.TabIndex = 100;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(156, 20);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(41, 20);
            this.CmbCardNo.TabIndex = 101;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // chkMEL
            // 
            this.chkMEL.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMEL.Location = new System.Drawing.Point(400, 312);
            this.chkMEL.Name = "chkMEL";
            this.chkMEL.Size = new System.Drawing.Size(48, 24);
            this.chkMEL.TabIndex = 102;
            this.chkMEL.Text = "MEL";
            this.chkMEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMEL.UseVisualStyleBackColor = true;
            this.chkMEL.CheckedChanged += new System.EventHandler(this.chkMEL_CheckedChanged);
            // 
            // chkPEL
            // 
            this.chkPEL.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPEL.Location = new System.Drawing.Point(456, 312);
            this.chkPEL.Name = "chkPEL";
            this.chkPEL.Size = new System.Drawing.Size(48, 24);
            this.chkPEL.TabIndex = 103;
            this.chkPEL.Text = "PEL";
            this.chkPEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPEL.UseVisualStyleBackColor = true;
            this.chkPEL.CheckedChanged += new System.EventHandler(this.chkPEL_CheckedChanged);
            // 
            // radPDL
            // 
            this.radPDL.AutoSize = true;
            this.radPDL.Location = new System.Drawing.Point(4, 57);
            this.radPDL.Name = "radPDL";
            this.radPDL.Size = new System.Drawing.Size(132, 16);
            this.radPDL.TabIndex = 82;
            this.radPDL.Text = "Pulse Direction DIR+ L";
            this.radPDL.UseVisualStyleBackColor = true;
            // 
            // radPDH
            // 
            this.radPDH.AutoSize = true;
            this.radPDH.Location = new System.Drawing.Point(4, 78);
            this.radPDH.Name = "radPDH";
            this.radPDH.Size = new System.Drawing.Size(133, 16);
            this.radPDH.TabIndex = 83;
            this.radPDH.Text = "Pulse Direction DIR+ H";
            this.radPDH.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 452);
            this.Controls.Add(this.chkPEL);
            this.Controls.Add(this.chkMEL);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.btnFindSlave);
            this.Controls.Add(this.chkDO2);
            this.Controls.Add(this.txtDO2);
            this.Controls.Add(this.txtDO1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSlaveNum);
            this.Controls.Add(this.btnNmove);
            this.Controls.Add(this.btnPmove);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnralm);
            this.Controls.Add(this.chksvon);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnstop);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btninitial);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninitial;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.CheckBox chksvon;
        private System.Windows.Forms.CheckBox chktimer;
        private System.Windows.Forms.Button btnralm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtStrVel;
        private System.Windows.Forms.TextBox txtMaxVel;
        private System.Windows.Forms.TextBox txtTAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSCurve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtcommand;
        private System.Windows.Forms.TextBox txtfeedback;
        private System.Windows.Forms.TextBox txtspeed;
        private System.Windows.Forms.TextBox txtmotion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPmove;
        private System.Windows.Forms.Button btnNmove;
        private System.Windows.Forms.TextBox txtSlaveNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkAbs;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtdist;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTDec;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.TextBox txtIO;
        private System.Windows.Forms.ComboBox cmbnode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radHigh;
        private System.Windows.Forms.RadioButton radLow;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIOsts0;
        private System.Windows.Forms.TextBox txtIOsts1;
        private System.Windows.Forms.TextBox txtIOsts2;
        private System.Windows.Forms.TextBox txtIOsts3;
        private System.Windows.Forms.TextBox txtIOsts4;
        private System.Windows.Forms.TextBox txtIOsts5;
        private System.Windows.Forms.TextBox txtIOsts6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtDO1;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtDO2;
        private System.Windows.Forms.CheckBox chkDO2;
        private System.Windows.Forms.RadioButton radCW;
        private System.Windows.Forms.RadioButton radAB;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.CheckBox chkMEL;
        private System.Windows.Forms.CheckBox chkPEL;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radPDH;
        private System.Windows.Forms.RadioButton radPDL;
    }
}

