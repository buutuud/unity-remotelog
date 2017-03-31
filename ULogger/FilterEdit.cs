using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ULogger
{
    public partial class FilterEdit : Form
    {
        private ULoggerFilter mCurFilter = null;
        private ULoggerFilter mCurFilterEdit = new ULoggerFilter();

        public FilterEdit()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(IWin32Window pOwner, ULoggerFilter pFilter)
        {
            mCurFilter = pFilter;
            mCurFilterEdit.Set(mCurFilter);

            tbFilterName.Text = mCurFilter == null ? "" : mCurFilter.FName;
            tbFilterByTag.Text = mCurFilter == null ? "" : mCurFilter.FTag;
            tbFilterByText.Text = mCurFilter == null ? "" : mCurFilter.FContent;
            cbLevel.Text = mCurFilter == null ? "" : mCurFilter.FLevel.ToString();
            return ShowDialog(pOwner);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbFilterName.Text.Length == 0)
            {
                return;
            }

            mCurFilterEdit.Set(tbFilterName.Text, tbFilterByTag.Text, ConvertLevel(cbLevel.Text), tbFilterByText.Text);
            if(mCurFilter != null)
            {
                mCurFilter.Set(mCurFilterEdit);
            }
            else
            {
                ULoggerImp.GetInstance().AddFilter(mCurFilterEdit);
            }
        }

        LogLevel ConvertLevel(string strLevel)
        {
            if (strLevel == "Debug")
            {
                return LogLevel.Debug;
            }
            else if (strLevel == "Warning")
            {
                return LogLevel.Warning;
            }
            else if (strLevel == "Error")
            {
                return LogLevel.Error;
            }

            return LogLevel.All;
        }
    }
}
