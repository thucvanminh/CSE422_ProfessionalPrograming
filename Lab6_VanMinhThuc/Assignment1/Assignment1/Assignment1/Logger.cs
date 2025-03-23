using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Logger
    {
        public void Log(string methodName, params object[] args)
        {
            var method = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method?.Invoke(this, args);
        }

        private void LogUserAction(string username, string action)
        {
            Console.WriteLine($"User {username} performed action: {action}");
        }

        private void LogTransaction(int transactionId, double amount)
        {
            Console.WriteLine($"Transaction {transactionId} processed with amount: {amount}");
        }

        private void LogError(string errorMessage, DateTime timestamp)
        {
            Console.WriteLine($"Error at {timestamp}: {errorMessage}");
        }
    }
}
