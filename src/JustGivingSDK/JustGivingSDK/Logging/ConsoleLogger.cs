using System;

namespace JustGivingSDK.Logging
{
    public class ConsoleLogger : ILogProvider
    {
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        public void Debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Error(string message, Exception ex = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            if (ex != null)
            {
                Console.Write(ex.ToString());
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public static class JustGivingApiClientConsoleLoggerExtensions
    {
        public static void UseConsoleLogger(this JustGivingApiClient client)
        {
            client.LogProvider = new ConsoleLogger();
        }
    }
}
