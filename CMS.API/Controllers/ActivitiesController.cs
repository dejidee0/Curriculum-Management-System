using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllActivities() 
        {
            var activities = await _activitiesService.GetAllActivitiesAsync();
            if(activities == null) 
            {
                return NotFound(new ResponseDto<Activity> { StatusCode = 404, DisplayMessage = "Activities not Found" });
            }

            return Ok(activities);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(string id) 
        {
            var deletedActivity = await _activitiesService.DeleteActivityAsync(id);
            if(deletedActivity == null) 
            {
                return NotFound(new ResponseDto<Activity> { StatusCode = 404, DisplayMessage = "ActivityId not Found" });
            }
            return Ok(deletedActivity); 
        }
    }
}