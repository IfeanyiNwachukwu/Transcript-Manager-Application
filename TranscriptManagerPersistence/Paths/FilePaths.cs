using TranscriptManagement.RepositoryInterfaces;

namespace TranscriptManagerPersistence.Paths
{
    public class FilePaths : IFilePaths
    {
        public string pathCourses { get ; set; } = "LecturerList.txt";
        public string pathStudent { get; set; } = @"C:\Users\HP\source\repos\Transcript\TranscriptManagerPersistence\Results";
    }
}
