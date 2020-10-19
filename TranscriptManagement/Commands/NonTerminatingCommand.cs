using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.Commands
{
    public abstract class NonTerminatingCommand : TranscriptCommand
    {
        public NonTerminatingCommand(IUserInterface userInterfaceN):base(userInterface:userInterfaceN,isTerminatingCommand:false)
        {

        }
    }
}
