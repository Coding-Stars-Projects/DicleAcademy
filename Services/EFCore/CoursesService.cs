using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class CoursesService : ICoursesService
	{
		private readonly ApplicationDbContext _context;

		public CoursesService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<CoursesDto> GetAll()
		{
			return _context.Courses.Select(c => new CoursesDto
			{
				CourseId = c.CourseId,
				CourseName = c.CourseName,
				Image = c.Image
			}).ToList();
		}

		public CoursesDto GetById(int id)
		{
			var course = _context.Courses.Find(id);
			return new CoursesDto
			{
				CourseId = course?.CourseId ?? 0,
				CourseName = course?.CourseName,
				Image = course?.Image
			};
		}

		public void Add(CoursesDto dto)
		{
			var entity = new Courses
			{
				CourseName = dto.CourseName,
				Image = dto.Image
			};

			_context.Courses.Add(entity);
			_context.SaveChanges();
		}

		public void Update(CoursesDto dto)
		{
			var entity = _context.Courses.Find(dto.CourseId);

			if (entity != null)
			{
				entity.CourseName = dto.CourseName;
				entity.Image = dto.Image;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.Courses.Find(id);

			if (entity != null)
			{
				_context.Courses.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
