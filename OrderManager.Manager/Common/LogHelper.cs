using log4net;
using log4net.Config;
using OrderManager.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"LogConfig\Log4Net.config", Watch = true)]
namespace OrderManager.Manager.Common
{

    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        private static readonly ConcurrentDictionary<string, ILog> _loggers = new ConcurrentDictionary<string, ILog>();
        private static string Log4Net_Info = "Info";
        private static string Log4Net_Error = "Error";
        private static string Log4Net_Debug = "Debug";



        static LogHelper()
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory + @"LogConfig\Log4net.xml";
            ExceptionLog.Write(path);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        }
        public static log4net.ILog GetLog(string logName)
        {

            var log = log4net.LogManager.GetLogger(logName);

            return log;

        }



        public static void Debug(string message)
        {

            var log = log4net.LogManager.GetLogger(Log4Net_Debug);

            if (log.IsDebugEnabled)

                log.Debug(message);

        }



        public static void Debug(string message, Exception ex)
        {

            var log = log4net.LogManager.GetLogger(Log4Net_Debug);

            if (log.IsDebugEnabled)

                log.Debug(message, ex);

        }



        public static void Error(string message)
        {

            var log = log4net.LogManager.GetLogger(Log4Net_Error);

            if (log.IsErrorEnabled)

                log.Error(message);

        }



        public static void Error(string message, Exception ex)
        {

            var log = log4net.LogManager.GetLogger(Log4Net_Error);

            if (log.IsErrorEnabled)

                log.Error(message, ex);

        }



        public static void Fatal(string message)
        {

            var log = log4net.LogManager.GetLogger(Log4Net_Info);

            if (log.IsFatalEnabled)

                log.Fatal(message);

        }



        public static void Info(string message)
        {

            log4net.ILog log = log4net.LogManager.GetLogger(Log4Net_Info);

            if (log.IsInfoEnabled)

                log.Info(message);

        }



        public static void Warn(string message)
        {

            var log = log4net.LogManager.GetLogger(Log4Net_Info);

            if (log.IsWarnEnabled)

                log.Warn(message);

        }
    }
}
