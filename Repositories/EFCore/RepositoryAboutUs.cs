using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryAboutUs : RepositoryBase<AboutUs>, IRepositoryAboutUs
    {
        public RepositoryAboutUs(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<Agent> GetAgent(int id, bool trackChanges)
            => GenericReadExpression(trackChanges, x => x.agtId == id);
    }
}
