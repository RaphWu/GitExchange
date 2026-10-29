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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTDec = new System.Windows.Forms.TextBox();
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
            this.label18 = new System.Windows.Forms.Label();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.txtIO = new System.Windows.Forms.TextBox();
            this.btnPmove = new System.Windows.Forms.Button();
            this.btnNmove = new System.Windows.Forms.Button();
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chkDebugEnable = new System.Windows.Forms.CheckBox();
            this.chkOuputFile = new System.Windows.Forms.CheckBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.cmbNodeID = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninitial
            // 
            this.btninitial.Location = new System.Drawing.Point(16, 0);
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
            this.btnreset.Location = new System.Drawing.Point(320, 296);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(79, 32);
            this.btnreset.TabIndex = 2;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnstop
            // 
            this.btnstop.Enabled = false;
            this.btnstop.Location = new System.Drawing.Point(278, 334);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(79, 32);
            this.btnstop.TabIndex = 3;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(18, 334);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(173, 31);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // chksvon
            // 
            this.chksvon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chksvon.Enabled = false;
            this.chksvon.Location = new System.Drawing.Point(110, 296);
            this.chksvon.Name = "chksvon";
            this.chksvon.Size = new System.Drawing.Size(79, 32);
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
            this.chktimer.Location = new System.Drawing.Point(18, 296);
            this.chktimer.Name = "chktimer";
            this.chktimer.Size = new System.Drawing.Size(79, 32);
            this.chktimer.TabIndex = 6;
            this.chktimer.Text = "Timer";
            this.chktimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chktimer.UseVisualStyleBackColor = true;
            // 
            // btnralm
            // 
            this.btnralm.Enabled = false;
            this.btnralm.Location = new System.Drawing.Point(236, 296);
            this.btnralm.Name = "btnralm";
            this.btnralm.Size = new System.Drawing.Size(78, 31);
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
            this.txtStrVel.Location = new System.Drawing.Point(64, 32);
            this.txtStrVel.Name = "txtStrVel";
            this.txtStrVel.Size = new System.Drawing.Size(77, 22);
            this.txtStrVel.TabIndex = 10;
            this.txtStrVel.Text = "100";
            this.txtStrVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxVel
            // 
            this.txtMaxVel.Location = new System.Drawing.Point(64, 54);
            this.txtMaxVel.Name = "txtMaxVel";
            this.txtMaxVel.Size = new System.Drawing.Size(77, 22);
            this.txtMaxVel.TabIndex = 11;
            this.txtMaxVel.Text = "50000";
            this.txtMaxVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTAcc
            // 
            this.txtTAcc.Location = new System.Drawing.Point(64, 76);
            this.txtTAcc.Name = "txtTAcc";
            this.txtTAcc.Size = new System.Drawing.Size(77, 22);
            this.txtTAcc.TabIndex = 12;
            this.txtTAcc.Text = "0.1";
            this.txtTAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "StrVel.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "MaxVel.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Acc.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "pps.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "pps.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "sec.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtTDec);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtdist);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTAcc);
            this.groupBox1.Controls.Add(this.txtMaxVel);
            this.groupBox1.Controls.Add(this.txtStrVel);
            this.groupBox1.Location = new System.Drawing.Point(16, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 159);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Vel. Prof.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 100);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 12);
            this.label24.TabIndex = 26;
            this.label24.Text = "Dec.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(147, 100);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(22, 12);
            this.label23.TabIndex = 25;
            this.label23.Text = "sec.";
            // 
            // txtTDec
            // 
            this.txtTDec.Location = new System.Drawing.Point(64, 98);
            this.txtTDec.Name = "txtTDec";
            this.txtTDec.Size = new System.Drawing.Size(77, 22);
            this.txtTDec.TabIndex = 24;
            this.txtTDec.Text = "0.1";
            this.txtTDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(147, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 12);
            this.label17.TabIndex = 22;
            this.label17.Text = "pls.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 12);
            this.label16.TabIndex = 21;
            this.label16.Text = "Dist.";
            // 
            // txtdist
            // 
            this.txtdist.Location = new System.Drawing.Point(64, 120);
            this.txtdist.Name = "txtdist";
            this.txtdist.Size = new System.Drawing.Size(77, 22);
            this.txtdist.TabIndex = 20;
            this.txtdist.Text = "100000";
            this.txtdist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(88, 19);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(84, 22);
            this.txtcommand.TabIndex = 21;
            this.txtcommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtfeedback
            // 
            this.txtfeedback.Location = new System.Drawing.Point(88, 41);
            this.txtfeedback.Name = "txtfeedback";
            this.txtfeedback.ReadOnly = true;
            this.txtfeedback.Size = new System.Drawing.Size(84, 22);
            this.txtfeedback.TabIndex = 22;
            this.txtfeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(88, 63);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.ReadOnly = true;
            this.txtspeed.Size = new System.Drawing.Size(84, 22);
            this.txtspeed.TabIndex = 23;
            this.txtspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmotion
            // 
            this.txtmotion.Location = new System.Drawing.Point(88, 107);
            this.txtmotion.Name = "txtmotion";
            this.txtmotion.ReadOnly = true;
            this.txtmotion.Size = new System.Drawing.Size(84, 22);
            this.txtmotion.TabIndex = 25;
            this.txtmotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Command";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Feedback";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Motion";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(176, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "pls.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "pls.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(176, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "pls.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
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
            this.groupBox2.Location = new System.Drawing.Point(205, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 159);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Motion";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 131);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 12);
            this.label18.TabIndex = 37;
            this.label18.Text = "Error";
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(88, 128);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(84, 22);
            this.txtERR.TabIndex = 36;
            this.txtERR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(28, 88);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(36, 12);
            this.txt.TabIndex = 35;
            this.txt.Text = "IO Sts.";
            // 
            // txtIO
            // 
            this.txtIO.Location = new System.Drawing.Point(88, 85);
            this.txtIO.Name = "txtIO";
            this.txtIO.ReadOnly = true;
            this.txtIO.Size = new System.Drawing.Size(84, 22);
            this.txtIO.TabIndex = 34;
            this.txtIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPmove
            // 
            this.btnPmove.Enabled = false;
            this.btnPmove.Location = new System.Drawing.Point(363, 334);
            this.btnPmove.Name = "btnPmove";
            this.btnPmove.Size = new System.Drawing.Size(40, 32);
            this.btnPmove.TabIndex = 35;
            this.btnPmove.Text = "--->";
            this.btnPmove.UseVisualStyleBackColor = true;
            this.btnPmove.Click += new System.EventHandler(this.btnPmove_Click);
            // 
            // btnNmove
            // 
            this.btnNmove.Enabled = false;
            this.btnNmove.Location = new System.Drawing.Point(232, 334);
            this.btnNmove.Name = "btnNmove";
            this.btnNmove.Size = new System.Drawing.Size(40, 32);
            this.btnNmove.TabIndex = 36;
            this.btnNmove.Text = "<---";
            this.btnNmove.UseVisualStyleBackColor = true;
            this.btnNmove.Click += new System.EventHandler(this.btnNmove_Click);
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(281, 17);
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
            this.label10.Location = new System.Drawing.Point(110, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(222, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "Slave Num:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(322, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(30, 12);
            this.label22.TabIndex = 70;
            this.label22.Text = "Node";
            // 
            // chkDebugEnable
            // 
            this.chkDebugEnable.AutoSize = true;
            this.chkDebugEnable.Enabled = false;
            this.chkDebugEnable.Location = new System.Drawing.Point(27, 17);
            this.chkDebugEnable.Name = "chkDebugEnable";
            this.chkDebugEnable.Size = new System.Drawing.Size(90, 16);
            this.chkDebugEnable.TabIndex = 72;
            this.chkDebugEnable.Text = "Debug Enable";
            this.chkDebugEnable.UseVisualStyleBackColor = true;
            this.chkDebugEnable.CheckedChanged += new System.EventHandler(this.chkDebugEnable_CheckedChanged);
            // 
            // chkOuputFile
            // 
            this.chkOuputFile.AutoSize = true;
            this.chkOuputFile.Enabled = false;
            this.chkOuputFile.Location = new System.Drawing.Point(292, 39);
            this.chkOuputFile.Name = "chkOuputFile";
            this.chkOuputFile.Size = new System.Drawing.Size(92, 16);
            this.chkOuputFile.TabIndex = 73;
            this.chkOuputFile.Text = "Output to dbg.";
            this.chkOuputFile.UseVisualStyleBackColor = true;
            this.chkOuputFile.CheckedChanged += new System.EventHandler(this.chkOuputFile_CheckedChanged);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(24, 36);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(251, 22);
            this.txtFilePath.TabIndex = 74;
            this.txtFilePath.Text = "C:\\log_output.txt";
            this.txtFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFilePath);
            this.groupBox3.Controls.Add(this.chkOuputFile);
            this.groupBox3.Controls.Add(this.chkDebugEnable);
            this.groupBox3.Location = new System.Drawing.Point(16, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 65);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Debug Log";
            // 
            // btnFindSlave
            // 
            this.btnFindSlave.Enabled = false;
            this.btnFindSlave.Location = new System.Drawing.Point(16, 28);
            this.btnFindSlave.Name = "btnFindSlave";
            this.btnFindSlave.Size = new System.Drawing.Size(83, 28);
            this.btnFindSlave.TabIndex = 76;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(158, 19);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(48, 20);
            this.CmbCardNo.TabIndex = 77;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // cmbNodeID
            // 
            this.cmbNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID.FormattingEnabled = true;
            this.cmbNodeID.Location = new System.Drawing.Point(360, 19);
            this.cmbNodeID.Name = "cmbNodeID";
            this.cmbNodeID.Size = new System.Drawing.Size(48, 20);
            this.cmbNodeID.TabIndex = 78;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 389);
            this.Controls.Add(this.cmbNodeID);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.btnFindSlave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSlaveNum);
            this.Controls.Add(this.btnNmove);
            this.Controls.Add(this.btnPmove);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnralm);
            this.Controls.Add(this.chktimer);
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtdist;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTDec;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.TextBox txtIO;
        private System.Windows.Forms.CheckBox chkDebugEnable;
        private System.Windows.Forms.CheckBox chkOuputFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.ComboBox cmbNodeID;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtERR;
    }
}

