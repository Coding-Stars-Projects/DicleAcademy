using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class GalleryService : IGalleryService
	{
		private readonly ApplicationDbContext _context;

		public GalleryService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<GalleryDto> GetAll()
		{
			return _context.Galleries.Select(g => new GalleryDto
			{
				GalleryId = g.GalleryId,
				Image = g.Image
			}).ToList();
		}

		public GalleryDto GetById(string id)
		{
			var galleryItem = _context.Galleries.Find(id);
			return new GalleryDto
			{
				GalleryId = galleryItem?.GalleryId,
				Image = galleryItem?.Image
			};
		}

		public void Add(GalleryDto dto)
		{
			var entity = new Gallery
			{
				GalleryId = dto.GalleryId,
				Image = dto.Image
			};

			_context.Galleries.Add(entity);
			_context.SaveChanges();
		}

		public void Update(GalleryDto dto)
		{
			var entity = _context.Galleries.Find(dto.GalleryId);

			if (entity != null)
			{
				entity.Image = dto.Image;
				_context.SaveChanges();
			}
		}

		public void Delete(string id)
		{
			var entity = _context.Galleries.Find(id);

			if (entity != null)
			{
				_context.Galleries.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
