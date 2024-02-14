using Entities.Models;
using Entities.ModelsDto;
using Service.Contracts;

namespace Service
{
	public class ContactService : IContactService
	{
		private readonly ApplicationDbContext _context;

		public ContactService(ApplicationDbContext context)
		{
			_context = context;
		}

		public List<ContactDto> GetAll()
		{
			return _context.Contacts.Select(c => new ContactDto
			{
				ContactId = c.ContactId,
				Name = c.Name,
				Surname = c.Surname,
				Email = c.Email,
				Description = c.Description,
				CourseId = c.CourseId
			}).ToList();
		}

		public ContactDto GetById(int id)
		{
			var contact = _context.Contacts.Find(id);
			return new ContactDto
			{
				ContactId = contact?.ContactId ?? 0,
				Name = contact?.Name,
				Surname = contact?.Surname,
				Email = contact?.Email,
				Description = contact?.Description,
				CourseId = contact?.CourseId ?? 0
			};
		}

		public void Add(ContactDto dto)
		{
			var entity = new Contact
			{
				Name = dto.Name,
				Surname = dto.Surname,
				Email = dto.Email,
				Description = dto.Description,
				CourseId = dto.CourseId
			};

			_context.Contacts.Add(entity);
			_context.SaveChanges();
		}

		public void Update(ContactDto dto)
		{
			var entity = _context.Contacts.Find(dto.ContactId);

			if (entity != null)
			{
				entity.Name = dto.Name;
				entity.Surname = dto.Surname;
				entity.Email = dto.Email;
				entity.Description = dto.Description;
				entity.CourseId = dto.CourseId;

				_context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			var entity = _context.Contacts.Find(id);

			if (entity != null)
			{
				_context.Contacts.Remove(entity);
				_context.SaveChanges();
			}
		}
	}
}
