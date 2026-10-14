namespace EmptyWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.input1 = new AntdUI.Input();
            this.pageHeader1 = new AntdUI.PageHeader();
            this.SuspendLayout();
            // 
            // input1
            // 
            this.input1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.input1.Location = new System.Drawing.Point(52, 105);
            this.input1.Multiline = true;
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(315, 168);
            this.input1.TabIndex = 0;
            // 
            // pageHeader1
            // 
            this.pageHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageHeader1.Location = new System.Drawing.Point(15, 9);
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowButton = true;
            this.pageHeader1.Size = new System.Drawing.Size(393, 34);
            this.pageHeader1.TabIndex = 1;
            this.pageHeader1.Text = "pageHeader1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 299);
            this.Controls.Add(this.pageHeader1);
            this.Controls.Add(this.input1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(15, 9, 15, 9);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Input input1;
        private AntdUI.PageHeader pageHeader1;
    }
}
