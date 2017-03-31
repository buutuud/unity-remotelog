namespace ULogger
{
    partial class ULoggerWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ULoggerWin));
            this.lstFilter = new System.Windows.Forms.ListBox();
            this.lstLogs = new System.Windows.Forms.ListView();
            this.LogIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Content = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpLogDetail = new System.Windows.Forms.GroupBox();
            this.btnCopyDetailLog2Clipboard = new System.Windows.Forms.Button();
            this.btnShowDetailLogDialog = new System.Windows.Forms.Button();
            this.tbLogDetailContent = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemStartListen = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSaveCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemLoadLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemOptionShowLastLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemExportFiltered = new System.Windows.Forms.ToolStripMenuItem();
            this.iMenuExportLogContentOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.iMenuEnableClearLogCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemLogColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFilterNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFilterDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemFilterEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbLogSearchContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.gpLogDetail.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFilter
            // 
            this.lstFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFilter.FormattingEnabled = true;
            this.lstFilter.ItemHeight = 12;
            this.lstFilter.Location = new System.Drawing.Point(10, 33);
            this.lstFilter.Name = "lstFilter";
            this.lstFilter.Size = new System.Drawing.Size(122, 364);
            this.lstFilter.TabIndex = 0;
            this.lstFilter.SelectedIndexChanged += new System.EventHandler(this.lstFilter_SelectedIndexChanged);
            // 
            // lstLogs
            // 
            this.lstLogs.AllowColumnReorder = true;
            this.lstLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLogs.BackColor = System.Drawing.Color.White;
            this.lstLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LogIndex,
            this.Time,
            this.Level,
            this.LogTag,
            this.Content});
            this.lstLogs.FullRowSelect = true;
            this.lstLogs.GridLines = true;
            this.lstLogs.Location = new System.Drawing.Point(140, 61);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(720, 336);
            this.lstLogs.TabIndex = 6;
            this.lstLogs.UseCompatibleStateImageBehavior = false;
            this.lstLogs.View = System.Windows.Forms.View.Details;
            this.lstLogs.VirtualMode = true;
            this.lstLogs.SelectedIndexChanged += new System.EventHandler(this.lstLogs_SelectedIndexChanged);
            // 
            // LogIndex
            // 
            this.LogIndex.Text = "Index";
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 154;
            // 
            // Level
            // 
            this.Level.Text = "Level";
            this.Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Level.Width = 45;
            // 
            // LogTag
            // 
            this.LogTag.Text = "Tag";
            this.LogTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LogTag.Width = 66;
            // 
            // Content
            // 
            this.Content.Text = "Content";
            this.Content.Width = 349;
            // 
            // gpLogDetail
            // 
            this.gpLogDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpLogDetail.Controls.Add(this.btnCopyDetailLog2Clipboard);
            this.gpLogDetail.Controls.Add(this.btnShowDetailLogDialog);
            this.gpLogDetail.Controls.Add(this.tbLogDetailContent);
            this.gpLogDetail.Location = new System.Drawing.Point(10, 403);
            this.gpLogDetail.Name = "gpLogDetail";
            this.gpLogDetail.Size = new System.Drawing.Size(850, 78);
            this.gpLogDetail.TabIndex = 16;
            this.gpLogDetail.TabStop = false;
            this.gpLogDetail.Text = "Count:0";
            // 
            // btnCopyDetailLog2Clipboard
            // 
            this.btnCopyDetailLog2Clipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyDetailLog2Clipboard.Location = new System.Drawing.Point(806, 45);
            this.btnCopyDetailLog2Clipboard.Name = "btnCopyDetailLog2Clipboard";
            this.btnCopyDetailLog2Clipboard.Size = new System.Drawing.Size(39, 23);
            this.btnCopyDetailLog2Clipboard.TabIndex = 21;
            this.btnCopyDetailLog2Clipboard.Text = "Clip";
            this.btnCopyDetailLog2Clipboard.UseVisualStyleBackColor = true;
            this.btnCopyDetailLog2Clipboard.Click += new System.EventHandler(this.btnCopyDetailLog2Clipboard_Click);
            // 
            // btnShowDetailLogDialog
            // 
            this.btnShowDetailLogDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowDetailLogDialog.Location = new System.Drawing.Point(807, 16);
            this.btnShowDetailLogDialog.Name = "btnShowDetailLogDialog";
            this.btnShowDetailLogDialog.Size = new System.Drawing.Size(39, 23);
            this.btnShowDetailLogDialog.TabIndex = 20;
            this.btnShowDetailLogDialog.Text = "Show";
            this.btnShowDetailLogDialog.UseVisualStyleBackColor = true;
            this.btnShowDetailLogDialog.Click += new System.EventHandler(this.btnShowDetailLogDialog_Click);
            // 
            // tbLogDetailContent
            // 
            this.tbLogDetailContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogDetailContent.Location = new System.Drawing.Point(9, 15);
            this.tbLogDetailContent.Multiline = true;
            this.tbLogDetailContent.Name = "tbLogDetailContent";
            this.tbLogDetailContent.ReadOnly = true;
            this.tbLogDetailContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogDetailContent.Size = new System.Drawing.Size(794, 58);
            this.tbLogDetailContent.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemFile,
            this.mItemOption,
            this.mItemFilters,
            this.mItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 25);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mItemFile
            // 
            this.mItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemStartListen,
            this.mItemClearLog,
            this.mItemSaveCfg,
            this.mItemSaveLog,
            this.mItemLoadLog,
            this.mItemExit});
            this.mItemFile.Name = "mItemFile";
            this.mItemFile.Size = new System.Drawing.Size(39, 21);
            this.mItemFile.Text = "File";
            // 
            // mItemStartListen
            // 
            this.mItemStartListen.Name = "mItemStartListen";
            this.mItemStartListen.Size = new System.Drawing.Size(145, 22);
            this.mItemStartListen.Text = "Start Listen";
            this.mItemStartListen.Click += new System.EventHandler(this.mItemStartListen_Click);
            // 
            // mItemClearLog
            // 
            this.mItemClearLog.Name = "mItemClearLog";
            this.mItemClearLog.Size = new System.Drawing.Size(145, 22);
            this.mItemClearLog.Text = "Clear Log";
            this.mItemClearLog.Click += new System.EventHandler(this.mItemClearLog_Click);
            // 
            // mItemSaveCfg
            // 
            this.mItemSaveCfg.Name = "mItemSaveCfg";
            this.mItemSaveCfg.Size = new System.Drawing.Size(145, 22);
            this.mItemSaveCfg.Text = "Save Config";
            this.mItemSaveCfg.Click += new System.EventHandler(this.mItemSaveCfg_Click);
            // 
            // mItemSaveLog
            // 
            this.mItemSaveLog.Name = "mItemSaveLog";
            this.mItemSaveLog.Size = new System.Drawing.Size(145, 22);
            this.mItemSaveLog.Text = "Export Log";
            this.mItemSaveLog.Click += new System.EventHandler(this.mItemSaveLog_Click);
            // 
            // mItemLoadLog
            // 
            this.mItemLoadLog.Name = "mItemLoadLog";
            this.mItemLoadLog.Size = new System.Drawing.Size(145, 22);
            this.mItemLoadLog.Text = "Import Log";
            this.mItemLoadLog.Click += new System.EventHandler(this.mItemLoadLog_Click);
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.Size = new System.Drawing.Size(145, 22);
            this.mItemExit.Text = "Exit";
            this.mItemExit.Click += new System.EventHandler(this.mItemExit_Click);
            // 
            // mItemOption
            // 
            this.mItemOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemOptionShowLastLog,
            this.mItemExportFiltered,
            this.iMenuExportLogContentOnly,
            this.iMenuEnableClearLogCommand,
            this.mItemLogColor});
            this.mItemOption.Name = "mItemOption";
            this.mItemOption.Size = new System.Drawing.Size(60, 21);
            this.mItemOption.Text = "Option";
            // 
            // mItemOptionShowLastLog
            // 
            this.mItemOptionShowLastLog.Name = "mItemOptionShowLastLog";
            this.mItemOptionShowLastLog.Size = new System.Drawing.Size(239, 22);
            this.mItemOptionShowLastLog.Text = "ShowLastLog";
            this.mItemOptionShowLastLog.Click += new System.EventHandler(this.mItemOptionShowLastLog_Click);
            // 
            // mItemExportFiltered
            // 
            this.mItemExportFiltered.Name = "mItemExportFiltered";
            this.mItemExportFiltered.Size = new System.Drawing.Size(239, 22);
            this.mItemExportFiltered.Text = "Export Filtered Log Only";
            this.mItemExportFiltered.Click += new System.EventHandler(this.mItemExportFiltered_Click);
            // 
            // iMenuExportLogContentOnly
            // 
            this.iMenuExportLogContentOnly.Name = "iMenuExportLogContentOnly";
            this.iMenuExportLogContentOnly.Size = new System.Drawing.Size(239, 22);
            this.iMenuExportLogContentOnly.Text = "Export Log Content Only";
            this.iMenuExportLogContentOnly.Click += new System.EventHandler(this.iMenuExportLogContentOnly_Click);
            // 
            // iMenuEnableClearLogCommand
            // 
            this.iMenuEnableClearLogCommand.Name = "iMenuEnableClearLogCommand";
            this.iMenuEnableClearLogCommand.Size = new System.Drawing.Size(239, 22);
            this.iMenuEnableClearLogCommand.Text = "Enable Clear Log Command";
            this.iMenuEnableClearLogCommand.Click += new System.EventHandler(this.iMenuEnableClearLogCommand_Click);
            // 
            // mItemLogColor
            // 
            this.mItemLogColor.Name = "mItemLogColor";
            this.mItemLogColor.Size = new System.Drawing.Size(239, 22);
            this.mItemLogColor.Text = "Log Color";
            this.mItemLogColor.Click += new System.EventHandler(this.mItemLogColor_Click);
            // 
            // mItemFilters
            // 
            this.mItemFilters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemFilterNew,
            this.mItemFilterDelete,
            this.mItemFilterEdit});
            this.mItemFilters.Name = "mItemFilters";
            this.mItemFilters.Size = new System.Drawing.Size(54, 21);
            this.mItemFilters.Text = "Filters";
            // 
            // mItemFilterNew
            // 
            this.mItemFilterNew.Name = "mItemFilterNew";
            this.mItemFilterNew.Size = new System.Drawing.Size(183, 22);
            this.mItemFilterNew.Text = "New Filter";
            this.mItemFilterNew.Click += new System.EventHandler(this.mItemFilterNew_Click);
            // 
            // mItemFilterDelete
            // 
            this.mItemFilterDelete.Name = "mItemFilterDelete";
            this.mItemFilterDelete.Size = new System.Drawing.Size(183, 22);
            this.mItemFilterDelete.Text = "Delete Filter";
            this.mItemFilterDelete.Click += new System.EventHandler(this.mItemFilterDelete_Click);
            // 
            // mItemFilterEdit
            // 
            this.mItemFilterEdit.Name = "mItemFilterEdit";
            this.mItemFilterEdit.Size = new System.Drawing.Size(183, 22);
            this.mItemFilterEdit.Text = "Edit Selected Filter";
            this.mItemFilterEdit.Click += new System.EventHandler(this.mItemFilterEdit_Click);
            // 
            // mItemHelp
            // 
            this.mItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemHelpAbout,
            this.mItemHelpHelp});
            this.mItemHelp.Name = "mItemHelp";
            this.mItemHelp.Size = new System.Drawing.Size(47, 21);
            this.mItemHelp.Text = "Help";
            // 
            // mItemHelpAbout
            // 
            this.mItemHelpAbout.Name = "mItemHelpAbout";
            this.mItemHelpAbout.Size = new System.Drawing.Size(111, 22);
            this.mItemHelpAbout.Text = "About";
            this.mItemHelpAbout.Click += new System.EventHandler(this.mItemHelpAbout_Click);
            // 
            // mItemHelpHelp
            // 
            this.mItemHelpHelp.Name = "mItemHelpHelp";
            this.mItemHelpHelp.Size = new System.Drawing.Size(111, 22);
            this.mItemHelpHelp.Text = "Help";
            this.mItemHelpHelp.Click += new System.EventHandler(this.mItemHelpHelp_Click);
            // 
            // tbLogSearchContent
            // 
            this.tbLogSearchContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogSearchContent.Location = new System.Drawing.Point(186, 34);
            this.tbLogSearchContent.Name = "tbLogSearchContent";
            this.tbLogSearchContent.Size = new System.Drawing.Size(605, 21);
            this.tbLogSearchContent.TabIndex = 18;
            this.tbLogSearchContent.TextChanged += new System.EventHandler(this.tbLogSearchContent_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Search:";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(797, 33);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(63, 23);
            this.btnClearLog.TabIndex = 22;
            this.btnClearLog.Text = "ClearLog";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // ULoggerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 489);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLogSearchContent);
            this.Controls.Add(this.gpLogDetail);
            this.Controls.Add(this.lstFilter);
            this.Controls.Add(this.lstLogs);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "ULoggerWin";
            this.Text = "ULoggerWin";
            this.gpLogDetail.ResumeLayout(false);
            this.gpLogDetail.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFilter;
        private System.Windows.Forms.ListView lstLogs;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader LogTag;
        private System.Windows.Forms.ColumnHeader Content;
        private System.Windows.Forms.ColumnHeader Level;
        private System.Windows.Forms.ColumnHeader LogIndex;
        private System.Windows.Forms.GroupBox gpLogDetail;
        private System.Windows.Forms.TextBox tbLogDetailContent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mItemFile;
        private System.Windows.Forms.ToolStripMenuItem mItemOption;
        private System.Windows.Forms.ToolStripMenuItem mItemHelp;
        private System.Windows.Forms.ToolStripMenuItem mItemExit;
        private System.Windows.Forms.ToolStripMenuItem mItemOptionShowLastLog;
        private System.Windows.Forms.ToolStripMenuItem mItemFilters;
        private System.Windows.Forms.ToolStripMenuItem mItemFilterNew;
        private System.Windows.Forms.ToolStripMenuItem mItemFilterDelete;
        private System.Windows.Forms.ToolStripMenuItem mItemFilterEdit;
        private System.Windows.Forms.ToolStripMenuItem mItemHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mItemStartListen;
        private System.Windows.Forms.ToolStripMenuItem mItemClearLog;
        private System.Windows.Forms.ToolStripMenuItem mItemSaveCfg;
        private System.Windows.Forms.ToolStripMenuItem mItemSaveLog;
        private System.Windows.Forms.ToolStripMenuItem mItemLoadLog;
        private System.Windows.Forms.ToolStripMenuItem mItemHelpHelp;
        private System.Windows.Forms.ToolStripMenuItem mItemExportFiltered;
        private System.Windows.Forms.ToolStripMenuItem iMenuExportLogContentOnly;
        private System.Windows.Forms.TextBox tbLogSearchContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem iMenuEnableClearLogCommand;
        private System.Windows.Forms.Button btnShowDetailLogDialog;
        private System.Windows.Forms.Button btnCopyDetailLog2Clipboard;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ToolStripMenuItem mItemLogColor;
    }
}

