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
            Interface.WriteMessage("\tget transcript for all sessions (ga)");
            Interface.WriteMessage("\tget transcript for one session (gs) ");
            Interface.WriteMessage("\tquit (q)");
            Interface.WriteMessage("\t?");

            Interface.WriteMessage("Examples");
            Interface.WriteMessage("GET TRANSCRIPT");
            

           
            return true;
        }
    }
}
