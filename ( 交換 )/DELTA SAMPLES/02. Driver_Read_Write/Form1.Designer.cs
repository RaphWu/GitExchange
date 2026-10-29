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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtslotid = new System.Windows.Forms.TextBox();
            this.txtgroup = new System.Windows.Forms.TextBox();
            this.txtindex = new System.Windows.Forms.TextBox();
            this.txtRrt = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.txtWrt = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.btnread = new System.Windows.Forms.Button();
            this.btnwrite = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNodeID = new System.Windows.Forms.ComboBox();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninitial
            // 
            this.btninitial.Location = new System.Drawing.Point(9, 0);
            this.btninitial.Name = "btninitial";
            this.btninitial.Size = new System.Drawing.Size(83, 28);
            this.btninitial.TabIndex = 0;
            this.btninitial.Text = "1-1 Open Card";
            this.btninitial.UseVisualStyleBackColor = true;
            this.btninitial.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(12, 230);
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
            this.label1.Location = new System.Drawing.Point(115, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Card No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Slave Num:";
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(167, 35);
            this.txtSlaveNum.Name = "txtSlaveNum";
            this.txtSlaveNum.ReadOnly = true;
            this.txtSlaveNum.Size = new System.Drawing.Size(42, 22);
            this.txtSlaveNum.TabIndex = 11;
            this.txtSlaveNum.Text = "0";
            this.txtSlaveNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Node ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Slot ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Group";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Index";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Rt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "Data";
            // 
            // txtslotid
            // 
            this.txtslotid.Location = new System.Drawing.Point(68, 41);
            this.txtslotid.Name = "txtslotid";
            this.txtslotid.ReadOnly = true;
            this.txtslotid.Size = new System.Drawing.Size(35, 22);
            this.txtslotid.TabIndex = 19;
            this.txtslotid.Text = "0";
            this.txtslotid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtgroup
            // 
            this.txtgroup.Location = new System.Drawing.Point(125, 41);
            this.txtgroup.Name = "txtgroup";
            this.txtgroup.Size = new System.Drawing.Size(35, 22);
            this.txtgroup.TabIndex = 20;
            this.txtgroup.Text = "0";
            this.txtgroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtindex
            // 
            this.txtindex.Location = new System.Drawing.Point(181, 41);
            this.txtindex.Name = "txtindex";
            this.txtindex.Size = new System.Drawing.Size(35, 22);
            this.txtindex.TabIndex = 21;
            this.txtindex.Text = "0";
            this.txtindex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRrt
            // 
            this.txtRrt.Location = new System.Drawing.Point(11, 92);
            this.txtRrt.Name = "txtRrt";
            this.txtRrt.ReadOnly = true;
            this.txtRrt.Size = new System.Drawing.Size(35, 22);
            this.txtRrt.TabIndex = 22;
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(55, 92);
            this.txtR.Name = "txtR";
            this.txtR.ReadOnly = true;
            this.txtR.Size = new System.Drawing.Size(75, 22);
            this.txtR.TabIndex = 23;
            this.txtR.Text = "0";
            this.txtR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWrt
            // 
            this.txtWrt.Location = new System.Drawing.Point(11, 121);
            this.txtWrt.Name = "txtWrt";
            this.txtWrt.ReadOnly = true;
            this.txtWrt.Size = new System.Drawing.Size(35, 22);
            this.txtWrt.TabIndex = 24;
            // 
            // txtW
            // 
            this.txtW.Location = new System.Drawing.Point(55, 121);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(75, 22);
            this.txtW.TabIndex = 25;
            this.txtW.Text = "0";
            this.txtW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnread
            // 
            this.btnread.Enabled = false;
            this.btnread.Location = new System.Drawing.Point(141, 92);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(75, 23);
            this.btnread.TabIndex = 26;
            this.btnread.Text = "Read";
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.btnread_Click);
            // 
            // btnwrite
            // 
            this.btnwrite.Enabled = false;
            this.btnwrite.Location = new System.Drawing.Point(141, 120);
            this.btnwrite.Name = "btnwrite";
            this.btnwrite.Size = new System.Drawing.Size(75, 23);
            this.btnwrite.TabIndex = 27;
            this.btnwrite.Text = "Write";
            this.btnwrite.UseVisualStyleBackColor = true;
            this.btnwrite.Click += new System.EventHandler(this.btnwrite_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNodeID);
            this.groupBox1.Controls.Add(this.btnwrite);
            this.groupBox1.Controls.Add(this.btnread);
            this.groupBox1.Controls.Add(this.txtW);
            this.groupBox1.Controls.Add(this.txtWrt);
            this.groupBox1.Controls.Add(this.txtR);
            this.groupBox1.Controls.Add(this.txtRrt);
            this.groupBox1.Controls.Add(this.txtindex);
            this.groupBox1.Controls.Add(this.txtgroup);
            this.groupBox1.Controls.Add(this.txtslotid);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 156);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Driver parameters";
            // 
            // cmbNodeID
            // 
            this.cmbNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID.FormattingEnabled = true;
            this.cmbNodeID.Location = new System.Drawing.Point(9, 42);
            this.cmbNodeID.Name = "cmbNodeID";
            this.cmbNodeID.Size = new System.Drawing.Size(45, 20);
            this.cmbNodeID.TabIndex = 32;
            // 
            // btnFindSlave
            // 
            this.btnFindSlave.Enabled = false;
            this.btnFindSlave.Location = new System.Drawing.Point(9, 28);
            this.btnFindSlave.Name = "btnFindSlave";
            this.btnFindSlave.Size = new System.Drawing.Size(83, 28);
            this.btnFindSlave.TabIndex = 29;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(167, 8);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(42, 20);
            this.CmbCardNo.TabIndex = 30;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 274);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtslotid;
        private System.Windows.Forms.TextBox txtgroup;
        private System.Windows.Forms.TextBox txtindex;
        private System.Windows.Forms.TextBox txtRrt;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.TextBox txtWrt;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.Button btnwrite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.ComboBox cmbNodeID;
    }
}

