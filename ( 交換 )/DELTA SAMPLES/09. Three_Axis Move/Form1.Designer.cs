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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.func1 = new System.Windows.Forms.RadioButton();
            this.func0 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkV3 = new System.Windows.Forms.CheckBox();
            this.txtPitch = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtCenY = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtDistY = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.chkSCurve = new System.Windows.Forms.CheckBox();
            this.chkAbs = new System.Windows.Forms.CheckBox();
            this.lblUnitDec = new System.Windows.Forms.Label();
            this.lblUnitAcc = new System.Windows.Forms.Label();
            this.lblUnitEndVel = new System.Windows.Forms.Label();
            this.lblUnitMaxVel = new System.Windows.Forms.Label();
            this.lblUnitStrVel = new System.Windows.Forms.Label();
            this.txtCenX = new System.Windows.Forms.TextBox();
            this.txtDistX = new System.Windows.Forms.TextBox();
            this.txtDec = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.txtEndVel = new System.Windows.Forms.TextBox();
            this.txtMaxVel = new System.Windows.Forms.TextBox();
            this.txtStrVel = new System.Windows.Forms.TextBox();
            this.lbl2Dist = new System.Windows.Forms.Label();
            this.lblDist = new System.Windows.Forms.Label();
            this.lblDec = new System.Windows.Forms.Label();
            this.lblAcc = new System.Windows.Forms.Label();
            this.lblEndVel = new System.Windows.Forms.Label();
            this.lblMaxVel = new System.Windows.Forms.Label();
            this.lblStrVel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtERR3 = new System.Windows.Forms.TextBox();
            this.txtMotion3 = new System.Windows.Forms.TextBox();
            this.txtIO3 = new System.Windows.Forms.TextBox();
            this.txtSPD3 = new System.Windows.Forms.TextBox();
            this.txtFBK3 = new System.Windows.Forms.TextBox();
            this.txtCMD3 = new System.Windows.Forms.TextBox();
            this.txtERR2 = new System.Windows.Forms.TextBox();
            this.txtMotion2 = new System.Windows.Forms.TextBox();
            this.txtIO2 = new System.Windows.Forms.TextBox();
            this.txtSPD2 = new System.Windows.Forms.TextBox();
            this.txtFBK2 = new System.Windows.Forms.TextBox();
            this.txtCMD2 = new System.Windows.Forms.TextBox();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.txtMotion = new System.Windows.Forms.TextBox();
            this.txtIO = new System.Windows.Forms.TextBox();
            this.txtSPD = new System.Windows.Forms.TextBox();
            this.txtFBK = new System.Windows.Forms.TextBox();
            this.txtCMD = new System.Windows.Forms.TextBox();
            this.lblMotion = new System.Windows.Forms.Label();
            this.lblIO = new System.Windows.Forms.Label();
            this.lblERR = new System.Windows.Forms.Label();
            this.lblSPD = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCMD = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdRALM = new System.Windows.Forms.Button();
            this.cmdSTOP = new System.Windows.Forms.Button();
            this.cmdNmove = new System.Windows.Forms.Button();
            this.chkSVON = new System.Windows.Forms.CheckBox();
            this.cmdPmove = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.chkTimer = new System.Windows.Forms.CheckBox();
            this.cmbNodeID1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNodeID2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNodeID3 = new System.Windows.Forms.ComboBox();
            this.NodeID3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(275, 22);
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
            this.label10.Location = new System.Drawing.Point(106, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(215, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "Slave Num:";
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
            this.CmbCardNo.Location = new System.Drawing.Point(153, 22);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(39, 20);
            this.CmbCardNo.TabIndex = 74;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.func1);
            this.groupBox2.Controls.Add(this.func0);
            this.groupBox2.Location = new System.Drawing.Point(8, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(72, 256);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // func1
            // 
            this.func1.AutoSize = true;
            this.func1.Location = new System.Drawing.Point(8, 56);
            this.func1.Name = "func1";
            this.func1.Size = new System.Drawing.Size(42, 16);
            this.func1.TabIndex = 1;
            this.func1.TabStop = true;
            this.func1.Text = "Heli";
            this.func1.UseVisualStyleBackColor = true;
            this.func1.CheckedChanged += new System.EventHandler(this.func1_CheckedChanged);
            // 
            // func0
            // 
            this.func0.AutoSize = true;
            this.func0.Location = new System.Drawing.Point(8, 24);
            this.func0.Name = "func0";
            this.func0.Size = new System.Drawing.Size(50, 16);
            this.func0.TabIndex = 0;
            this.func0.TabStop = true;
            this.func0.Text = "Line3";
            this.func0.UseVisualStyleBackColor = true;
            this.func0.CheckedChanged += new System.EventHandler(this.func0_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDepth);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtDistZ);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.chkV3);
            this.groupBox3.Controls.Add(this.txtPitch);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.txtDir);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.txtCenY);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.txtDistY);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.chkSCurve);
            this.groupBox3.Controls.Add(this.chkAbs);
            this.groupBox3.Controls.Add(this.lblUnitDec);
            this.groupBox3.Controls.Add(this.lblUnitAcc);
            this.groupBox3.Controls.Add(this.lblUnitEndVel);
            this.groupBox3.Controls.Add(this.lblUnitMaxVel);
            this.groupBox3.Controls.Add(this.lblUnitStrVel);
            this.groupBox3.Controls.Add(this.txtCenX);
            this.groupBox3.Controls.Add(this.txtDistX);
            this.groupBox3.Controls.Add(this.txtDec);
            this.groupBox3.Controls.Add(this.txtAcc);
            this.groupBox3.Controls.Add(this.txtEndVel);
            this.groupBox3.Controls.Add(this.txtMaxVel);
            this.groupBox3.Controls.Add(this.txtStrVel);
            this.groupBox3.Controls.Add(this.lbl2Dist);
            this.groupBox3.Controls.Add(this.lblDist);
            this.groupBox3.Controls.Add(this.lblDec);
            this.groupBox3.Controls.Add(this.lblAcc);
            this.groupBox3.Controls.Add(this.lblEndVel);
            this.groupBox3.Controls.Add(this.lblMaxVel);
            this.groupBox3.Controls.Add(this.lblStrVel);
            this.groupBox3.Location = new System.Drawing.Point(88, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 256);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set vel. prof.";
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(208, 64);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(64, 22);
            this.txtDepth.TabIndex = 78;
            this.txtDepth.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 77;
            this.label4.Text = "Depth";
            // 
            // txtDistZ
            // 
            this.txtDistZ.Location = new System.Drawing.Point(64, 192);
            this.txtDistZ.Name = "txtDistZ";
            this.txtDistZ.Size = new System.Drawing.Size(64, 22);
            this.txtDistZ.TabIndex = 76;
            this.txtDistZ.Text = "10000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 75;
            this.label3.Text = "Dist_Z";
            // 
            // chkV3
            // 
            this.chkV3.AutoSize = true;
            this.chkV3.Location = new System.Drawing.Point(208, 224);
            this.chkV3.Name = "chkV3";
            this.chkV3.Size = new System.Drawing.Size(38, 16);
            this.chkV3.TabIndex = 74;
            this.chkV3.Text = "V3";
            this.chkV3.UseVisualStyleBackColor = true;
            this.chkV3.CheckedChanged += new System.EventHandler(this.chkV3_CheckedChanged);
            // 
            // txtPitch
            // 
            this.txtPitch.Location = new System.Drawing.Point(208, 16);
            this.txtPitch.Name = "txtPitch";
            this.txtPitch.Size = new System.Drawing.Size(64, 22);
            this.txtPitch.TabIndex = 71;
            this.txtPitch.Text = "100";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(166, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(28, 12);
            this.label29.TabIndex = 70;
            this.label29.Text = "Pitch";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(208, 40);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(64, 22);
            this.txtDir.TabIndex = 69;
            this.txtDir.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(170, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(20, 12);
            this.label28.TabIndex = 68;
            this.label28.Text = "Dir";
            // 
            // txtCenY
            // 
            this.txtCenY.Location = new System.Drawing.Point(208, 160);
            this.txtCenY.Name = "txtCenY";
            this.txtCenY.Size = new System.Drawing.Size(64, 22);
            this.txtCenY.TabIndex = 63;
            this.txtCenY.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(160, 168);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 12);
            this.label25.TabIndex = 62;
            this.label25.Text = "Cen_Y";
            // 
            // txtDistY
            // 
            this.txtDistY.Location = new System.Drawing.Point(64, 168);
            this.txtDistY.Name = "txtDistY";
            this.txtDistY.Size = new System.Drawing.Size(64, 22);
            this.txtDistY.TabIndex = 61;
            this.txtDistY.Text = "10000";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(17, 176);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 12);
            this.label24.TabIndex = 60;
            this.label24.Text = "Dist_Y";
            // 
            // chkSCurve
            // 
            this.chkSCurve.AutoSize = true;
            this.chkSCurve.Location = new System.Drawing.Point(120, 224);
            this.chkSCurve.Name = "chkSCurve";
            this.chkSCurve.Size = new System.Drawing.Size(59, 16);
            this.chkSCurve.TabIndex = 59;
            this.chkSCurve.Text = "SCurve";
            this.chkSCurve.UseVisualStyleBackColor = true;
            this.chkSCurve.CheckedChanged += new System.EventHandler(this.chkSCurve_CheckedChanged);
            // 
            // chkAbs
            // 
            this.chkAbs.AutoSize = true;
            this.chkAbs.Location = new System.Drawing.Point(32, 224);
            this.chkAbs.Name = "chkAbs";
            this.chkAbs.Size = new System.Drawing.Size(42, 16);
            this.chkAbs.TabIndex = 58;
            this.chkAbs.Text = "Abs";
            this.chkAbs.UseVisualStyleBackColor = true;
            this.chkAbs.CheckedChanged += new System.EventHandler(this.chkAbs_CheckedChanged);
            // 
            // lblUnitDec
            // 
            this.lblUnitDec.AutoSize = true;
            this.lblUnitDec.Location = new System.Drawing.Point(136, 120);
            this.lblUnitDec.Name = "lblUnitDec";
            this.lblUnitDec.Size = new System.Drawing.Size(22, 12);
            this.lblUnitDec.TabIndex = 24;
            this.lblUnitDec.Text = "sec.";
            // 
            // lblUnitAcc
            // 
            this.lblUnitAcc.AutoSize = true;
            this.lblUnitAcc.Location = new System.Drawing.Point(136, 96);
            this.lblUnitAcc.Name = "lblUnitAcc";
            this.lblUnitAcc.Size = new System.Drawing.Size(22, 12);
            this.lblUnitAcc.TabIndex = 22;
            this.lblUnitAcc.Text = "sec.";
            // 
            // lblUnitEndVel
            // 
            this.lblUnitEndVel.AutoSize = true;
            this.lblUnitEndVel.Location = new System.Drawing.Point(136, 72);
            this.lblUnitEndVel.Name = "lblUnitEndVel";
            this.lblUnitEndVel.Size = new System.Drawing.Size(24, 12);
            this.lblUnitEndVel.TabIndex = 20;
            this.lblUnitEndVel.Text = "pps.";
            // 
            // lblUnitMaxVel
            // 
            this.lblUnitMaxVel.AutoSize = true;
            this.lblUnitMaxVel.Location = new System.Drawing.Point(136, 48);
            this.lblUnitMaxVel.Name = "lblUnitMaxVel";
            this.lblUnitMaxVel.Size = new System.Drawing.Size(24, 12);
            this.lblUnitMaxVel.TabIndex = 19;
            this.lblUnitMaxVel.Text = "pps.";
            // 
            // lblUnitStrVel
            // 
            this.lblUnitStrVel.AutoSize = true;
            this.lblUnitStrVel.Location = new System.Drawing.Point(136, 24);
            this.lblUnitStrVel.Name = "lblUnitStrVel";
            this.lblUnitStrVel.Size = new System.Drawing.Size(24, 12);
            this.lblUnitStrVel.TabIndex = 18;
            this.lblUnitStrVel.Text = "pps.";
            // 
            // txtCenX
            // 
            this.txtCenX.Location = new System.Drawing.Point(208, 136);
            this.txtCenX.Name = "txtCenX";
            this.txtCenX.Size = new System.Drawing.Size(64, 22);
            this.txtCenX.TabIndex = 16;
            this.txtCenX.Text = "0";
            // 
            // txtDistX
            // 
            this.txtDistX.Location = new System.Drawing.Point(64, 144);
            this.txtDistX.Name = "txtDistX";
            this.txtDistX.Size = new System.Drawing.Size(64, 22);
            this.txtDistX.TabIndex = 15;
            this.txtDistX.Text = "10000";
            // 
            // txtDec
            // 
            this.txtDec.Location = new System.Drawing.Point(64, 112);
            this.txtDec.Name = "txtDec";
            this.txtDec.Size = new System.Drawing.Size(64, 22);
            this.txtDec.TabIndex = 14;
            this.txtDec.Text = "0.1";
            // 
            // txtAcc
            // 
            this.txtAcc.Location = new System.Drawing.Point(64, 88);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(64, 22);
            this.txtAcc.TabIndex = 12;
            this.txtAcc.Text = "0.1";
            // 
            // txtEndVel
            // 
            this.txtEndVel.Enabled = false;
            this.txtEndVel.Location = new System.Drawing.Point(64, 64);
            this.txtEndVel.Name = "txtEndVel";
            this.txtEndVel.Size = new System.Drawing.Size(64, 22);
            this.txtEndVel.TabIndex = 11;
            this.txtEndVel.Text = "0";
            // 
            // txtMaxVel
            // 
            this.txtMaxVel.Location = new System.Drawing.Point(64, 40);
            this.txtMaxVel.Name = "txtMaxVel";
            this.txtMaxVel.Size = new System.Drawing.Size(64, 22);
            this.txtMaxVel.TabIndex = 10;
            this.txtMaxVel.Text = "12800";
            // 
            // txtStrVel
            // 
            this.txtStrVel.Location = new System.Drawing.Point(64, 16);
            this.txtStrVel.Name = "txtStrVel";
            this.txtStrVel.Size = new System.Drawing.Size(64, 22);
            this.txtStrVel.TabIndex = 9;
            this.txtStrVel.Text = "0";
            // 
            // lbl2Dist
            // 
            this.lbl2Dist.AutoSize = true;
            this.lbl2Dist.Location = new System.Drawing.Point(160, 144);
            this.lbl2Dist.Name = "lbl2Dist";
            this.lbl2Dist.Size = new System.Drawing.Size(38, 12);
            this.lbl2Dist.TabIndex = 7;
            this.lbl2Dist.Text = "Cen_X";
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Location = new System.Drawing.Point(17, 152);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(37, 12);
            this.lblDist.TabIndex = 6;
            this.lblDist.Text = "Dist_X";
            // 
            // lblDec
            // 
            this.lblDec.AutoSize = true;
            this.lblDec.Location = new System.Drawing.Point(17, 120);
            this.lblDec.Name = "lblDec";
            this.lblDec.Size = new System.Drawing.Size(26, 12);
            this.lblDec.TabIndex = 5;
            this.lblDec.Text = "Dec.";
            this.lblDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Location = new System.Drawing.Point(17, 96);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(26, 12);
            this.lblAcc.TabIndex = 3;
            this.lblAcc.Text = "Acc.";
            this.lblAcc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEndVel
            // 
            this.lblEndVel.AutoSize = true;
            this.lblEndVel.Location = new System.Drawing.Point(10, 72);
            this.lblEndVel.Name = "lblEndVel";
            this.lblEndVel.Size = new System.Drawing.Size(40, 12);
            this.lblEndVel.TabIndex = 2;
            this.lblEndVel.Text = "EndVel";
            // 
            // lblMaxVel
            // 
            this.lblMaxVel.AutoSize = true;
            this.lblMaxVel.Location = new System.Drawing.Point(9, 48);
            this.lblMaxVel.Name = "lblMaxVel";
            this.lblMaxVel.Size = new System.Drawing.Size(42, 12);
            this.lblMaxVel.TabIndex = 1;
            this.lblMaxVel.Text = "MaxVel";
            // 
            // lblStrVel
            // 
            this.lblStrVel.AutoSize = true;
            this.lblStrVel.Location = new System.Drawing.Point(12, 24);
            this.lblStrVel.Name = "lblStrVel";
            this.lblStrVel.Size = new System.Drawing.Size(37, 12);
            this.lblStrVel.TabIndex = 0;
            this.lblStrVel.Text = "StrVel.";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtERR3);
            this.groupBox5.Controls.Add(this.txtMotion3);
            this.groupBox5.Controls.Add(this.txtIO3);
            this.groupBox5.Controls.Add(this.txtSPD3);
            this.groupBox5.Controls.Add(this.txtFBK3);
            this.groupBox5.Controls.Add(this.txtCMD3);
            this.groupBox5.Controls.Add(this.txtERR2);
            this.groupBox5.Controls.Add(this.txtMotion2);
            this.groupBox5.Controls.Add(this.txtIO2);
            this.groupBox5.Controls.Add(this.txtSPD2);
            this.groupBox5.Controls.Add(this.txtFBK2);
            this.groupBox5.Controls.Add(this.txtCMD2);
            this.groupBox5.Controls.Add(this.txtERR);
            this.groupBox5.Controls.Add(this.txtMotion);
            this.groupBox5.Controls.Add(this.txtIO);
            this.groupBox5.Controls.Add(this.txtSPD);
            this.groupBox5.Controls.Add(this.txtFBK);
            this.groupBox5.Controls.Add(this.txtCMD);
            this.groupBox5.Controls.Add(this.lblMotion);
            this.groupBox5.Controls.Add(this.lblIO);
            this.groupBox5.Controls.Add(this.lblERR);
            this.groupBox5.Controls.Add(this.lblSPD);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.lblCMD);
            this.groupBox5.Location = new System.Drawing.Point(376, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(336, 168);
            this.groupBox5.TabIndex = 80;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Status";
            // 
            // txtERR3
            // 
            this.txtERR3.Location = new System.Drawing.Point(240, 136);
            this.txtERR3.Name = "txtERR3";
            this.txtERR3.ReadOnly = true;
            this.txtERR3.Size = new System.Drawing.Size(80, 22);
            this.txtERR3.TabIndex = 24;
            // 
            // txtMotion3
            // 
            this.txtMotion3.Location = new System.Drawing.Point(240, 112);
            this.txtMotion3.Name = "txtMotion3";
            this.txtMotion3.ReadOnly = true;
            this.txtMotion3.Size = new System.Drawing.Size(80, 22);
            this.txtMotion3.TabIndex = 23;
            // 
            // txtIO3
            // 
            this.txtIO3.Location = new System.Drawing.Point(240, 88);
            this.txtIO3.Name = "txtIO3";
            this.txtIO3.ReadOnly = true;
            this.txtIO3.Size = new System.Drawing.Size(80, 22);
            this.txtIO3.TabIndex = 22;
            // 
            // txtSPD3
            // 
            this.txtSPD3.Location = new System.Drawing.Point(240, 64);
            this.txtSPD3.Name = "txtSPD3";
            this.txtSPD3.ReadOnly = true;
            this.txtSPD3.Size = new System.Drawing.Size(80, 22);
            this.txtSPD3.TabIndex = 21;
            // 
            // txtFBK3
            // 
            this.txtFBK3.Location = new System.Drawing.Point(240, 40);
            this.txtFBK3.Name = "txtFBK3";
            this.txtFBK3.ReadOnly = true;
            this.txtFBK3.Size = new System.Drawing.Size(80, 22);
            this.txtFBK3.TabIndex = 20;
            // 
            // txtCMD3
            // 
            this.txtCMD3.Location = new System.Drawing.Point(240, 16);
            this.txtCMD3.Name = "txtCMD3";
            this.txtCMD3.ReadOnly = true;
            this.txtCMD3.Size = new System.Drawing.Size(80, 22);
            this.txtCMD3.TabIndex = 19;
            // 
            // txtERR2
            // 
            this.txtERR2.Location = new System.Drawing.Point(152, 136);
            this.txtERR2.Name = "txtERR2";
            this.txtERR2.ReadOnly = true;
            this.txtERR2.Size = new System.Drawing.Size(80, 22);
            this.txtERR2.TabIndex = 18;
            // 
            // txtMotion2
            // 
            this.txtMotion2.Location = new System.Drawing.Point(152, 112);
            this.txtMotion2.Name = "txtMotion2";
            this.txtMotion2.ReadOnly = true;
            this.txtMotion2.Size = new System.Drawing.Size(80, 22);
            this.txtMotion2.TabIndex = 17;
            // 
            // txtIO2
            // 
            this.txtIO2.Location = new System.Drawing.Point(152, 88);
            this.txtIO2.Name = "txtIO2";
            this.txtIO2.ReadOnly = true;
            this.txtIO2.Size = new System.Drawing.Size(80, 22);
            this.txtIO2.TabIndex = 16;
            // 
            // txtSPD2
            // 
            this.txtSPD2.Location = new System.Drawing.Point(152, 64);
            this.txtSPD2.Name = "txtSPD2";
            this.txtSPD2.ReadOnly = true;
            this.txtSPD2.Size = new System.Drawing.Size(80, 22);
            this.txtSPD2.TabIndex = 15;
            // 
            // txtFBK2
            // 
            this.txtFBK2.Location = new System.Drawing.Point(152, 40);
            this.txtFBK2.Name = "txtFBK2";
            this.txtFBK2.ReadOnly = true;
            this.txtFBK2.Size = new System.Drawing.Size(80, 22);
            this.txtFBK2.TabIndex = 14;
            // 
            // txtCMD2
            // 
            this.txtCMD2.Location = new System.Drawing.Point(152, 16);
            this.txtCMD2.Name = "txtCMD2";
            this.txtCMD2.ReadOnly = true;
            this.txtCMD2.Size = new System.Drawing.Size(80, 22);
            this.txtCMD2.TabIndex = 13;
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(64, 136);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(80, 22);
            this.txtERR.TabIndex = 11;
            // 
            // txtMotion
            // 
            this.txtMotion.Location = new System.Drawing.Point(64, 112);
            this.txtMotion.Name = "txtMotion";
            this.txtMotion.ReadOnly = true;
            this.txtMotion.Size = new System.Drawing.Size(80, 22);
            this.txtMotion.TabIndex = 10;
            // 
            // txtIO
            // 
            this.txtIO.Location = new System.Drawing.Point(64, 88);
            this.txtIO.Name = "txtIO";
            this.txtIO.ReadOnly = true;
            this.txtIO.Size = new System.Drawing.Size(80, 22);
            this.txtIO.TabIndex = 9;
            // 
            // txtSPD
            // 
            this.txtSPD.Location = new System.Drawing.Point(64, 64);
            this.txtSPD.Name = "txtSPD";
            this.txtSPD.ReadOnly = true;
            this.txtSPD.Size = new System.Drawing.Size(80, 22);
            this.txtSPD.TabIndex = 8;
            // 
            // txtFBK
            // 
            this.txtFBK.Location = new System.Drawing.Point(64, 40);
            this.txtFBK.Name = "txtFBK";
            this.txtFBK.ReadOnly = true;
            this.txtFBK.Size = new System.Drawing.Size(80, 22);
            this.txtFBK.TabIndex = 7;
            // 
            // txtCMD
            // 
            this.txtCMD.Location = new System.Drawing.Point(64, 16);
            this.txtCMD.Name = "txtCMD";
            this.txtCMD.ReadOnly = true;
            this.txtCMD.Size = new System.Drawing.Size(80, 22);
            this.txtCMD.TabIndex = 6;
            // 
            // lblMotion
            // 
            this.lblMotion.AutoSize = true;
            this.lblMotion.Location = new System.Drawing.Point(16, 120);
            this.lblMotion.Name = "lblMotion";
            this.lblMotion.Size = new System.Drawing.Size(39, 12);
            this.lblMotion.TabIndex = 5;
            this.lblMotion.Text = "Motion";
            // 
            // lblIO
            // 
            this.lblIO.AutoSize = true;
            this.lblIO.Location = new System.Drawing.Point(17, 96);
            this.lblIO.Name = "lblIO";
            this.lblIO.Size = new System.Drawing.Size(36, 12);
            this.lblIO.TabIndex = 4;
            this.lblIO.Text = "IO Sts.";
            // 
            // lblERR
            // 
            this.lblERR.AutoSize = true;
            this.lblERR.Location = new System.Drawing.Point(20, 144);
            this.lblERR.Name = "lblERR";
            this.lblERR.Size = new System.Drawing.Size(30, 12);
            this.lblERR.TabIndex = 3;
            this.lblERR.Text = "Error";
            // 
            // lblSPD
            // 
            this.lblSPD.AutoSize = true;
            this.lblSPD.Location = new System.Drawing.Point(21, 72);
            this.lblSPD.Name = "lblSPD";
            this.lblSPD.Size = new System.Drawing.Size(28, 12);
            this.lblSPD.TabIndex = 2;
            this.lblSPD.Text = "SPD.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "FBK.";
            // 
            // lblCMD
            // 
            this.lblCMD.AutoSize = true;
            this.lblCMD.Location = new System.Drawing.Point(18, 24);
            this.lblCMD.Name = "lblCMD";
            this.lblCMD.Size = new System.Drawing.Size(34, 12);
            this.lblCMD.TabIndex = 0;
            this.lblCMD.Text = "CMD.";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cmdReset);
            this.groupBox7.Controls.Add(this.cmdRALM);
            this.groupBox7.Controls.Add(this.cmdSTOP);
            this.groupBox7.Controls.Add(this.cmdNmove);
            this.groupBox7.Controls.Add(this.chkSVON);
            this.groupBox7.Controls.Add(this.cmdPmove);
            this.groupBox7.Controls.Add(this.cmdExit);
            this.groupBox7.Location = new System.Drawing.Point(376, 232);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(336, 88);
            this.groupBox7.TabIndex = 82;
            this.groupBox7.TabStop = false;
            // 
            // cmdReset
            // 
            this.cmdReset.Enabled = false;
            this.cmdReset.Location = new System.Drawing.Point(8, 48);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(80, 30);
            this.cmdReset.TabIndex = 13;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdRALM
            // 
            this.cmdRALM.Enabled = false;
            this.cmdRALM.Location = new System.Drawing.Point(88, 48);
            this.cmdRALM.Name = "cmdRALM";
            this.cmdRALM.Size = new System.Drawing.Size(80, 30);
            this.cmdRALM.TabIndex = 10;
            this.cmdRALM.Text = "RALM";
            this.cmdRALM.UseVisualStyleBackColor = true;
            this.cmdRALM.Click += new System.EventHandler(this.cmdRALM_Click);
            // 
            // cmdSTOP
            // 
            this.cmdSTOP.Enabled = false;
            this.cmdSTOP.Location = new System.Drawing.Point(168, 16);
            this.cmdSTOP.Name = "cmdSTOP";
            this.cmdSTOP.Size = new System.Drawing.Size(80, 30);
            this.cmdSTOP.TabIndex = 9;
            this.cmdSTOP.Text = "STOP";
            this.cmdSTOP.UseVisualStyleBackColor = true;
            this.cmdSTOP.Click += new System.EventHandler(this.cmdSTOP_Click);
            // 
            // cmdNmove
            // 
            this.cmdNmove.Enabled = false;
            this.cmdNmove.Location = new System.Drawing.Point(88, 16);
            this.cmdNmove.Name = "cmdNmove";
            this.cmdNmove.Size = new System.Drawing.Size(80, 30);
            this.cmdNmove.TabIndex = 8;
            this.cmdNmove.Text = "<--";
            this.cmdNmove.UseVisualStyleBackColor = true;
            this.cmdNmove.Click += new System.EventHandler(this.cmdNmove_Click);
            // 
            // chkSVON
            // 
            this.chkSVON.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSVON.Enabled = false;
            this.chkSVON.Location = new System.Drawing.Point(8, 16);
            this.chkSVON.Name = "chkSVON";
            this.chkSVON.Size = new System.Drawing.Size(80, 30);
            this.chkSVON.TabIndex = 7;
            this.chkSVON.Text = "SVON";
            this.chkSVON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSVON.UseVisualStyleBackColor = true;
            this.chkSVON.CheckedChanged += new System.EventHandler(this.chkSVON_CheckedChanged_1);
            // 
            // cmdPmove
            // 
            this.cmdPmove.Enabled = false;
            this.cmdPmove.Location = new System.Drawing.Point(248, 16);
            this.cmdPmove.Name = "cmdPmove";
            this.cmdPmove.Size = new System.Drawing.Size(80, 30);
            this.cmdPmove.TabIndex = 6;
            this.cmdPmove.Text = "-->";
            this.cmdPmove.UseVisualStyleBackColor = true;
            this.cmdPmove.Click += new System.EventHandler(this.cmdPmove_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(248, 48);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(80, 30);
            this.cmdExit.TabIndex = 5;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // chkTimer
            // 
            this.chkTimer.AutoSize = true;
            this.chkTimer.Location = new System.Drawing.Point(632, 24);
            this.chkTimer.Name = "chkTimer";
            this.chkTimer.Size = new System.Drawing.Size(52, 16);
            this.chkTimer.TabIndex = 88;
            this.chkTimer.Text = "Timer";
            this.chkTimer.UseVisualStyleBackColor = true;
            // 
            // cmbNodeID1
            // 
            this.cmbNodeID1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID1.FormattingEnabled = true;
            this.cmbNodeID1.Location = new System.Drawing.Point(376, 22);
            this.cmbNodeID1.Name = "cmbNodeID1";
            this.cmbNodeID1.Size = new System.Drawing.Size(40, 20);
            this.cmbNodeID1.TabIndex = 86;
            this.cmbNodeID1.SelectedIndexChanged += new System.EventHandler(this.cmbNodeID1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "NodeID1:";
            // 
            // cmbNodeID2
            // 
            this.cmbNodeID2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID2.FormattingEnabled = true;
            this.cmbNodeID2.Location = new System.Drawing.Point(472, 22);
            this.cmbNodeID2.Name = "cmbNodeID2";
            this.cmbNodeID2.Size = new System.Drawing.Size(40, 20);
            this.cmbNodeID2.TabIndex = 90;
            this.cmbNodeID2.SelectedIndexChanged += new System.EventHandler(this.cmbNodeID2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 89;
            this.label2.Text = "NodeID2:";
            // 
            // cmbNodeID3
            // 
            this.cmbNodeID3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID3.FormattingEnabled = true;
            this.cmbNodeID3.Location = new System.Drawing.Point(568, 22);
            this.cmbNodeID3.Name = "cmbNodeID3";
            this.cmbNodeID3.Size = new System.Drawing.Size(40, 20);
            this.cmbNodeID3.TabIndex = 92;
            this.cmbNodeID3.SelectedIndexChanged += new System.EventHandler(this.cmbNodeID3_SelectedIndexChanged);
            // 
            // NodeID3
            // 
            this.NodeID3.AutoSize = true;
            this.NodeID3.Location = new System.Drawing.Point(520, 25);
            this.NodeID3.Name = "NodeID3";
            this.NodeID3.Size = new System.Drawing.Size(51, 12);
            this.NodeID3.TabIndex = 91;
            this.NodeID3.Text = "NodeID3:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 326);
            this.Controls.Add(this.cmbNodeID3);
            this.Controls.Add(this.NodeID3);
            this.Controls.Add(this.cmbNodeID2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkTimer);
            this.Controls.Add(this.cmbNodeID1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.btnFindSlave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSlaveNum);
            this.Controls.Add(this.btninitial);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninitial;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtSlaveNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton func1;
        private System.Windows.Forms.RadioButton func0;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDistX;
        private System.Windows.Forms.TextBox txtDec;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.TextBox txtEndVel;
        private System.Windows.Forms.TextBox txtMaxVel;
        private System.Windows.Forms.TextBox txtStrVel;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Label lblDec;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.Label lblEndVel;
        private System.Windows.Forms.Label lblMaxVel;
        private System.Windows.Forms.Label lblStrVel;
        private System.Windows.Forms.Label lblUnitDec;
        private System.Windows.Forms.Label lblUnitAcc;
        private System.Windows.Forms.Label lblUnitEndVel;
        private System.Windows.Forms.Label lblUnitMaxVel;
        private System.Windows.Forms.Label lblUnitStrVel;
        private System.Windows.Forms.CheckBox chkSCurve;
        private System.Windows.Forms.CheckBox chkAbs;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button cmdPmove;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.TextBox txtMotion;
        private System.Windows.Forms.TextBox txtIO;
        private System.Windows.Forms.TextBox txtSPD;
        private System.Windows.Forms.TextBox txtFBK;
        private System.Windows.Forms.TextBox txtCMD;
        private System.Windows.Forms.Label lblMotion;
        private System.Windows.Forms.Label lblIO;
        private System.Windows.Forms.Label lblERR;
        private System.Windows.Forms.Label lblSPD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCMD;
        private System.Windows.Forms.Button cmdRALM;
        private System.Windows.Forms.Button cmdSTOP;
        private System.Windows.Forms.Button cmdNmove;
        private System.Windows.Forms.CheckBox chkSVON;
        private System.Windows.Forms.TextBox txtERR2;
        private System.Windows.Forms.TextBox txtMotion2;
        private System.Windows.Forms.TextBox txtIO2;
        private System.Windows.Forms.TextBox txtSPD2;
        private System.Windows.Forms.TextBox txtFBK2;
        private System.Windows.Forms.TextBox txtCMD2;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.CheckBox chkTimer;
        private System.Windows.Forms.ComboBox cmbNodeID1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNodeID2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkV3;
        private System.Windows.Forms.TextBox txtPitch;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtDistY;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCenY;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtCenX;
        private System.Windows.Forms.Label lbl2Dist;
        private System.Windows.Forms.TextBox txtERR3;
        private System.Windows.Forms.TextBox txtMotion3;
        private System.Windows.Forms.TextBox txtIO3;
        private System.Windows.Forms.TextBox txtSPD3;
        private System.Windows.Forms.TextBox txtFBK3;
        private System.Windows.Forms.TextBox txtCMD3;
        private System.Windows.Forms.ComboBox cmbNodeID3;
        private System.Windows.Forms.Label NodeID3;
    }
}

