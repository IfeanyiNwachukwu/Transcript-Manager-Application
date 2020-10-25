using System.Collections.Generic;
using System.IO;
using System.Linq;
using TranscriptManagement.Models;
using TranscriptManagement.RepositoryInterfaces;

namespace TranscriptManagerPersistence.Repositories
{
    public class ReadContext : IReadContext
    {

        List<Course> GetAllCourses(string getCourses)
        {
            var query = File.ReadAllLines(getCourses)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var columns = l.Split(',');
                    return new Course()
                    {
                        CourseCode = columns[0],
                        Description = columns[1],
                        Classification = columns[2],
                        Unit = int.Parse(columns[3]),
                        LecturerName = columns[4]

                    };
                });
            return query.ToList();
        }
        public List<Student> GetAllStudents(string path)
        {
            var files = Directory.GetFiles(path, "*.csv");
            var students = new List<Student>();
            Student student = null;
            foreach (var file in files)
            {
                var query = File.ReadAllLines(file)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var columns = l.Split(',');
                    return student = new Student()
                    {

                        MatriculationNumber = columns[2],
                        Name = columns[3],
                    };
                }).ToList();
                students.Add(student);
            }
            return students;
        }

        List<Result> GetAllStudentResult(string path)
        {
            var files = Directory.GetFiles(path, "*.csv");
            var results = new List<Result>();
            var studentsResults = new List<Result>();
            Result studentResult = null;
            foreach (var file in files)
            {
                var queries = File.ReadAllLines(file);

                foreach (var query in queries)
                {
                    var columns = query.Split(',');
                    studentResult = new Result()
                    {
                        CourseCode = columns[0],
                        Score = int.Parse(columns[1]),
                        MatricNumber = columns[2],
                        Name = columns[3],
                        Unit = int.Parse(columns[4])

                    };
                    studentsResults.Add(studentResult);
                }
                    


            }
            return studentsResults;
              
        }

        List<Result> GetAllResultsForAStudent(string path, string matric)
        {
            return GetAllStudentResult(path).Where(s => s.MatricNumber == matric).ToList();
        }

        public List<StudentDetail> GetDetailForSTudent(string pathCourses, string pathStudents, string matric)
        {
            var courses = GetAllCourses(pathCourses);
            var results = GetAllResultsForAStudent(pathStudents, matric);

            var studentDetail = courses.Join(results, c => c.CourseCode, r => r.CourseCode, (c, r) =>
             {
                 return new StudentDetail()
                 {
                     CourseCode = c.CourseCode,
                     Description = c.Description,
                     Classification = c.Classification,
                     LecturerName = c.LecturerName,
                     MatricNumber = r.MatricNumber,
                     Name = r.Name,
                     Unit = r.Unit,
                     Score = r.Score

                 };
             }).ToList();

            return studentDetail;
        }

        public List<StudentDetail> GetDetailsForStudentBasedOnSession(string pathCourses, string pathStudents, string matric, int studyLevel)
        {
            return GetDetailForSTudent(pathCourses, pathStudents, matric).Where(s => s.CourseCode.Substring(3, 1) == studyLevel.ToString()).ToList();
        }




    }
}
