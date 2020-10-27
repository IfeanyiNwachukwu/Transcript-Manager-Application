using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.Commands
{
    public class UnknownCommand : NonTerminatingCommand
    {
        public UnknownCommand(IUserInterface userInterfaceN) : base(userInterfaceN)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage("You have entered an unknown command. Please enter '?' to view available options. ");
            return false;
        }
    }
}
