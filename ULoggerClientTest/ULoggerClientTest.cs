using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ULoggerClientTest
{
    public partial class ULoggerClientTest : Form
    {
        private Socket mSocket = null;
        private int mPort = 0;
        private byte[] mBuffer = new byte[2048];

        public ULoggerClientTest()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            mBuffer = Encoding.ASCII.GetBytes(tbContent.Text);
            int nCount = mSocket.SendTo(mBuffer, mBuffer.Length, SocketFlags.None, new IPEndPoint(IPAddress.Parse("127.0.0.1"), mPort));
            if(nCount > 0)
            {

            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool bConnected = false;
            if(btnConnect.Text == "Connect")
            {
                string[] arrAdd = tbAddr.Text.Split(':');
                if (arrAdd.Length != 2)
                {
                    return;
                }
                string strIP = arrAdd[0];
                mPort = 0;
                if (!int.TryParse(arrAdd[1], out mPort))
                {
                    return;
                }
                bConnected = ConnectServer(strIP, mPort);
            }
            else
            {
                DisconnectServer();
            }

            tbAddr.Enabled = !bConnected;
            btnConnect.Text = bConnected ? "Disconnect" : "Connect";
            lblConnectState.Text = bConnected ? "Connected" : "Ready";
            lblConnectState.ForeColor = bConnected ? Color.Green : Color.Black;
        }

        private bool ConnectServer(string strIP, int nPort)
        {
            mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mBuffer = Encoding.ASCII.GetBytes("Connected Test");
            int nCount = mSocket.SendTo(mBuffer, mBuffer.Length, SocketFlags.None, new IPEndPoint(IPAddress.Parse("127.0.0.1"), nPort));
            return nCount > 0;
        }

        private void DisconnectServer()
        {
            if(mSocket != null)
            {
                mSocket.Shutdown(SocketShutdown.Both);
                mSocket.Close();
                mSocket = null;
            }
        }
    }
}
