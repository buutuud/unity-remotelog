using System;
using System.Linq;
using System.Text;
using NLog;
using NLog.Targets;
namespace ULogger
{
    class Log
    {
        public static void Info(string ipAddrees,string info)
        {
            if(LogManager.Configuration != null)
            {
                FileTarget fileTarget = LogManager.Configuration.AllTargets.Where(t => t.Name == "unity").First() as FileTarget;
                DateTime Now = DateTime.Now;
                fileTarget.FileName = string.Format("logs/{0}/{1}.log", Now.ToString("yyyy-MM-dd"), ipAddrees);

                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Info(info);
            }
        }
    }
}