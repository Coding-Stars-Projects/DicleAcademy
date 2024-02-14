using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class BestCoursesService : IBestCoursesService
	{
		private readonly ApplicationDbContext _context;

		public BestCoursesService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<BestCoursesDto> GetAll()
		{
			return _context.BestCourses.Select(c => new BestCoursesDto
			{
				BestCourseId = c.BestCourseId,
				CourseName = c.CourseName,
				CourseId = c.CourseId
			}).ToList();
		}

		public BestCoursesDto GetById(int id)
		{
			var course = _context.BestCourses.Find(id);
			return new BestCoursesDto
			{
				BestCourseId = course?.BestCourseId ?? 0,
				CourseName = course?.CourseName,
				CourseId = course?.CourseId ?? 0
			};
		}

		public void Add(BestCoursesDto dto)
		{
			var entity = new BestCourses
			{
				CourseName = dto.CourseName,
				CourseId = dto.CourseId
			};

			_context.BestCourses.Add(entity);
			_context.SaveChanges();
		}

		public void Update(BestCoursesDto dto)
		{
			var entity = _context.BestCourses.Find(dto.BestCourseId);

			if (entity != null)
			{
				entity.CourseName = dto.CourseName;
				entity.CourseId = dto.CourseId;

				_context.SaveChanges();
			}
		}


		public void Delete(int id)
		{
			var entity = _context.BestCourses.Find(id);

			if (entity != null)
			{
				_context.BestCourses.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
