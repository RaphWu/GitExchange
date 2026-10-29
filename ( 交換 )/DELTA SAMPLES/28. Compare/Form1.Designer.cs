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
            this.cmdOpenCard = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmdFindSlave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCmd = new System.Windows.Forms.Label();
            this.CmdReset = new System.Windows.Forms.Button();
            this.CmdNMove = new System.Windows.Forms.Button();
            this.CmdStop = new System.Windows.Forms.Button();
            this.CmdPMove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_interval = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_start_pos = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chk_level = new System.Windows.Forms.CheckBox();
            this.chk_abs = new System.Windows.Forms.CheckBox();
            this._cmd_PlusCp_1 = new System.Windows.Forms.Button();
            this._cmd_MinusCp_0 = new System.Windows.Forms.Button();
            this.cmd_OneShot = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_TCTimes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_TgTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.MPC = new System.Windows.Forms.GroupBox();
            this._chkQEP_Inv_1 = new System.Windows.Forms.CheckBox();
            this._chkQEP_Inv_0 = new System.Windows.Forms.CheckBox();
            this._lblQEPCount_1 = new System.Windows.Forms.Label();
            this._lblQEPCount_0 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_DE = new System.Windows.Forms.Button();
            this.btn_EN = new System.Windows.Forms.Button();
            this.cmd_MPCreset = new System.Windows.Forms.Button();
            this._Op_MPC_1 = new System.Windows.Forms.RadioButton();
            this._Op_MPC_0 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbl_tablecount = new System.Windows.Forms.Label();
            this.Label_tc = new System.Windows.Forms.Label();
            this.cbo_CompareType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._Op_CPtype_1 = new System.Windows.Forms.RadioButton();
            this._Op_CPtype_0 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._op_QEPselect_1 = new System.Windows.Forms.RadioButton();
            this._op_QEPselect_0 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboNodeID = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboCardNum = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.MPC.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOpenCard
            // 
            this.cmdOpenCard.Location = new System.Drawing.Point(9, 11);
            this.cmdOpenCard.Name = "cmdOpenCard";
            this.cmdOpenCard.Size = new System.Drawing.Size(77, 28);
            this.cmdOpenCard.TabIndex = 0;
            this.cmdOpenCard.Text = "Open Card";
            this.cmdOpenCard.UseVisualStyleBackColor = true;
            this.cmdOpenCard.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmdFindSlave
            // 
            this.cmdFindSlave.Enabled = false;
            this.cmdFindSlave.Location = new System.Drawing.Point(92, 11);
            this.cmdFindSlave.Name = "cmdFindSlave";
            this.cmdFindSlave.Size = new System.Drawing.Size(68, 28);
            this.cmdFindSlave.TabIndex = 73;
            this.cmdFindSlave.Text = "Find Slave";
            this.cmdFindSlave.UseVisualStyleBackColor = true;
            this.cmdFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 76;
            this.label1.Text = "Command";
            // 
            // lbCmd
            // 
            this.lbCmd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCmd.Location = new System.Drawing.Point(220, 14);
            this.lbCmd.Name = "lbCmd";
            this.lbCmd.Size = new System.Drawing.Size(69, 20);
            this.lbCmd.TabIndex = 77;
            // 
            // CmdReset
            // 
            this.CmdReset.Location = new System.Drawing.Point(294, 13);
            this.CmdReset.Name = "CmdReset";
            this.CmdReset.Size = new System.Drawing.Size(53, 26);
            this.CmdReset.TabIndex = 78;
            this.CmdReset.Text = "Reset";
            this.CmdReset.UseVisualStyleBackColor = true;
            this.CmdReset.Click += new System.EventHandler(this.CmdReset_Click);
            // 
            // CmdNMove
            // 
            this.CmdNMove.Location = new System.Drawing.Point(353, 13);
            this.CmdNMove.Name = "CmdNMove";
            this.CmdNMove.Size = new System.Drawing.Size(79, 26);
            this.CmdNMove.TabIndex = 79;
            this.CmdNMove.Text = "<<<P2PMove";
            this.CmdNMove.UseVisualStyleBackColor = true;
            this.CmdNMove.Click += new System.EventHandler(this.CmdNMove_Click);
            // 
            // CmdStop
            // 
            this.CmdStop.Location = new System.Drawing.Point(438, 13);
            this.CmdStop.Name = "CmdStop";
            this.CmdStop.Size = new System.Drawing.Size(42, 26);
            this.CmdStop.TabIndex = 80;
            this.CmdStop.Text = "Stop";
            this.CmdStop.UseVisualStyleBackColor = true;
            this.CmdStop.Click += new System.EventHandler(this.CmdStop_Click);
            // 
            // CmdPMove
            // 
            this.CmdPMove.Location = new System.Drawing.Point(485, 14);
            this.CmdPMove.Name = "CmdPMove";
            this.CmdPMove.Size = new System.Drawing.Size(86, 26);
            this.CmdPMove.TabIndex = 81;
            this.CmdPMove.Text = "P2PMove>>>";
            this.CmdPMove.UseVisualStyleBackColor = true;
            this.CmdPMove.Click += new System.EventHandler(this.CmdPMove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.MPC);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnexit);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 352);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Triger Compare";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.txt_interval);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.txt_start_pos);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.chk_level);
            this.groupBox6.Controls.Add(this.chk_abs);
            this.groupBox6.Controls.Add(this._cmd_PlusCp_1);
            this.groupBox6.Controls.Add(this._cmd_MinusCp_0);
            this.groupBox6.Controls.Add(this.cmd_OneShot);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txt_TCTimes);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.txt_TgTime);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(8, 184);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(542, 162);
            this.groupBox6.TabIndex = 88;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Operate";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(476, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 16;
            this.label17.Text = "Pulse";
            // 
            // txt_interval
            // 
            this.txt_interval.Location = new System.Drawing.Point(401, 133);
            this.txt_interval.Name = "txt_interval";
            this.txt_interval.Size = new System.Drawing.Size(69, 22);
            this.txt_interval.TabIndex = 15;
            this.txt_interval.Text = "5000";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(352, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 14;
            this.label18.Text = "Interval\r\n";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(272, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "Pulse";
            // 
            // txt_start_pos
            // 
            this.txt_start_pos.Location = new System.Drawing.Point(197, 133);
            this.txt_start_pos.Name = "txt_start_pos";
            this.txt_start_pos.Size = new System.Drawing.Size(69, 22);
            this.txt_start_pos.TabIndex = 12;
            this.txt_start_pos.Text = "5000";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(121, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "Start Position";
            // 
            // chk_level
            // 
            this.chk_level.AutoSize = true;
            this.chk_level.Location = new System.Drawing.Point(19, 135);
            this.chk_level.Name = "chk_level";
            this.chk_level.Size = new System.Drawing.Size(50, 16);
            this.chk_level.TabIndex = 10;
            this.chk_level.Text = "Level";
            this.chk_level.UseVisualStyleBackColor = true;
            this.chk_level.CheckedChanged += new System.EventHandler(this.chk_level_CheckedChanged);
            // 
            // chk_abs
            // 
            this.chk_abs.AutoSize = true;
            this.chk_abs.Location = new System.Drawing.Point(19, 113);
            this.chk_abs.Name = "chk_abs";
            this.chk_abs.Size = new System.Drawing.Size(42, 16);
            this.chk_abs.TabIndex = 9;
            this.chk_abs.Text = "Abs";
            this.chk_abs.UseVisualStyleBackColor = true;
            this.chk_abs.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // _cmd_PlusCp_1
            // 
            this._cmd_PlusCp_1.Location = new System.Drawing.Point(433, 75);
            this._cmd_PlusCp_1.Name = "_cmd_PlusCp_1";
            this._cmd_PlusCp_1.Size = new System.Drawing.Size(75, 23);
            this._cmd_PlusCp_1.TabIndex = 8;
            this._cmd_PlusCp_1.Text = "Set >>>";
            this._cmd_PlusCp_1.UseVisualStyleBackColor = true;
            this._cmd_PlusCp_1.Click += new System.EventHandler(this._cmd_PlusCp_1_Click);
            // 
            // _cmd_MinusCp_0
            // 
            this._cmd_MinusCp_0.Location = new System.Drawing.Point(19, 75);
            this._cmd_MinusCp_0.Name = "_cmd_MinusCp_0";
            this._cmd_MinusCp_0.Size = new System.Drawing.Size(75, 23);
            this._cmd_MinusCp_0.TabIndex = 7;
            this._cmd_MinusCp_0.Text = "<<< Set";
            this._cmd_MinusCp_0.UseVisualStyleBackColor = true;
            this._cmd_MinusCp_0.Click += new System.EventHandler(this._cmd_MinusCp_0_Click);
            // 
            // cmd_OneShot
            // 
            this.cmd_OneShot.Location = new System.Drawing.Point(450, 20);
            this.cmd_OneShot.Name = "cmd_OneShot";
            this.cmd_OneShot.Size = new System.Drawing.Size(75, 23);
            this.cmd_OneShot.TabIndex = 6;
            this.cmd_OneShot.Text = "One Shot";
            this.cmd_OneShot.UseVisualStyleBackColor = true;
            this.cmd_OneShot.Click += new System.EventHandler(this.cmd_OneShot_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(352, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "times";
            // 
            // txt_TCTimes
            // 
            this.txt_TCTimes.Location = new System.Drawing.Point(277, 22);
            this.txt_TCTimes.Name = "txt_TCTimes";
            this.txt_TCTimes.Size = new System.Drawing.Size(69, 22);
            this.txt_TCTimes.TabIndex = 4;
            this.txt_TCTimes.Text = "5000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(201, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "Trigger Count";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(146, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "us";
            // 
            // txt_TgTime
            // 
            this.txt_TgTime.Location = new System.Drawing.Point(82, 21);
            this.txt_TgTime.Name = "txt_TgTime";
            this.txt_TgTime.Size = new System.Drawing.Size(58, 22);
            this.txt_TgTime.TabIndex = 1;
            this.txt_TgTime.Text = "4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "Trigger Time";
            // 
            // MPC
            // 
            this.MPC.Controls.Add(this._chkQEP_Inv_1);
            this.MPC.Controls.Add(this._chkQEP_Inv_0);
            this.MPC.Controls.Add(this._lblQEPCount_1);
            this.MPC.Controls.Add(this._lblQEPCount_0);
            this.MPC.Controls.Add(this.label7);
            this.MPC.Controls.Add(this.label6);
            this.MPC.Controls.Add(this.label5);
            this.MPC.Controls.Add(this.btn_DE);
            this.MPC.Controls.Add(this.btn_EN);
            this.MPC.Controls.Add(this.cmd_MPCreset);
            this.MPC.Controls.Add(this._Op_MPC_1);
            this.MPC.Controls.Add(this._Op_MPC_0);
            this.MPC.Controls.Add(this.label4);
            this.MPC.Location = new System.Drawing.Point(285, 52);
            this.MPC.Name = "MPC";
            this.MPC.Size = new System.Drawing.Size(266, 125);
            this.MPC.TabIndex = 87;
            this.MPC.TabStop = false;
            this.MPC.Text = "MPC";
            // 
            // _chkQEP_Inv_1
            // 
            this._chkQEP_Inv_1.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkQEP_Inv_1.AutoSize = true;
            this._chkQEP_Inv_1.Location = new System.Drawing.Point(178, 39);
            this._chkQEP_Inv_1.Name = "_chkQEP_Inv_1";
            this._chkQEP_Inv_1.Size = new System.Drawing.Size(79, 22);
            this._chkQEP_Inv_1.TabIndex = 90;
            this._chkQEP_Inv_1.Text = "QEP2 Inverse";
            this._chkQEP_Inv_1.UseVisualStyleBackColor = true;
            this._chkQEP_Inv_1.CheckedChanged += new System.EventHandler(this._chkQEP_Inv_1_CheckedChanged);
            // 
            // _chkQEP_Inv_0
            // 
            this._chkQEP_Inv_0.Appearance = System.Windows.Forms.Appearance.Button;
            this._chkQEP_Inv_0.AutoSize = true;
            this._chkQEP_Inv_0.Location = new System.Drawing.Point(90, 39);
            this._chkQEP_Inv_0.Name = "_chkQEP_Inv_0";
            this._chkQEP_Inv_0.Size = new System.Drawing.Size(79, 22);
            this._chkQEP_Inv_0.TabIndex = 89;
            this._chkQEP_Inv_0.Text = "QEP1 Inverse";
            this._chkQEP_Inv_0.UseVisualStyleBackColor = true;
            this._chkQEP_Inv_0.CheckedChanged += new System.EventHandler(this._chkQEP_Inv_0_CheckedChanged);
            // 
            // _lblQEPCount_1
            // 
            this._lblQEPCount_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblQEPCount_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblQEPCount_1.Location = new System.Drawing.Point(178, 89);
            this._lblQEPCount_1.Name = "_lblQEPCount_1";
            this._lblQEPCount_1.Size = new System.Drawing.Size(75, 23);
            this._lblQEPCount_1.TabIndex = 12;
            // 
            // _lblQEPCount_0
            // 
            this._lblQEPCount_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblQEPCount_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblQEPCount_0.Location = new System.Drawing.Point(90, 89);
            this._lblQEPCount_0.Name = "_lblQEPCount_0";
            this._lblQEPCount_0.Size = new System.Drawing.Size(75, 23);
            this._lblQEPCount_0.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.Location = new System.Drawing.Point(178, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "QEP2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label6.Location = new System.Drawing.Point(90, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "QEP1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "MPC Count";
            // 
            // btn_DE
            // 
            this.btn_DE.Location = new System.Drawing.Point(55, 67);
            this.btn_DE.Name = "btn_DE";
            this.btn_DE.Size = new System.Drawing.Size(29, 23);
            this.btn_DE.TabIndex = 7;
            this.btn_DE.Text = "DE";
            this.btn_DE.UseVisualStyleBackColor = true;
            this.btn_DE.Click += new System.EventHandler(this.btn_DE_Click);
            // 
            // btn_EN
            // 
            this.btn_EN.Location = new System.Drawing.Point(23, 67);
            this.btn_EN.Name = "btn_EN";
            this.btn_EN.Size = new System.Drawing.Size(29, 23);
            this.btn_EN.TabIndex = 6;
            this.btn_EN.Text = "EN";
            this.btn_EN.UseVisualStyleBackColor = true;
            this.btn_EN.Click += new System.EventHandler(this.btn_EN_Click);
            // 
            // cmd_MPCreset
            // 
            this.cmd_MPCreset.Location = new System.Drawing.Point(23, 39);
            this.cmd_MPCreset.Name = "cmd_MPCreset";
            this.cmd_MPCreset.Size = new System.Drawing.Size(61, 23);
            this.cmd_MPCreset.TabIndex = 4;
            this.cmd_MPCreset.Text = "Reset";
            this.cmd_MPCreset.UseVisualStyleBackColor = true;
            this.cmd_MPCreset.Click += new System.EventHandler(this.cmd_MPCreset_Click);
            // 
            // _Op_MPC_1
            // 
            this._Op_MPC_1.AutoSize = true;
            this._Op_MPC_1.Location = new System.Drawing.Point(171, 17);
            this._Op_MPC_1.Name = "_Op_MPC_1";
            this._Op_MPC_1.Size = new System.Drawing.Size(72, 16);
            this._Op_MPC_1.TabIndex = 2;
            this._Op_MPC_1.TabStop = true;
            this._Op_MPC_1.Text = "CW/CCW";
            this._Op_MPC_1.UseVisualStyleBackColor = true;
            this._Op_MPC_1.CheckedChanged += new System.EventHandler(this._Op_MPC_1_CheckedChanged);
            // 
            // _Op_MPC_0
            // 
            this._Op_MPC_0.AutoSize = true;
            this._Op_MPC_0.Location = new System.Drawing.Point(97, 17);
            this._Op_MPC_0.Name = "_Op_MPC_0";
            this._Op_MPC_0.Size = new System.Drawing.Size(68, 16);
            this._Op_MPC_0.TabIndex = 1;
            this._Op_MPC_0.TabStop = true;
            this._Op_MPC_0.Text = "AB Phase";
            this._Op_MPC_0.UseVisualStyleBackColor = true;
            this._Op_MPC_0.CheckedChanged += new System.EventHandler(this._Op_MPC_0_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Inpulse Type:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbl_tablecount);
            this.groupBox5.Controls.Add(this.Label_tc);
            this.groupBox5.Controls.Add(this.cbo_CompareType);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(104, 105);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(170, 72);
            this.groupBox5.TabIndex = 86;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Compare Type";
            // 
            // lbl_tablecount
            // 
            this.lbl_tablecount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_tablecount.Location = new System.Drawing.Point(41, 44);
            this.lbl_tablecount.Name = "lbl_tablecount";
            this.lbl_tablecount.Size = new System.Drawing.Size(110, 20);
            this.lbl_tablecount.TabIndex = 3;
            // 
            // Label_tc
            // 
            this.Label_tc.AutoSize = true;
            this.Label_tc.Location = new System.Drawing.Point(7, 50);
            this.Label_tc.Name = "Label_tc";
            this.Label_tc.Size = new System.Drawing.Size(32, 12);
            this.Label_tc.TabIndex = 2;
            this.Label_tc.Text = "TCou";
            // 
            // cbo_CompareType
            // 
            this.cbo_CompareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_CompareType.FormattingEnabled = true;
            this.cbo_CompareType.Location = new System.Drawing.Point(41, 17);
            this.cbo_CompareType.Name = "cbo_CompareType";
            this.cbo_CompareType.Size = new System.Drawing.Size(110, 20);
            this.cbo_CompareType.TabIndex = 1;
            this.cbo_CompareType.SelectedIndexChanged += new System.EventHandler(this.cbo_CompareType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Type";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._Op_CPtype_1);
            this.groupBox4.Controls.Add(this._Op_CPtype_0);
            this.groupBox4.Location = new System.Drawing.Point(144, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(131, 47);
            this.groupBox4.TabIndex = 85;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Polarity";
            // 
            // _Op_CPtype_1
            // 
            this._Op_CPtype_1.AutoSize = true;
            this._Op_CPtype_1.Location = new System.Drawing.Point(67, 20);
            this._Op_CPtype_1.Name = "_Op_CPtype_1";
            this._Op_CPtype_1.Size = new System.Drawing.Size(44, 16);
            this._Op_CPtype_1.TabIndex = 1;
            this._Op_CPtype_1.TabStop = true;
            this._Op_CPtype_1.Text = "Low";
            this._Op_CPtype_1.UseVisualStyleBackColor = true;
            this._Op_CPtype_1.CheckedChanged += new System.EventHandler(this._Op_CPtype_1_CheckedChanged);
            // 
            // _Op_CPtype_0
            // 
            this._Op_CPtype_0.AutoSize = true;
            this._Op_CPtype_0.Location = new System.Drawing.Point(15, 20);
            this._Op_CPtype_0.Name = "_Op_CPtype_0";
            this._Op_CPtype_0.Size = new System.Drawing.Size(46, 16);
            this._Op_CPtype_0.TabIndex = 0;
            this._Op_CPtype_0.TabStop = true;
            this._Op_CPtype_0.Text = "High";
            this._Op_CPtype_0.UseVisualStyleBackColor = true;
            this._Op_CPtype_0.CheckedChanged += new System.EventHandler(this._Op_CPtype_0_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._op_QEPselect_1);
            this.groupBox3.Controls.Add(this._op_QEPselect_0);
            this.groupBox3.Location = new System.Drawing.Point(6, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(92, 73);
            this.groupBox3.TabIndex = 84;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select QEP";
            // 
            // _op_QEPselect_1
            // 
            this._op_QEPselect_1.AutoSize = true;
            this._op_QEPselect_1.Location = new System.Drawing.Point(21, 43);
            this._op_QEPselect_1.Name = "_op_QEPselect_1";
            this._op_QEPselect_1.Size = new System.Drawing.Size(50, 16);
            this._op_QEPselect_1.TabIndex = 1;
            this._op_QEPselect_1.TabStop = true;
            this._op_QEPselect_1.Text = "QEP2";
            this._op_QEPselect_1.UseVisualStyleBackColor = true;
            this._op_QEPselect_1.CheckedChanged += new System.EventHandler(this._op_QEPselect_1_CheckedChanged);
            // 
            // _op_QEPselect_0
            // 
            this._op_QEPselect_0.AutoSize = true;
            this._op_QEPselect_0.Location = new System.Drawing.Point(21, 21);
            this._op_QEPselect_0.Name = "_op_QEPselect_0";
            this._op_QEPselect_0.Size = new System.Drawing.Size(50, 16);
            this._op_QEPselect_0.TabIndex = 0;
            this._op_QEPselect_0.TabStop = true;
            this._op_QEPselect_0.Text = "QEP1";
            this._op_QEPselect_0.UseVisualStyleBackColor = true;
            this._op_QEPselect_0.CheckedChanged += new System.EventHandler(this._op_QEPselect_0_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboNodeID);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cboCardNum);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 78);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Card Select";
            // 
            // cboNodeID
            // 
            this.cboNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNodeID.FormattingEnabled = true;
            this.cboNodeID.Location = new System.Drawing.Point(55, 47);
            this.cboNodeID.Name = "cboNodeID";
            this.cboNodeID.Size = new System.Drawing.Size(71, 20);
            this.cboNodeID.TabIndex = 85;
            this.cboNodeID.SelectedIndexChanged += new System.EventHandler(this.cboNodeID_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 50);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(33, 12);
            this.label22.TabIndex = 84;
            this.label22.Text = "Node:";
            // 
            // cboCardNum
            // 
            this.cboCardNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardNum.FormattingEnabled = true;
            this.cboCardNum.Location = new System.Drawing.Point(55, 21);
            this.cboCardNum.Name = "cboCardNum";
            this.cboCardNum.Size = new System.Drawing.Size(71, 20);
            this.cboCardNum.TabIndex = 83;
            this.cboCardNum.SelectedIndexChanged += new System.EventHandler(this.cboCardNum_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "Card No:";
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(144, 15);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(407, 31);
            this.btnexit.TabIndex = 76;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmdPMove);
            this.Controls.Add(this.CmdStop);
            this.Controls.Add(this.CmdNMove);
            this.Controls.Add(this.CmdReset);
            this.Controls.Add(this.lbCmd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdFindSlave);
            this.Controls.Add(this.cmdOpenCard);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.MPC.ResumeLayout(false);
            this.MPC.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOpenCard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button cmdFindSlave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCmd;
        private System.Windows.Forms.Button CmdReset;
        private System.Windows.Forms.Button CmdNMove;
        private System.Windows.Forms.Button CmdStop;
        private System.Windows.Forms.Button CmdPMove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboNodeID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboCardNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton _Op_CPtype_1;
        private System.Windows.Forms.RadioButton _Op_CPtype_0;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton _op_QEPselect_1;
        private System.Windows.Forms.RadioButton _op_QEPselect_0;
        private System.Windows.Forms.Label lbl_tablecount;
        private System.Windows.Forms.Label Label_tc;
        private System.Windows.Forms.ComboBox cbo_CompareType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox MPC;
        private System.Windows.Forms.Button btn_DE;
        private System.Windows.Forms.Button btn_EN;
        private System.Windows.Forms.Button cmd_MPCreset;
        private System.Windows.Forms.RadioButton _Op_MPC_1;
        private System.Windows.Forms.RadioButton _Op_MPC_0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblQEPCount_1;
        private System.Windows.Forms.Label _lblQEPCount_0;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_TgTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chk_level;
        private System.Windows.Forms.CheckBox chk_abs;
        private System.Windows.Forms.Button _cmd_PlusCp_1;
        private System.Windows.Forms.Button _cmd_MinusCp_0;
        private System.Windows.Forms.Button cmd_OneShot;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_TCTimes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_interval;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_start_pos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox _chkQEP_Inv_1;
        private System.Windows.Forms.CheckBox _chkQEP_Inv_0;
    }
}

