using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ULogger
{
    public partial class LogServerOption : Form
    {
        public LogServerOption()
        {
            InitializeComponent();
            tbLoggerSvr.Text = ULoggerImp.GetInstance().LoggerSvrAddr;
            if(tbLoggerSvr.Text.Length == 0)
            {
                SetLocalIP();
            }
            UpdateBtnState();
        }

        void UpdateBtnState()
        {
            bool bRuning = ULoggerServer.GetInstance().GetListenState();
            tbLoggerSvr.Enabled = !bRuning;
            btnStartSvr.Text = bRuning ? "Stop" : "Start";
            btnSetLocalIP.Enabled = !bRuning;
        }

        private void SetLocalIP()
        {
            IPHostEntry pIPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            for(int nIndex = 0; nIndex < pIPHostEntry.AddressList.Length; nIndex++)
            {
                if(pIPHostEntry.AddressList[nIndex].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    tbLoggerSvr.Text = pIPHostEntry.AddressList[nIndex].ToString() + ":8889";
                    break;
                }
            }
        }

        private void btnSetLocalIP_Click(object sender, EventArgs e)
        {
            SetLocalIP();
        }

        private void btnStartSvr_Click(object sender, EventArgs e)
        {

            if (!ULoggerServer.GetInstance().GetListenState())
            {
                ULoggerServer.GetInstance().StartServer(tbLoggerSvr.Text);

                ULoggerImp.GetInstance().LoggerSvrAddr = tbLoggerSvr.Text;
            }
            else
            {
                ULoggerServer.GetInstance().StopServer();
            }
            UpdateBtnState();
        }

    }
}
