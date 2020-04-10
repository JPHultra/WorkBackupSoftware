namespace WorkBackSoftware
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LogsTXT = new System.Windows.Forms.TextBox();
            this.ToTXT = new System.Windows.Forms.TextBox();
            this.FromTXT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SyncBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "From:";
            // 
            // LogsTXT
            // 
            this.LogsTXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogsTXT.Location = new System.Drawing.Point(19, 115);
            this.LogsTXT.Multiline = true;
            this.LogsTXT.Name = "LogsTXT";
            this.LogsTXT.Size = new System.Drawing.Size(247, 207);
            this.LogsTXT.TabIndex = 2;
            // 
            // ToTXT
            // 
            this.ToTXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTXT.Location = new System.Drawing.Point(58, 19);
            this.ToTXT.Name = "ToTXT";
            this.ToTXT.Size = new System.Drawing.Size(208, 20);
            this.ToTXT.TabIndex = 3;
            // 
            // FromTXT
            // 
            this.FromTXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FromTXT.Location = new System.Drawing.Point(58, 54);
            this.FromTXT.Name = "FromTXT";
            this.FromTXT.Size = new System.Drawing.Size(208, 20);
            this.FromTXT.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Logs";
            // 
            // SyncBTN
            // 
            this.SyncBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SyncBTN.Location = new System.Drawing.Point(19, 346);
            this.SyncBTN.Name = "SyncBTN";
            this.SyncBTN.Size = new System.Drawing.Size(247, 58);
            this.SyncBTN.TabIndex = 6;
            this.SyncBTN.Text = "Synchronize";
            this.SyncBTN.UseVisualStyleBackColor = true;
            this.SyncBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 423);
            this.Controls.Add(this.SyncBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FromTXT);
            this.Controls.Add(this.ToTXT);
            this.Controls.Add(this.LogsTXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Work Backup Software";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LogsTXT;
        private System.Windows.Forms.TextBox ToTXT;
        private System.Windows.Forms.TextBox FromTXT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SyncBTN;
    }
}

