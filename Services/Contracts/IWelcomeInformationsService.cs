using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IWelcomeInformationsService
	{
		List<WelcomeInformationsDto> GetAll();
		WelcomeInformationsDto GetById(int id);
		void Add(WelcomeInformationsDto dto);
		void Update(WelcomeInformationsDto dto);
		void Delete(int id);
	}
}
