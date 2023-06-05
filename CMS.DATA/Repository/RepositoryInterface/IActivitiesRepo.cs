using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IActivitiesRepo
    {
        Task<IEnumerable<Activity>> GetAllActivities();
        Task<bool> DeleteActivityById(string id);
    }
}