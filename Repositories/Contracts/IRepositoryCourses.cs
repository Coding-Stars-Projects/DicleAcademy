using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryCourses : IRepositoryBase<Courses>
    {
        IQueryable<Courses> GetCoursest(int id, bool trackchanges);
    }
}
