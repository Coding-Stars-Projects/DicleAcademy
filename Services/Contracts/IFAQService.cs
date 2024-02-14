using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IFAQService
	{
		List<FAQDto> GetAll();
		FAQDto GetById(int id);
		void Add(FAQDto dto);
		void Update(FAQDto dto);
		void Delete(int id);
	}
}
