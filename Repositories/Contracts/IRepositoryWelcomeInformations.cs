﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryWelcomeInformations : IRepositoryBase<WelcomeInformations>
    {
        IQueryable<WelcomeInformations> GetWelcomeInformations(int id, bool trackchanges);
        IEnumerable<WelcomeInformations> GetWelcomeInformations(RequestParameters parameters, bool trackChanges);
    }
}
