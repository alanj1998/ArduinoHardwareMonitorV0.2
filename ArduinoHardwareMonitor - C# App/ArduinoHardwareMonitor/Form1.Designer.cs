namespace ArduinoHardwareMonitor
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
            this.portBox = new System.Windows.Forms.ComboBox();
            this.intrvlBox = new System.Windows.Forms.ComboBox();
            this.portlbl = new System.Windows.Forms.Label();
            this.intrvllbl = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.disBtn = new System.Windows.Forms.Button();
            this.conBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.serverLinkLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.emailCheckBtn = new System.Windows.Forms.Button();
            this.serverCheck = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // portBox
            // 
            this.portBox.FormattingEnabled = true;
            this.portBox.Location = new System.Drawing.Point(12, 32);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(121, 21);
            this.portBox.TabIndex = 0;
            this.portBox.TabStop = false;
            // 
            // intrvlBox
            // 
            this.intrvlBox.FormattingEnabled = true;
            this.intrvlBox.Location = new System.Drawing.Point(12, 97);
            this.intrvlBox.Name = "intrvlBox";
            this.intrvlBox.Size = new System.Drawing.Size(121, 21);
            this.intrvlBox.TabIndex = 1;
            this.intrvlBox.TabStop = false;
            // 
            // portlbl
            // 
            this.portlbl.AutoSize = true;
            this.portlbl.Location = new System.Drawing.Point(16, 16);
            this.portlbl.Name = "portlbl";
            this.portlbl.Size = new System.Drawing.Size(63, 13);
            this.portlbl.TabIndex = 2;
            this.portlbl.Text = "Set the Port";
            // 
            // intrvllbl
            // 
            this.intrvllbl.AutoSize = true;
            this.intrvllbl.Location = new System.Drawing.Point(12, 81);
            this.intrvllbl.Name = "intrvllbl";
            this.intrvllbl.Size = new System.Drawing.Size(42, 13);
            this.intrvllbl.TabIndex = 3;
            this.intrvllbl.Text = "Interval";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(261, 32);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(52, 13);
            this.status.TabIndex = 4;
            this.status.Text = "Waiting...";
            // 
            // disBtn
            // 
            this.disBtn.Enabled = false;
            this.disBtn.Location = new System.Drawing.Point(294, 81);
            this.disBtn.Name = "disBtn";
            this.disBtn.Size = new System.Drawing.Size(75, 23);
            this.disBtn.TabIndex = 5;
            this.disBtn.TabStop = false;
            this.disBtn.Text = "Disconnect";
            this.disBtn.UseVisualStyleBackColor = true;
            this.disBtn.Click += new System.EventHandler(this.disBtn_Click);
            // 
            // conBtn
            // 
            this.conBtn.Location = new System.Drawing.Point(187, 81);
            this.conBtn.Name = "conBtn";
            this.conBtn.Size = new System.Drawing.Size(75, 23);
            this.conBtn.TabIndex = 6;
            this.conBtn.TabStop = false;
            this.conBtn.Text = "Connect";
            this.conBtn.UseVisualStyleBackColor = true;
            this.conBtn.Click += new System.EventHandler(this.conBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatusLbl,
            this.serverLinkLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 214);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(395, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStatusLbl
            // 
            this.toolStatusLbl.Name = "toolStatusLbl";
            this.toolStatusLbl.Size = new System.Drawing.Size(115, 17);
            this.toolStatusLbl.Text = "Waiting For Details...";
            // 
            // serverLinkLbl
            // 
            this.serverLinkLbl.IsLink = true;
            this.serverLinkLbl.Name = "serverLinkLbl";
            this.serverLinkLbl.Size = new System.Drawing.Size(206, 17);
            this.serverLinkLbl.Text = "Click Here to Access The Control Hub";
            this.serverLinkLbl.Visible = false;
            this.serverLinkLbl.Click += new System.EventHandler(this.serverLinkLbl_Click);
            // 
            // emailBox
            // 
            this.emailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailBox.Location = new System.Drawing.Point(12, 147);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(262, 20);
            this.emailBox.TabIndex = 8;
            this.emailBox.TabStop = false;
            this.emailBox.Text = "Enter Email Here...";
            this.emailBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.emailBox_MouseClick);
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(12, 131);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(35, 13);
            this.emailLbl.TabIndex = 9;
            this.emailLbl.Text = "Email:";
            // 
            // emailCheckBtn
            // 
            this.emailCheckBtn.Location = new System.Drawing.Point(294, 145);
            this.emailCheckBtn.Name = "emailCheckBtn";
            this.emailCheckBtn.Size = new System.Drawing.Size(75, 23);
            this.emailCheckBtn.TabIndex = 10;
            this.emailCheckBtn.TabStop = false;
            this.emailCheckBtn.Text = "Email Check";
            this.emailCheckBtn.UseVisualStyleBackColor = true;
            this.emailCheckBtn.Click += new System.EventHandler(this.emailCheckBtn_Click);
            // 
            // serverCheck
            // 
            this.serverCheck.AutoSize = true;
            this.serverCheck.Location = new System.Drawing.Point(12, 184);
            this.serverCheck.Name = "serverCheck";
            this.serverCheck.Size = new System.Drawing.Size(310, 17);
            this.serverCheck.TabIndex = 11;
            this.serverCheck.TabStop = false;
            this.serverCheck.Text = "Use the Local Server to Update and Use the Email Service?";
            this.serverCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 236);
            this.Controls.Add(this.serverCheck);
            this.Controls.Add(this.emailCheckBtn);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.conBtn);
            this.Controls.Add(this.disBtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.intrvllbl);
            this.Controls.Add(this.portlbl);
            this.Controls.Add(this.intrvlBox);
            this.Controls.Add(this.portBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Arduino Read";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portBox;
        private System.Windows.Forms.ComboBox intrvlBox;
        private System.Windows.Forms.Label portlbl;
        private System.Windows.Forms.Label intrvllbl;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button disBtn;
        private System.Windows.Forms.Button conBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusLbl;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Button emailCheckBtn;
        private System.Windows.Forms.CheckBox serverCheck;
        private System.Windows.Forms.ToolStripStatusLabel serverLinkLbl;
    }
}

