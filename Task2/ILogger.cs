using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface ILogger
    {
        void LogInfo(string Message);
        void LogError(string Message);
    }

    public class Logger : ILogger
    {
        public void LogInfo(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine($"INFO: {Message}");
            Console.ResetColor();
        }

        public void LogError(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"ERROR: {Message}");
            Console.ResetColor();
        }
    }
}
