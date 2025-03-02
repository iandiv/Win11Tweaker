using System;
using System.IO;

namespace Win11_Tweaker
{
    public static class LoggerHelper
    {
        private static readonly string logFilePath = Path.Combine(AppContext.BaseDirectory, "log.txt");

        /// <summary>
        /// Writes a log message to the log file.
        /// </summary>
        public static void Log(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                File.AppendAllText(logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logger Error: {ex.Message}");
            }
        }
    }
}
