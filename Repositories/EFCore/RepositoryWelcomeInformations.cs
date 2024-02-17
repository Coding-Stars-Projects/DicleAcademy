using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryWelcomeInformations: RepositoryBase<WelcomeInformations>, IRepositoryWelcomeInformations
    {
        public RepositoryWelcomeInformations(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositoryWelcomeInformations> GetWelcomeInformations(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.welcomeInformationsId == id);
    }
}
