﻿using Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryAboutUs: IRepositoryBase<AboutUs>
    {
        IQueryable<AboutUs> GetAboutUs(int id, bool trackchanges);
        IEnumerable<AboutUs> GetAboutUs(RequestParameters parameters, bool trackChanges);
    }
}
