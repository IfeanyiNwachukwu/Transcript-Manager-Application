using System;
using TranscriptManagement.TranscriptManager;
using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.Commands
{
    public class GetTranscriptForAllSessionCommand : NonTerminatingCommand, IParameterisedCommand
    {
        public string MatricNumber { get; set; }
       
        readonly ITranscriptDesigner _transcriptDesigner;
        public GetTranscriptForAllSessionCommand(IUserInterface userInterfaceN,ITranscriptDesigner transcriptDesigner) : base(userInterfaceN)
        {
            _transcriptDesigner = transcriptDesigner;
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
            return  _transcriptDesigner.DisplayTranscriptForAllSessions(MatricNumber);
        }
    }
}
