using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface ICourseDetailsService
	{
		List<CourseDetailsDto> GetAll();
		CourseDetailsDto GetById(int id);
		void Add(CourseDetailsDto dto);
		void Update(CourseDetailsDto dto);
		void Delete(int id);
	}
}
