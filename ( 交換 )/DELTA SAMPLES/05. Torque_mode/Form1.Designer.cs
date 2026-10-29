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
            this.btnstop = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.chksvon = new System.Windows.Forms.CheckBox();
            this.btnralm = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtslop = new System.Windows.Forms.TextBox();
            this.txtratio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.btnreset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtERR = new System.Windows.Forms.TextBox();
            this.btnPmove = new System.Windows.Forms.Button();
            this.btnNmove = new System.Windows.Forms.Button();
            this.txtSlaveNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnFindSlave = new System.Windows.Forms.Button();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chktimer = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNodeID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btninitial
            // 
            this.btninitial.Location = new System.Drawing.Point(12, 0);
            this.btninitial.Name = "btninitial";
            this.btninitial.Size = new System.Drawing.Size(90, 28);
            this.btninitial.TabIndex = 0;
            this.btninitial.Text = "1-1 Open Card";
            this.btninitial.UseVisualStyleBackColor = true;
            this.btninitial.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // btnstop
            // 
            this.btnstop.Enabled = false;
            this.btnstop.Location = new System.Drawing.Point(223, 217);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(70, 45);
            this.btnstop.TabIndex = 3;
            this.btnstop.Text = "Stop";
            this.btnstop.UseVisualStyleBackColor = true;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(363, 217);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(70, 45);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // chksvon
            // 
            this.chksvon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chksvon.Enabled = false;
            this.chksvon.Location = new System.Drawing.Point(13, 217);
            this.chksvon.Name = "chksvon";
            this.chksvon.Size = new System.Drawing.Size(70, 45);
            this.chksvon.TabIndex = 5;
            this.chksvon.Text = "SVON";
            this.chksvon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chksvon.UseVisualStyleBackColor = true;
            this.chksvon.CheckedChanged += new System.EventHandler(this.chksvon_CheckedChanged);
            // 
            // btnralm
            // 
            this.btnralm.Enabled = false;
            this.btnralm.Location = new System.Drawing.Point(83, 217);
            this.btnralm.Name = "btnralm";
            this.btnralm.Size = new System.Drawing.Size(70, 45);
            this.btnralm.TabIndex = 7;
            this.btnralm.Text = "RALM";
            this.btnralm.UseVisualStyleBackColor = true;
            this.btnralm.Click += new System.EventHandler(this.btnralm_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtslop
            // 
            this.txtslop.Location = new System.Drawing.Point(6, 19);
            this.txtslop.Name = "txtslop";
            this.txtslop.Size = new System.Drawing.Size(77, 22);
            this.txtslop.TabIndex = 10;
            this.txtslop.Text = "1000";
            this.txtslop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtratio
            // 
            this.txtratio.Location = new System.Drawing.Point(6, 41);
            this.txtratio.Name = "txtratio";
            this.txtratio.Size = new System.Drawing.Size(77, 22);
            this.txtratio.TabIndex = 11;
            this.txtratio.Text = "300";
            this.txtratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "milliseconds";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "/1000 rated torque";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtratio);
            this.groupBox1.Controls.Add(this.txtslop);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 78);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Vel. Prof.";
            // 
            // txtcommand
            // 
            this.txtcommand.Location = new System.Drawing.Point(72, 21);
            this.txtcommand.Name = "txtcommand";
            this.txtcommand.ReadOnly = true;
            this.txtcommand.Size = new System.Drawing.Size(84, 22);
            this.txtcommand.TabIndex = 21;
            this.txtcommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtfeedback
            // 
            this.txtfeedback.Location = new System.Drawing.Point(72, 43);
            this.txtfeedback.Name = "txtfeedback";
            this.txtfeedback.ReadOnly = true;
            this.txtfeedback.Size = new System.Drawing.Size(84, 22);
            this.txtfeedback.TabIndex = 22;
            this.txtfeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtspeed
            // 
            this.txtspeed.Location = new System.Drawing.Point(72, 65);
            this.txtspeed.Name = "txtspeed";
            this.txtspeed.ReadOnly = true;
            this.txtspeed.Size = new System.Drawing.Size(84, 22);
            this.txtspeed.TabIndex = 23;
            this.txtspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmotion
            // 
            this.txtmotion.Location = new System.Drawing.Point(72, 87);
            this.txtmotion.Name = "txtmotion";
            this.txtmotion.ReadOnly = true;
            this.txtmotion.Size = new System.Drawing.Size(84, 22);
            this.txtmotion.TabIndex = 25;
            this.txtmotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Command";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "Feedback";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Speed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "Motion";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(160, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "pls.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "pls.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(160, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "pls.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnreset);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtERR);
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
            this.groupBox2.Location = new System.Drawing.Point(207, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 159);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Motion";
            // 
            // btnreset
            // 
            this.btnreset.Enabled = false;
            this.btnreset.Location = new System.Drawing.Point(162, 98);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(58, 55);
            this.btnreset.TabIndex = 36;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "Error";
            // 
            // txtERR
            // 
            this.txtERR.Location = new System.Drawing.Point(72, 109);
            this.txtERR.Name = "txtERR";
            this.txtERR.ReadOnly = true;
            this.txtERR.Size = new System.Drawing.Size(84, 22);
            this.txtERR.TabIndex = 34;
            this.txtERR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPmove
            // 
            this.btnPmove.Enabled = false;
            this.btnPmove.Location = new System.Drawing.Point(293, 217);
            this.btnPmove.Name = "btnPmove";
            this.btnPmove.Size = new System.Drawing.Size(70, 45);
            this.btnPmove.TabIndex = 35;
            this.btnPmove.Text = "--->";
            this.btnPmove.UseVisualStyleBackColor = true;
            this.btnPmove.Click += new System.EventHandler(this.btnPmove_Click);
            // 
            // btnNmove
            // 
            this.btnNmove.Enabled = false;
            this.btnNmove.Location = new System.Drawing.Point(153, 217);
            this.btnNmove.Name = "btnNmove";
            this.btnNmove.Size = new System.Drawing.Size(70, 45);
            this.btnNmove.TabIndex = 36;
            this.btnNmove.Text = "<---";
            this.btnNmove.UseVisualStyleBackColor = true;
            this.btnNmove.Click += new System.EventHandler(this.btnNmove_Click);
            // 
            // txtSlaveNum
            // 
            this.txtSlaveNum.Location = new System.Drawing.Point(294, 19);
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
            this.label10.Location = new System.Drawing.Point(121, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 12);
            this.label10.TabIndex = 56;
            this.label10.Text = "Card No:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(233, 22);
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
            this.btnFindSlave.Size = new System.Drawing.Size(90, 28);
            this.btnFindSlave.TabIndex = 60;
            this.btnFindSlave.Text = "1-2 Find Slave";
            this.btnFindSlave.UseVisualStyleBackColor = true;
            this.btnFindSlave.Click += new System.EventHandler(this.btnFindSlave_Click);
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(170, 21);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(37, 20);
            this.CmbCardNo.TabIndex = 61;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chktimer);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cmbNodeID);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 65);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Node ID";
            // 
            // chktimer
            // 
            this.chktimer.Location = new System.Drawing.Point(110, 31);
            this.chktimer.Name = "chktimer";
            this.chktimer.Size = new System.Drawing.Size(54, 22);
            this.chktimer.TabIndex = 64;
            this.chktimer.Text = "Timer";
            this.chktimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chktimer.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(29, 22);
            this.textBox1.TabIndex = 63;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "SlotID";
            // 
            // cmbNodeID
            // 
            this.cmbNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeID.FormattingEnabled = true;
            this.cmbNodeID.Location = new System.Drawing.Point(9, 33);
            this.cmbNodeID.Name = "cmbNodeID";
            this.cmbNodeID.Size = new System.Drawing.Size(46, 20);
            this.cmbNodeID.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "NodeID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 272);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninitial;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.CheckBox chksvon;
        private System.Windows.Forms.Button btnralm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtslop;
        private System.Windows.Forms.TextBox txtratio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Button btnFindSlave;
        private System.Windows.Forms.ComboBox CmbCardNo;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtERR;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chktimer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNodeID;
        private System.Windows.Forms.Label label1;
    }
}

