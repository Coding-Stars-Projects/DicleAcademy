using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class SkillsService : ISkillsService
	{
		private readonly ApplicationDbContext _context;

		public SkillsService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<SkillsDto> GetAll()
		{
			return _context.Skills.Select(s => new SkillsDto
			{
				SkillId = s.SkillId,
				Title = s.Title,
				Description = s.Description
			}).ToList();
		}

		public SkillsDto GetById(int id)
		{
			var skill = _context.Skills.Find(id);
			return new SkillsDto
			{
				SkillId = skill?.SkillId ?? 0,
				Title = skill?.Title,
				Description = skill?.Description
			};
		}

		public void Add(SkillsDto dto)
		{
			var entity = new Skills
			{
				Title = dto.Title,
				Description = dto.Description
			};

			_context.Skills.Add(entity);
			_context.SaveChanges();
		}

		public void Update(SkillsDto dto)
		{
			var entity = _context.Skills.Find(dto.SkillId);

			if (entity != null)
			{
				entity.Title = dto.Title;
				entity.Description = dto.Description;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.Skills.Find(id);

			if (entity != null)
			{
				_context.Skills.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
