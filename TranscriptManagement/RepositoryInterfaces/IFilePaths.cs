using System;
using System.Collections.Generic;
using System.Text;

namespace TranscriptManagement.RepositoryInterfaces
{
    public interface IFilePaths
    {
        string pathCourses { get; set; }
        string pathStudent { get; set; }
    }
}
