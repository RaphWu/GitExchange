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
            this.btnexit = new System.Windows.Forms.Button();
            this.chksvon = new System.Windows.Forms.CheckBox();
            this.chktimer = new System.Windows.Forms.CheckBox();
            this.btnralm = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIO = new System.Windows.Forms.TextBox();
            this.txtStatus0 = new System.Windows.Forms.TextBox();
            this.txtStatus1 = new System.Windows.Forms.TextBox();
            this.txtStatus2 = new System.Windows.Forms.TextBox();
            this.txtStatus3 = new System.Windows.Forms.TextBox();
            this.txtStatus4 = new System.Windows.Forms.TextBox();
            this.txtStatus5 = new System.Windows.Forms.TextBox();
            this.txtStatus6 = new System.Windows.Forms.TextBox();
            this.txtStatus7 = new System.Windows.Forms.TextBox();
            this.txtStatus15 = new System.Windows.Forms.TextBox();
            this.txtStatus14 = new System.Windows.Forms.TextBox();
            this.txtStatus13 = new System.Windows.Forms.TextBox();
            this.txtStatus12 = new System.Windows.Forms.TextBox();
            this.txtStatus11 = new System.Windows.Forms.TextBox();
            this.txtStatus10 = new System.Windows.Forms.TextBox();
            this.txtStatus9 = new System.Windows.Forms.TextBox();
            this.txtStatus8 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbNodeID = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMNID = new System.Windows.Forms.ComboBox();
            this.cmbplsratio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRatio = new System.Windows.Forms.TextBox();
            this.txtSlope = new System.Windows.Forms.TextBox();
            this.chkMPG = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkJog = new System.Windows.Forms.CheckBox();
            this.cmbJogMode = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtJogspeed = new System.Windows.Forms.TextBox();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDen = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.btnreset.Location = new System.Drawing.Point(328, 48);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(51, 32);
            this.btnreset.TabIndex = 2;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(400, 21);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(84, 31);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // chksvon
            // 
            this.chksvon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chksvon.Location = new System.Drawing.Point(179, 21);
            this.chksvon.Name = "chksvon";
            this.chksvon.Size = new System.Drawing.Size(50, 32);
            this.chksvon.TabIndex = 5;
            this.chksvon.Text = "SVON";
            this.chksvon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chksvon.UseVisualStyleBackColor = true;
            this.chksvon.CheckedChanged += new System.EventHandler(this.chksvon_CheckedChanged);
            // 
            // chktimer
            // 
            this.chktimer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chktimer.Location = new System.Drawing.Point(13, 21);
            this.chktimer.Name = "chktimer";
            this.chktimer.Size = new System.Drawing.Size(48, 32);
            this.chktimer.TabIndex = 6;
            this.chktimer.Text = "Timer";
            this.chktimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chktimer.UseVisualStyleBackColor = true;
            // 
            // btnralm
            // 
            this.btnralm.Location = new System.Drawing.Point(328, 16);
            this.btnralm.Name = "btnralm";
            this.btnralm.Size = new System.Drawing.Size(51, 32);
            this.btnralm.TabIndex = 7;
            this.btnralm.Text = "RALM";
            this.btnralm.UseVisualStyleBackColor = true;
            this.btnralm.Click += new System.EventHandler(this.btnralm_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(66, 15);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(84, 22);
            this.txtcommand.TabIndex = 21;
            this.txtcommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtfeedback
            // 
            this.txtfeedback.Location = new System.Drawing.Point(66, 37);
            this.txtfeedback.Name = "txtfeedback";
            this.txtfeedback.ReadOnly = true;
            this.txtfeedback.Size = new System.Drawing.Size(84, 22);
            this.txtfeedback.TabIndex = 22;
            this.txtfeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(66, 59);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.ReadOnly = true;
            this.txtspeed.Size = new System.Drawing.Size(84, 22);
            this.txtspeed.TabIndex = 23;
            this.txtspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmotion
            // 
            this.txtmotion.Location = new System.Drawing.Point(230, 37);
            this.txtmotion.Name = "txtmotion";
            this.txtmotion.ReadOnly = true;
            this.txtmotion.Size = new System.Drawing.Size(84, 22);
            this.txtmotion.TabIndex = 25;
            this.txtmotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Command";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Feedback";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(185, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Motion";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(156, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "pls.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(156, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "pls.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(156, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "pls.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtERR);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtIO);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnralm);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtmotion);
            this.groupBox2.Controls.Add(this.btnreset);
            this.groupBox2.Controls.Add(this.txtspeed);
            this.groupBox2.Controls.Add(this.txtfeedback);
            this.groupBox2.Controls.Add(this.txtcommand);
            this.groupBox2.Location = new System.Drawing.Point(8, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 91);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servo status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "IO Sts.";
            // 
            // txtIO
            // 
            this.txtIO.Location = new System.Drawing.Point(230, 15);
            this.txtIO.Name = "txtIO";
            this.txtIO.ReadOnly = true;
            this.txtIO.Size = new System.Drawing.Size(84, 22);
            this.txtIO.TabIndex = 34;
            this.txtIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStatus0
            // 
            this.txtStatus0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus0.Location = new System.Drawing.Point(16, 20);
            this.txtStatus0.Name = "txtStatus0";
            this.txtStatus0.ReadOnly = true;
            this.txtStatus0.Size = new System.Drawing.Size(25, 22);
            this.txtStatus0.TabIndex = 37;
            this.txtStatus0.Text = " ";
            this.txtStatus0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus1
            // 
            this.txtStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus1.Location = new System.Drawing.Point(16, 42);
            this.txtStatus1.Name = "txtStatus1";
            this.txtStatus1.ReadOnly = true;
            this.txtStatus1.Size = new System.Drawing.Size(25, 22);
            this.txtStatus1.TabIndex = 38;
            this.txtStatus1.Text = " ";
            this.txtStatus1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus2
            // 
            this.txtStatus2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus2.Location = new System.Drawing.Point(16, 64);
            this.txtStatus2.Name = "txtStatus2";
            this.txtStatus2.ReadOnly = true;
            this.txtStatus2.Size = new System.Drawing.Size(25, 22);
            this.txtStatus2.TabIndex = 39;
            this.txtStatus2.Text = " ";
            this.txtStatus2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus3
            // 
            this.txtStatus3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus3.Location = new System.Drawing.Point(16, 86);
            this.txtStatus3.Name = "txtStatus3";
            this.txtStatus3.ReadOnly = true;
            this.txtStatus3.Size = new System.Drawing.Size(25, 22);
            this.txtStatus3.TabIndex = 40;
            this.txtStatus3.Text = " ";
            this.txtStatus3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus4
            // 
            this.txtStatus4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus4.Location = new System.Drawing.Point(16, 108);
            this.txtStatus4.Name = "txtStatus4";
            this.txtStatus4.ReadOnly = true;
            this.txtStatus4.Size = new System.Drawing.Size(25, 22);
            this.txtStatus4.TabIndex = 41;
            this.txtStatus4.Text = " ";
            this.txtStatus4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus5
            // 
            this.txtStatus5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus5.Location = new System.Drawing.Point(16, 130);
            this.txtStatus5.Name = "txtStatus5";
            this.txtStatus5.ReadOnly = true;
            this.txtStatus5.Size = new System.Drawing.Size(25, 22);
            this.txtStatus5.TabIndex = 42;
            this.txtStatus5.Text = " ";
            this.txtStatus5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus6
            // 
            this.txtStatus6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus6.Location = new System.Drawing.Point(16, 152);
            this.txtStatus6.Name = "txtStatus6";
            this.txtStatus6.ReadOnly = true;
            this.txtStatus6.Size = new System.Drawing.Size(25, 22);
            this.txtStatus6.TabIndex = 43;
            this.txtStatus6.Text = " ";
            this.txtStatus6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus7
            // 
            this.txtStatus7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus7.Location = new System.Drawing.Point(16, 174);
            this.txtStatus7.Name = "txtStatus7";
            this.txtStatus7.ReadOnly = true;
            this.txtStatus7.Size = new System.Drawing.Size(25, 22);
            this.txtStatus7.TabIndex = 44;
            this.txtStatus7.Text = " ";
            this.txtStatus7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus15
            // 
            this.txtStatus15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus15.Location = new System.Drawing.Point(41, 174);
            this.txtStatus15.Name = "txtStatus15";
            this.txtStatus15.ReadOnly = true;
            this.txtStatus15.Size = new System.Drawing.Size(24, 22);
            this.txtStatus15.TabIndex = 52;
            this.txtStatus15.Text = " ";
            this.txtStatus15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus14
            // 
            this.txtStatus14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus14.Location = new System.Drawing.Point(41, 152);
            this.txtStatus14.Name = "txtStatus14";
            this.txtStatus14.ReadOnly = true;
            this.txtStatus14.Size = new System.Drawing.Size(24, 22);
            this.txtStatus14.TabIndex = 51;
            this.txtStatus14.Text = " ";
            this.txtStatus14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus13
            // 
            this.txtStatus13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus13.Location = new System.Drawing.Point(41, 130);
            this.txtStatus13.Name = "txtStatus13";
            this.txtStatus13.ReadOnly = true;
            this.txtStatus13.Size = new System.Drawing.Size(24, 22);
            this.txtStatus13.TabIndex = 50;
            this.txtStatus13.Text = " ";
            this.txtStatus13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus12
            // 
            this.txtStatus12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus12.Location = new System.Drawing.Point(41, 108);
            this.txtStatus12.Name = "txtStatus12";
            this.txtStatus12.ReadOnly = true;
            this.txtStatus12.Size = new System.Drawing.Size(24, 22);
            this.txtStatus12.TabIndex = 49;
            this.txtStatus12.Text = " ";
            this.txtStatus12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus11
            // 
            this.txtStatus11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus11.Location = new System.Drawing.Point(41, 86);
            this.txtStatus11.Name = "txtStatus11";
            this.txtStatus11.ReadOnly = true;
            this.txtStatus11.Size = new System.Drawing.Size(24, 22);
            this.txtStatus11.TabIndex = 48;
            this.txtStatus11.Text = " ";
            this.txtStatus11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus10
            // 
            this.txtStatus10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus10.Location = new System.Drawing.Point(41, 64);
            this.txtStatus10.Name = "txtStatus10";
            this.txtStatus10.ReadOnly = true;
            this.txtStatus10.Size = new System.Drawing.Size(24, 22);
            this.txtStatus10.TabIndex = 47;
            this.txtStatus10.Text = " ";
            this.txtStatus10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus9
            // 
            this.txtStatus9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus9.Location = new System.Drawing.Point(41, 42);
            this.txtStatus9.Name = "txtStatus9";
            this.txtStatus9.ReadOnly = true;
            this.txtStatus9.Size = new System.Drawing.Size(24, 22);
            this.txtStatus9.TabIndex = 46;
            this.txtStatus9.Text = " ";
            this.txtStatus9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatus8
            // 
            this.txtStatus8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStatus8.Location = new System.Drawing.Point(41, 20);
            this.txtStatus8.Name = "txtStatus8";
            this.txtStatus8.ReadOnly = true;
            this.txtStatus8.Size = new System.Drawing.Size(24, 22);
            this.txtStatus8.TabIndex = 45;
            this.txtStatus8.Text = " ";
            this.txtStatus8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtStatus15);
            this.groupBox3.Controls.Add(this.txtStatus14);
            this.groupBox3.Controls.Add(this.txtStatus13);
            this.groupBox3.Controls.Add(this.txtStatus12);
            this.groupBox3.Controls.Add(this.txtStatus11);
            this.groupBox3.Controls.Add(this.txtStatus10);
            this.groupBox3.Controls.Add(this.txtStatus9);
            this.groupBox3.Controls.Add(this.txtStatus8);
            this.groupBox3.Controls.Add(this.txtStatus7);
            this.groupBox3.Controls.Add(this.txtStatus6);
            this.groupBox3.Controls.Add(this.txtStatus5);
            this.groupBox3.Controls.Add(this.txtStatus4);
            this.groupBox3.Controls.Add(this.txtStatus3);
            this.groupBox3.Controls.Add(this.txtStatus2);
            this.groupBox3.Controls.Add(this.txtStatus1);
            this.groupBox3.Controls.Add(this.txtStatus0);
            this.groupBox3.Location = new System.Drawing.Point(400, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(84, 209);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RM IO Status";
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(271, 19);
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
            this.label10.Location = new System.Drawing.Point(102, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(211, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "Slave Num:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(66, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 12);
            this.label16.TabIndex = 58;
            this.label16.Text = "Node";
            // 
            // cmbNodeID
            // 
            this.cmbNodeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID.Enabled = false;
            this.cmbNodeID.FormattingEnabled = true;
            this.cmbNodeID.Location = new System.Drawing.Point(104, 28);
            this.cmbNodeID.Name = "cmbNodeID";
            this.cmbNodeID.Size = new System.Drawing.Size(40, 20);
            this.cmbNodeID.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNodeID);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.chktimer);
            this.groupBox1.Controls.Add(this.chksvon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbMNID);
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 73);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2-1. Set servo node id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "MN ID";
            // 
            // cmbMNID
            // 
            this.cmbMNID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMNID.FormattingEnabled = true;
            this.cmbMNID.Location = new System.Drawing.Point(300, 28);
            this.cmbMNID.Name = "cmbMNID";
            this.cmbMNID.Size = new System.Drawing.Size(40, 20);
            this.cmbMNID.TabIndex = 62;
            // 
            // cmbplsratio
            // 
            this.cmbplsratio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbplsratio.FormattingEnabled = true;
            this.cmbplsratio.Items.AddRange(new object[] {
            "1",
            "4"});
            this.cmbplsratio.Location = new System.Drawing.Point(96, 88);
            this.cmbplsratio.Name = "cmbplsratio";
            this.cmbplsratio.Size = new System.Drawing.Size(40, 20);
            this.cmbplsratio.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 63;
            this.label3.Text = "pulse ratio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 65;
            this.label4.Text = "Ratio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 12);
            this.label5.TabIndex = 66;
            this.label5.Text = "Slope";
            // 
            // txtRatio
            // 
            this.txtRatio.Location = new System.Drawing.Point(47, 21);
            this.txtRatio.Name = "txtRatio";
            this.txtRatio.Size = new System.Drawing.Size(38, 22);
            this.txtRatio.TabIndex = 67;
            this.txtRatio.Text = "1";
            this.txtRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSlope
            // 
            this.txtSlope.Location = new System.Drawing.Point(47, 51);
            this.txtSlope.Name = "txtSlope";
            this.txtSlope.Size = new System.Drawing.Size(38, 22);
            this.txtSlope.TabIndex = 68;
            this.txtSlope.Text = "500";
            this.txtSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkMPG
            // 
            this.chkMPG.Enabled = false;
            this.chkMPG.Location = new System.Drawing.Point(112, 56);
            this.chkMPG.Name = "chkMPG";
            this.chkMPG.Size = new System.Drawing.Size(56, 17);
            this.chkMPG.TabIndex = 0;
            this.chkMPG.Text = "Enable";
            this.chkMPG.UseVisualStyleBackColor = true;
            this.chkMPG.CheckedChanged += new System.EventHandler(this.chkMPG_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDen);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.chkMPG);
            this.groupBox4.Controls.Add(this.txtSlope);
            this.groupBox4.Controls.Add(this.txtRatio);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cmbplsratio);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(8, 92);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(179, 116);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2-2. Set MPG";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Location = new System.Drawing.Point(7, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(387, 219);
            this.groupBox5.TabIndex = 70;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "2. MPG";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkJog);
            this.groupBox6.Controls.Add(this.cmbJogMode);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txtJogspeed);
            this.groupBox6.Location = new System.Drawing.Point(193, 92);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(173, 90);
            this.groupBox6.TabIndex = 75;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "2-3. Set JOG";
            // 
            // chkJog
            // 
            this.chkJog.AutoSize = true;
            this.chkJog.Enabled = false;
            this.chkJog.Location = new System.Drawing.Point(115, 57);
            this.chkJog.Name = "chkJog";
            this.chkJog.Size = new System.Drawing.Size(40, 16);
            this.chkJog.TabIndex = 74;
            this.chkJog.Text = "Jog";
            this.chkJog.UseVisualStyleBackColor = true;
            this.chkJog.CheckedChanged += new System.EventHandler(this.chkJog_CheckedChanged);
            // 
            // cmbJogMode
            // 
            this.cmbJogMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJogMode.FormattingEnabled = true;
            this.cmbJogMode.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbJogMode.Location = new System.Drawing.Point(69, 56);
            this.cmbJogMode.Name = "cmbJogMode";
            this.cmbJogMode.Size = new System.Drawing.Size(40, 20);
            this.cmbJogMode.TabIndex = 73;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 12);
            this.label17.TabIndex = 72;
            this.label17.Text = "Jog mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "Jog speed";
            // 
            // txtJogspeed
            // 
            this.txtJogspeed.Location = new System.Drawing.Point(71, 23);
            this.txtJogspeed.Name = "txtJogspeed";
            this.txtJogspeed.Size = new System.Drawing.Size(84, 22);
            this.txtJogspeed.TabIndex = 70;
            this.txtJogspeed.Text = "128000";
            this.txtJogspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnFindSlave
            // 
            this.btnFindSlave.Enabled = false;
            this.btnFindSlave.Location = new System.Drawing.Point(12, 28);
            this.btnFindSlave.Name = "btnFindSlave";
            this.btnFindSlave.Size = new System.Drawing.Size(83, 28);
            this.btnFindSlave.TabIndex = 71;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(148, 19);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(45, 20);
            this.CmbCardNo.TabIndex = 72;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(185, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 12);
            this.label18.TabIndex = 37;
            this.label18.Text = "Error";
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(230, 59);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(84, 22);
            this.txtERR.TabIndex = 36;
            this.txtERR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(104, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 12);
            this.label19.TabIndex = 69;
            this.label19.Text = "Den";
            // 
            // txtDen
            // 
            this.txtDen.Location = new System.Drawing.Point(136, 21);
            this.txtDen.Name = "txtDen";
            this.txtDen.Size = new System.Drawing.Size(38, 22);
            this.txtDen.TabIndex = 70;
            this.txtDen.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 391);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.btnFindSlave);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSlaveNum);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btninitial);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninitial;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.CheckBox chksvon;
        private System.Windows.Forms.CheckBox chktimer;
        private System.Windows.Forms.Button btnralm;
        private System.Windows.Forms.Timer timer1;
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
        private System.Windows.Forms.TextBox txtStatus0;
        private System.Windows.Forms.TextBox txtStatus1;
        private System.Windows.Forms.TextBox txtStatus2;
        private System.Windows.Forms.TextBox txtStatus3;
        private System.Windows.Forms.TextBox txtStatus4;
        private System.Windows.Forms.TextBox txtStatus5;
        private System.Windows.Forms.TextBox txtStatus6;
        private System.Windows.Forms.TextBox txtStatus7;
        private System.Windows.Forms.TextBox txtStatus15;
        private System.Windows.Forms.TextBox txtStatus14;
        private System.Windows.Forms.TextBox txtStatus13;
        private System.Windows.Forms.TextBox txtStatus12;
        private System.Windows.Forms.TextBox txtStatus11;
        private System.Windows.Forms.TextBox txtStatus10;
        private System.Windows.Forms.TextBox txtStatus9;
        private System.Windows.Forms.TextBox txtStatus8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSlaveNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbNodeID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMNID;
        private System.Windows.Forms.ComboBox cmbplsratio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRatio;
        private System.Windows.Forms.TextBox txtSlope;
        private System.Windows.Forms.CheckBox chkMPG;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbJogMode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtJogspeed;
        private System.Windows.Forms.CheckBox chkJog;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.TextBox txtDen;
        private System.Windows.Forms.Label label19;
    }
}

