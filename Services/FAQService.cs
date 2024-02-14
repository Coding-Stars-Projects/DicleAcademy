using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class FAQService : IFAQService
	{
		private readonly ApplicationDbContext _context;

		public FAQService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<FAQDto> GetAll()
		{
			return _context.FAQs.Select(faq => new FAQDto
			{
				FAQId = faq.FAQId,
				Question = faq.Question,
				Answer = faq.Answer
			}).ToList();
		}

		public FAQDto GetById(int id)
		{
			var faq = _context.FAQs.Find(id);
			return new FAQDto
			{
				FAQId = faq?.FAQId ?? 0,
				Question = faq?.Question,
				Answer = faq?.Answer
			};
		}

		public void Add(FAQDto dto)
		{
			var entity = new FAQ
			{
				Question = dto.Question,
				Answer = dto.Answer
			};

			_context.FAQs.Add(entity);
			_context.SaveChanges();
		}

		public void Update(FAQDto dto)
		{
			var entity = _context.FAQs.Find(dto.FAQId);

			if (entity != null)
			{
				entity.Question = dto.Question;
				entity.Answer = dto.Answer;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.FAQs.Find(id);

			if (entity != null)
			{
				_context.FAQs.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
