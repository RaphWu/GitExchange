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
            this.btnexit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnopen = new System.Windows.Forms.Button();
            this.btninitial = new System.Windows.Forms.Button();
            this.btnfindslave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcardnum = new System.Windows.Forms.TextBox();
            this.txtslavenum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbCardNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(12, 121);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(80, 31);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnopen
            // 
            this.btnopen.Location = new System.Drawing.Point(12, 12);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(80, 31);
            this.btnopen.TabIndex = 5;
            this.btnopen.Text = "1.Open Card";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // btninitial
            // 
            this.btninitial.Enabled = false;
            this.btninitial.Location = new System.Drawing.Point(12, 49);
            this.btninitial.Name = "btninitial";
            this.btninitial.Size = new System.Drawing.Size(80, 30);
            this.btninitial.TabIndex = 6;
            this.btninitial.Text = "2.Initial Card";
            this.btninitial.UseVisualStyleBackColor = true;
            this.btninitial.Click += new System.EventHandler(this.btninitial_Click);
            // 
            // btnfindslave
            // 
            this.btnfindslave.Enabled = false;
            this.btnfindslave.Location = new System.Drawing.Point(12, 85);
            this.btnfindslave.Name = "btnfindslave";
            this.btnfindslave.Size = new System.Drawing.Size(80, 30);
            this.btnfindslave.TabIndex = 7;
            this.btnfindslave.Text = "3.Find Slave";
            this.btnfindslave.UseVisualStyleBackColor = true;
            this.btnfindslave.Click += new System.EventHandler(this.btnfindslave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Card num.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Slave num.";
            // 
            // txtcardnum
            // 
            this.txtcardnum.Location = new System.Drawing.Point(151, 18);
            this.txtcardnum.Name = "txtcardnum";
            this.txtcardnum.ReadOnly = true;
            this.txtcardnum.Size = new System.Drawing.Size(41, 22);
            this.txtcardnum.TabIndex = 10;
            // 
            // txtslavenum
            // 
            this.txtslavenum.Location = new System.Drawing.Point(159, 91);
            this.txtslavenum.Name = "txtslavenum";
            this.txtslavenum.ReadOnly = true;
            this.txtslavenum.Size = new System.Drawing.Size(33, 22);
            this.txtslavenum.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Card No:";
            // 
            // CmbCardNo
            // 
            this.CmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCardNo.FormattingEnabled = true;
            this.CmbCardNo.Location = new System.Drawing.Point(151, 54);
            this.CmbCardNo.Name = "CmbCardNo";
            this.CmbCardNo.Size = new System.Drawing.Size(42, 20);
            this.CmbCardNo.TabIndex = 13;
            this.CmbCardNo.SelectedIndexChanged += new System.EventHandler(this.CmbCardNo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 163);
            this.Controls.Add(this.CmbCardNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtslavenum);
            this.Controls.Add(this.txtcardnum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnfindslave);
            this.Controls.Add(this.btninitial);
            this.Controls.Add(this.btnopen);
            this.Controls.Add(this.btnexit);
            this.Name = "Form1";
            this.Text = "DMC-NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.Button btninitial;
        private System.Windows.Forms.Button btnfindslave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcardnum;
        private System.Windows.Forms.TextBox txtslavenum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbCardNo;
    }
}

