using Entities.ModelsDto;

namespace Service.Contracts
{
	public interface IGalleryService
	{
		List<GalleryDto> GetAll();
		GalleryDto GetById(string id);
		void Add(GalleryDto dto);
		void Update(GalleryDto dto);
		void Delete(string id);
	}
}
