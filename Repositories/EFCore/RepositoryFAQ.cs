using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryFAQ : RepositoryBase<FAQ>, IRepositoryFAQ
    {
        public RepositoryFAQ(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositoryFAQ> GetFAQ(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.faqId == id);
    }
}
