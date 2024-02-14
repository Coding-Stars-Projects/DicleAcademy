using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IGetInTouchService
	{
		List<GetInTouchDto> GetAll();
		GetInTouchDto GetById(int id);
		void Add(GetInTouchDto dto);
		void Update(GetInTouchDto dto);
		void Delete(int id);
	}
}
