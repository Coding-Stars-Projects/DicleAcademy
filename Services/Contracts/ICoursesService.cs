using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface ICoursesService
	{
		List<CoursesDto> GetAll();
		CoursesDto GetById(int id);
		void Add(CoursesDto dto);
		void Update(CoursesDto dto);
		void Delete(int id);
	}
}
