using TranscriptManagement.TranscriptManager;
using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.Commands
{
    public class GetTranscriptForASession : NonTerminatingCommand, IParameterisedCommand
    {
        public string MatricNumber { get; set; }
        private int _studyLevel;

        public int StudyLevel
        {
            get { return _studyLevel; }
            set { _studyLevel = value; }
        }

        readonly ITranscriptDesigner _transcriptDesigner;
        public GetTranscriptForASession(IUserInterface userInterfaceN, ITranscriptDesigner transcriptDesigner) : base(userInterfaceN)
        {
            _transcriptDesigner = transcriptDesigner;
        }

        public bool GetParameter()
        {
            if (string.IsNullOrWhiteSpace(MatricNumber))
            {
                MatricNumber = GetParameter("matriculation number");
            }
            if (StudyLevel == 0)
            {
                int.TryParse(GetParameter("study level"), out _studyLevel);
            }

            return !string.IsNullOrWhiteSpace(MatricNumber) && _studyLevel > 0;
        }

        protected override bool InternalCommand()
        {
            return _transcriptDesigner.DisplayTranscriptForASession(MatricNumber, StudyLevel);
        }
    }
}
