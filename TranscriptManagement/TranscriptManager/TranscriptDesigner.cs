using System;
using TranscriptManagement.RepositoryInterfaces;
using TranscriptManagement.UserInterfaces;

namespace TranscriptManagement.TranscriptManager
{
    public interface ITranscriptDesigner
    {
        bool DisplayTranscriptForASession(string matric, int studyLevel);
        bool DisplayTranscriptForAllSessions(string matric);
    }
    public class TranscriptDesigner : ITranscriptDesigner
    {
        readonly IModelCOntext _context;
        readonly ITranscriptCalculator _transcriptCalculator;
        readonly IFilePaths _filePaths;
        IUserInterface _userInterface { get; set; }
        public TranscriptDesigner(IModelCOntext modelCOntext, ITranscriptCalculator transcriptCalculator, IUserInterface userInterface, IFilePaths filePaths)
        {
            _context = modelCOntext;
            _transcriptCalculator = transcriptCalculator;
            _userInterface = userInterface;
            _filePaths = filePaths;
        }

        public bool DisplayTranscriptForASession(string matric, int studyLevel)
        {
            var student = _context.GetStudent(matric, _filePaths.pathStudent);
            var studentDetail = _context.GetDetailsForStudentBasedOnSession(_filePaths.pathCourses, _filePaths.pathStudent, matric, studyLevel);
            var CGPA = _transcriptCalculator.CalcCGPAPerSession(matric, studyLevel);
            var totalGradePoints = _transcriptCalculator.CalcTotalPointsPerSession(matric, studyLevel);
            var totalUnits = _transcriptCalculator.CalculateTotalUnitsPerSession(matric, studyLevel);
            var totalScore = _transcriptCalculator.CalcTotalScorePerSession(matric, studyLevel);

            _userInterface.WriteMessage($"\tNAME:                                        {student.Name}");
            _userInterface.WriteMessage($"\tDEPT:                                        Computer Science");
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|       Course Code       |                       Title                            |      Units       |    Grade Score    |    Grade Points     |");
            foreach(var detail in studentDetail)
            {
                int gradepoint = CalcGradePoint(detail);

            _userInterface.WriteMessage($"| {detail.CourseCode}     |   {detail.Description}                                 |  {detail.Unit}   |  {detail.Score}    |    {gradepoint}     |");

            }
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                              TOTAL                                                |   {totalUnits}  |       {totalScore} |{totalGradePoints}  |");
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                              CGPA                                                      {CGPA}                                                 |");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");

            return true;
        }
        public bool DisplayTranscriptForAllSessions(string matric)
        {
            var student = _context.GetStudent(matric, _filePaths.pathStudent);
            var studentDetail = _context.GetDetailForSTudent(_filePaths.pathCourses, _filePaths.pathStudent, matric);
            var CGPA = _transcriptCalculator.CalcCGPAForAllSessions(matric);
            var totalGradePoints = _transcriptCalculator.CalcTotalPointsforAllSessions(matric);
            var totalUnits = _transcriptCalculator.CalculateTotalUnitsForAllSessions(matric);
            var totalScore = _transcriptCalculator.CalcTotalScoreForAllSessions(matric);

            _userInterface.WriteMessage($"\tNAME:                                        {student.Name}");
            _userInterface.WriteMessage($"\tDEPT:                                        Computer Science");
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|       Course Code       |                       Title                            |      Units       |    Grade Score    |    Grade Points     |");
            foreach (var detail in studentDetail)
            {
                int gradepoint = CalcGradePoint(detail);

                _userInterface.WriteMessage($"| {detail.CourseCode}     |   {detail.Description}                                 |  {detail.Unit}   |  {detail.Score}    |    {gradepoint}     |");

            }
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                              TOTAL                                                |   {totalUnits}  |       {totalScore} |{totalGradePoints}  |");
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"|                              CGPA                                                      {CGPA}                                                 |");
            _userInterface.WriteMessage($"|                                                                                                                                               |");
            _userInterface.WriteMessage($"________________________________________________________________________________________________________________________________________________");

            return true;

        }

        private static int CalcGradePoint(Models.StudentDetail detail)
        {
            int gradepoint = 0;
            if (detail.Score > 39 && detail.Score <= 44)
            {
                gradepoint = Convert.ToInt32(Grading.WeakPass) * detail.Unit;
            }
            else if (detail.Score > 44 && detail.Score <= 49)
            {
                gradepoint = Convert.ToInt32(Grading.Pass) * detail.Unit;
            }
            else if (detail.Score > 49 && detail.Score <= 59)
            {
                gradepoint = Convert.ToInt32(Grading.Credit) * detail.Unit;
            }
            else if (detail.Score > 59 && detail.Score <= 69)
            {
                gradepoint = Convert.ToInt32(Grading.VeryGood) * detail.Unit;
            }
            else if (detail.Score > 69 && detail.Score <= 99)
            {
                gradepoint = Convert.ToInt32(Grading.Distinction) * detail.Unit;
            }
            else
            {
                gradepoint = Convert.ToInt32(Grading.Fail) * detail.Unit;
            }

            return gradepoint;
        }

      
    }
}
