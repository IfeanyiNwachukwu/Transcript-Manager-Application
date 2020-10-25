using System;
using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.Commands
{
    public class GetTranscriptCommand : NonTerminatingCommand, IParameterisedCommand
    {
        public string MatricNumber { get; set; }
        public GetTranscriptCommand(IUserInterface userInterfaceN) : base(userInterfaceN)
        {
        }

        public bool GetParameter()
        {
            if (string.IsNullOrWhiteSpace(MatricNumber))
            {
                MatricNumber = GetParameter("matric number");
            }
            return !string.IsNullOrWhiteSpace(MatricNumber);
        }

        protected override bool InternalCommand()
        {
            throw new NotImplementedException();
        }
    }
}
