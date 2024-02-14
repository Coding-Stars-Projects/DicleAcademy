using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class CoursesCategoriesService : ICoursesCategoriesService
	{
		private readonly ApplicationDbContext _context;

		public CoursesCategoriesService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<CoursesCategoriesDto> GetAll()
		{
			return _context.CoursesCategories.Select(cc => new CoursesCategoriesDto
			{
				CategoryID = cc.CategoryID,
				CategoryName = cc.CategoryName,
				Image = cc.Image,
				CourseId = cc.CourseId
			}).ToList();
		}

		public CoursesCategoriesDto GetById(int id)
		{
			var category = _context.CoursesCategories.Find(id);
			return new CoursesCategoriesDto
			{
				CategoryID = category?.CategoryID ?? 0,
				CategoryName = category?.CategoryName,
				Image = category?.Image,
				CourseId = category?.CourseId ?? 0
			};
		}

		public void Add(CoursesCategoriesDto dto)
		{
			var entity = new CoursesCategories
			{
				CategoryName = dto.CategoryName,
				Image = dto.Image,
				CourseId = dto.CourseId
			};

			_context.CoursesCategories.Add(entity);
			_context.SaveChanges();
		}

		public void Update(CoursesCategoriesDto dto)
		{
			var entity = _context.CoursesCategories.Find(dto.CategoryID);

			if (entity != null)
			{
				entity.CategoryName = dto.CategoryName;
				entity.Image = dto.Image;
				entity.CourseId = dto.CourseId;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.CoursesCategories.Find(id);

			if (entity != null)
			{
				_context.CoursesCategories.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
