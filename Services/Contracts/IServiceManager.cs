using System;
using Service.Contracts;

namespace Services.Abstract
{
	public interface IServiceManager
	{
		IAboutUsService AboutUsService { get; }
		IBestCoursesService BestCoursesService { get; }
		IContactService ContactService { get; }
		ICourseDetailsService CourseDetailsService { get; }
		ICoursesCategoriesService CoursesCategoriesService { get; }
		ICoursesService CoursesService { get; }
		IFAQService FAQService { get; }
		IGalleryService GalleryService { get; }
		IGetInTouchService GetInTouchService { get; }
		IInstructorsService InstructorsService { get; }
		ISkillsService SkillsService { get; }
		IWelcomeInformationsService WelcomeInformationsService { get; }
		IUserService UserService { get; }
	}
}

