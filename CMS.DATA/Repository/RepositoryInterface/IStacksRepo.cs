
using CMS.DATA.DTO;
using CMS.DATA.Entities;


namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IStacksRepo
    {
        Task<Stack> GetStackAsync(string stackid);
        Task<IEnumerable<Stack>> GetStacks();
        Task<List<UserDto>> GetUsersByStack(string stackId);
        Task<bool> DeleteStack(string stackId);
    }
}