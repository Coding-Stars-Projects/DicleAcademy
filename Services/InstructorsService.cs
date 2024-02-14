using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class InstructorsService : IInstructorsService
	{
		private readonly ApplicationDbContext _context;

		public InstructorsService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<InstructorsDto> GetAll()
		{
			return _context.Instructors.Select(i => new InstructorsDto
			{
				InstructorId = i.InstructorId,
				Name = i.Name,
				Description = i.Description,
				AreaOfExpertise = i.AreaOfExpertise
			}).ToList();
		}

		public InstructorsDto GetById(int id)
		{
			var instructor = _context.Instructors.Find(id);
			return new InstructorsDto
			{
				InstructorId = instructor?.InstructorId ?? 0,
				Name = instructor?.Name,
				Description = instructor?.Description,
				AreaOfExpertise = instructor?.AreaOfExpertise
			};
		}

		public void Add(InstructorsDto dto)
		{
			var entity = new Instructors
			{
				Name = dto.Name,
				Description = dto.Description,
				AreaOfExpertise = dto.AreaOfExpertise
			};

			_context.Instructors.Add(entity);
			_context.SaveChanges();
		}

		public void Update(InstructorsDto dto)
		{
			var entity = _context.Instructors.Find(dto.InstructorId);

			if (entity != null)
			{
				entity.Name = dto.Name;
				entity.Description = dto.Description;
				entity.AreaOfExpertise = dto.AreaOfExpertise;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.Instructors.Find(id);

			if (entity != null)
			{
				_context.Instructors.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
