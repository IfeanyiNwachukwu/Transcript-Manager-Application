using System;
using TranscriptManagement.TranscriptManager;
using TranscriptManagement.UserInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TranscriptManagement.Commands
{
    public abstract class TranscriptCommand
    {
        public IUserInterface Interface { get; set; }
        protected readonly bool _isterminatingCommand;
        public TranscriptCommand(IUserInterface userInterface, bool isTerminatingCommand)
        {
            Interface = userInterface;
            _isterminatingCommand = isTerminatingCommand;
        }

        public (bool shouldEnd, bool wasSuccessful) RunCommand()
        {
            if(this is IParameterisedCommand parameterisedCommand)
            {
                var fieldsCompleted = false;
                while(fieldsCompleted == false)
                {
                    fieldsCompleted = parameterisedCommand.GetParameter();
                }
            }
            return (_isterminatingCommand, InternalCommand());
        }

        protected string GetParameter(string parameterName)
        {
            var input = Interface.ReadMessage($"Please enter {parameterName}");
            return input;
        }
        protected abstract bool InternalCommand();


        public static Func<IServiceProvider, Func<string, TranscriptCommand>> GetTranscriptCommand => provider => input =>
        {
            switch (input.ToLower())
            {
                case "q":
                case "quit":
                    return new QuitCommand(provider.GetService<IUserInterface>());
                case "ga":
                case "gettranscriptforallsessioncommand":
                    return new GetTranscriptForAllSessionCommand(provider.GetService<IUserInterface>(), provider.GetService<ITranscriptDesigner>());
                case "gs":
                case "gettranscriptforasession":
                    return new GetTranscriptForASession(provider.GetService<IUserInterface>(), provider.GetService<ITranscriptDesigner>());
                case "?":
                    return new HelpCommand(provider.GetService<IUserInterface>());
                default:
                    return new UnknownCommand(provider.GetService<IUserInterface>());
            }
        };

    }
}
