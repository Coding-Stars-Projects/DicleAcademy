using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBestCourses: IRepositoryBase<BestCourses>

    {
        IQueryable<BestCourses> GetBestCourses(int id, bool trackchanges);
        IEnumerable<BestCourses> GetBestCourses(RequestParameters parameters, bool trackChanges);
    }
}
