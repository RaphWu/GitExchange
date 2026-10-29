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
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSCurve = new System.Windows.Forms.CheckBox();
            this.chkAbs = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDist = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDec = new System.Windows.Forms.TextBox();
            this.txtcommand = new System.Windows.Forms.TextBox();
            this.txtfeedback = new System.Windows.Forms.TextBox();
            this.txtspeed = new System.Windows.Forms.TextBox();
            this.txtmotion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtIO = new System.Windows.Forms.TextBox();
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.cmbNodeID = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdPMove = new System.Windows.Forms.Button();
            this.cmdNMove = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdSC = new System.Windows.Forms.Button();
            this.txtSC = new System.Windows.Forms.TextBox();
            this.cmbSC = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chkSC = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninitial
            // 
            this.btninitial.Location = new System.Drawing.Point(12, 0);
            this.btninitial.Name = "btninitial";
            this.btninitial.Size = new System.Drawing.Size(83, 28);
            this.btninitial.TabIndex = 0;
            this.btninitial.Text = "1-1 Open Card";
            this.btninitial.UseVisualStyleBackColor = true;
            this.btninitial.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // btnreset
            // 
            this.btnreset.Enabled = false;
            this.btnreset.Location = new System.Drawing.Point(8, 72);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(60, 51);
            this.btnreset.TabIndex = 2;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnstop
            // 
            this.btnstop.Enabled = false;
            this.btnstop.Location = new System.Drawing.Point(128, 16);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(60, 51);
            this.btnstop.TabIndex = 3;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(188, 72);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(60, 51);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // chksvon
            // 
            this.chksvon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chksvon.Enabled = false;
            this.chksvon.Location = new System.Drawing.Point(8, 16);
            this.chksvon.Name = "chksvon";
            this.chksvon.Size = new System.Drawing.Size(60, 51);
            this.chksvon.TabIndex = 5;
            this.chksvon.Text = "SVON";
            this.chksvon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chksvon.UseVisualStyleBackColor = true;
            this.chksvon.CheckedChanged += new System.EventHandler(this.chksvon_CheckedChanged);
            // 
            // chktimer
            // 
            this.chktimer.Location = new System.Drawing.Point(312, 24);
            this.chktimer.Name = "chktimer";
            this.chktimer.Size = new System.Drawing.Size(64, 24);
            this.chktimer.TabIndex = 6;
            this.chktimer.Text = "Timer";
            this.chktimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chktimer.UseVisualStyleBackColor = true;
            // 
            // btnralm
            // 
            this.btnralm.Enabled = false;
            this.btnralm.Location = new System.Drawing.Point(68, 72);
            this.btnralm.Name = "btnralm";
            this.btnralm.Size = new System.Drawing.Size(60, 51);
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
            this.txtStrVel.Location = new System.Drawing.Point(80, 16);
            this.txtStrVel.Name = "txtStrVel";
            this.txtStrVel.Size = new System.Drawing.Size(77, 22);
            this.txtStrVel.TabIndex = 10;
            this.txtStrVel.Text = "0";
            this.txtStrVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxVel
            // 
            this.txtMaxVel.Location = new System.Drawing.Point(80, 38);
            this.txtMaxVel.Name = "txtMaxVel";
            this.txtMaxVel.Size = new System.Drawing.Size(77, 22);
            this.txtMaxVel.TabIndex = 11;
            this.txtMaxVel.Text = "12800";
            this.txtMaxVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAcc
            // 
            this.txtAcc.Location = new System.Drawing.Point(80, 60);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(77, 22);
            this.txtAcc.TabIndex = 12;
            this.txtAcc.Text = "0.1";
            this.txtAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "StrVel.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "MaxVel.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Acc.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "pps.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "pps.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "sec.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSCurve);
            this.groupBox1.Controls.Add(this.chkAbs);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtDist);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtDec);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAcc);
            this.groupBox1.Controls.Add(this.txtMaxVel);
            this.groupBox1.Controls.Add(this.txtStrVel);
            this.groupBox1.Location = new System.Drawing.Point(8, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 160);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Vel. Prof.";
            // 
            // chkSCurve
            // 
            this.chkSCurve.AutoSize = true;
            this.chkSCurve.Location = new System.Drawing.Point(112, 136);
            this.chkSCurve.Name = "chkSCurve";
            this.chkSCurve.Size = new System.Drawing.Size(59, 16);
            this.chkSCurve.TabIndex = 26;
            this.chkSCurve.Text = "SCurve";
            this.chkSCurve.UseVisualStyleBackColor = true;
            this.chkSCurve.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkAbs
            // 
            this.chkAbs.AutoSize = true;
            this.chkAbs.Location = new System.Drawing.Point(48, 136);
            this.chkAbs.Name = "chkAbs";
            this.chkAbs.Size = new System.Drawing.Size(42, 16);
            this.chkAbs.TabIndex = 25;
            this.chkAbs.Text = "Abs";
            this.chkAbs.UseVisualStyleBackColor = true;
            this.chkAbs.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(163, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "pls.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 12);
            this.label18.TabIndex = 23;
            this.label18.Text = "Dist.";
            // 
            // txtDist
            // 
            this.txtDist.Location = new System.Drawing.Point(80, 108);
            this.txtDist.Name = "txtDist";
            this.txtDist.Size = new System.Drawing.Size(77, 22);
            this.txtDist.TabIndex = 22;
            this.txtDist.Text = "10000";
            this.txtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(163, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "sec.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "Dec.";
            // 
            // txtDec
            // 
            this.txtDec.Location = new System.Drawing.Point(80, 84);
            this.txtDec.Name = "txtDec";
            this.txtDec.Size = new System.Drawing.Size(77, 22);
            this.txtDec.TabIndex = 19;
            this.txtDec.Text = "0.1";
            this.txtDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(72, 16);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(84, 22);
            this.txtcommand.TabIndex = 21;
            this.txtcommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtfeedback
            // 
            this.txtfeedback.Location = new System.Drawing.Point(72, 38);
            this.txtfeedback.Name = "txtfeedback";
            this.txtfeedback.ReadOnly = true;
            this.txtfeedback.Size = new System.Drawing.Size(84, 22);
            this.txtfeedback.TabIndex = 22;
            this.txtfeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(72, 60);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.ReadOnly = true;
            this.txtspeed.Size = new System.Drawing.Size(84, 22);
            this.txtspeed.TabIndex = 23;
            this.txtspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmotion
            // 
            this.txtmotion.Location = new System.Drawing.Point(72, 104);
            this.txtmotion.Name = "txtmotion";
            this.txtmotion.ReadOnly = true;
            this.txtmotion.Size = new System.Drawing.Size(84, 22);
            this.txtmotion.TabIndex = 25;
            this.txtmotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Command";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Feedback";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Motion";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtERR);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtIO);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtmotion);
            this.groupBox2.Controls.Add(this.txtspeed);
            this.groupBox2.Controls.Add(this.txtfeedback);
            this.groupBox2.Controls.Add(this.txtcommand);
            this.groupBox2.Location = new System.Drawing.Point(224, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 160);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 130);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 12);
            this.label19.TabIndex = 37;
            this.label19.Text = "Error";
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(72, 127);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(84, 22);
            this.txtERR.TabIndex = 36;
            this.txtERR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 12);
            this.label16.TabIndex = 35;
            this.label16.Text = "IO Sts.";
            // 
            // txtIO
            // 
            this.txtIO.Location = new System.Drawing.Point(72, 82);
            this.txtIO.Name = "txtIO";
            this.txtIO.ReadOnly = true;
            this.txtIO.Size = new System.Drawing.Size(84, 22);
            this.txtIO.TabIndex = 34;
            this.txtIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(272, 8);
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
            this.label10.Location = new System.Drawing.Point(103, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(210, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "Slave Num:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(104, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 12);
            this.label22.TabIndex = 70;
            this.label22.Text = "NodeID:";
            // 
            // btnFindSlave
            // 
            this.btnFindSlave.Enabled = false;
            this.btnFindSlave.Location = new System.Drawing.Point(12, 28);
            this.btnFindSlave.Name = "btnFindSlave";
            this.btnFindSlave.Size = new System.Drawing.Size(83, 28);
            this.btnFindSlave.TabIndex = 73;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(152, 8);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(47, 20);
            this.CmbCardNo.TabIndex = 74;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // cmbNodeID
            // 
            this.cmbNodeID.FormattingEnabled = true;
            this.cmbNodeID.Location = new System.Drawing.Point(152, 36);
            this.cmbNodeID.Name = "cmbNodeID";
            this.cmbNodeID.Size = new System.Drawing.Size(47, 20);
            this.cmbNodeID.TabIndex = 75;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(228, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 77;
            this.label17.Text = "Slot ID:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(272, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(29, 22);
            this.textBox1.TabIndex = 76;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdPMove);
            this.groupBox3.Controls.Add(this.cmdNMove);
            this.groupBox3.Controls.Add(this.btnexit);
            this.groupBox3.Controls.Add(this.btnstop);
            this.groupBox3.Controls.Add(this.chksvon);
            this.groupBox3.Controls.Add(this.btnreset);
            this.groupBox3.Controls.Add(this.btnralm);
            this.groupBox3.Location = new System.Drawing.Point(136, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 128);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            // 
            // cmdPMove
            // 
            this.cmdPMove.Enabled = false;
            this.cmdPMove.Location = new System.Drawing.Point(188, 16);
            this.cmdPMove.Name = "cmdPMove";
            this.cmdPMove.Size = new System.Drawing.Size(60, 51);
            this.cmdPMove.TabIndex = 6;
            this.cmdPMove.Text = "-->";
            this.cmdPMove.UseVisualStyleBackColor = true;
            this.cmdPMove.Click += new System.EventHandler(this.cmdPMove_Click);
            // 
            // cmdNMove
            // 
            this.cmdNMove.Enabled = false;
            this.cmdNMove.Location = new System.Drawing.Point(68, 16);
            this.cmdNMove.Name = "cmdNMove";
            this.cmdNMove.Size = new System.Drawing.Size(60, 51);
            this.cmdNMove.TabIndex = 5;
            this.cmdNMove.Text = "<--";
            this.cmdNMove.UseVisualStyleBackColor = true;
            this.cmdNMove.Click += new System.EventHandler(this.cmdNMove_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdSC);
            this.groupBox4.Controls.Add(this.txtSC);
            this.groupBox4.Controls.Add(this.cmbSC);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.chkSC);
            this.groupBox4.Location = new System.Drawing.Point(8, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 128);
            this.groupBox4.TabIndex = 79;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Speed Continue";
            // 
            // cmdSC
            // 
            this.cmdSC.Enabled = false;
            this.cmdSC.Location = new System.Drawing.Point(24, 96);
            this.cmdSC.Name = "cmdSC";
            this.cmdSC.Size = new System.Drawing.Size(75, 23);
            this.cmdSC.TabIndex = 6;
            this.cmdSC.Text = "SET";
            this.cmdSC.UseVisualStyleBackColor = true;
            this.cmdSC.Click += new System.EventHandler(this.cmdSC_Click);
            // 
            // txtSC
            // 
            this.txtSC.Location = new System.Drawing.Point(40, 64);
            this.txtSC.Name = "txtSC";
            this.txtSC.Size = new System.Drawing.Size(48, 22);
            this.txtSC.TabIndex = 5;
            this.txtSC.Text = "100";
            // 
            // cmbSC
            // 
            this.cmbSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSC.FormattingEnabled = true;
            this.cmbSC.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cmbSC.Location = new System.Drawing.Point(40, 40);
            this.cmbSC.Name = "cmbSC";
            this.cmbSC.Size = new System.Drawing.Size(56, 20);
            this.cmbSC.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(88, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(14, 12);
            this.label23.TabIndex = 3;
            this.label23.Text = "%";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 12);
            this.label21.TabIndex = 2;
            this.label21.Text = "Ratio";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 12);
            this.label20.TabIndex = 1;
            this.label20.Text = "Mode";
            // 
            // chkSC
            // 
            this.chkSC.AutoSize = true;
            this.chkSC.Enabled = false;
            this.chkSC.Location = new System.Drawing.Point(32, 16);
            this.chkSC.Name = "chkSC";
            this.chkSC.Size = new System.Drawing.Size(56, 16);
            this.chkSC.TabIndex = 0;
            this.chkSC.Text = "Enable";
            this.chkSC.UseVisualStyleBackColor = true;
            this.chkSC.CheckedChanged += new System.EventHandler(this.chkSC_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 366);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbNodeID);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.chktimer);
            this.Controls.Add(this.btnFindSlave);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSlaveNum);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btninitial);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtcommand;
        private System.Windows.Forms.TextBox txtfeedback;
        private System.Windows.Forms.TextBox txtspeed;
        private System.Windows.Forms.TextBox txtmotion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSlaveNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtIO;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.ComboBox cmbNodeID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDist;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDec;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdPMove;
        private System.Windows.Forms.Button cmdNMove;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkSC;
        private System.Windows.Forms.Button cmdSC;
        private System.Windows.Forms.TextBox txtSC;
        private System.Windows.Forms.ComboBox cmbSC;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkSCurve;
        private System.Windows.Forms.CheckBox chkAbs;
    }
}

