using System.Collections.Generic;
using TranscriptManagement.Models;

namespace TranscriptManagement.RepositoryInterfaces
{
    public interface IReadContext
    {
        List<Student> GetAllStudents(string path);
        List<StudentDetail> GetDetailForSTudent(string pathCourses, string pathStudents, string matric);
        List<StudentDetail> GetDetailsForStudentBasedOnSession(string pathCourses, string pathStudents, string matric, int studyLevel);

    }
}
