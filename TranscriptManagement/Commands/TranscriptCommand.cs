using TranscriptManagement.UserInterfaces;

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
        
    }
}
