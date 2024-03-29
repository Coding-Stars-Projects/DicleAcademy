﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryFAQ : IRepositoryBase<FAQ>
    {
        IQueryable<FAQ> GetFAQ(int id, bool trackchanges);
        IEnumerable<FAQ> GetFAQs(RequestParameters parameters, bool trackChanges);
    }
}
