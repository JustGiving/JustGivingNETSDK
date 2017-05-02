using System;

namespace JustGivingSDK.Logging
{
    public interface ILogProvider
    {
        void Warn(string message);
        void Info(string message);
        void Debug(string message);
        void Error(string message, Exception ex = null);
    }
}