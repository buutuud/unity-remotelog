using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public static class UDebug
{
    [Flags]
    public enum UDisplayType
    {
        Unity = 1,
        Remote = 2,
        All = Unity | Remote,
    }

    public enum ULogLevel
    {
        Debug,
        Warning,
        Error,
    }

    public static bool EnableLog = true;
#if UNITY_EDITOR
    public static UDisplayType UType = UDisplayType.Unity;
#elif UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_IOS
	public static UDisplayType UType = UDisplayType.Unity;
#else
    public static UDisplayType UType = UDisplayType.Unity;
#endif
    public static ULogLevel MinLogType = ULogLevel.Warning;
#if UNITY_EDITOR
    public static bool EnableErrorStack = false;
#else
        public static bool EnableErrorStack = true;
#endif

    static UDebug()
    {
        LoadServerCfg();

        Debug("", "VeryFirstLog");
        Application.logMessageReceived += UDebug.UnityLogCallback;
    }

    static public void Debug<T1>(string tag, T1 arg1)
    {
        if (EnableLog && ULogLevel.Debug < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Debug, tag, arg1);
    }

    static public void Debug<T1, T2>(string tag, T1 arg1, T2 arg2)
    {
        if (EnableLog && ULogLevel.Debug < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Debug, tag, arg1, arg2);
    }

    static public void Debug<T1, T2, T3>(string tag, T1 arg1, T2 arg2, T3 arg3)
    {
        if (EnableLog && ULogLevel.Debug < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Debug, tag, arg1, arg2, arg3);
    }

    static public void Debug<T1, T2, T3, T4>(string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (EnableLog && ULogLevel.Debug < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Debug, tag, arg1, arg2, arg3, arg4);
    }

    static public void Warning<T1>(string tag, T1 arg1)
    {
        if (EnableLog && ULogLevel.Warning < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Warning, tag, arg1);
    }

    static public void Warning<T1, T2>(string tag, T1 arg1, T2 arg2)
    {
        if (EnableLog && ULogLevel.Warning < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Warning, tag, arg1, arg2);
    }

    static public void Warning<T1, T2, T3>(string tag, T1 arg1, T2 arg2, T3 arg3)
    {
        if (EnableLog && ULogLevel.Warning < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Warning, tag, arg1, arg2, arg3);
    }

    static public void Warning<T1, T2, T3, T4>(string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (EnableLog && ULogLevel.Warning < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Warning, tag, arg1, arg2, arg3, arg4);
    }

    static public void Error<T1>(string tag, T1 arg1)
    {
        if (EnableLog && ULogLevel.Error < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Error, tag, arg1);
    }

    static public void Error<T1, T2>(string tag, T1 arg1, T2 arg2)
    {
        if (EnableLog && ULogLevel.Error < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Error, tag, arg1, arg2);
    }

    static public void Error<T1, T2, T3>(string tag, T1 arg1, T2 arg2, T3 arg3)
    {
        if (EnableLog && ULogLevel.Error < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Error, tag, arg1, arg2, arg3);
    }

    static public void Error<T1, T2, T3, T4>(string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (EnableLog && ULogLevel.Error < MinLogType)
        {
            return;
        }

        WriteLog(ULogLevel.Error, tag, arg1, arg2, arg3, arg4);
    }

    static public void UnityLogCallback(string strCondition, string strStackTrace, LogType eType)
    {
        if (!strCondition.Contains(mSpliter) && !strStackTrace.Contains("UDebug:WriteLog"))
        {
            switch (eType)
            {
                case LogType.Log:
                    {
                        Debug("Unity", strCondition, strStackTrace);
                    }
                    break;
                case LogType.Warning:
                    {
                        Warning("Unity", strCondition, strStackTrace);
                    }
                    break;
                case LogType.Exception:
                case LogType.Error:
                    {
                        Error("Unity", strCondition, strStackTrace);
                    }
                    break;
            }
        }
    }

    #region Remove Log
    private static string mLogServerIP = "127.0.0.1";
    private static int mLogServerPort = 8889;
    private static IPEndPoint mLogServerEP = null;
    private static Socket mSocket = null;
    private static byte[] mBuffer = new byte[1024 * 64];
    private const string mSpliter = "$";
    private static Socket LSocket
    {
        get
        {
            if (mSocket == null)
            {
                mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            }
            return mSocket;
        }
    }

    static void LoadServerCfg()
    {
        mLogServerIP = PlayerPrefs.GetString("LogServerIP", "127.0.0.1");
        mLogServerPort = PlayerPrefs.GetInt("LogServerPort", 8889);
    }

    static void SaveServerCfg()
    {
        PlayerPrefs.SetString("LogServerIP", mLogServerIP);
        PlayerPrefs.SetInt("LogServerPort", mLogServerPort);
    }

    private static IPEndPoint LogServerEP
    {
        get
        {
            if (mLogServerEP == null)
            {
                mLogServerEP = new IPEndPoint(IPAddress.Parse(mLogServerIP), mLogServerPort); ;
            }
            return mLogServerEP;
        }
    }

    private static void SendLog(string strLog)
    {
        if (strLog.Length >= 1024 * 64)
        {
            strLog = strLog.Substring(0, 1024 * 64 - 1);
        }
        int nLen = Encoding.UTF8.GetBytes(strLog, 0, strLog.Length, mBuffer, 0);
        try
        {
            LSocket.SendTo(mBuffer, nLen, SocketFlags.None, LogServerEP);
        }
        catch (Exception)
        {
            //Nothing
        }
    }

    public static bool SetLS(string strAddr)
    {
        string strIP = "";
        int nPort = 0;
        if (GetValidIPPort(strAddr, out strIP, out nPort))
        {
            if (mLogServerIP != strIP || mLogServerPort != nPort)
            {
                mLogServerIP = strIP;
                mLogServerPort = nPort;
                mLogServerEP = null;
                SaveServerCfg();
            }
            return true;
        }
        return false;
    }
    private static bool GetValidIPPort(string strAddr, out string strIP, out int nPort)
    {
        strIP = "";
        nPort = 0;
        string[] arrIP = strAddr.Split(':');
        if (arrIP.Length != 2)
        {
            return false;
        }
        System.Text.RegularExpressions.Regex pRegex = new System.Text.RegularExpressions.Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
        if (pRegex.IsMatch(arrIP[0]) && int.TryParse(arrIP[1], out nPort))
        {
            strIP = arrIP[0];
            return true;
        }
        return false;
    }
    #endregion

    #region Log
    private const int TrimStrBufferSize = 4096;
    private const int StrBufferInitSize = 256;
    private static StringBuilder StrBuffer = new StringBuilder(StrBufferInitSize);

    static private void TrimStringBuffer()
    {
        if (StrBuffer.Length != 0)
        {
            StrBuffer.Length = 0;
        }
        if (StrBuffer.Length >= TrimStrBufferSize)
        {
            StrBuffer.Capacity = StrBufferInitSize;
        }
    }

    static private void AppendErrorStack(ULogLevel level, string tag)
    {
        if (level == ULogLevel.Error && EnableErrorStack)
        {
            System.Diagnostics.StackTrace pStackTrace = new System.Diagnostics.StackTrace(3, true);
            StrBuffer.Append(":");
            StrBuffer.Append(pStackTrace);
        }
    }

    static private void WriteLog<T1>(ULogLevel level, string tag, T1 arg1)
    {
        TrimStringBuffer();

        StrBuffer.Append(tag);
        StrBuffer.Append(mSpliter);
        StrBuffer.Append(arg1);
        AppendErrorStack(level, tag);

        WriteLog(level);
    }

    static private void WriteLog<T1, T2>(ULogLevel level, string tag, T1 arg1, T2 arg2)
    {
        TrimStringBuffer();

        StrBuffer.Append(tag);
        StrBuffer.Append(mSpliter);
        StrBuffer.Append(arg1);
        StrBuffer.Append(arg2);
        AppendErrorStack(level, tag);

        WriteLog(level);
    }

    static private void WriteLog<T1, T2, T3>(ULogLevel level, string tag, T1 arg1, T2 arg2, T3 arg3)
    {
        TrimStringBuffer();

        StrBuffer.Append(tag);
        StrBuffer.Append(mSpliter);
        StrBuffer.Append(arg1);
        StrBuffer.Append(arg2);
        StrBuffer.Append(arg3);
        AppendErrorStack(level, tag);

        WriteLog(level);
    }

    static private void WriteLog<T1, T2, T3, T4>(ULogLevel level, string tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        TrimStringBuffer();

        StrBuffer.Append(tag);
        StrBuffer.Append(mSpliter);
        StrBuffer.Append(arg1);
        StrBuffer.Append(arg2);
        StrBuffer.Append(arg3);
        StrBuffer.Append(arg4);
        AppendErrorStack(level, tag);

        WriteLog(level);
    }

    static private void WriteLog(ULogLevel level)
    {
        if ((UType & UDisplayType.Unity) > 0)
        {
            switch (level)
            {
                case ULogLevel.Debug: { UnityEngine.Debug.Log(StrBuffer.ToString()); } break;
                case ULogLevel.Warning: { UnityEngine.Debug.LogWarning(StrBuffer.ToString()); } break;
                case ULogLevel.Error: { UnityEngine.Debug.LogError(StrBuffer.ToString()); } break;
            }
        }

        if ((UType & UDisplayType.Remote) > 0)
        {
            StrBuffer.Insert(0, mSpliter);
            switch (level)
            {
                case ULogLevel.Debug: { StrBuffer.Insert(0, "Debug"); } break;
                case ULogLevel.Warning: { StrBuffer.Insert(0, "Warning"); } break;
                case ULogLevel.Error: { StrBuffer.Insert(0, "Error"); } break;
            }
            StrBuffer.Insert(0, mSpliter);
            StrBuffer.Insert(0, DateTime.Now.Ticks);
            StrBuffer.Insert(0, mSpliter);
            SendLog(StrBuffer.ToString());
        }
    }
    #endregion
}

public static class UDebugTag
{
    public const string TMeshCreator = "MeshCreator";
}