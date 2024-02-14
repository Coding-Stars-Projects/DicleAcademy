using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface ICoursesCategoriesService
	{
		List<CoursesCategoriesDto> GetAll();
		CoursesCategoriesDto GetById(int id);
		void Add(CoursesCategoriesDto dto);
		void Update(CoursesCategoriesDto dto);
		void Delete(int id);
	}
}
