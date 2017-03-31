using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ULogger
{
    public partial class ULoggerWin : Form
    {
        private ULoggerServer pULoggerServer = new ULoggerServer();
        private Timer mTimer = new Timer();
        private URingbuffer<ULoggerInfo> mLogInfo = new URingbuffer<ULoggerInfo>();
        private ListViewItem[] mCache = null;
        private int mFirstItemIndex = 0;

        public ULoggerWin()
        {
            InitializeComponent();
            UpdateAll();
            ULoggerServer.GetInstance().LogCallback += OnAddLog;
            mTimer.Tick += new EventHandler(TimeTick);
            mTimer.Interval = 50;
            mTimer.Start();

            this.Text = "ULoggerWin - Ready";

            lstLogs.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(lstLogs_RetrieveVirtualItem);
            lstLogs.CacheVirtualItems += new CacheVirtualItemsEventHandler(lstLogs_CacheVirtualItems);
        }

        private void TimeTick(Object obj, EventArgs args)
        {
            if (mLogInfo.Size() == 0)
            {
                return;
            }

            int nCount = mLogInfo.Size();
            for (int nIndex = 0; nIndex < nCount; nIndex++)
            {
                ULoggerInfo pLog = mLogInfo.Peek();
                if (pLog != null)
                {
                    if (ULoggerImp.GetInstance().EnableClearLogCommand && pLog.IContent == "VeryFirstLog")
                    {
                        mItemClearLog_Click(obj, args);
                    }
                    else
                    {
                        bool bFilterPass = ULoggerImp.GetInstance().AddLog(pLog);
                        if (bFilterPass)
                        {
                            AddLog(pLog, nIndex == nCount - 1);
                        }
                    }
                }
                mLogInfo.Pop();
            }
            gpLogDetail.Text = "LogCount:" + lstLogs.Items.Count;
        }


        private void UpdateAll()
        {
            UpdateFilterList();
            UpdateLogList();
        }

        private void UpdateFilterList()
        {
            List<ULoggerFilter> lstFilters = ULoggerImp.GetInstance().Filters;
            lstFilter.Items.Clear();
            foreach (ULoggerFilter pFilter in lstFilters)
            {
                lstFilter.Items.Add(pFilter.FName);
            }
            lstFilter.SelectedIndex = ULoggerImp.GetInstance().CurFilterIndex;
        }

        private void UpdateLogList()
        {
            List<int> lstLogData = ULoggerImp.GetInstance().FilterLogs;
            List<ULoggerInfo> lstAllLog = ULoggerImp.GetInstance().AllLogs;
            lstLogs.VirtualListSize = 0;
            for (int nIndex = 0; nIndex < lstLogData.Count; nIndex++)
            {
                AddLog(lstAllLog[lstLogData[nIndex]], nIndex == lstLogData.Count - 1);
            }
            gpLogDetail.Text = "LogCount:" + lstLogs.Items.Count;
            mItemOptionShowLastLog.Checked = ULoggerImp.GetInstance().AlwaysShowLast;
            mItemExportFiltered.Checked = ULoggerImp.GetInstance().ExportFilteredLogOnly;
            iMenuExportLogContentOnly.Checked = ULoggerImp.GetInstance().ExportLogContentOnly;
            iMenuEnableClearLogCommand.Checked = ULoggerImp.GetInstance().EnableClearLogCommand;

        }

        public void AddLog(ULoggerInfo pLog, bool bLast = false)
        {
            try
            {
                lstLogs.VirtualListSize = lstLogs.VirtualListSize + 1;
                if (lstLogs.VirtualListSize > 500)
                    lstLogs.VirtualListSize = 1;
            }
            catch
            {
                lstLogs.VirtualListSize = 0;
            }

            if (bLast && ULoggerImp.GetInstance().AlwaysShowLast)
            {
                lstLogs.EnsureVisible(lstLogs.VirtualListSize - 1);
            }
        }

        public void OnAddLog(ULoggerInfo pLog)
        {
            mLogInfo.Push(pLog);
        }

        private void lstFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().CurFilterIndex = lstFilter.SelectedIndex;
            UpdateLogList();

            mItemFilterDelete.Enabled = lstFilter.SelectedIndex != 0;
            mItemFilterEdit.Enabled = lstFilter.SelectedIndex != 0;
        }

        private void lstLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLogs.SelectedIndices.Count == 0)
            {
                return;
            }
            int nIndex = lstLogs.SelectedIndices[0];
            List<int> lstLog = ULoggerImp.GetInstance().FilterLogs;
            List<ULoggerInfo> lstAllLog = ULoggerImp.GetInstance().AllLogs;
            if (nIndex < 0 || nIndex >= lstLog.Count)
            {
                return;
            }
            ULoggerInfo pLog = lstAllLog[lstLog[nIndex]];

            tbLogDetailContent.ForeColor = ULoggerImp.GetInstance().GetTagColor(pLog.ITag);
            tbLogDetailContent.Text = pLog.IContent;
        }

        private void mItemStartListen_Click(object sender, EventArgs e)
        {
            LogServerOption pLogServerOption = new LogServerOption();
            DialogResult pResult = pLogServerOption.ShowDialog(this);

            bool bListen = ULoggerServer.GetInstance().GetListenState();
            mItemStartListen.Text = bListen ? "Stop Listen" : "Start Listen";
            this.Text = "ULoggerWin - " + (bListen ? "Running " + ULoggerServer.GetInstance().IP + ":" + ULoggerServer.GetInstance().Port : "Ready");
        }

        private void mItemOptionShowLastLog_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().AlwaysShowLast = !ULoggerImp.GetInstance().AlwaysShowLast;
            mItemOptionShowLastLog.Checked = ULoggerImp.GetInstance().AlwaysShowLast;
        }

        private void mItemClearLog_Click(object sender, EventArgs e)
        {
            lock (lstLogs)
            {
                lstLogs.VirtualListSize = 0;
            }
            gpLogDetail.Text = "LogCount:0";
            lock (ULoggerImp.GetInstance())
            {
                ULoggerImp.GetInstance().ClearLog();
            }
        }

        private void mItemFilterNew_Click(object sender, EventArgs e)
        {
            FilterEdit pFilterEdit = new FilterEdit();
            DialogResult pResult = pFilterEdit.ShowDialog(this, null);
            if (pResult == DialogResult.OK)
            {
                ULoggerImp.GetInstance().CurFilterIndex = ULoggerImp.GetInstance().Filters.Count - 1;
                UpdateAll();
            }
        }

        private void mItemFilterDelete_Click(object sender, EventArgs e)
        {
            if (lstFilter.SelectedIndex == -1)
            {
                return;
            }

            List<ULoggerFilter> lstFilters = ULoggerImp.GetInstance().Filters;
            lstFilters.RemoveAt(lstFilter.SelectedIndex);
            lstFilter.SelectedIndex = 0;
            UpdateAll();
        }

        private void mItemFilterEdit_Click(object sender, EventArgs e)
        {
            List<ULoggerFilter> lstFilters = ULoggerImp.GetInstance().Filters;
            if (lstFilter.SelectedIndex == -1 || lstFilter.SelectedIndex >= lstFilters.Count)
            {
                return;
            }

            FilterEdit pFilterEdit = new FilterEdit();
            DialogResult pResult = pFilterEdit.ShowDialog(this, lstFilters[lstFilter.SelectedIndex]);
            if (pResult == DialogResult.OK)
            {
                ULoggerImp.GetInstance().UpdateFilterLogs();
                UpdateAll();
            }
        }


        private void mItemSaveCfg_Click(object sender, EventArgs e)
        {
            bool bOK = ULoggerImp.GetInstance().SaveCfg();
            MessageBox.Show(this, bOK ? "Save Complete" : "Save Failed");
        }

        private void mItemSaveLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog pSave = new SaveFileDialog();
            pSave.Filter = "ULogFile|*.ulog";
            if (pSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ULoggerImp.GetInstance().ExportLog(pSave.FileName);
                MessageBox.Show("Export Log Complete");
            }
        }

        private void mItemLoadLog_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpen = new OpenFileDialog();
            pOpen.Filter = "ULogFile|*.ulog";
            if (pOpen.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ULoggerImp.GetInstance().ImportLog(pOpen.FileName);
                UpdateLogList();
                MessageBox.Show("Import Log Complete");
            }
        }

        private void mItemExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("退出？", "确认", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (ULoggerServer.GetInstance().GetListenState())
            {
                ULoggerServer.GetInstance().StopServer();
            }
            Application.Exit();
        }

        private void mItemHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("日志监听工具");
        }

        private void mItemHelpHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"File->Start Listen开始监听日志
最大支持64k字符串
发送 VeryFirstLog 清除日志");
        }

        private void mItemExportFiltered_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().ExportFilteredLogOnly = !ULoggerImp.GetInstance().ExportFilteredLogOnly;
            mItemExportFiltered.Checked = ULoggerImp.GetInstance().ExportFilteredLogOnly;
        }

        private void tbLogSearchContent_TextChanged(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().CurSearchContent = tbLogSearchContent.Text;
            UpdateLogList();
        }

        private void iMenuEnableClearLogCommand_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().EnableClearLogCommand = !ULoggerImp.GetInstance().EnableClearLogCommand;
            iMenuEnableClearLogCommand.Checked = ULoggerImp.GetInstance().EnableClearLogCommand;
        }

        private void iMenuExportLogContentOnly_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().ExportLogContentOnly = !ULoggerImp.GetInstance().ExportLogContentOnly;
            iMenuExportLogContentOnly.Checked = ULoggerImp.GetInstance().ExportLogContentOnly;
        }

        private void btnShowDetailLogDialog_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tbLogDetailContent.Text, "Log");
        }

        private void btnCopyDetailLog2Clipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(tbLogDetailContent.Text);
            MessageBox.Show("Copy to Clipboard Successed.", "Msg");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            mItemClearLog_Click(sender, e);
        }

        private void mItemLogColor_Click(object sender, EventArgs e)
        {
            LogColorOptionDialog pColorDialog = new LogColorOptionDialog();
            pColorDialog.ShowDialog(this);
            UpdateLogList();
        }

        void lstLogs_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            List<int> lstLogData = ULoggerImp.GetInstance().FilterLogs;
            if (e.ItemIndex >= lstLogData.Count)
            {
                return;
            }
            if (mCache != null && e.ItemIndex >= mFirstItemIndex && e.ItemIndex < mFirstItemIndex + mCache.Length)
            {
                e.Item = mCache[e.ItemIndex - mFirstItemIndex];
            }
            else
            {
                List<ULoggerInfo> lstAllLog = ULoggerImp.GetInstance().AllLogs;
                ULoggerInfo pLog = lstAllLog[lstLogData[e.ItemIndex]];
                e.Item = new ListViewItem(pLog.GetInfo(e.ItemIndex + 1));
                e.Item.ForeColor = ULoggerImp.GetInstance().GetTagColor(pLog.ITag);
            }
        }

        void lstLogs_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (mCache != null && e.StartIndex >= mFirstItemIndex && e.EndIndex <= mFirstItemIndex + mCache.Length)
            {
                return;
            }

            List<int> lstLogData = ULoggerImp.GetInstance().FilterLogs;
            List<ULoggerInfo> lstAllLog = ULoggerImp.GetInstance().AllLogs;
            mFirstItemIndex = e.StartIndex;
            int length = e.EndIndex - e.StartIndex + 1;
            mCache = new ListViewItem[length];

            for (int i = 0; i < length; i++)
            {
                int nIndex = (i + mFirstItemIndex);
                ULoggerInfo pLog = lstAllLog[lstLogData[nIndex]];
                mCache[i] = new ListViewItem(pLog.GetInfo(nIndex + 1));
                mCache[i].ForeColor = ULoggerImp.GetInstance().GetTagColor(pLog.ITag);
            }

        }

    }
}
