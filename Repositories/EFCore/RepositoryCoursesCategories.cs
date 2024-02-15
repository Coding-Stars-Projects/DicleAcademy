using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryCoursesCategories: RepositoryBase<CoursesCategories>, IRepositoryCoursesCategories
    {
        public RepositoryCoursesCategories(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositoryCoursesCategories> GetCoursesCategories(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.coursesCategoriesId == id);

    }
}
