using System;
using TranscriptManagerPersistence.Repositories;

namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathLecturer = "LecturerList.txt";
            var db = new ReadContext();
            var lecturers = db.GetAllLecturers(pathLecturer);

            foreach(var lecturer in lecturers)
            {
                Console.WriteLine($"{lecturer.Name}   {lecturer.CourseCode}");
            }
        }
    }
}
