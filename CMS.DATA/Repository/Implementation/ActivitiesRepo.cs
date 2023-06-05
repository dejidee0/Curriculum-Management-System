using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace CMS.DATA.Repository.Implementation
{
    public class ActivitiesRepo : IActivitiesRepo
    {
        private readonly CMSDbContext _context;

        public ActivitiesRepo(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetAllActivities()
        {
            return await _context.Activities.ToListAsync();

        } 

        public async Task<bool> DeleteActivityById(string id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);
            if (activity == null)
            {
                throw new Exception("Activity with the id not found");
            }
            _context.Activities.Remove(activity);
           var result= await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}