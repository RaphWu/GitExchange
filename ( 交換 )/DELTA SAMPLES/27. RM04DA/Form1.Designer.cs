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
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.cmbNodeID = new System.Windows.Forms.ComboBox();
            this.frm04DA = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdClearERR = new System.Windows.Forms.Button();
            this.cmdSetOffset = new System.Windows.Forms.Button();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkOverRange = new System.Windows.Forms.CheckBox();
            this.chkERR = new System.Windows.Forms.CheckBox();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.barV = new System.Windows.Forms.TrackBar();
            this.txtRead = new System.Windows.Forms.TextBox();
            this.txtAppro = new System.Windows.Forms.TextBox();
            this.txtUnitRead = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitAppro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frm04DA.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barV)).BeginInit();
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
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(8, 272);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(424, 31);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(253, 17);
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
            this.label10.Location = new System.Drawing.Point(98, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(191, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "Slave Num:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(288, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 12);
            this.label22.TabIndex = 70;
            this.label22.Text = "DA NodeID:";
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
            this.CmbCardNo.Location = new System.Drawing.Point(147, 17);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(39, 20);
            this.CmbCardNo.TabIndex = 74;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // cmbNodeID
            // 
            this.cmbNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID.FormattingEnabled = true;
            this.cmbNodeID.Location = new System.Drawing.Point(352, 16);
            this.cmbNodeID.Name = "cmbNodeID";
            this.cmbNodeID.Size = new System.Drawing.Size(47, 20);
            this.cmbNodeID.TabIndex = 75;
            // 
            // frm04DA
            // 
            this.frm04DA.Controls.Add(this.groupBox2);
            this.frm04DA.Controls.Add(this.cmdApply);
            this.frm04DA.Controls.Add(this.cmbMode);
            this.frm04DA.Controls.Add(this.cmbChannel);
            this.frm04DA.Controls.Add(this.label9);
            this.frm04DA.Controls.Add(this.label8);
            this.frm04DA.Controls.Add(this.label7);
            this.frm04DA.Controls.Add(this.label6);
            this.frm04DA.Controls.Add(this.label5);
            this.frm04DA.Controls.Add(this.barV);
            this.frm04DA.Controls.Add(this.txtRead);
            this.frm04DA.Controls.Add(this.txtAppro);
            this.frm04DA.Controls.Add(this.txtUnitRead);
            this.frm04DA.Controls.Add(this.label3);
            this.frm04DA.Controls.Add(this.txtUnitAppro);
            this.frm04DA.Controls.Add(this.label1);
            this.frm04DA.Location = new System.Drawing.Point(8, 56);
            this.frm04DA.Name = "frm04DA";
            this.frm04DA.Size = new System.Drawing.Size(424, 208);
            this.frm04DA.TabIndex = 76;
            this.frm04DA.TabStop = false;
            this.frm04DA.Text = "RM04DA Channel 0 Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdClearERR);
            this.groupBox2.Controls.Add(this.cmdSetOffset);
            this.groupBox2.Controls.Add(this.txtERR);
            this.groupBox2.Controls.Add(this.txtOffset);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.chkOverRange);
            this.groupBox2.Controls.Add(this.chkERR);
            this.groupBox2.Location = new System.Drawing.Point(8, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 80);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Choice";
            // 
            // cmdClearERR
            // 
            this.cmdClearERR.Location = new System.Drawing.Point(280, 53);
            this.cmdClearERR.Name = "cmdClearERR";
            this.cmdClearERR.Size = new System.Drawing.Size(75, 23);
            this.cmdClearERR.TabIndex = 8;
            this.cmdClearERR.Text = "Clear Error";
            this.cmdClearERR.UseVisualStyleBackColor = true;
            this.cmdClearERR.Click += new System.EventHandler(this.cmdClearERR_Click);
            // 
            // cmdSetOffset
            // 
            this.cmdSetOffset.Location = new System.Drawing.Point(280, 29);
            this.cmdSetOffset.Name = "cmdSetOffset";
            this.cmdSetOffset.Size = new System.Drawing.Size(75, 23);
            this.cmdSetOffset.TabIndex = 7;
            this.cmdSetOffset.Text = "Set Offset";
            this.cmdSetOffset.UseVisualStyleBackColor = true;
            this.cmdSetOffset.Click += new System.EventHandler(this.cmdSetOffset_Click);
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(208, 53);
            this.txtERR.Name = "txtERR";
            this.txtERR.Size = new System.Drawing.Size(56, 22);
            this.txtERR.TabIndex = 6;
            this.txtERR.Text = "0";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(208, 29);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(56, 22);
            this.txtOffset.TabIndex = 5;
            this.txtOffset.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(136, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "Return Code:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(160, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "Offset:";
            // 
            // chkOverRange
            // 
            this.chkOverRange.AutoSize = true;
            this.chkOverRange.Location = new System.Drawing.Point(40, 56);
            this.chkOverRange.Name = "chkOverRange";
            this.chkOverRange.Size = new System.Drawing.Size(80, 16);
            this.chkOverRange.TabIndex = 1;
            this.chkOverRange.Text = "Over Range";
            this.chkOverRange.UseVisualStyleBackColor = true;
            this.chkOverRange.CheckedChanged += new System.EventHandler(this.chkOverRange_CheckedChanged);
            // 
            // chkERR
            // 
            this.chkERR.AutoSize = true;
            this.chkERR.Location = new System.Drawing.Point(40, 32);
            this.chkERR.Name = "chkERR";
            this.chkERR.Size = new System.Drawing.Size(85, 16);
            this.chkERR.TabIndex = 0;
            this.chkERR.Text = "Error Handle";
            this.chkERR.UseVisualStyleBackColor = true;
            this.chkERR.CheckedChanged += new System.EventHandler(this.chkERR_CheckedChanged);
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(280, 80);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(120, 32);
            this.cmdApply.TabIndex = 14;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "0: 0 ~ 5 V",
            "1: 0 ~ 10 V",
            "2: -5 ~ 5 V",
            "3: -10 ~ 10 V",
            "4: NULL",
            "5: 4 ~ 20 mA",
            "6: 0 ~ 20 mA",
            "7: 0 ~ 24 mA"});
            this.cmbMode.Location = new System.Drawing.Point(328, 56);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(80, 20);
            this.cmbMode.TabIndex = 13;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Items.AddRange(new object[] {
            "0: Channel 0",
            "1: Channel 1",
            "2: Channel 2",
            "3: Channel 3"});
            this.cmbChannel.Location = new System.Drawing.Point(328, 24);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(80, 20);
            this.cmbChannel.TabIndex = 12;
            this.cmbChannel.SelectedIndexChanged += new System.EventHandler(this.cmdChannel_SelectedIndexChanged_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "Mode:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "Channel:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "100%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "0";
            // 
            // barV
            // 
            this.barV.Location = new System.Drawing.Point(8, 48);
            this.barV.Maximum = 65535;
            this.barV.Name = "barV";
            this.barV.Size = new System.Drawing.Size(256, 42);
            this.barV.TabIndex = 6;
            // 
            // txtRead
            // 
            this.txtRead.Location = new System.Drawing.Point(184, 24);
            this.txtRead.Name = "txtRead";
            this.txtRead.Size = new System.Drawing.Size(56, 22);
            this.txtRead.TabIndex = 5;
            // 
            // txtAppro
            // 
            this.txtAppro.Location = new System.Drawing.Point(56, 24);
            this.txtAppro.Name = "txtAppro";
            this.txtAppro.Size = new System.Drawing.Size(56, 22);
            this.txtAppro.TabIndex = 4;
            // 
            // txtUnitRead
            // 
            this.txtUnitRead.AutoSize = true;
            this.txtUnitRead.Location = new System.Drawing.Point(248, 29);
            this.txtUnitRead.Name = "txtUnitRead";
            this.txtUnitRead.Size = new System.Drawing.Size(13, 12);
            this.txtUnitRead.TabIndex = 3;
            this.txtUnitRead.Text = "V";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Read:";
            // 
            // txtUnitAppro
            // 
            this.txtUnitAppro.AutoSize = true;
            this.txtUnitAppro.Location = new System.Drawing.Point(120, 29);
            this.txtUnitAppro.Name = "txtUnitAppro";
            this.txtUnitAppro.Size = new System.Drawing.Size(13, 12);
            this.txtUnitAppro.TabIndex = 1;
            this.txtUnitAppro.Text = "V";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appro:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 311);
            this.Controls.Add(this.frm04DA);
            this.Controls.Add(this.cmbNodeID);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.btnFindSlave);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSlaveNum);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btninitial);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.frm04DA.ResumeLayout(false);
            this.frm04DA.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninitial;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtSlaveNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.ComboBox cmbNodeID;
        private System.Windows.Forms.GroupBox frm04DA;
        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.TextBox txtAppro;
        private System.Windows.Forms.Label txtUnitRead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtUnitAppro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar barV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdClearERR;
        private System.Windows.Forms.Button cmdSetOffset;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkOverRange;
        private System.Windows.Forms.CheckBox chkERR;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.ComboBox cmbMode;
    }
}

