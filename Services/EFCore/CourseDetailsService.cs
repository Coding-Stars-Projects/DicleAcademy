using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class CourseDetailsService : ICourseDetailsService
	{
		private readonly ApplicationDbContext _context;

		public CourseDetailsService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<CourseDetailsDto> GetAll()
		{
			return _context.CourseDetails.Select(cd => new CourseDetailsDto
			{
				CourseDetailId = cd.CourseDetailId,
				CourseName = cd.CourseName,
				Description = cd.Description,
				CourseLocation = cd.CourseLocation,
				CourseDuration = cd.CourseDuration,
				CourseId = cd.CourseId,
				CategoryID = cd.CategoryID
			}).ToList();
		}

		public CourseDetailsDto GetById(int id)
		{
			var courseDetails = _context.CourseDetails.Find(id);
			return new CourseDetailsDto
			{
				CourseDetailId = courseDetails?.CourseDetailId ?? 0,
				CourseName = courseDetails?.CourseName,
				Description = courseDetails?.Description,
				CourseLocation = courseDetails?.CourseLocation,
				CourseDuration = courseDetails?.CourseDuration ?? 0,
				CourseId = courseDetails?.CourseId ?? 0,
				CategoryID = courseDetails?.CategoryID ?? 0
			};
		}

		public void Add(CourseDetailsDto dto)
		{
			var entity = new CourseDetails
			{
				CourseName = dto.CourseName,
				Description = dto.Description,
				CourseLocation = dto.CourseLocation,
				CourseDuration = dto.CourseDuration,
				CourseId = dto.CourseId,
				CategoryID = dto.CategoryID
			};

			_context.CourseDetails.Add(entity);
			_context.SaveChanges();
		}

		public void Update(CourseDetailsDto dto)
		{
			var entity = _context.CourseDetails.Find(dto.CourseDetailId);

			if (entity != null)
			{
				entity.CourseName = dto.CourseName;
				entity.Description = dto.Description;
				entity.CourseLocation = dto.CourseLocation;
				entity.CourseDuration = dto.CourseDuration;
				entity.CourseId = dto.CourseId;
				entity.CategoryID = dto.CategoryID;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.CourseDetails.Find(id);

			if (entity != null)
			{
				_context.CourseDetails.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
