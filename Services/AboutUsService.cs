using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class AboutUsService : IAboutUsService
	{
		private readonly ApplicationDbContext _context;

		public AboutUsService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<AboutUsDto> GetAll()
		{
			return _context.AboutUs.Select(a => new AboutUsDto
			{
				AboutUsId = a.AboutUsId,
				Title = a.Title,
				Description = a.Description,
				Image = a.Image
			}).ToList();
		}

		public AboutUsDto GetById(int id)
		{
			var aboutUs = _context.AboutUs.Find(id);
			return new AboutUsDto
			{
				AboutUsId = aboutUs?.AboutUsId ?? 0,
				Title = aboutUs?.Title,
				Description = aboutUs?.Description,
				Image = aboutUs?.Image
			};
		}

		public void Add(AboutUsDto dto)
		{
			var entity = new AboutUs
			{
				Title = dto.Title,
				Description = dto.Description,
				Image = dto.Image
			};

			_context.AboutUs.Add(entity);
			_context.SaveChanges();
		}

		public void Update(AboutUsDto dto)
		{
			var entity = _context.AboutUs.Find(dto.AboutUsId);

			if (entity != null)
			{
				entity.Title = dto.Title;
				entity.Description = dto.Description;
				entity.Image = dto.Image;

				_context.SaveChanges();
			}
		}


		public void Delete(int id)
		{
			var entity = _context.AboutUs.Find(id);

			if (entity != null)
			{
				_context.AboutUs.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}