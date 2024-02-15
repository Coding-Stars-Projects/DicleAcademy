using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryCourseDatails : RepositoryBase<CourseDetails>, IRepositoryCourseDetails
    {
        public RepositoryCourseDetails(RepositoryContext context) : base(context)
        {

        }

        public IQueryable<IRepositoryCourseDetails> GetCourseDetails(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.courseDetailsId == id);

    }
}
