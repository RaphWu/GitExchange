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
            this.label27 = new System.Windows.Forms.Label();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtIO = new System.Windows.Forms.TextBox();
            this.btnPmove = new System.Windows.Forms.Button();
            this.btnNmove = new System.Windows.Forms.Button();
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbNodeID = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtInt = new System.Windows.Forms.TextBox();
            this.chkInt = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninitial
            // 
            this.btninitial.Location = new System.Drawing.Point(12, 0);
            this.btninitial.Name = "btninitial";
            this.btninitial.Size = new System.Drawing.Size(87, 28);
            this.btninitial.TabIndex = 0;
            this.btninitial.Text = "1-1 Open Card";
            this.btninitial.UseVisualStyleBackColor = true;
            this.btninitial.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // btnreset
            // 
            this.btnreset.Enabled = false;
            this.btnreset.Location = new System.Drawing.Point(152, 88);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(40, 56);
            this.btnreset.TabIndex = 2;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnstop
            // 
            this.btnstop.Enabled = false;
            this.btnstop.Location = new System.Drawing.Point(240, 336);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(75, 40);
            this.btnstop.TabIndex = 3;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(16, 376);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(376, 31);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // chksvon
            // 
            this.chksvon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chksvon.Enabled = false;
            this.chksvon.Location = new System.Drawing.Point(15, 336);
            this.chksvon.Name = "chksvon";
            this.chksvon.Size = new System.Drawing.Size(75, 40);
            this.chksvon.TabIndex = 5;
            this.chksvon.Text = "SVON";
            this.chksvon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chksvon.UseVisualStyleBackColor = true;
            this.chksvon.CheckedChanged += new System.EventHandler(this.chksvon_CheckedChanged);
            // 
            // chktimer
            // 
            this.chktimer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chktimer.Enabled = false;
            this.chktimer.Location = new System.Drawing.Point(112, 24);
            this.chktimer.Name = "chktimer";
            this.chktimer.Size = new System.Drawing.Size(64, 32);
            this.chktimer.TabIndex = 6;
            this.chktimer.Text = "Timer";
            this.chktimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chktimer.UseVisualStyleBackColor = true;
            // 
            // btnralm
            // 
            this.btnralm.Enabled = false;
            this.btnralm.Location = new System.Drawing.Point(90, 336);
            this.btnralm.Name = "btnralm";
            this.btnralm.Size = new System.Drawing.Size(75, 40);
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
            this.chkSCurve.Location = new System.Drawing.Point(24, 16);
            this.chkSCurve.Name = "chkSCurve";
            this.chkSCurve.Size = new System.Drawing.Size(63, 16);
            this.chkSCurve.TabIndex = 19;
            this.chkSCurve.Text = "S-Curve";
            this.chkSCurve.UseVisualStyleBackColor = true;
            this.chkSCurve.CheckedChanged += new System.EventHandler(this.chkSCurve_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtTDec);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTAcc);
            this.groupBox1.Controls.Add(this.txtMaxVel);
            this.groupBox1.Controls.Add(this.txtStrVel);
            this.groupBox1.Location = new System.Drawing.Point(8, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 120);
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
            this.chkAbs.Location = new System.Drawing.Point(95, 16);
            this.chkAbs.Name = "chkAbs";
            this.chkAbs.Size = new System.Drawing.Size(45, 16);
            this.chkAbs.TabIndex = 23;
            this.chkAbs.Text = "Abs.";
            this.chkAbs.UseVisualStyleBackColor = true;
            this.chkAbs.CheckedChanged += new System.EventHandler(this.chkAbs_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(120, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 12);
            this.label17.TabIndex = 22;
            this.label17.Text = "pls.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 12);
            this.label16.TabIndex = 21;
            this.label16.Text = "Dist.";
            // 
            // txtdist
            // 
            this.txtdist.Location = new System.Drawing.Point(40, 40);
            this.txtdist.Name = "txtdist";
            this.txtdist.Size = new System.Drawing.Size(77, 22);
            this.txtdist.TabIndex = 20;
            this.txtdist.Text = "100000";
            this.txtdist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(68, 13);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(76, 22);
            this.txtcommand.TabIndex = 21;
            this.txtcommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtfeedback
            // 
            this.txtfeedback.Location = new System.Drawing.Point(68, 35);
            this.txtfeedback.Name = "txtfeedback";
            this.txtfeedback.ReadOnly = true;
            this.txtfeedback.Size = new System.Drawing.Size(76, 22);
            this.txtfeedback.TabIndex = 22;
            this.txtfeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(68, 57);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.ReadOnly = true;
            this.txtspeed.Size = new System.Drawing.Size(76, 22);
            this.txtspeed.TabIndex = 23;
            this.txtspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmotion
            // 
            this.txtmotion.Location = new System.Drawing.Point(68, 104);
            this.txtmotion.Name = "txtmotion";
            this.txtmotion.ReadOnly = true;
            this.txtmotion.Size = new System.Drawing.Size(76, 22);
            this.txtmotion.TabIndex = 25;
            this.txtmotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Command";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Feedback";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Motion";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "pls.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "pls.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(144, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "pps.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.txtERR);
            this.groupBox2.Controls.Add(this.label26);
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
            this.groupBox2.Controls.Add(this.btnreset);
            this.groupBox2.Location = new System.Drawing.Point(200, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 160);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(20, 131);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(30, 12);
            this.label27.TabIndex = 37;
            this.label27.Text = "Error";
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(68, 128);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(76, 22);
            this.txtERR.TabIndex = 36;
            this.txtERR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 83);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 12);
            this.label26.TabIndex = 35;
            this.label26.Text = "IO Status";
            // 
            // txtIO
            // 
            this.txtIO.Location = new System.Drawing.Point(68, 80);
            this.txtIO.Name = "txtIO";
            this.txtIO.ReadOnly = true;
            this.txtIO.Size = new System.Drawing.Size(76, 22);
            this.txtIO.TabIndex = 34;
            this.txtIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPmove
            // 
            this.btnPmove.Enabled = false;
            this.btnPmove.Location = new System.Drawing.Point(315, 336);
            this.btnPmove.Name = "btnPmove";
            this.btnPmove.Size = new System.Drawing.Size(75, 40);
            this.btnPmove.TabIndex = 35;
            this.btnPmove.Text = "--->";
            this.btnPmove.UseVisualStyleBackColor = true;
            this.btnPmove.Click += new System.EventHandler(this.btnPmove_Click);
            // 
            // btnNmove
            // 
            this.btnNmove.Enabled = false;
            this.btnNmove.Location = new System.Drawing.Point(165, 336);
            this.btnNmove.Name = "btnNmove";
            this.btnNmove.Size = new System.Drawing.Size(75, 40);
            this.btnNmove.TabIndex = 36;
            this.btnNmove.Text = "<---";
            this.btnNmove.UseVisualStyleBackColor = true;
            this.btnNmove.Click += new System.EventHandler(this.btnNmove_Click);
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(277, 19);
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
            this.label10.Location = new System.Drawing.Point(106, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(218, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "Slave Num:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 12);
            this.label22.TabIndex = 70;
            this.label22.Text = "NodeID";
            // 
            // btnFindSlave
            // 
            this.btnFindSlave.Enabled = false;
            this.btnFindSlave.Location = new System.Drawing.Point(12, 28);
            this.btnFindSlave.Name = "btnFindSlave";
            this.btnFindSlave.Size = new System.Drawing.Size(87, 28);
            this.btnFindSlave.TabIndex = 72;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(154, 19);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(43, 20);
            this.CmbCardNo.TabIndex = 73;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.cmbNodeID);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.chktimer);
            this.groupBox3.Location = new System.Drawing.Point(8, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 72);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Node ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(32, 22);
            this.textBox1.TabIndex = 73;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbNodeID
            // 
            this.cmbNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID.FormattingEnabled = true;
            this.cmbNodeID.Location = new System.Drawing.Point(16, 40);
            this.cmbNodeID.Name = "cmbNodeID";
            this.cmbNodeID.Size = new System.Drawing.Size(40, 20);
            this.cmbNodeID.TabIndex = 72;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(64, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 12);
            this.label25.TabIndex = 71;
            this.label25.Text = "SlotID";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtdist);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.chkAbs);
            this.groupBox6.Controls.Add(this.chkSCurve);
            this.groupBox6.Location = new System.Drawing.Point(8, 256);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(184, 72);
            this.groupBox6.TabIndex = 75;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Set Distance";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtInt);
            this.groupBox4.Controls.Add(this.chkInt);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(200, 224);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 76;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Normal Stop Interrupt";
            // 
            // txtInt
            // 
            this.txtInt.Location = new System.Drawing.Point(120, 27);
            this.txtInt.Name = "txtInt";
            this.txtInt.ReadOnly = true;
            this.txtInt.Size = new System.Drawing.Size(64, 22);
            this.txtInt.TabIndex = 2;
            this.txtInt.Text = "0";
            // 
            // chkInt
            // 
            this.chkInt.AutoSize = true;
            this.chkInt.Location = new System.Drawing.Point(72, 64);
            this.chkInt.Name = "chkInt";
            this.chkInt.Size = new System.Drawing.Size(56, 16);
            this.chkInt.TabIndex = 1;
            this.chkInt.Text = "Enable";
            this.chkInt.UseVisualStyleBackColor = true;
            this.chkInt.CheckedChanged += new System.EventHandler(this.chkInt_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "Normal Stop Counter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 417);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.btnFindSlave);
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
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtIO;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbNodeID;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.CheckBox chkInt;
        private System.Windows.Forms.Label label18;
    }
}

