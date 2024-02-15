using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryContact : RepositoryBase<Contact>, IRepositoryContact
    {
        public RepositoryBestCourses(RepositoryContext context) : base(context)
        {

        }

        public IQueryable<Contact> GetContact(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.contactId == id);

    }
}
