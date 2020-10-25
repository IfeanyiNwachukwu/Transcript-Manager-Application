using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.Commands
{
    public class QuitCommand : TranscriptCommand
    {
        public QuitCommand(IUserInterface userInterfaceQ):base(userInterface:userInterfaceQ,isTerminatingCommand:true)
        {

        }
        protected override bool InternalCommand()
        {
            Interface.WriteMessage("Thank you for using the Transcript Manager Application");
            return true;
        }
    }
}
