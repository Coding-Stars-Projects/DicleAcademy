using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryInstructors: IRepositoryBase<Instructors>
    {
        IQueryable<Instructors> GetInstructorsh(int id, bool trackchanges);
    }
}
