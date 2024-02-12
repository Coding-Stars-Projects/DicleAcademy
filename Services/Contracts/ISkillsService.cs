using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface ISkillsService
	{
		List<SkillsDto> GetAll();
		SkillsDto GetById(int id);
		void Add(SkillsDto dto);
		void Update(SkillsDto dto);
		void Delete(int id);
	}
}
