using System;
using System.Linq;
using TranscriptManagement.RepositoryInterfaces;

namespace TranscriptManagement.TranscriptManager
{
    public interface ITranscriptCalculator
    {
        int CalcTotalPointsForSTudent();
        int CalculateTotalUnits();
        decimal CalcCGPA();
        int CalcTotalPointsPerSession();
        int CalculateTotalUnitsPerSession();
        decimal CalcCGPAPerSession();
        int CalcTotalGradePoints(string matric);

    }
    public class TranscriptCalculator : ITranscriptCalculator
    {
        
        //public TranscriptCalculator(IModelContext context)
        //{
        //    _context = context;
        //}
        public decimal CalcCGPA()
        {
            throw new System.NotImplementedException();
        }

        public decimal CalcCGPAPerSession()
        {
            throw new System.NotImplementedException();
        }

        public int CalcTotalGradePoints(string matric)
        {
            throw new NotImplementedException();
        }

        public int CalcTotalPointsForSTudent()
        {
            throw new System.NotImplementedException();
        }

        public int CalcTotalPointsPerSession()
        {
            throw new System.NotImplementedException();
        }

        public int CalculateTotalUnits()
        {
            throw new NotImplementedException();
           
        }

        public int CalculateTotalUnitsPerSession()
        {
            throw new System.NotImplementedException();
        }

        // 70 - 100 (A) 5
        // 60 - 69 (B)  4
        // 50 - 59 (c)  3
        // 46 - 49  (D) 2
        // 40 -  45 (E) 1
        // 0 - 39 (F) 0
    }
}
