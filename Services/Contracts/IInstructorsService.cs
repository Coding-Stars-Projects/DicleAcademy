using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IInstructorsService
	{
		List<InstructorsDto> GetAll();
		InstructorsDto GetById(int id);
		void Add(InstructorsDto dto);
		void Update(InstructorsDto dto);
		void Delete(int id);
	}
}
