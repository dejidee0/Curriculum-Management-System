using CMS.API.Models;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IActivitiesService
    {
        Task<ResponseDto<IEnumerable<Activity>>> GetAllActivitiesAsync();
        Task<ResponseDto<bool>> DeleteActivityAsync(string id);

    }
}