using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryGallery: RepositoryBase<Gallery>, IRepositoryGallery
    {
        public RepositoryGallery(RepositoryContext context) : base(context)
        {

        }
        public IQueryable<IRepositoryGallery> GetGallery(int id, bool trackchanges)

                => GenericReadExpression(trackchanges, x => x.galleryId == id);
    }
}
