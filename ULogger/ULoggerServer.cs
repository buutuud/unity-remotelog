using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ULogger
{
    public class ULoggerServer
    {
        private static ULoggerServer mInstance = null;
        private string mIP = "127.0.0.1";
        private int mPort = 8888;
        private Socket mSocket = null;
        private Thread mReceiveThread = null;

        public delegate void OnAddLogCallback(ULoggerInfo pLog);
        public OnAddLogCallback LogCallback = null;

        public string IP { get { return mIP; } }
        public int Port { get { return mPort; } }

        public static ULoggerServer GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new ULoggerServer();
            }
            return mInstance;
        }

        public bool StartServer(string strAddr)
        {
            string[] arrAdd = strAddr.Split(':');
            if (arrAdd.Length != 2)
            {
                return false;
            }
            mIP = arrAdd[0];
            if (!int.TryParse(arrAdd[1], out mPort))
            {
                return false;
            }

            try
            {
                mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                mSocket.Bind(new IPEndPoint(IPAddress.Any, mPort));
            }
            catch (Exception)
            {
                MessageBox.Show("Bind Port Failed:" + mPort, "Error");
                return false;
            }

            mReceiveThread = new Thread(ReceiveMessage);
            mReceiveThread.IsBackground = true;
            mReceiveThread.Start(mSocket);

            return true;
        }

        public bool GetListenState()
        {
            return mSocket != null;
        }

        public void StopServer()
        {
            if (mReceiveThread != null)
            {
                mReceiveThread.Abort();
                mReceiveThread = null;
            }
            if (mSocket != null)
            {
                mSocket.Shutdown(SocketShutdown.Both);
                mSocket.Close();
                mSocket = null;
            }
        }

        private void ReceiveMessage(object obj)
        {
            Socket pSocket = obj as Socket;
            byte[] bResult = new byte[1024 * 64];
            EndPoint pRemote = new IPEndPoint(IPAddress.Any, 0);
            ULoggerInfo pLog = new ULoggerInfo();
            while (true)
            {
                try
                {
                    int nReceiveNumber = pSocket.ReceiveFrom(bResult, ref pRemote);
                    if (nReceiveNumber > 0)
                    {
                        string strLog = Encoding.UTF8.GetString(bResult, 0, nReceiveNumber);
                        if (LogCallback != null)
                        {
                            pLog.Set(strLog);
                            LogCallback(pLog);
                        }
                    }
                }
                catch (ThreadAbortException)
                {

                }
                catch (Exception e)
                {
                    MessageBox.Show("ReceiveMessage Exception:" + e.ToString());
                }
            }
        }
    }
}
