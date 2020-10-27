using System;
using System.Collections.Generic;
using System.Linq;
using TranscriptManagement.Models;
using TranscriptManagement.RepositoryInterfaces;

namespace TranscriptManagement.TranscriptManager
{
    public interface ITranscriptCalculator
    {
        decimal CalcCGPAPerSession(string matricNumber, int studyLevel);
        decimal CalcCGPAForAllSessions(string matricNumber);
        int CalculateTotalUnitsPerSession(string matricNumber, int studyLevel);
        int CalcTotalPointsPerSession(string matricNumber, int studyLevel);
        int CalculateTotalUnitsForAllSessions(string matricNumber);
        int CalcTotalPointsforAllSessions(string matricNumber);
        int CalcTotalScorePerSession(string matricNumber, int studyLevel);
        int CalcTotalScoreForAllSessions(string matricNumber);

    }
    public class TranscriptCalculator : ITranscriptCalculator
    {
        readonly IModelCOntext _context;
        readonly IFilePaths _filePath;
        public TranscriptCalculator(IModelCOntext modelCOntext, IFilePaths filePaths)
        {
            _context = modelCOntext;
            _filePath = filePaths;
        }


        public decimal CalcCGPAPerSession(string matricNumber, int studyLevel)
        {
            var totalPoints = CalcTotalPointsPerSession(matricNumber, studyLevel);
            var totalUnits = CalculateTotalUnitsPerSession(matricNumber, studyLevel);
            decimal CGPA = totalPoints / totalUnits;
            return CGPA;
        }
        public decimal CalcCGPAForAllSessions(string matricNumber)
        {
            var totalPoints = CalcTotalPointsforAllSessions(matricNumber);
            var totalUnits = CalculateTotalUnitsForAllSessions(matricNumber);
            decimal CGPA = totalPoints / totalUnits;
            return CGPA;
        }

        public int CalcTotalPointsPerSession(string matricNumber, int studyLevel)
        {
            var results = _context.GetDetailsForStudentBasedOnSession(pathCourses: _filePath.pathCourses, pathStudents: _filePath.pathStudent, matric: matricNumber, studyLevel: studyLevel);
            var totalPoints = CalculatePoints(results);
            return totalPoints;
        }



        public int CalculateTotalUnitsPerSession(string matricNumber, int studyLevel)
        {
            return _context.GetDetailsForStudentBasedOnSession(pathCourses: _filePath.pathCourses, pathStudents: _filePath.pathStudent, matric: matricNumber, studyLevel: studyLevel).Sum(c => c.Unit);
        }
        public int CalculateTotalUnitsForAllSessions(string matricNumber)
        {
            return _context.GetDetailForSTudent(pathCourses: _filePath.pathCourses, pathStudents: _filePath.pathStudent, matric: matricNumber).Sum(c => c.Unit);
        }

        public int CalcTotalPointsforAllSessions(string matricNumber)
        {
            var results = _context.GetDetailForSTudent(pathCourses: _filePath.pathCourses, pathStudents: _filePath.pathStudent, matric: matricNumber);
            var totalPoints = CalculatePoints(results);
            return totalPoints;
        }

        private static int CalculatePoints(List<StudentDetail> results)
        {
            int gradePoints = 0;
            foreach (var result in results)
            {
                int point;
                if (result.Score > 39 && result.Score <= 44)
                {
                    point = Convert.ToInt32(Grading.WeakPass) * result.Unit;
                }
                else if (result.Score > 44 && result.Score <= 49)
                {
                    point = Convert.ToInt32(Grading.Pass) * result.Unit;
                }
                else if (result.Score > 49 && result.Score <= 59)
                {
                    point = Convert.ToInt32(Grading.Credit) * result.Unit;
                }
                else if (result.Score > 59 && result.Score <= 69)
                {
                    point = Convert.ToInt32(Grading.VeryGood) * result.Unit;
                }
                else if (result.Score > 69 && result.Score <= 99)
                {
                    point = Convert.ToInt32(Grading.Distinction) * result.Unit;
                }
                else
                {
                    point = Convert.ToInt32(Grading.Fail) * result.Unit;
                }
                gradePoints += point;
            }
            return gradePoints;
        }

        public int CalcTotalScorePerSession(string matricNumber, int studyLevel)
        {
            return _context.GetDetailsForStudentBasedOnSession(pathCourses: _filePath.pathCourses, pathStudents: _filePath.pathStudent, matric: matricNumber, studyLevel: studyLevel).Sum(c => c.Score);
        }

        public int CalcTotalScoreForAllSessions(string matricNumber)
        {
            return _context.GetDetailForSTudent(pathCourses: _filePath.pathCourses, pathStudents: _filePath.pathStudent, matric: matricNumber).Sum(c => c.Score);
        }

        // 70 - 100 (A) 5
        // 60 - 69 (B)  4
        // 50 - 59 (c)  3
        // 46 - 49  (D) 2
        // 40 -  45 (E) 1
        // 0 - 39 (F) 0
    }
    public enum Grading
    {
        Fail,
        WeakPass,
        Pass,
        Credit,
        VeryGood,
        Distinction
    }

}
