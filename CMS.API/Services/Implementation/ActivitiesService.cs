using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IActivitiesRepo _activitiesRepo;

        public ActivitiesService(IActivitiesRepo activitiesRepo)
        {
            _activitiesRepo = activitiesRepo;
        }

        public async Task<ResponseDto<IEnumerable<Activity>>> GetAllActivitiesAsync()
        {
            var response = new ResponseDto<IEnumerable<Activity>>();
            try
            {
                var result = await _activitiesRepo.GetAllActivities();
                if (result.Any())
                {
                    response.Result = result;
                    response.DisplayMessage = "Successfull";
                    response.StatusCode = StatusCodes.Status200OK;
                    return response;
                }
                response.DisplayMessage = "No activity available";
                response.StatusCode = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                response.DisplayMessage = ex.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
                return response;
            }
                
        }

        public async Task<ResponseDto<bool>> DeleteActivityAsync(string id)
        {
            var response = new ResponseDto<bool>();
            try
            {
                var result = await _activitiesRepo.DeleteActivityById(id);
                if(result == true)
                {
                    response.Result = true;
                    response.DisplayMessage = "Delete activity was successfull";
                    response.StatusCode = StatusCodes.Status200OK;
                    return response;
                }
                else
                {
                    response.DisplayMessage ="Activity was not deleted successfully";
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.DisplayMessage = ex.Message;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;

            }
        }
    }

}