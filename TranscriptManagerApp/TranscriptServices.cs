using System;
using System.Reflection;
using TranscriptManagement.Commands;
using TranscriptManagement.UserInterfaces;

namespace TranscriptManagerClient
{
    public interface ITranscriptServices
    {
        void Run();
    }
    public class TranscriptServices : ITranscriptServices
    {
        IUserInterface _userInterface { get; set; }
        Func<string, TranscriptCommand> _commandFactory;
        public TranscriptServices(IUserInterface userInterface, Func<string, TranscriptCommand> commandFactory)
        {
            _userInterface = userInterface;
            _commandFactory = commandFactory;
        }
        public void Run()
        {
            Greetings();
            var response = _commandFactory("?").RunCommand();

            while (!response.shouldEnd)
            {
                var input = _userInterface.ReadMessage(">");
                response = _commandFactory(input).RunCommand();

                if (!response.wasSuccessful)
                {
                    _userInterface.WriteWarning("your last command wasn't processed successfully. Please enter \"?\" to view more options. ");
                }
            }
        }

        private void Greetings()
        {
            // get version and display
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            _userInterface.WriteMessage("*********************************************************************************************");
            _userInterface.WriteMessage("*                                                                                           *");
            _userInterface.WriteMessage("*               Welcome to Transcript Reader Application                              *");
            _userInterface.WriteMessage($"*                                                                             v{version}        *");
            _userInterface.WriteMessage("*********************************************************************************************");
            _userInterface.WriteMessage("");
        }
    }
}
