using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ULogger
{
    [Flags]
    public enum LogLevel
    {
        Debug = 1,
        Warning = 2,
        Error = 4,
        Excaption = 8,

        All = Debug | Warning | Error | Excaption,
    }

    public class ULoggerInfo : ISetterInterface
    {
        public DateTime ITime;
        public string ITag = "";
        public LogLevel ILevel = LogLevel.All;
        public string IContent = "";
        private string[] mInfo = { "", "", "", "", "" };
        private char mSpliter = '$';

        public ULoggerInfo()
        {

        }
        public ULoggerInfo(long nTime, string strTag, LogLevel nLevel = LogLevel.Debug, string strContent = "")
        {
            ITime = new DateTime(nTime);
            ITag = strTag;
            ILevel = nLevel;
            IContent = strContent;
        }
        public ULoggerInfo(string strLog)
        {
            Set(strLog);
        }
        public bool Set(string strLog)
        {
            do
            {
                if (strLog.Length == 0)
                {
                    break;
                }
                mSpliter = strLog.ToCharArray()[0];
                strLog = strLog.Substring(1);
                string[] arrLog = strLog.Split(mSpliter);
                if (arrLog.Length == 4)
                {
                    long nTime = 0;
                    if (!long.TryParse(arrLog[0], out nTime))
                    {
                        break;
                    }
                    ITime = new DateTime(nTime);
                    ILevel = ULoggerImp.ConvertLogLevel(arrLog[1]);
                    ITag = arrLog[2];
                    IContent = arrLog[3];
                    IContent = IContent.Replace("\n", "\r\n");
                    return true;
                }
                else if (arrLog.Length == 5)
                {
                    long nTime = 0;
                    if (!long.TryParse(arrLog[1], out nTime))
                    {
                        break;
                    }
                    ITime = new DateTime(nTime);
                    ILevel = ULoggerImp.ConvertLogLevel(arrLog[2]);
                    ITag = arrLog[3];
                    IContent = arrLog[4];
                    IContent = IContent.Replace("\n", "\r\n");
                    return true;
                }
                else if (arrLog.Length == 0)
                {
                    ITime = DateTime.Now;
                    ILevel = LogLevel.Error;
                    ITag = "ParseError";
                    IContent = strLog.Replace("\n", "\r\n");
                    return false;
                }
            } while (false);

            ITime = DateTime.Now;
            ILevel = LogLevel.Error;
            ITag = "ParseError";
            IContent = strLog.Replace("\n", "\r\n");
            return false;
        }
        public string[] GetInfo(int nIndex)
        {
            mInfo[0] = nIndex.ToString();
            mInfo[1] = string.Format("{0}.{1:00}.{2:00} {3:00}:{4:00}:{5:00}.{6:000}", ITime.Year, ITime.Month, ITime.Day, ITime.Hour, ITime.Minute, ITime.Second, ITime.Millisecond);
            mInfo[2] = ILevel.ToString();
            mInfo[3] = ITag;
            mInfo[4] = IContent;
            return mInfo;
        }
        public override void Set(ISetterInterface pOther)
        {
            ULoggerInfo pValue = pOther as ULoggerInfo;
            if (pValue == null)
            {
                return;
            }
            ITime = pValue.ITime;
            ITag = pValue.ITag;
            ILevel = pValue.ILevel;
            IContent = pValue.IContent;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", mSpliter, ITime.Ticks.ToString(), mSpliter, ULoggerImp.ConvertLogLevel(ILevel), mSpliter, ITag, mSpliter, IContent);
        }
    }

    public class ULoggerFilter
    {
        public string FName;
        public string FTag;
        public LogLevel FLevel;
        public string FContent;
        private const char Spliter = '#';

        public ULoggerFilter()
        {

        }
        public ULoggerFilter(string strName, string strTag = "", LogLevel nLevel = LogLevel.All, string strContent = "")
        {
            Set(strName, strTag, nLevel, strContent);
        }
        public ULoggerFilter(ULoggerFilter pFilter)
        {
            Set(pFilter);
        }

        public void Set(ULoggerFilter pFilter)
        {
            if (pFilter == null)
            {
                return;
            }
            FName = pFilter.FName;
            FTag = pFilter.FTag;
            FLevel = pFilter.FLevel;
            FContent = pFilter.FContent;
        }
        public void Set(string strName, string strTag = "", LogLevel nLevel = LogLevel.All, string strContent = "")
        {
            FName = strName;
            FTag = strTag;
            FLevel = nLevel;
            FContent = strContent;
        }

        public bool PassFilter(ULoggerInfo pLog)
        {
            if (pLog != null &&
                (FTag.Length == 0 || FTag == pLog.ITag) &&
                (FLevel & pLog.ILevel) > 0 &&
                (FContent.Length == 0 || pLog.IContent.Contains(FContent)))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}", FName, Spliter, FTag, Spliter, FLevel.ToString(), Spliter, FContent);
        }
        public bool Set(string strValue)
        {
            string[] arrSplite = strValue.Split(Spliter);
            if (arrSplite.Length == 4)
            {
                FName = arrSplite[0];
                FTag = arrSplite[1];
                FLevel = ULoggerImp.ConvertLogLevel(arrSplite[2]);
                FContent = arrSplite[3];
                return true;
            }
            return false;
        }
    }

    [XmlRoot("AssetBundleHashDesc")]
    public class ULoggerCfg
    {
        public class ULoggerCfgStrItem
        {
            [XmlAttribute("Key")]
            public string Key;
            [XmlAttribute("Value")]
            public string Value;
            public ULoggerCfgStrItem() { }
            public ULoggerCfgStrItem(string strKey, string strValue) { Key = strKey; Value = strValue; }
        }

        public class ULoggerCfgBoolItem
        {
            [XmlAttribute("Key")]
            public string Key;
            [XmlAttribute("Value")]
            public bool Value;
            public ULoggerCfgBoolItem() { }
            public ULoggerCfgBoolItem(string strKey, bool bValue) { Key = strKey; Value = bValue; }
        }

        public class ULoggerCfgIntItem
        {
            [XmlAttribute("Key")]
            public string Key;
            [XmlAttribute("Value")]
            public int Value;
            public ULoggerCfgIntItem() { }
            public ULoggerCfgIntItem(string strKey, int nValue) { Key = strKey; Value = nValue; }
        }

        public class ULoggerCfgColorItem
        {
            [XmlAttribute("Key")]
            public string Key;
            [XmlAttribute("ColorA")]
            public Byte ColorA;
            [XmlAttribute("ColorR")]
            public Byte ColorR;
            [XmlAttribute("ColorG")]
            public Byte ColorG;
            [XmlAttribute("ColorB")]
            public Byte ColorB;
            public ULoggerCfgColorItem() { }
            public ULoggerCfgColorItem(string strKey, Color nValue) { Key = strKey; ColorA = nValue.A; ColorR = nValue.R; ColorG = nValue.G; ColorB = nValue.B; }
        }

        [XmlElement("StrCfg")]
        public List<ULoggerCfgStrItem> StrElements = new List<ULoggerCfgStrItem>();
        [XmlElement("BoolCfg")]
        public List<ULoggerCfgBoolItem> BoolElements = new List<ULoggerCfgBoolItem>();
        [XmlElement("IntCfg")]
        public List<ULoggerCfgIntItem> IntElements = new List<ULoggerCfgIntItem>();
        [XmlElement("ColorCfg")]
        public List<ULoggerCfgColorItem> ColorElements = new List<ULoggerCfgColorItem>();

        public static ULoggerCfg Load(string strPpath)
        {
            ULoggerCfg pRet = null;
            try
            {
                using (FileStream pFileStream = new FileStream(strPpath, FileMode.Open))
                {
                    XmlSerializer pXmlSerializer = new XmlSerializer(typeof(ULoggerCfg));
                    pRet = (ULoggerCfg)pXmlSerializer.Deserialize(pFileStream);
                }
            }
            catch (Exception) { }
            return pRet;
        }

        public static bool Save(ULoggerCfg pULoggerCfg, string strPpath)
        {
            try
            {
                using (FileStream pFileStream = new FileStream(strPpath, FileMode.Create))
                {
                    XmlSerializer pXmlSerializer = new XmlSerializer(typeof(ULoggerCfg));
                    pXmlSerializer.Serialize(pFileStream, pULoggerCfg);
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }

    public class ULoggerImp
    {
        private List<ULoggerFilter> mFilters = new List<ULoggerFilter>();
        private List<ULoggerInfo> mAllLogs = new List<ULoggerInfo>();
        private List<int> mFilterLogs = new List<int>();
        private int mCurFilterIndex = 0;
        private string mCurSearchContent = "";
        private static ULoggerImp mInstance = null;
        private string mLoggerSvrAddr = "";

        public List<ULoggerFilter> Filters { get { return mFilters; } private set { } }
        public List<int> FilterLogs { get { return mFilterLogs; } private set { } }
        public List<ULoggerInfo> AllLogs { get { return mAllLogs; } private set { } }
        public string LoggerSvrAddr { get { return mLoggerSvrAddr; } set { mLoggerSvrAddr = value; } }
        public bool AlwaysShowLast { get; set; }
        public bool ExportFilteredLogOnly { get; set; }
        public bool ExportLogContentOnly { get; set; }
        public bool EnableClearLogCommand { get; set; }
        public Color LogColDebug { get; set; }
        public Color LogColExcaption { get; set; }
        public Color LogColError { get; set; }
        public Color LogColWarning { get; set; }
        public Dictionary<string, Color> LogColTags = new Dictionary<string, Color>();

        public int CurFilterIndex
        {
            get
            {
                return mCurFilterIndex;
            }
            set
            {
                if (mCurFilterIndex == value)
                {
                    return;
                }
                if (value < 0 || value >= mFilters.Count)
                {
                    return;
                }
                mCurFilterIndex = value;
                UpdateFilterLogs();
            }
        }

        public string CurSearchContent
        {
            get
            {
                return mCurSearchContent;
            }
            set
            {
                if (mCurSearchContent == value)
                {
                    return;
                }
                mCurSearchContent = value.Trim();
                UpdateFilterLogs();
            }
        }

        public static ULoggerImp GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new ULoggerImp();
            }
            return mInstance;
        }

        public ULoggerImp()
        {
            LoadCfg();
        }

        public Color GetLevelColor(LogLevel nLevel)
        {
            Color nRet = LogColDebug;
            switch (nLevel)
            {
                case LogLevel.Excaption: { nRet = LogColExcaption; } break;
                case LogLevel.Error: { nRet = LogColError; } break;
                case LogLevel.Warning: { nRet = LogColWarning; } break;
            }
            return nRet;
        }
        public Color GetTagColor(string sTag)
        {
            if(this.LogColTags.ContainsKey(sTag))
            {
                return LogColTags[sTag];
            }
            return Color.Black;
        }

        #region Filter
        public void AddFilter(ULoggerFilter pFilter)
        {
            if (pFilter == null)
            {
                return;
            }
            mFilters.Add(pFilter);
        }

        public void DeleteFilter(ULoggerFilter pFilter)
        {
            if (pFilter == null)
            {
                return;
            }

            for (int nIndex = 0; nIndex < mFilters.Count; nIndex++)
            {
                if (mFilters[nIndex] == pFilter)
                {
                    mFilters.RemoveAt(nIndex);
                    CurFilterIndex = 0;
                    break;
                }
            }
        }

        public ULoggerFilter GetCurFilter()
        {
            return (mCurFilterIndex >= 0 && mCurFilterIndex < mFilters.Count) ? mFilters[mCurFilterIndex] : (mFilters.Count > 0 ? mFilters[0] : null);
        }
        #endregion

        public void UpdateFilterLogs()
        {
            mFilterLogs.Clear();
            ULoggerFilter pFilter = GetCurFilter();
            if (pFilter == null)
            {
                return;
            }

            int nCount = mAllLogs.Count;
            for (int nIndex = 0; nIndex < nCount; nIndex++)
            {
                ULoggerInfo pLog = mAllLogs[nIndex];
                if (mCurSearchContent.Length > 0 && !System.Text.RegularExpressions.Regex.IsMatch(pLog.IContent, mCurSearchContent))
                {
                    continue;
                }
                if (pFilter.PassFilter(pLog))
                {
                    mFilterLogs.Add(nIndex);
                }
            }
        }

        public bool AddLog(ULoggerInfo pLog)
        {
            if (pLog == null)
            {
                return false;
            }

            mAllLogs.Add(pLog);
            ULoggerFilter pFilter = GetCurFilter();
            if (pFilter != null && pFilter.PassFilter(pLog))
            {
                mFilterLogs.Add(mAllLogs.Count - 1);
                return true;
            }
            return false;
        }

        public void ClearLog()
        {
            mFilterLogs.Clear();
            mAllLogs.Clear();
        }

        string GetCfgFile()
        {
            return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Replace(".exe", ".xml");
        }
        public void LoadCfg()
        {
            mFilters.Clear();

            DefaultCfg();

            string strCfgFile = GetCfgFile();
            ULoggerCfg pULoggerCfg = ULoggerCfg.Load(strCfgFile);
            if (pULoggerCfg != null)
            {
                foreach (ULoggerCfg.ULoggerCfgStrItem pStrItem in pULoggerCfg.StrElements)
                {
                    if (pStrItem.Key == "LoggerSvrAddr")
                    {
                        LoggerSvrAddr = pStrItem.Value;
                    }
                    else if (pStrItem.Key == "Filter")
                    {
                        ULoggerFilter pFilter = new ULoggerFilter();
                        if (pFilter.Set(pStrItem.Value))
                        {
                            mFilters.Add(pFilter);
                        }
                    }
                }
                foreach (ULoggerCfg.ULoggerCfgBoolItem pBoolItem in pULoggerCfg.BoolElements)
                {
                    if (pBoolItem.Key == "AlwaysShowLast")
                    {
                        AlwaysShowLast = pBoolItem.Value;
                    }
                    else if (pBoolItem.Key == "ExportFilteredLogOnly")
                    {
                        ExportFilteredLogOnly = pBoolItem.Value;
                    }
                    else if (pBoolItem.Key == "ExportLogContentOnly")
                    {
                        ExportLogContentOnly = pBoolItem.Value;
                    }
                    else if (pBoolItem.Key == "EnableClearLogCommand")
                    {
                        EnableClearLogCommand = pBoolItem.Value;
                    }
                }
                foreach (ULoggerCfg.ULoggerCfgColorItem pColorItem in pULoggerCfg.ColorElements)
                {
                    if (pColorItem.Key == "LogColDebug")
                    {
                        LogColDebug = Color.FromArgb(pColorItem.ColorA, pColorItem.ColorR, pColorItem.ColorG, pColorItem.ColorB);
                    }
                    else if (pColorItem.Key == "LogColWarning")
                    {
                        LogColWarning = Color.FromArgb(pColorItem.ColorA, pColorItem.ColorR, pColorItem.ColorG, pColorItem.ColorB);
                    }
                    else if (pColorItem.Key == "LogColExcaption")
                    {
                        LogColExcaption = Color.FromArgb(pColorItem.ColorA, pColorItem.ColorR, pColorItem.ColorG, pColorItem.ColorB);
                    }
                    else if (pColorItem.Key == "LogColError")
                    {
                        LogColError = Color.FromArgb(pColorItem.ColorA, pColorItem.ColorR, pColorItem.ColorG, pColorItem.ColorB);
                    }

                    LogColTags.Add(pColorItem.Key, Color.FromArgb(pColorItem.ColorA, pColorItem.ColorR, pColorItem.ColorG, pColorItem.ColorB));
                }
            }

            if (mFilters.Count == 0)
            {
                mFilters.Add(new ULoggerFilter("All(no filters)"));
            }
        }
        public bool SaveCfg()
        {
            string strCfgFile = GetCfgFile();

            ULoggerCfg pULoggerCfg = new ULoggerCfg();
            pULoggerCfg.StrElements.Add(new ULoggerCfg.ULoggerCfgStrItem("LoggerSvrAddr", LoggerSvrAddr));
            for (int nIndex = 0; nIndex < mFilters.Count; nIndex++)
            {
                pULoggerCfg.StrElements.Add(new ULoggerCfg.ULoggerCfgStrItem("Filter", mFilters[nIndex].ToString()));
            }
            pULoggerCfg.BoolElements.Add(new ULoggerCfg.ULoggerCfgBoolItem("AlwaysShowLast", AlwaysShowLast));
            pULoggerCfg.BoolElements.Add(new ULoggerCfg.ULoggerCfgBoolItem("ExportFilteredLogOnly", ExportFilteredLogOnly));
            pULoggerCfg.BoolElements.Add(new ULoggerCfg.ULoggerCfgBoolItem("ExportLogContentOnly", ExportLogContentOnly));
            pULoggerCfg.BoolElements.Add(new ULoggerCfg.ULoggerCfgBoolItem("EnableClearLogCommand", EnableClearLogCommand));

            pULoggerCfg.ColorElements.Add(new ULoggerCfg.ULoggerCfgColorItem("LogColDebug", LogColDebug));
            pULoggerCfg.ColorElements.Add(new ULoggerCfg.ULoggerCfgColorItem("LogColWarning", LogColWarning));
            pULoggerCfg.ColorElements.Add(new ULoggerCfg.ULoggerCfgColorItem("LogColExcaption", LogColExcaption));
            pULoggerCfg.ColorElements.Add(new ULoggerCfg.ULoggerCfgColorItem("LogColError", LogColError));

            return ULoggerCfg.Save(pULoggerCfg, strCfgFile);
        }
        public void DefaultCfg()
        {
            AlwaysShowLast = true;
            ExportFilteredLogOnly = false;
            ExportLogContentOnly = false;
            EnableClearLogCommand = true;

            LogColDebug = Color.Black;
            LogColExcaption = Color.Red;
            LogColError = Color.Red;
            LogColWarning = Color.Yellow;
        }

        public static LogLevel ConvertLogLevel(string strLevel)
        {
            if (strLevel == "Warning") { return LogLevel.Warning; }
            else if (strLevel == "Excaption") { return LogLevel.Excaption; }
            else if (strLevel == "Error") { return LogLevel.Error; }
            else if (strLevel == "All") { return LogLevel.All; }
            return LogLevel.Debug;
        }
        public static string ConvertLogLevel(LogLevel nLevel)
        {
            if (nLevel == LogLevel.Warning) { return "Warning"; }
            else if (nLevel == LogLevel.Excaption) { return "Excaption"; }
            else if (nLevel == LogLevel.Error) { return "Error"; }
            else if (nLevel == LogLevel.All) { return "All"; }
            return "Debug";
        }

        public void ExportLog(string strLogFile)
        {
            using (StreamWriter pStream = new StreamWriter(strLogFile))
            {
                if (ExportFilteredLogOnly)
                {
                    for (int nIndex = 0; nIndex < mFilterLogs.Count; nIndex++)
                    {
                        ULoggerInfo pLog = mAllLogs[mFilterLogs[nIndex]];
                        pStream.WriteLine(pLog.ToString().Replace("\r", "\\rr").Replace("\n", "\\nn"));
                    }
                }
                else
                {
                    for (int nIndex = 0; nIndex < mAllLogs.Count; nIndex++)
                    {
                        ULoggerInfo pLog = mAllLogs[nIndex];
                        pStream.WriteLine(pLog.ToString().Replace("\r", "\\rr").Replace("\n", "\\nn"));
                    }
                }
            }
        }

        public void ImportLog(string strLogFile)
        {
            using (StreamReader pStream = new StreamReader(strLogFile))
            {
                while (!pStream.EndOfStream)
                {
                    string strLog = pStream.ReadLine();
                    ULoggerInfo pInfo = new ULoggerInfo();
                    if (pInfo.Set(strLog.Replace("\\rr", "\r").Replace("\\nn", "\n")))
                    {
                        mAllLogs.Add(pInfo);
                    }
                }
            }
            UpdateFilterLogs();
        }
    }
}
