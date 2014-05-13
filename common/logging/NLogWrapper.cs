using NLog;

namespace common.logging
{
    public class NLogWrapper : ILogger//todo s.rozhin
    {
        private Logger _nLogLogger;
        private NLogWrapper(Logger nLogLogger)
        {
            _nLogLogger = nLogLogger;
        }

        public static ILogger GetNLogWrapper()
         {
             var nLogLogger = LogManager.GetCurrentClassLogger();
             return new NLogWrapper(nLogLogger);
         }

        public void Info(string message)
        {
            _nLogLogger.Info(message);
        }
    }
}