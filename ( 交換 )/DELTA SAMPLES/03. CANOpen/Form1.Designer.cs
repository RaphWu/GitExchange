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
            this.btnexit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsub = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtslotid = new System.Windows.Forms.TextBox();
            this.txtsubidx = new System.Windows.Forms.TextBox();
            this.txtindex = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.btnread = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNodeID2 = new System.Windows.Forms.ComboBox();
            this.cmbNodeID1 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnget = new System.Windows.Forms.Button();
            this.txtD7 = new System.Windows.Forms.TextBox();
            this.txtD6 = new System.Windows.Forms.TextBox();
            this.txtD5 = new System.Windows.Forms.TextBox();
            this.txtD4 = new System.Windows.Forms.TextBox();
            this.txttype2 = new System.Windows.Forms.TextBox();
            this.txtidxR2 = new System.Windows.Forms.TextBox();
            this.txtsubidxR2 = new System.Windows.Forms.TextBox();
            this.txtsubidx2 = new System.Windows.Forms.TextBox();
            this.txtindex2 = new System.Windows.Forms.TextBox();
            this.txtslotid2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtD3R = new System.Windows.Forms.TextBox();
            this.txtD2R = new System.Windows.Forms.TextBox();
            this.txtD1R = new System.Windows.Forms.TextBox();
            this.txtD0R = new System.Windows.Forms.TextBox();
            this.txttypeR = new System.Windows.Forms.TextBox();
            this.txtidxR = new System.Windows.Forms.TextBox();
            this.txtsubidxR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtD3 = new System.Windows.Forms.TextBox();
            this.txtD2 = new System.Windows.Forms.TextBox();
            this.txtD1 = new System.Windows.Forms.TextBox();
            this.txtD0 = new System.Windows.Forms.TextBox();
            this.txttype = new System.Windows.Forms.TextBox();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninitial
            // 
            this.btninitial.Location = new System.Drawing.Point(12, 0);
            this.btninitial.Name = "btninitial";
            this.btninitial.Size = new System.Drawing.Size(85, 28);
            this.btninitial.TabIndex = 0;
            this.btninitial.Text = "1-1 Open Card";
            this.btninitial.UseVisualStyleBackColor = true;
            this.btninitial.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(278, 25);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(213, 31);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Card No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Slave Num:";
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(176, 35);
            this.txtSlaveNum.Name = "txtSlaveNum";
            this.txtSlaveNum.ReadOnly = true;
            this.txtSlaveNum.Size = new System.Drawing.Size(27, 22);
            this.txtSlaveNum.TabIndex = 11;
            this.txtSlaveNum.Text = "0";
            this.txtSlaveNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Node ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Slot ID";
            // 
            // txtsub
            // 
            this.txtsub.AutoSize = true;
            this.txtsub.Location = new System.Drawing.Point(151, 26);
            this.txtsub.Name = "txtsub";
            this.txtsub.Size = new System.Drawing.Size(23, 12);
            this.txtsub.TabIndex = 14;
            this.txtsub.Text = "Sub";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Index";
            // 
            // txtslotid
            // 
            this.txtslotid.Location = new System.Drawing.Point(58, 41);
            this.txtslotid.Name = "txtslotid";
            this.txtslotid.ReadOnly = true;
            this.txtslotid.Size = new System.Drawing.Size(35, 22);
            this.txtslotid.TabIndex = 19;
            this.txtslotid.Text = "0";
            this.txtslotid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtsubidx
            // 
            this.txtsubidx.Location = new System.Drawing.Point(140, 41);
            this.txtsubidx.Name = "txtsubidx";
            this.txtsubidx.Size = new System.Drawing.Size(35, 22);
            this.txtsubidx.TabIndex = 20;
            this.txtsubidx.Text = "0";
            this.txtsubidx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtindex
            // 
            this.txtindex.Location = new System.Drawing.Point(105, 41);
            this.txtindex.Name = "txtindex";
            this.txtindex.Size = new System.Drawing.Size(35, 22);
            this.txtindex.TabIndex = 21;
            this.txtindex.Text = "0";
            this.txtindex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(368, 41);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(42, 23);
            this.btnsend.TabIndex = 26;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // btnread
            // 
            this.btnread.Location = new System.Drawing.Point(368, 82);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(42, 23);
            this.btnread.TabIndex = 27;
            this.btnread.Text = "Read";
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.btnread_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNodeID2);
            this.groupBox1.Controls.Add(this.cmbNodeID1);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btnget);
            this.groupBox1.Controls.Add(this.txtD7);
            this.groupBox1.Controls.Add(this.txtD6);
            this.groupBox1.Controls.Add(this.txtD5);
            this.groupBox1.Controls.Add(this.txtD4);
            this.groupBox1.Controls.Add(this.txttype2);
            this.groupBox1.Controls.Add(this.txtidxR2);
            this.groupBox1.Controls.Add(this.txtsubidxR2);
            this.groupBox1.Controls.Add(this.txtsubidx2);
            this.groupBox1.Controls.Add(this.txtindex2);
            this.groupBox1.Controls.Add(this.txtslotid2);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtD3R);
            this.groupBox1.Controls.Add(this.txtD2R);
            this.groupBox1.Controls.Add(this.txtD1R);
            this.groupBox1.Controls.Add(this.txtD0R);
            this.groupBox1.Controls.Add(this.txttypeR);
            this.groupBox1.Controls.Add(this.txtidxR);
            this.groupBox1.Controls.Add(this.txtsubidxR);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtD3);
            this.groupBox1.Controls.Add(this.txtD2);
            this.groupBox1.Controls.Add(this.txtD1);
            this.groupBox1.Controls.Add(this.txtD0);
            this.groupBox1.Controls.Add(this.txttype);
            this.groupBox1.Controls.Add(this.btnread);
            this.groupBox1.Controls.Add(this.btnsend);
            this.groupBox1.Controls.Add(this.txtindex);
            this.groupBox1.Controls.Add(this.txtsubidx);
            this.groupBox1.Controls.Add(this.txtslotid);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtsub);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 156);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " CANOPEN operate";
            // 
            // cmbNodeID2
            // 
            this.cmbNodeID2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID2.FormattingEnabled = true;
            this.cmbNodeID2.Location = new System.Drawing.Point(8, 127);
            this.cmbNodeID2.Name = "cmbNodeID2";
            this.cmbNodeID2.Size = new System.Drawing.Size(40, 20);
            this.cmbNodeID2.TabIndex = 76;
            // 
            // cmbNodeID1
            // 
            this.cmbNodeID1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID1.FormattingEnabled = true;
            this.cmbNodeID1.Location = new System.Drawing.Point(8, 41);
            this.cmbNodeID1.Name = "cmbNodeID1";
            this.cmbNodeID1.Size = new System.Drawing.Size(40, 20);
            this.cmbNodeID1.TabIndex = 75;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(395, 113);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(19, 12);
            this.label25.TabIndex = 74;
            this.label25.Text = "D3";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(360, 113);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 12);
            this.label26.TabIndex = 73;
            this.label26.Text = "D2";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(327, 113);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(19, 12);
            this.label27.TabIndex = 72;
            this.label27.Text = "D1";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(289, 113);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(19, 12);
            this.label28.TabIndex = 71;
            this.label28.Text = "D0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(244, 113);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 70;
            this.label23.Text = "Type";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(209, 113);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 12);
            this.label24.TabIndex = 69;
            this.label24.Text = "Cmd";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(162, 113);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 68;
            this.label22.Text = "COBID";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(126, 113);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 12);
            this.label21.TabIndex = 67;
            this.label21.Text = "Subidx";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(92, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 12);
            this.label20.TabIndex = 66;
            this.label20.Text = "Index";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(50, 113);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 12);
            this.label19.TabIndex = 65;
            this.label19.Text = "Slot ID";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 113);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 12);
            this.label18.TabIndex = 64;
            this.label18.Text = "Node ID";
            // 
            // btnget
            // 
            this.btnget.Location = new System.Drawing.Point(426, 127);
            this.btnget.Name = "btnget";
            this.btnget.Size = new System.Drawing.Size(42, 23);
            this.btnget.TabIndex = 63;
            this.btnget.Text = "Get";
            this.btnget.UseVisualStyleBackColor = true;
            this.btnget.Click += new System.EventHandler(this.btnget_Click);
            // 
            // txtD7
            // 
            this.txtD7.Location = new System.Drawing.Point(385, 128);
            this.txtD7.Name = "txtD7";
            this.txtD7.ReadOnly = true;
            this.txtD7.Size = new System.Drawing.Size(35, 22);
            this.txtD7.TabIndex = 62;
            this.txtD7.Text = " ";
            this.txtD7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD6
            // 
            this.txtD6.Location = new System.Drawing.Point(350, 128);
            this.txtD6.Name = "txtD6";
            this.txtD6.ReadOnly = true;
            this.txtD6.Size = new System.Drawing.Size(35, 22);
            this.txtD6.TabIndex = 61;
            this.txtD6.Text = " ";
            this.txtD6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD5
            // 
            this.txtD5.Location = new System.Drawing.Point(315, 128);
            this.txtD5.Name = "txtD5";
            this.txtD5.ReadOnly = true;
            this.txtD5.Size = new System.Drawing.Size(35, 22);
            this.txtD5.TabIndex = 60;
            this.txtD5.Text = " ";
            this.txtD5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD4
            // 
            this.txtD4.Location = new System.Drawing.Point(280, 128);
            this.txtD4.Name = "txtD4";
            this.txtD4.ReadOnly = true;
            this.txtD4.Size = new System.Drawing.Size(35, 22);
            this.txtD4.TabIndex = 59;
            this.txtD4.Text = " ";
            this.txtD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txttype2
            // 
            this.txttype2.Location = new System.Drawing.Point(239, 128);
            this.txttype2.Name = "txttype2";
            this.txttype2.ReadOnly = true;
            this.txttype2.Size = new System.Drawing.Size(35, 22);
            this.txttype2.TabIndex = 58;
            this.txttype2.Text = " ";
            this.txttype2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtidxR2
            // 
            this.txtidxR2.Location = new System.Drawing.Point(204, 128);
            this.txtidxR2.Name = "txtidxR2";
            this.txtidxR2.ReadOnly = true;
            this.txtidxR2.Size = new System.Drawing.Size(35, 22);
            this.txtidxR2.TabIndex = 57;
            this.txtidxR2.Text = " ";
            this.txtidxR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtsubidxR2
            // 
            this.txtsubidxR2.Location = new System.Drawing.Point(163, 128);
            this.txtsubidxR2.Name = "txtsubidxR2";
            this.txtsubidxR2.ReadOnly = true;
            this.txtsubidxR2.Size = new System.Drawing.Size(35, 22);
            this.txtsubidxR2.TabIndex = 56;
            this.txtsubidxR2.Text = " ";
            this.txtsubidxR2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtsubidx2
            // 
            this.txtsubidx2.Location = new System.Drawing.Point(128, 128);
            this.txtsubidx2.Name = "txtsubidx2";
            this.txtsubidx2.Size = new System.Drawing.Size(35, 22);
            this.txtsubidx2.TabIndex = 55;
            this.txtsubidx2.Text = "0";
            this.txtsubidx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtindex2
            // 
            this.txtindex2.Location = new System.Drawing.Point(93, 128);
            this.txtindex2.Name = "txtindex2";
            this.txtindex2.Size = new System.Drawing.Size(35, 22);
            this.txtindex2.TabIndex = 54;
            this.txtindex2.Text = "0";
            this.txtindex2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtslotid2
            // 
            this.txtslotid2.Location = new System.Drawing.Point(52, 128);
            this.txtslotid2.Name = "txtslotid2";
            this.txtslotid2.ReadOnly = true;
            this.txtslotid2.Size = new System.Drawing.Size(35, 22);
            this.txtslotid2.TabIndex = 53;
            this.txtslotid2.Text = "0";
            this.txtslotid2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(181, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 51;
            this.label17.Text = "Type";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(146, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 12);
            this.label16.TabIndex = 50;
            this.label16.Text = "Cmd";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(101, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 49;
            this.label15.Text = "COBID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "D3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 12);
            this.label8.TabIndex = 47;
            this.label8.Text = "D2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(267, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 12);
            this.label13.TabIndex = 46;
            this.label13.Text = "D1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(229, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 12);
            this.label14.TabIndex = 45;
            this.label14.Text = "D0";
            // 
            // txtD3R
            // 
            this.txtD3R.Location = new System.Drawing.Point(327, 84);
            this.txtD3R.Name = "txtD3R";
            this.txtD3R.ReadOnly = true;
            this.txtD3R.Size = new System.Drawing.Size(35, 22);
            this.txtD3R.TabIndex = 44;
            this.txtD3R.Text = " ";
            this.txtD3R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtD3R.UseWaitCursor = true;
            // 
            // txtD2R
            // 
            this.txtD2R.Location = new System.Drawing.Point(292, 84);
            this.txtD2R.Name = "txtD2R";
            this.txtD2R.ReadOnly = true;
            this.txtD2R.Size = new System.Drawing.Size(35, 22);
            this.txtD2R.TabIndex = 43;
            this.txtD2R.Text = " ";
            this.txtD2R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtD2R.UseWaitCursor = true;
            // 
            // txtD1R
            // 
            this.txtD1R.Location = new System.Drawing.Point(257, 84);
            this.txtD1R.Name = "txtD1R";
            this.txtD1R.ReadOnly = true;
            this.txtD1R.Size = new System.Drawing.Size(35, 22);
            this.txtD1R.TabIndex = 42;
            this.txtD1R.Text = " ";
            this.txtD1R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtD1R.UseWaitCursor = true;
            // 
            // txtD0R
            // 
            this.txtD0R.Location = new System.Drawing.Point(222, 84);
            this.txtD0R.Name = "txtD0R";
            this.txtD0R.ReadOnly = true;
            this.txtD0R.Size = new System.Drawing.Size(35, 22);
            this.txtD0R.TabIndex = 41;
            this.txtD0R.Text = " ";
            this.txtD0R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtD0R.UseWaitCursor = true;
            // 
            // txttypeR
            // 
            this.txttypeR.Location = new System.Drawing.Point(175, 84);
            this.txttypeR.Name = "txttypeR";
            this.txttypeR.ReadOnly = true;
            this.txttypeR.Size = new System.Drawing.Size(35, 22);
            this.txttypeR.TabIndex = 40;
            this.txttypeR.Text = " ";
            this.txttypeR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttypeR.UseWaitCursor = true;
            // 
            // txtidxR
            // 
            this.txtidxR.Location = new System.Drawing.Point(140, 84);
            this.txtidxR.Name = "txtidxR";
            this.txtidxR.ReadOnly = true;
            this.txtidxR.Size = new System.Drawing.Size(35, 22);
            this.txtidxR.TabIndex = 39;
            this.txtidxR.Text = " ";
            this.txtidxR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtidxR.UseWaitCursor = true;
            // 
            // txtsubidxR
            // 
            this.txtsubidxR.Location = new System.Drawing.Point(105, 84);
            this.txtsubidxR.Name = "txtsubidxR";
            this.txtsubidxR.ReadOnly = true;
            this.txtsubidxR.Size = new System.Drawing.Size(35, 22);
            this.txtsubidxR.TabIndex = 38;
            this.txtsubidxR.Text = " ";
            this.txtsubidxR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsubidxR.UseWaitCursor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(335, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 12);
            this.label12.TabIndex = 37;
            this.label12.Text = "D3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 12);
            this.label11.TabIndex = 36;
            this.label11.Text = "D2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(267, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 12);
            this.label10.TabIndex = 35;
            this.label10.Text = "D1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "D0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "Type";
            // 
            // txtD3
            // 
            this.txtD3.Location = new System.Drawing.Point(327, 41);
            this.txtD3.Name = "txtD3";
            this.txtD3.Size = new System.Drawing.Size(35, 22);
            this.txtD3.TabIndex = 32;
            this.txtD3.Text = "0";
            this.txtD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD2
            // 
            this.txtD2.Location = new System.Drawing.Point(292, 41);
            this.txtD2.Name = "txtD2";
            this.txtD2.Size = new System.Drawing.Size(35, 22);
            this.txtD2.TabIndex = 31;
            this.txtD2.Text = "0";
            this.txtD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD1
            // 
            this.txtD1.Location = new System.Drawing.Point(257, 41);
            this.txtD1.Name = "txtD1";
            this.txtD1.Size = new System.Drawing.Size(35, 22);
            this.txtD1.TabIndex = 30;
            this.txtD1.Text = "0";
            this.txtD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtD0
            // 
            this.txtD0.Location = new System.Drawing.Point(222, 41);
            this.txtD0.Name = "txtD0";
            this.txtD0.Size = new System.Drawing.Size(35, 22);
            this.txtD0.TabIndex = 29;
            this.txtD0.Text = "0";
            this.txtD0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txttype
            // 
            this.txttype.Location = new System.Drawing.Point(175, 41);
            this.txttype.Name = "txttype";
            this.txttype.Size = new System.Drawing.Size(35, 22);
            this.txttype.TabIndex = 28;
            this.txttype.Text = "0";
            this.txttype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFindSlave
            // 
            this.btnFindSlave.Enabled = false;
            this.btnFindSlave.Location = new System.Drawing.Point(12, 28);
            this.btnFindSlave.Name = "btnFindSlave";
            this.btnFindSlave.Size = new System.Drawing.Size(85, 28);
            this.btnFindSlave.TabIndex = 29;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(176, 7);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(43, 20);
            this.CmbCardNo.TabIndex = 30;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 242);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.btnFindSlave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSlaveNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btninitial);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninitial;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSlaveNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtsub;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtslotid;
        private System.Windows.Forms.TextBox txtsubidx;
        private System.Windows.Forms.TextBox txtindex;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtD3;
        private System.Windows.Forms.TextBox txtD2;
        private System.Windows.Forms.TextBox txtD1;
        private System.Windows.Forms.TextBox txtD0;
        private System.Windows.Forms.TextBox txttype;
        private System.Windows.Forms.TextBox txtD3R;
        private System.Windows.Forms.TextBox txtD2R;
        private System.Windows.Forms.TextBox txtD1R;
        private System.Windows.Forms.TextBox txtD0R;
        private System.Windows.Forms.TextBox txttypeR;
        private System.Windows.Forms.TextBox txtidxR;
        private System.Windows.Forms.TextBox txtsubidxR;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnget;
        private System.Windows.Forms.TextBox txtD7;
        private System.Windows.Forms.TextBox txtD6;
        private System.Windows.Forms.TextBox txtD5;
        private System.Windows.Forms.TextBox txtD4;
        private System.Windows.Forms.TextBox txttype2;
        private System.Windows.Forms.TextBox txtidxR2;
        private System.Windows.Forms.TextBox txtsubidxR2;
        private System.Windows.Forms.TextBox txtsubidx2;
        private System.Windows.Forms.TextBox txtindex2;
        private System.Windows.Forms.TextBox txtslotid2;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.ComboBox cmbNodeID2;
        private System.Windows.Forms.ComboBox cmbNodeID1;
    }
}

