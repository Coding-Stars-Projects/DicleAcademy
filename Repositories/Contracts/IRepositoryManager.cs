using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager : IRepositoryBase<Manager>
    {
        IRepositoryAboutUs AboutUs { get; }
        IRepositoryBestCourses BestCourses { get; } // yönetim olduğu için set yapamayız 
        IRepositoryContact Contact { get; }
        IRepositoryCourseDetails CourseDetails { get; }
        IRepositoryCourses Courses { get; }
        IRepositoryCoursesCategories CoursesCategories { get; }
        IRepositoryFAQ Faq { get; }
        IRepositoryGallery Gallery { get; }
        IRepositoryGetInTouch GetInTouch { get; }
        IRepositoryInstructors Instructors { get; }
        IRepositorySkills Skills{ get; }
        IRepositoryWelcomeInformations WelcomeInformations { get; }
        void Save(); // unit of work kullanımı 
    }
}
