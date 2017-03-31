using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ULogger
{
    public partial class LogColorOptionDialog : Form
    {
        public LogColorOptionDialog()
        {
            InitializeComponent();

            UpdateUI();
        }

        private void UpdateUI()
        {
            btnLogDebug.ForeColor = ULoggerImp.GetInstance().LogColDebug;
            btnLogWarn.ForeColor = ULoggerImp.GetInstance().LogColWarning;
            btnLogErr.ForeColor = ULoggerImp.GetInstance().LogColError;
            btnLogException.ForeColor = ULoggerImp.GetInstance().LogColExcaption;
        }

        private void btnLogDebug_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().LogColDebug = ChooseColor(ULoggerImp.GetInstance().LogColDebug);
            UpdateUI();
        }

        private void btnLogWarn_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().LogColWarning = ChooseColor(ULoggerImp.GetInstance().LogColWarning);
            UpdateUI();
        }

        private void btnLogErr_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().LogColError = ChooseColor(ULoggerImp.GetInstance().LogColError);
            UpdateUI();
        }

        private void btnLogException_Click(object sender, EventArgs e)
        {
            ULoggerImp.GetInstance().LogColExcaption = ChooseColor(ULoggerImp.GetInstance().LogColExcaption);
            UpdateUI();
        }

        private Color ChooseColor(Color col)
        {
            ColorDialog pColorDialog = new ColorDialog();
            pColorDialog.Color = col;
            if (pColorDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                col = pColorDialog.Color;
            }
            return col;
        }
    }
}
