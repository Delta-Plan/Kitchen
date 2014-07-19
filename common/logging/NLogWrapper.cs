using System;
using NLog;

namespace common.Logging
{
    public class NLogWrapper : ILogger//todo s.rozhin
    {
        private Logger _nLogLogger;
        private static ILogger _logWrapper;
        private NLogWrapper()
        {
            var nLogLogger = LogManager.GetCurrentClassLogger();
            _nLogLogger = nLogLogger;
            _nLogLogger.LoggerReconfigured += _nLogLogger_LoggerReconfigured;
        }

        void _nLogLogger_LoggerReconfigured(object sender, EventArgs e)
        {
            _nLogLogger.Info("LoggerReconfigured");//todo s.rozhin AddMoreInfo
            _nLogLogger = LogManager.GetCurrentClassLogger();
        }

        public static ILogger GetNLogWrapper()
        {
            return _logWrapper ?? (_logWrapper = new NLogWrapper());
        }

        public void Info(string message)
        {
            _nLogLogger.Info(message);
        }

        public void Debug(string message)
        {
            _nLogLogger.Debug(message);
        }

        public void Warn(string message)
        {
            _nLogLogger.Warn(message);
        }

        public void Error(string message)
        {
            _nLogLogger.Error(message);
        }

        public void Fatal(string message)
        {
            _nLogLogger.Fatal(message);
        }

        public void ErrorException(string message, Exception exception)
        {
            _nLogLogger.ErrorException(message,exception);
        }

        public void FatalException(string message, Exception exception)
        {
            _nLogLogger.FatalException(message, exception);
        }
    }
}