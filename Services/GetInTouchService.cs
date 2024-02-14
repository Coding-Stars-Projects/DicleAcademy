using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class GetInTouchService : IGetInTouchService
	{
		private readonly ApplicationDbContext _context;

		public GetInTouchService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<GetInTouchDto> GetAll()
		{
			return _context.GetInTouchItems.Select(git => new GetInTouchDto
			{
				GetInTouchId = git.GetInTouchId,
				Title = git.Title,
				Description = git.Description
			}).ToList();
		}

		public GetInTouchDto GetById(int id)
		{
			var getInTouchItem = _context.GetInTouchItems.Find(id);
			return new GetInTouchDto
			{
				GetInTouchId = getInTouchItem?.GetInTouchId ?? 0,
				Title = getInTouchItem?.Title,
				Description = getInTouchItem?.Description
			};
		}

		public void Add(GetInTouchDto dto)
		{
			var entity = new GetInTouch
			{
				Title = dto.Title,
				Description = dto.Description
			};

			_context.GetInTouchItems.Add(entity);
			_context.SaveChanges();
		}

		public void Update(GetInTouchDto dto)
		{
			var entity = _context.GetInTouchItems.Find(dto.GetInTouchId);

			if (entity != null)
			{
				entity.Title = dto.Title;
				entity.Description = dto.Description;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.GetInTouchItems.Find(id);

			if (entity != null)
			{
				_context.GetInTouchItems.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
