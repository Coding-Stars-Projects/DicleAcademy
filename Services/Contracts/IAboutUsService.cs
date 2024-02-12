using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IAboutUsService
	{
		List<AboutUsDto> GetAll();
		AboutUsDto GetById(int id);
		void Add(AboutUsDto dto);
		void Update(AboutUsDto dto);
		void Delete(int id);
	}
}
