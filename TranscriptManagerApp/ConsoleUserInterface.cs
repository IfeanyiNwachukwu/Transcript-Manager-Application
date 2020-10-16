using System;
using TranscriptManagement.UserInterfaces;

namespace TranscriptManagerClient
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Please enter {message}");
            var input = Console.ReadLine();
            return input;
        }

        public void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Please enter {message}");

        }

        public void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Please enter {message}");
        }
    }
}
