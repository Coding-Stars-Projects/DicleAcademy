using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryInstructors : RepositoryBase<Instructors>, IRepositoryInstructors
    {
        public RepositoryInstructors(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositoryInstructors> GetInstructors(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.ınstructorsId == id);
    }
}
