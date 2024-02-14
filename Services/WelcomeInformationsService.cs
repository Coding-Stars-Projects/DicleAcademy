using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class WelcomeInformationsService : IWelcomeInformationsService
	{
		private readonly ApplicationDbContext _context;

		public WelcomeInformationsService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<WelcomeInformationsDto> GetAll()
		{
			return _context.WelcomeInformations.Select(w => new WelcomeInformationsDto
			{
				WelcomeInformationId = w.WelcomeInformationId,
				Title = w.Title,
				Description = w.Description
			}).ToList();
		}

		public WelcomeInformationsDto GetById(int id)
		{
			var welcomeInformation = _context.WelcomeInformations.Find(id);
			return new WelcomeInformationsDto
			{
				WelcomeInformationId = welcomeInformation?.WelcomeInformationId ?? 0,
				Title = welcomeInformation?.Title,
				Description = welcomeInformation?.Description
			};
		}

		public void Add(WelcomeInformationsDto dto)
		{
			var entity = new WelcomeInformations
			{
				Title = dto.Title,
				Description = dto.Description
			};

			_context.WelcomeInformations.Add(entity);
			_context.SaveChanges();
		}

		public void Update(WelcomeInformationsDto dto)
		{
			var entity = _context.WelcomeInformations.Find(dto.WelcomeInformationId);

			if (entity != null)
			{
				entity.Title = dto.Title;
				entity.Description = dto.Description;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.WelcomeInformations.Find(id);

			if (entity != null)
			{
				_context.WelcomeInformations.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
