using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryCourses: RepositoryBase<Courses>, IRepositoryCourses
    {
        public RepositoryCourses(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositoryCourses> GetCourses(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.coursesId == id);

    }
}
