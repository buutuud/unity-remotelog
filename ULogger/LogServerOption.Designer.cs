namespace ULogger
{
    partial class LogServerOption
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbLoggerSvr = new System.Windows.Forms.TextBox();
            this.btnSetLocalIP = new System.Windows.Forms.Button();
            this.btnStartSvr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Logger Svr:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbLoggerSvr
            // 
            this.tbLoggerSvr.Location = new System.Drawing.Point(96, 13);
            this.tbLoggerSvr.Name = "tbLoggerSvr";
            this.tbLoggerSvr.Size = new System.Drawing.Size(123, 21);
            this.tbLoggerSvr.TabIndex = 3;
            // 
            // btnSetLocalIP
            // 
            this.btnSetLocalIP.Location = new System.Drawing.Point(230, 12);
            this.btnSetLocalIP.Name = "btnSetLocalIP";
            this.btnSetLocalIP.Size = new System.Drawing.Size(75, 23);
            this.btnSetLocalIP.TabIndex = 4;
            this.btnSetLocalIP.Text = "SetLocalIP";
            this.btnSetLocalIP.UseVisualStyleBackColor = true;
            this.btnSetLocalIP.Click += new System.EventHandler(this.btnSetLocalIP_Click);
            // 
            // btnStartSvr
            // 
            this.btnStartSvr.Location = new System.Drawing.Point(60, 41);
            this.btnStartSvr.Name = "btnStartSvr";
            this.btnStartSvr.Size = new System.Drawing.Size(187, 28);
            this.btnStartSvr.TabIndex = 6;
            this.btnStartSvr.Text = "Start";
            this.btnStartSvr.UseVisualStyleBackColor = true;
            this.btnStartSvr.Click += new System.EventHandler(this.btnStartSvr_Click);
            // 
            // LogServerOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 81);
            this.Controls.Add(this.btnStartSvr);
            this.Controls.Add(this.btnSetLocalIP);
            this.Controls.Add(this.tbLoggerSvr);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogServerOption";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LogServerOption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLoggerSvr;
        private System.Windows.Forms.Button btnSetLocalIP;
        private System.Windows.Forms.Button btnStartSvr;
    }
}