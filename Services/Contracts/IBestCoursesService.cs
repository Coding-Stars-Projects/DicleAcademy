using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IBestCoursesService
	{
		List<BestCoursesDto> GetAll();
		BestCoursesDto GetById(int id);
		void Add(BestCoursesDto dto);
		void Update(BestCoursesDto dto);
		void Delete(int id);
	}

}
