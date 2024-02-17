using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositorySkills: RepositoryBase<Skills>, IRepositorySkills
    {
        public RepositorySkills(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositorySkills> GetSkills(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.SkillsId == id);
    }
}
