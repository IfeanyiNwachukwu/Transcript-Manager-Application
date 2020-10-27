using System;
using TranscriptManagement.UserInterfaces;

namespace TranscriptManagerClient
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" {message}");
            var input = Console.ReadLine();
            return input;
        }

        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");

        }

        public void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" {message}");
        }
    }
}
