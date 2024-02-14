using Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    {
        IQueryable<AboutUs> GetAboutUs(int id, bool trackchanges);
    }
}
