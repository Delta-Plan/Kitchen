using System;

namespace common.logging
{
    public interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
        void ErrorException(string message, Exception exception);
        void FatalException(string message, Exception exception);
    }
}
