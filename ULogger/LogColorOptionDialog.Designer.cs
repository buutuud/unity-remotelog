namespace ULogger
{
    partial class LogColorOptionDialog
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
            this.btnLogDebug = new System.Windows.Forms.Button();
            this.btnLogErr = new System.Windows.Forms.Button();
            this.btnLogWarn = new System.Windows.Forms.Button();
            this.btnLogException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogDebug
            // 
            this.btnLogDebug.Location = new System.Drawing.Point(25, 17);
            this.btnLogDebug.Name = "btnLogDebug";
            this.btnLogDebug.Size = new System.Drawing.Size(187, 23);
            this.btnLogDebug.TabIndex = 3;
            this.btnLogDebug.Text = "Debug Message Message Message";
            this.btnLogDebug.UseVisualStyleBackColor = true;
            this.btnLogDebug.Click += new System.EventHandler(this.btnLogDebug_Click);
            // 
            // btnLogErr
            // 
            this.btnLogErr.Location = new System.Drawing.Point(25, 75);
            this.btnLogErr.Name = "btnLogErr";
            this.btnLogErr.Size = new System.Drawing.Size(187, 23);
            this.btnLogErr.TabIndex = 4;
            this.btnLogErr.Text = "Err Message Message Message";
            this.btnLogErr.UseVisualStyleBackColor = true;
            this.btnLogErr.Click += new System.EventHandler(this.btnLogErr_Click);
            // 
            // btnLogWarn
            // 
            this.btnLogWarn.Location = new System.Drawing.Point(25, 46);
            this.btnLogWarn.Name = "btnLogWarn";
            this.btnLogWarn.Size = new System.Drawing.Size(187, 23);
            this.btnLogWarn.TabIndex = 5;
            this.btnLogWarn.Text = "Warn Message Message Message";
            this.btnLogWarn.UseVisualStyleBackColor = true;
            this.btnLogWarn.Click += new System.EventHandler(this.btnLogWarn_Click);
            // 
            // btnLogException
            // 
            this.btnLogException.Location = new System.Drawing.Point(25, 104);
            this.btnLogException.Name = "btnLogException";
            this.btnLogException.Size = new System.Drawing.Size(187, 23);
            this.btnLogException.TabIndex = 6;
            this.btnLogException.Text = "Exception Message Message";
            this.btnLogException.UseVisualStyleBackColor = true;
            this.btnLogException.Click += new System.EventHandler(this.btnLogException_Click);
            // 
            // LogColorOptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 141);
            this.Controls.Add(this.btnLogException);
            this.Controls.Add(this.btnLogWarn);
            this.Controls.Add(this.btnLogErr);
            this.Controls.Add(this.btnLogDebug);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogColorOptionDialog";
            this.Text = "LogColorOptionDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogDebug;
        private System.Windows.Forms.Button btnLogErr;
        private System.Windows.Forms.Button btnLogWarn;
        private System.Windows.Forms.Button btnLogException;
    }
}