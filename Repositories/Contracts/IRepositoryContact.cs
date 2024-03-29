﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryContact: IRepositoryBase<Contact>
    {
        IQueryable<Contact> GetContact(int id, bool trackchanges);
        IEnumerable<Contact> GetContact(RequestParameters parameters, bool trackChanges);
    }
}
