namespace DMC_MotionbufferSample
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.combo_X_NodeID = new System.Windows.Forms.ComboBox();
            this.combo_CardNo = new System.Windows.Forms.ComboBox();
            this.text_SlaveNum = new System.Windows.Forms.TextBox();
            this.text_Initial_Satatus = new System.Windows.Forms.TextBox();
            this.text_CardNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_FindSlave = new System.Windows.Forms.Button();
            this.btn_Initial = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_Y_NodeID = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_DO_NodeID = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_Axis_NodeID = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chk_Timer = new System.Windows.Forms.CheckBox();
            this.btn_SVON = new System.Windows.Forms.Button();
            this.btn_RALM = new System.Windows.Forms.Button();
            this.btn_RESET = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.text_MoveMode_3 = new System.Windows.Forms.TextBox();
            this.text_MoveMode_2 = new System.Windows.Forms.TextBox();
            this.text_Motion_3 = new System.Windows.Forms.TextBox();
            this.text_Motion_2 = new System.Windows.Forms.TextBox();
            this.text_Buffer_3 = new System.Windows.Forms.TextBox();
            this.text_Buffer_2 = new System.Windows.Forms.TextBox();
            this.text_IO_3 = new System.Windows.Forms.TextBox();
            this.text_IO_2 = new System.Windows.Forms.TextBox();
            this.text_MoveMode_1 = new System.Windows.Forms.TextBox();
            this.text_SPD_3 = new System.Windows.Forms.TextBox();
            this.text_Motion_1 = new System.Windows.Forms.TextBox();
            this.text_SPD_2 = new System.Windows.Forms.TextBox();
            this.text_Buffer_1 = new System.Windows.Forms.TextBox();
            this.text_FBK_3 = new System.Windows.Forms.TextBox();
            this.text_IO_1 = new System.Windows.Forms.TextBox();
            this.text_FBK_2 = new System.Windows.Forms.TextBox();
            this.text_SPD_1 = new System.Windows.Forms.TextBox();
            this.text_CMD_3 = new System.Windows.Forms.TextBox();
            this.text_FBK_1 = new System.Windows.Forms.TextBox();
            this.text_CMD_2 = new System.Windows.Forms.TextBox();
            this.text_CMD_1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.text_RxMaxTime = new System.Windows.Forms.TextBox();
            this.text_TxMaxTime = new System.Windows.Forms.TextBox();
            this.text_RxTime = new System.Windows.Forms.TextBox();
            this.text_TxTime = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.text_MB_BlockNum_Fifo1 = new System.Windows.Forms.TextBox();
            this.text_MB_RemainSize_Fifo1 = new System.Windows.Forms.TextBox();
            this.text_MB_BlockNum_Fifo0 = new System.Windows.Forms.TextBox();
            this.text_MB_Status_Fifo1 = new System.Windows.Forms.TextBox();
            this.text_MB_RemainSize_Fifo0 = new System.Windows.Forms.TextBox();
            this.text_MB_Status_Fifo0 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btn_MB_SetData = new System.Windows.Forms.Button();
            this.btn_MB_Start = new System.Windows.Forms.Button();
            this.btn_MB_Clear = new System.Windows.Forms.Button();
            this.btn_MB_Stop = new System.Windows.Forms.Button();
            this.btn_MB_Set_Stop_Dec = new System.Windows.Forms.Button();
            this.btn_MB_Get_Stop_Dec = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.combo_TableNo = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.combo_FifoNo = new System.Windows.Forms.ComboBox();
            this.combo_SW_Test = new System.Windows.Forms.ComboBox();
            this.combo_MB_Stop_Mode = new System.Windows.Forms.ComboBox();
            this.text_MB_Stop_Dec = new System.Windows.Forms.TextBox();
            this.chk_Drwing = new System.Windows.Forms.CheckBox();
            this.myScope1 = new MyScope.MyScope();
            this.myScope2 = new MyScope.MyScope();
            this.ClearScope_button = new System.Windows.Forms.Button();
            this.IOControlcheckBox = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.DelaytextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_X_NodeID
            // 
            this.combo_X_NodeID.FormattingEnabled = true;
            this.combo_X_NodeID.Location = new System.Drawing.Point(51, 18);
            this.combo_X_NodeID.Name = "combo_X_NodeID";
            this.combo_X_NodeID.Size = new System.Drawing.Size(179, 20);
            this.combo_X_NodeID.TabIndex = 9;
            this.combo_X_NodeID.SelectedIndexChanged += new System.EventHandler(this.combo_X_NodeID_SelectedIndexChanged);
            // 
            // combo_CardNo
            // 
            this.combo_CardNo.FormattingEnabled = true;
            this.combo_CardNo.Location = new System.Drawing.Point(167, 33);
            this.combo_CardNo.Name = "combo_CardNo";
            this.combo_CardNo.Size = new System.Drawing.Size(81, 20);
            this.combo_CardNo.TabIndex = 20;
            this.combo_CardNo.SelectedIndexChanged += new System.EventHandler(this.combo_CardNo_SelectedIndexChanged);
            // 
            // text_SlaveNum
            // 
            this.text_SlaveNum.Location = new System.Drawing.Point(167, 84);
            this.text_SlaveNum.Name = "text_SlaveNum";
            this.text_SlaveNum.ReadOnly = true;
            this.text_SlaveNum.Size = new System.Drawing.Size(81, 22);
            this.text_SlaveNum.TabIndex = 17;
            this.text_SlaveNum.Text = "0";
            // 
            // text_Initial_Satatus
            // 
            this.text_Initial_Satatus.Location = new System.Drawing.Point(167, 59);
            this.text_Initial_Satatus.Name = "text_Initial_Satatus";
            this.text_Initial_Satatus.ReadOnly = true;
            this.text_Initial_Satatus.Size = new System.Drawing.Size(81, 22);
            this.text_Initial_Satatus.TabIndex = 18;
            // 
            // text_CardNum
            // 
            this.text_CardNum.Location = new System.Drawing.Point(167, 6);
            this.text_CardNum.Name = "text_CardNum";
            this.text_CardNum.ReadOnly = true;
            this.text_CardNum.Size = new System.Drawing.Size(81, 22);
            this.text_CardNum.TabIndex = 19;
            this.text_CardNum.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Slave Num :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Initial Status :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Card Num :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "X Axis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Card No :";
            // 
            // btn_FindSlave
            // 
            this.btn_FindSlave.Enabled = false;
            this.btn_FindSlave.Location = new System.Drawing.Point(6, 30);
            this.btn_FindSlave.Name = "btn_FindSlave";
            this.btn_FindSlave.Size = new System.Drawing.Size(75, 23);
            this.btn_FindSlave.TabIndex = 10;
            this.btn_FindSlave.Text = "Find Slave";
            this.btn_FindSlave.UseVisualStyleBackColor = true;
            this.btn_FindSlave.Click += new System.EventHandler(this.btn_FindSlave_Click);
            // 
            // btn_Initial
            // 
            this.btn_Initial.Location = new System.Drawing.Point(6, 6);
            this.btn_Initial.Name = "btn_Initial";
            this.btn_Initial.Size = new System.Drawing.Size(75, 23);
            this.btn_Initial.TabIndex = 11;
            this.btn_Initial.Text = "Initial";
            this.btn_Initial.UseVisualStyleBackColor = true;
            this.btn_Initial.Click += new System.EventHandler(this.btn_Initial_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.combo_Y_NodeID);
            this.groupBox1.Controls.Add(this.combo_X_NodeID);
            this.groupBox1.Location = new System.Drawing.Point(6, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 72);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordinate NodeID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Y Axis";
            // 
            // combo_Y_NodeID
            // 
            this.combo_Y_NodeID.FormattingEnabled = true;
            this.combo_Y_NodeID.Location = new System.Drawing.Point(51, 43);
            this.combo_Y_NodeID.Name = "combo_Y_NodeID";
            this.combo_Y_NodeID.Size = new System.Drawing.Size(179, 20);
            this.combo_Y_NodeID.TabIndex = 9;
            this.combo_Y_NodeID.SelectedIndexChanged += new System.EventHandler(this.combo_Y_NodeID_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.combo_DO_NodeID);
            this.groupBox2.Location = new System.Drawing.Point(6, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 49);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DO NodeID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "DO";
            // 
            // combo_DO_NodeID
            // 
            this.combo_DO_NodeID.FormattingEnabled = true;
            this.combo_DO_NodeID.Location = new System.Drawing.Point(51, 18);
            this.combo_DO_NodeID.Name = "combo_DO_NodeID";
            this.combo_DO_NodeID.Size = new System.Drawing.Size(179, 20);
            this.combo_DO_NodeID.TabIndex = 9;
            this.combo_DO_NodeID.SelectedIndexChanged += new System.EventHandler(this.combo_DO_NodeID_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.combo_Axis_NodeID);
            this.groupBox3.Location = new System.Drawing.Point(6, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 49);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Axis NodeID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Axis";
            // 
            // combo_Axis_NodeID
            // 
            this.combo_Axis_NodeID.FormattingEnabled = true;
            this.combo_Axis_NodeID.Location = new System.Drawing.Point(51, 18);
            this.combo_Axis_NodeID.Name = "combo_Axis_NodeID";
            this.combo_Axis_NodeID.Size = new System.Drawing.Size(179, 20);
            this.combo_Axis_NodeID.TabIndex = 9;
            this.combo_Axis_NodeID.SelectedIndexChanged += new System.EventHandler(this.combo_Axis_NodeID_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chk_Timer
            // 
            this.chk_Timer.AutoSize = true;
            this.chk_Timer.Location = new System.Drawing.Point(827, 140);
            this.chk_Timer.Name = "chk_Timer";
            this.chk_Timer.Size = new System.Drawing.Size(52, 16);
            this.chk_Timer.TabIndex = 25;
            this.chk_Timer.Text = "Timer";
            this.chk_Timer.UseVisualStyleBackColor = true;
            // 
            // btn_SVON
            // 
            this.btn_SVON.Location = new System.Drawing.Point(6, 298);
            this.btn_SVON.Name = "btn_SVON";
            this.btn_SVON.Size = new System.Drawing.Size(75, 23);
            this.btn_SVON.TabIndex = 26;
            this.btn_SVON.Text = "SVON";
            this.btn_SVON.UseVisualStyleBackColor = true;
            this.btn_SVON.Click += new System.EventHandler(this.but_SVON_Click);
            // 
            // btn_RALM
            // 
            this.btn_RALM.Location = new System.Drawing.Point(86, 298);
            this.btn_RALM.Name = "btn_RALM";
            this.btn_RALM.Size = new System.Drawing.Size(75, 23);
            this.btn_RALM.TabIndex = 26;
            this.btn_RALM.Text = "RALM";
            this.btn_RALM.UseVisualStyleBackColor = true;
            this.btn_RALM.Click += new System.EventHandler(this.btn_RALM_Click);
            // 
            // btn_RESET
            // 
            this.btn_RESET.Location = new System.Drawing.Point(173, 298);
            this.btn_RESET.Name = "btn_RESET";
            this.btn_RESET.Size = new System.Drawing.Size(75, 23);
            this.btn_RESET.TabIndex = 26;
            this.btn_RESET.Text = "RESET";
            this.btn_RESET.UseVisualStyleBackColor = true;
            this.btn_RESET.Click += new System.EventHandler(this.btn_RESET_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.text_MoveMode_3);
            this.groupBox4.Controls.Add(this.text_MoveMode_2);
            this.groupBox4.Controls.Add(this.text_Motion_3);
            this.groupBox4.Controls.Add(this.text_Motion_2);
            this.groupBox4.Controls.Add(this.text_Buffer_3);
            this.groupBox4.Controls.Add(this.text_Buffer_2);
            this.groupBox4.Controls.Add(this.text_IO_3);
            this.groupBox4.Controls.Add(this.text_IO_2);
            this.groupBox4.Controls.Add(this.text_MoveMode_1);
            this.groupBox4.Controls.Add(this.text_SPD_3);
            this.groupBox4.Controls.Add(this.text_Motion_1);
            this.groupBox4.Controls.Add(this.text_SPD_2);
            this.groupBox4.Controls.Add(this.text_Buffer_1);
            this.groupBox4.Controls.Add(this.text_FBK_3);
            this.groupBox4.Controls.Add(this.text_IO_1);
            this.groupBox4.Controls.Add(this.text_FBK_2);
            this.groupBox4.Controls.Add(this.text_SPD_1);
            this.groupBox4.Controls.Add(this.text_CMD_3);
            this.groupBox4.Controls.Add(this.text_FBK_1);
            this.groupBox4.Controls.Add(this.text_CMD_2);
            this.groupBox4.Controls.Add(this.text_CMD_1);
            this.groupBox4.Location = new System.Drawing.Point(254, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 234);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Driver Status";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(258, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "Axis";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(166, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 12);
            this.label16.TabIndex = 12;
            this.label16.Text = "Y Axis";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 208);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 12);
            this.label32.TabIndex = 14;
            this.label32.Text = "Mode";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 179);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "Motion";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(81, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "X Axis";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "Buffer";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "IO Sts.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(317, 95);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 12);
            this.label20.TabIndex = 14;
            this.label20.Text = "PPS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "SPD.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(317, 67);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 12);
            this.label19.TabIndex = 14;
            this.label19.Text = "pls.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(317, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 12);
            this.label18.TabIndex = 14;
            this.label18.Text = "pls.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "FBK.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "CMD.";
            // 
            // text_MoveMode_3
            // 
            this.text_MoveMode_3.Location = new System.Drawing.Point(230, 205);
            this.text_MoveMode_3.Name = "text_MoveMode_3";
            this.text_MoveMode_3.ReadOnly = true;
            this.text_MoveMode_3.Size = new System.Drawing.Size(81, 22);
            this.text_MoveMode_3.TabIndex = 18;
            // 
            // text_MoveMode_2
            // 
            this.text_MoveMode_2.Location = new System.Drawing.Point(143, 205);
            this.text_MoveMode_2.Name = "text_MoveMode_2";
            this.text_MoveMode_2.ReadOnly = true;
            this.text_MoveMode_2.Size = new System.Drawing.Size(81, 22);
            this.text_MoveMode_2.TabIndex = 18;
            // 
            // text_Motion_3
            // 
            this.text_Motion_3.Location = new System.Drawing.Point(230, 176);
            this.text_Motion_3.Name = "text_Motion_3";
            this.text_Motion_3.ReadOnly = true;
            this.text_Motion_3.Size = new System.Drawing.Size(81, 22);
            this.text_Motion_3.TabIndex = 18;
            // 
            // text_Motion_2
            // 
            this.text_Motion_2.Location = new System.Drawing.Point(143, 176);
            this.text_Motion_2.Name = "text_Motion_2";
            this.text_Motion_2.ReadOnly = true;
            this.text_Motion_2.Size = new System.Drawing.Size(81, 22);
            this.text_Motion_2.TabIndex = 18;
            // 
            // text_Buffer_3
            // 
            this.text_Buffer_3.Location = new System.Drawing.Point(230, 148);
            this.text_Buffer_3.Name = "text_Buffer_3";
            this.text_Buffer_3.ReadOnly = true;
            this.text_Buffer_3.Size = new System.Drawing.Size(81, 22);
            this.text_Buffer_3.TabIndex = 18;
            // 
            // text_Buffer_2
            // 
            this.text_Buffer_2.Location = new System.Drawing.Point(143, 148);
            this.text_Buffer_2.Name = "text_Buffer_2";
            this.text_Buffer_2.ReadOnly = true;
            this.text_Buffer_2.Size = new System.Drawing.Size(81, 22);
            this.text_Buffer_2.TabIndex = 18;
            // 
            // text_IO_3
            // 
            this.text_IO_3.Location = new System.Drawing.Point(230, 120);
            this.text_IO_3.Name = "text_IO_3";
            this.text_IO_3.ReadOnly = true;
            this.text_IO_3.Size = new System.Drawing.Size(81, 22);
            this.text_IO_3.TabIndex = 18;
            // 
            // text_IO_2
            // 
            this.text_IO_2.Location = new System.Drawing.Point(143, 120);
            this.text_IO_2.Name = "text_IO_2";
            this.text_IO_2.ReadOnly = true;
            this.text_IO_2.Size = new System.Drawing.Size(81, 22);
            this.text_IO_2.TabIndex = 18;
            // 
            // text_MoveMode_1
            // 
            this.text_MoveMode_1.Location = new System.Drawing.Point(56, 205);
            this.text_MoveMode_1.Name = "text_MoveMode_1";
            this.text_MoveMode_1.ReadOnly = true;
            this.text_MoveMode_1.Size = new System.Drawing.Size(81, 22);
            this.text_MoveMode_1.TabIndex = 18;
            // 
            // text_SPD_3
            // 
            this.text_SPD_3.Location = new System.Drawing.Point(230, 92);
            this.text_SPD_3.Name = "text_SPD_3";
            this.text_SPD_3.ReadOnly = true;
            this.text_SPD_3.Size = new System.Drawing.Size(81, 22);
            this.text_SPD_3.TabIndex = 18;
            // 
            // text_Motion_1
            // 
            this.text_Motion_1.Location = new System.Drawing.Point(56, 176);
            this.text_Motion_1.Name = "text_Motion_1";
            this.text_Motion_1.ReadOnly = true;
            this.text_Motion_1.Size = new System.Drawing.Size(81, 22);
            this.text_Motion_1.TabIndex = 18;
            // 
            // text_SPD_2
            // 
            this.text_SPD_2.Location = new System.Drawing.Point(143, 92);
            this.text_SPD_2.Name = "text_SPD_2";
            this.text_SPD_2.ReadOnly = true;
            this.text_SPD_2.Size = new System.Drawing.Size(81, 22);
            this.text_SPD_2.TabIndex = 18;
            // 
            // text_Buffer_1
            // 
            this.text_Buffer_1.Location = new System.Drawing.Point(56, 148);
            this.text_Buffer_1.Name = "text_Buffer_1";
            this.text_Buffer_1.ReadOnly = true;
            this.text_Buffer_1.Size = new System.Drawing.Size(81, 22);
            this.text_Buffer_1.TabIndex = 18;
            // 
            // text_FBK_3
            // 
            this.text_FBK_3.Location = new System.Drawing.Point(230, 64);
            this.text_FBK_3.Name = "text_FBK_3";
            this.text_FBK_3.ReadOnly = true;
            this.text_FBK_3.Size = new System.Drawing.Size(81, 22);
            this.text_FBK_3.TabIndex = 18;
            // 
            // text_IO_1
            // 
            this.text_IO_1.Location = new System.Drawing.Point(56, 120);
            this.text_IO_1.Name = "text_IO_1";
            this.text_IO_1.ReadOnly = true;
            this.text_IO_1.Size = new System.Drawing.Size(81, 22);
            this.text_IO_1.TabIndex = 18;
            // 
            // text_FBK_2
            // 
            this.text_FBK_2.Location = new System.Drawing.Point(143, 64);
            this.text_FBK_2.Name = "text_FBK_2";
            this.text_FBK_2.ReadOnly = true;
            this.text_FBK_2.Size = new System.Drawing.Size(81, 22);
            this.text_FBK_2.TabIndex = 18;
            // 
            // text_SPD_1
            // 
            this.text_SPD_1.Location = new System.Drawing.Point(56, 92);
            this.text_SPD_1.Name = "text_SPD_1";
            this.text_SPD_1.ReadOnly = true;
            this.text_SPD_1.Size = new System.Drawing.Size(81, 22);
            this.text_SPD_1.TabIndex = 18;
            // 
            // text_CMD_3
            // 
            this.text_CMD_3.Location = new System.Drawing.Point(230, 36);
            this.text_CMD_3.Name = "text_CMD_3";
            this.text_CMD_3.ReadOnly = true;
            this.text_CMD_3.Size = new System.Drawing.Size(81, 22);
            this.text_CMD_3.TabIndex = 18;
            // 
            // text_FBK_1
            // 
            this.text_FBK_1.Location = new System.Drawing.Point(56, 64);
            this.text_FBK_1.Name = "text_FBK_1";
            this.text_FBK_1.ReadOnly = true;
            this.text_FBK_1.Size = new System.Drawing.Size(81, 22);
            this.text_FBK_1.TabIndex = 18;
            // 
            // text_CMD_2
            // 
            this.text_CMD_2.Location = new System.Drawing.Point(143, 36);
            this.text_CMD_2.Name = "text_CMD_2";
            this.text_CMD_2.ReadOnly = true;
            this.text_CMD_2.Size = new System.Drawing.Size(81, 22);
            this.text_CMD_2.TabIndex = 18;
            // 
            // text_CMD_1
            // 
            this.text_CMD_1.Location = new System.Drawing.Point(56, 36);
            this.text_CMD_1.Name = "text_CMD_1";
            this.text_CMD_1.ReadOnly = true;
            this.text_CMD_1.Size = new System.Drawing.Size(81, 22);
            this.text_CMD_1.TabIndex = 18;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.text_RxMaxTime);
            this.groupBox5.Controls.Add(this.text_TxMaxTime);
            this.groupBox5.Controls.Add(this.text_RxTime);
            this.groupBox5.Controls.Add(this.text_TxTime);
            this.groupBox5.Location = new System.Drawing.Point(254, 243);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(359, 78);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "DO NodeID";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(179, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 12);
            this.label24.TabIndex = 12;
            this.label24.Text = "Rx_Max_Time";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 50);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 12);
            this.label22.TabIndex = 12;
            this.label22.Text = "Rx_Time";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(179, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 12);
            this.label23.TabIndex = 12;
            this.label23.Text = "Tx_Max_Time";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 12);
            this.label21.TabIndex = 12;
            this.label21.Text = "Tx_Time";
            // 
            // text_RxMaxTime
            // 
            this.text_RxMaxTime.Location = new System.Drawing.Point(262, 47);
            this.text_RxMaxTime.Name = "text_RxMaxTime";
            this.text_RxMaxTime.ReadOnly = true;
            this.text_RxMaxTime.Size = new System.Drawing.Size(81, 22);
            this.text_RxMaxTime.TabIndex = 18;
            // 
            // text_TxMaxTime
            // 
            this.text_TxMaxTime.Location = new System.Drawing.Point(262, 16);
            this.text_TxMaxTime.Name = "text_TxMaxTime";
            this.text_TxMaxTime.ReadOnly = true;
            this.text_TxMaxTime.Size = new System.Drawing.Size(81, 22);
            this.text_TxMaxTime.TabIndex = 18;
            // 
            // text_RxTime
            // 
            this.text_RxTime.Location = new System.Drawing.Point(65, 47);
            this.text_RxTime.Name = "text_RxTime";
            this.text_RxTime.ReadOnly = true;
            this.text_RxTime.Size = new System.Drawing.Size(81, 22);
            this.text_RxTime.TabIndex = 18;
            // 
            // text_TxTime
            // 
            this.text_TxTime.Location = new System.Drawing.Point(65, 16);
            this.text_TxTime.Name = "text_TxTime";
            this.text_TxTime.ReadOnly = true;
            this.text_TxTime.Size = new System.Drawing.Size(81, 22);
            this.text_TxTime.TabIndex = 18;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.text_MB_BlockNum_Fifo1);
            this.groupBox6.Controls.Add(this.text_MB_RemainSize_Fifo1);
            this.groupBox6.Controls.Add(this.text_MB_BlockNum_Fifo0);
            this.groupBox6.Controls.Add(this.text_MB_Status_Fifo1);
            this.groupBox6.Controls.Add(this.text_MB_RemainSize_Fifo0);
            this.groupBox6.Controls.Add(this.text_MB_Status_Fifo0);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Location = new System.Drawing.Point(622, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(257, 124);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "MotionBuffer Status";
            // 
            // text_MB_BlockNum_Fifo1
            // 
            this.text_MB_BlockNum_Fifo1.Location = new System.Drawing.Point(167, 92);
            this.text_MB_BlockNum_Fifo1.Name = "text_MB_BlockNum_Fifo1";
            this.text_MB_BlockNum_Fifo1.ReadOnly = true;
            this.text_MB_BlockNum_Fifo1.Size = new System.Drawing.Size(81, 22);
            this.text_MB_BlockNum_Fifo1.TabIndex = 18;
            // 
            // text_MB_RemainSize_Fifo1
            // 
            this.text_MB_RemainSize_Fifo1.Location = new System.Drawing.Point(167, 64);
            this.text_MB_RemainSize_Fifo1.Name = "text_MB_RemainSize_Fifo1";
            this.text_MB_RemainSize_Fifo1.ReadOnly = true;
            this.text_MB_RemainSize_Fifo1.Size = new System.Drawing.Size(81, 22);
            this.text_MB_RemainSize_Fifo1.TabIndex = 18;
            // 
            // text_MB_BlockNum_Fifo0
            // 
            this.text_MB_BlockNum_Fifo0.Location = new System.Drawing.Point(80, 92);
            this.text_MB_BlockNum_Fifo0.Name = "text_MB_BlockNum_Fifo0";
            this.text_MB_BlockNum_Fifo0.ReadOnly = true;
            this.text_MB_BlockNum_Fifo0.Size = new System.Drawing.Size(81, 22);
            this.text_MB_BlockNum_Fifo0.TabIndex = 18;
            // 
            // text_MB_Status_Fifo1
            // 
            this.text_MB_Status_Fifo1.Location = new System.Drawing.Point(167, 36);
            this.text_MB_Status_Fifo1.Name = "text_MB_Status_Fifo1";
            this.text_MB_Status_Fifo1.ReadOnly = true;
            this.text_MB_Status_Fifo1.Size = new System.Drawing.Size(81, 22);
            this.text_MB_Status_Fifo1.TabIndex = 18;
            // 
            // text_MB_RemainSize_Fifo0
            // 
            this.text_MB_RemainSize_Fifo0.Location = new System.Drawing.Point(80, 64);
            this.text_MB_RemainSize_Fifo0.Name = "text_MB_RemainSize_Fifo0";
            this.text_MB_RemainSize_Fifo0.ReadOnly = true;
            this.text_MB_RemainSize_Fifo0.Size = new System.Drawing.Size(81, 22);
            this.text_MB_RemainSize_Fifo0.TabIndex = 18;
            // 
            // text_MB_Status_Fifo0
            // 
            this.text_MB_Status_Fifo0.Location = new System.Drawing.Point(80, 36);
            this.text_MB_Status_Fifo0.Name = "text_MB_Status_Fifo0";
            this.text_MB_Status_Fifo0.ReadOnly = true;
            this.text_MB_Status_Fifo0.Size = new System.Drawing.Size(81, 22);
            this.text_MB_Status_Fifo0.TabIndex = 18;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 95);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 12);
            this.label27.TabIndex = 14;
            this.label27.Text = "BlockNum";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 67);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 12);
            this.label26.TabIndex = 14;
            this.label26.Text = "RemainSize";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(187, 18);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 12);
            this.label29.TabIndex = 14;
            this.label29.Text = "FIFO 1";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(103, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 12);
            this.label28.TabIndex = 14;
            this.label28.Text = "FIFO 0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 39);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 12);
            this.label25.TabIndex = 14;
            this.label25.Text = "Status";
            // 
            // btn_MB_SetData
            // 
            this.btn_MB_SetData.Location = new System.Drawing.Point(630, 136);
            this.btn_MB_SetData.Name = "btn_MB_SetData";
            this.btn_MB_SetData.Size = new System.Drawing.Size(75, 23);
            this.btn_MB_SetData.TabIndex = 26;
            this.btn_MB_SetData.Text = "MB_SetData";
            this.btn_MB_SetData.UseVisualStyleBackColor = true;
            this.btn_MB_SetData.Click += new System.EventHandler(this.btn_MB_SetData_Click);
            // 
            // btn_MB_Start
            // 
            this.btn_MB_Start.Location = new System.Drawing.Point(630, 162);
            this.btn_MB_Start.Name = "btn_MB_Start";
            this.btn_MB_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_MB_Start.TabIndex = 26;
            this.btn_MB_Start.Text = "MB Start";
            this.btn_MB_Start.UseVisualStyleBackColor = true;
            this.btn_MB_Start.Click += new System.EventHandler(this.btn_MB_Start_Click);
            // 
            // btn_MB_Clear
            // 
            this.btn_MB_Clear.Location = new System.Drawing.Point(630, 188);
            this.btn_MB_Clear.Name = "btn_MB_Clear";
            this.btn_MB_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_MB_Clear.TabIndex = 26;
            this.btn_MB_Clear.Text = "MB Clear";
            this.btn_MB_Clear.UseVisualStyleBackColor = true;
            this.btn_MB_Clear.Click += new System.EventHandler(this.btn_MB_Clear_Click);
            // 
            // btn_MB_Stop
            // 
            this.btn_MB_Stop.Location = new System.Drawing.Point(630, 214);
            this.btn_MB_Stop.Name = "btn_MB_Stop";
            this.btn_MB_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_MB_Stop.TabIndex = 26;
            this.btn_MB_Stop.Text = "MB Stop";
            this.btn_MB_Stop.UseVisualStyleBackColor = true;
            this.btn_MB_Stop.Click += new System.EventHandler(this.btn_MB_Stop_Click);
            // 
            // btn_MB_Set_Stop_Dec
            // 
            this.btn_MB_Set_Stop_Dec.Location = new System.Drawing.Point(630, 240);
            this.btn_MB_Set_Stop_Dec.Name = "btn_MB_Set_Stop_Dec";
            this.btn_MB_Set_Stop_Dec.Size = new System.Drawing.Size(75, 23);
            this.btn_MB_Set_Stop_Dec.TabIndex = 26;
            this.btn_MB_Set_Stop_Dec.Text = "Set Stop Dec";
            this.btn_MB_Set_Stop_Dec.UseVisualStyleBackColor = true;
            this.btn_MB_Set_Stop_Dec.Click += new System.EventHandler(this.btn_MB_Set_Stop_Dec_Click);
            // 
            // btn_MB_Get_Stop_Dec
            // 
            this.btn_MB_Get_Stop_Dec.Location = new System.Drawing.Point(630, 266);
            this.btn_MB_Get_Stop_Dec.Name = "btn_MB_Get_Stop_Dec";
            this.btn_MB_Get_Stop_Dec.Size = new System.Drawing.Size(75, 23);
            this.btn_MB_Get_Stop_Dec.TabIndex = 26;
            this.btn_MB_Get_Stop_Dec.Text = "Get Stop Dec";
            this.btn_MB_Get_Stop_Dec.UseVisualStyleBackColor = true;
            this.btn_MB_Get_Stop_Dec.Click += new System.EventHandler(this.btn_MB_Get_Stop_Dec_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(628, 298);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(51, 12);
            this.label30.TabIndex = 14;
            this.label30.Text = "Table No:";
            // 
            // combo_TableNo
            // 
            this.combo_TableNo.FormattingEnabled = true;
            this.combo_TableNo.Location = new System.Drawing.Point(678, 293);
            this.combo_TableNo.Name = "combo_TableNo";
            this.combo_TableNo.Size = new System.Drawing.Size(73, 20);
            this.combo_TableNo.TabIndex = 29;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(758, 298);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(44, 12);
            this.label31.TabIndex = 14;
            this.label31.Text = "Fifo No:";
            // 
            // combo_FifoNo
            // 
            this.combo_FifoNo.FormattingEnabled = true;
            this.combo_FifoNo.Location = new System.Drawing.Point(806, 293);
            this.combo_FifoNo.Name = "combo_FifoNo";
            this.combo_FifoNo.Size = new System.Drawing.Size(73, 20);
            this.combo_FifoNo.TabIndex = 29;
            // 
            // combo_SW_Test
            // 
            this.combo_SW_Test.FormattingEnabled = true;
            this.combo_SW_Test.Location = new System.Drawing.Point(727, 138);
            this.combo_SW_Test.Name = "combo_SW_Test";
            this.combo_SW_Test.Size = new System.Drawing.Size(73, 20);
            this.combo_SW_Test.TabIndex = 29;
            // 
            // combo_MB_Stop_Mode
            // 
            this.combo_MB_Stop_Mode.FormattingEnabled = true;
            this.combo_MB_Stop_Mode.Location = new System.Drawing.Point(727, 216);
            this.combo_MB_Stop_Mode.Name = "combo_MB_Stop_Mode";
            this.combo_MB_Stop_Mode.Size = new System.Drawing.Size(73, 20);
            this.combo_MB_Stop_Mode.TabIndex = 29;
            // 
            // text_MB_Stop_Dec
            // 
            this.text_MB_Stop_Dec.Location = new System.Drawing.Point(727, 243);
            this.text_MB_Stop_Dec.Name = "text_MB_Stop_Dec";
            this.text_MB_Stop_Dec.Size = new System.Drawing.Size(73, 22);
            this.text_MB_Stop_Dec.TabIndex = 30;
            // 
            // chk_Drwing
            // 
            this.chk_Drwing.AutoSize = true;
            this.chk_Drwing.Location = new System.Drawing.Point(827, 169);
            this.chk_Drwing.Name = "chk_Drwing";
            this.chk_Drwing.Size = new System.Drawing.Size(59, 16);
            this.chk_Drwing.TabIndex = 25;
            this.chk_Drwing.Text = "Drwing";
            this.chk_Drwing.UseVisualStyleBackColor = true;
            // 
            // myScope1
            // 
            this.myScope1.BackColor = System.Drawing.Color.Transparent;
            this.myScope1.Location = new System.Drawing.Point(6, 327);
            this.myScope1.Name = "myScope1";
            this.myScope1.Size = new System.Drawing.Size(873, 254);
            this.myScope1.TabIndex = 31;
            // 
            // myScope2
            // 
            this.myScope2.Location = new System.Drawing.Point(885, 19);
            this.myScope2.Name = "myScope2";
            this.myScope2.Size = new System.Drawing.Size(502, 562);
            this.myScope2.TabIndex = 32;
            // 
            // ClearScope_button
            // 
            this.ClearScope_button.Location = new System.Drawing.Point(827, 197);
            this.ClearScope_button.Name = "ClearScope_button";
            this.ClearScope_button.Size = new System.Drawing.Size(75, 23);
            this.ClearScope_button.TabIndex = 33;
            this.ClearScope_button.Text = "ClearScope";
            this.ClearScope_button.UseVisualStyleBackColor = true;
            this.ClearScope_button.Click += new System.EventHandler(this.ClearScope_button_Click);
            // 
            // IOControlcheckBox
            // 
            this.IOControlcheckBox.AutoSize = true;
            this.IOControlcheckBox.Location = new System.Drawing.Point(827, 246);
            this.IOControlcheckBox.Name = "IOControlcheckBox";
            this.IOControlcheckBox.Size = new System.Drawing.Size(72, 16);
            this.IOControlcheckBox.TabIndex = 34;
            this.IOControlcheckBox.Text = "IOControl";
            this.IOControlcheckBox.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(628, 327);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 12);
            this.label33.TabIndex = 35;
            this.label33.Text = "Delay:";
            // 
            // DelaytextBox
            // 
            this.DelaytextBox.Location = new System.Drawing.Point(678, 319);
            this.DelaytextBox.Name = "DelaytextBox";
            this.DelaytextBox.Size = new System.Drawing.Size(73, 22);
            this.DelaytextBox.TabIndex = 36;
            this.DelaytextBox.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 613);
            this.Controls.Add(this.DelaytextBox);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.IOControlcheckBox);
            this.Controls.Add(this.ClearScope_button);
            this.Controls.Add(this.myScope2);
            this.Controls.Add(this.myScope1);
            this.Controls.Add(this.text_MB_Stop_Dec);
            this.Controls.Add(this.combo_MB_Stop_Mode);
            this.Controls.Add(this.combo_SW_Test);
            this.Controls.Add(this.combo_FifoNo);
            this.Controls.Add(this.combo_TableNo);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_RESET);
            this.Controls.Add(this.btn_RALM);
            this.Controls.Add(this.btn_MB_Get_Stop_Dec);
            this.Controls.Add(this.btn_MB_Set_Stop_Dec);
            this.Controls.Add(this.btn_MB_Stop);
            this.Controls.Add(this.btn_MB_Clear);
            this.Controls.Add(this.btn_MB_Start);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.btn_MB_SetData);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.btn_SVON);
            this.Controls.Add(this.chk_Drwing);
            this.Controls.Add(this.chk_Timer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.combo_CardNo);
            this.Controls.Add(this.text_SlaveNum);
            this.Controls.Add(this.text_Initial_Satatus);
            this.Controls.Add(this.text_CardNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_FindSlave);
            this.Controls.Add(this.btn_Initial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_X_NodeID;
        private System.Windows.Forms.ComboBox combo_CardNo;
        private System.Windows.Forms.TextBox text_SlaveNum;
        private System.Windows.Forms.TextBox text_Initial_Satatus;
        private System.Windows.Forms.TextBox text_CardNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_FindSlave;
        private System.Windows.Forms.Button btn_Initial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_Y_NodeID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combo_DO_NodeID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_Axis_NodeID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chk_Timer;
        private System.Windows.Forms.Button btn_SVON;
        private System.Windows.Forms.Button btn_RALM;
        private System.Windows.Forms.Button btn_RESET;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text_Motion_3;
        private System.Windows.Forms.TextBox text_Motion_2;
        private System.Windows.Forms.TextBox text_Buffer_3;
        private System.Windows.Forms.TextBox text_Buffer_2;
        private System.Windows.Forms.TextBox text_IO_3;
        private System.Windows.Forms.TextBox text_IO_2;
        private System.Windows.Forms.TextBox text_SPD_3;
        private System.Windows.Forms.TextBox text_Motion_1;
        private System.Windows.Forms.TextBox text_SPD_2;
        private System.Windows.Forms.TextBox text_Buffer_1;
        private System.Windows.Forms.TextBox text_FBK_3;
        private System.Windows.Forms.TextBox text_IO_1;
        private System.Windows.Forms.TextBox text_FBK_2;
        private System.Windows.Forms.TextBox text_SPD_1;
        private System.Windows.Forms.TextBox text_CMD_3;
        private System.Windows.Forms.TextBox text_FBK_1;
        private System.Windows.Forms.TextBox text_CMD_2;
        private System.Windows.Forms.TextBox text_CMD_1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox text_RxMaxTime;
        private System.Windows.Forms.TextBox text_TxMaxTime;
        private System.Windows.Forms.TextBox text_RxTime;
        private System.Windows.Forms.TextBox text_TxTime;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox text_MB_BlockNum_Fifo1;
        private System.Windows.Forms.TextBox text_MB_RemainSize_Fifo1;
        private System.Windows.Forms.TextBox text_MB_BlockNum_Fifo0;
        private System.Windows.Forms.TextBox text_MB_Status_Fifo1;
        private System.Windows.Forms.TextBox text_MB_RemainSize_Fifo0;
        private System.Windows.Forms.TextBox text_MB_Status_Fifo0;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btn_MB_SetData;
        private System.Windows.Forms.Button btn_MB_Start;
        private System.Windows.Forms.Button btn_MB_Clear;
        private System.Windows.Forms.Button btn_MB_Stop;
        private System.Windows.Forms.Button btn_MB_Set_Stop_Dec;
        private System.Windows.Forms.Button btn_MB_Get_Stop_Dec;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox combo_TableNo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox combo_FifoNo;
        private System.Windows.Forms.ComboBox combo_SW_Test;
        private System.Windows.Forms.ComboBox combo_MB_Stop_Mode;
        private System.Windows.Forms.TextBox text_MB_Stop_Dec;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox text_MoveMode_3;
        private System.Windows.Forms.TextBox text_MoveMode_2;
        private System.Windows.Forms.TextBox text_MoveMode_1;
        private MyScope.MyScope myScope1;
        private System.Windows.Forms.CheckBox chk_Drwing;
        private MyScope.MyScope myScope2;
        private System.Windows.Forms.Button ClearScope_button;
        private System.Windows.Forms.CheckBox IOControlcheckBox;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox DelaytextBox;

    }
}

