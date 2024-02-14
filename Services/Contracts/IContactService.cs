using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IContactService
	{
		List<ContactDto> GetAll();
		ContactDto GetById(int id);
		void Add(ContactDto dto);
		void Update(ContactDto dto);
		void Delete(int id);
	}
}
