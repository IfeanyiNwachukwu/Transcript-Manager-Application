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
            Interface.WriteMessage("\tprinttranscript (p)");
            Interface.WriteMessage("\tquit (q)");
            Interface.WriteMessage("\t?");
           
            return true;
        }
    }
}
