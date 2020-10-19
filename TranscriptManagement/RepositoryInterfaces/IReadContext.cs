using System.Collections.Generic;
using TranscriptManagement.Models;

namespace TranscriptManagement.RepositoryInterfaces
{
    public interface IReadContext
    {
        List<Student> GetAllStudents(string path);
        Student GetStudent(string path, string matric);
        List<Lecturer> GetAllLecturers(string path);
        Lecturer GetLecturer(string path,string courseCode);

        List<Course> GetAllCourses(string path);
        List<Course> GetCoursesByLevel(string path, string level);
        Course GetCourse(string path, string courseCode);
        PerformanceScores StudentResult(string path, string matric);

        


    }
}
