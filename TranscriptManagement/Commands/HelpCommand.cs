using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.Commands
{
    public class HelpCommand : NonTerminatingCommand
    {
        public HelpCommand(IUserInterface userInterfaceN) : base(userInterfaceN)
        {
        }

        protected override bool InternalCommand()
        {
            Interface.WriteMessage("USAGE:");
            Interface.WriteMessage("\tgettranscript (g)");
            Interface.WriteMessage("\tquit (q)");
            Interface.WriteMessage("\t?");

            Interface.WriteMessage("Examples");
            Interface.WriteMessage("GET TRANSCRIPT");
            

           
            return true;
        }
    }
}
