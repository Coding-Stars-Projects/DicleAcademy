using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryGetInTouch :RepositoryBase<GetInTouch>, IRepositoryGetInTouch
    {
        public RepositoryGetInTouch(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositoryGetInTouch> GetGetInTouch(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.getInTouchId == id);
    }
}
}
