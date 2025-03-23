using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Common.Utilities
{
    public class Logger
    {
        private readonly string _logFilePath;

        public Logger()
        {
            // Đường dẫn file log mặc định, có thể thay đổi qua cấu hình sau
            _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");
        }

        public void LogInfo(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}";
            WriteLog(logEntry);
        }

        public void LogError(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}";
            WriteLog(logEntry);
        }

        private void WriteLog(string logEntry)
        {
            try
            {
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Nếu ghi log thất bại, in ra console để debug
                Console.WriteLine($"Failed to write log: {ex.Message}");
            }
        }
    }
}
