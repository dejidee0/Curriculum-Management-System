using CMS.DATA.Context;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.DATA.Repository.Implementation
{
    public class PermissionsRepo : IPermissionsRepo
    {
        private readonly CMSDbContext _context;

        public PermissionsRepo(CMSDbContext context)
        {
            _context = context;
        }
    }
}