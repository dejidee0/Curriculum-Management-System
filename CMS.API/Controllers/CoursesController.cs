using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById(string courseId)
        {
            var result = await _coursesService.GetCourseById(courseId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpDelete("{courseId}/delete")]
        public async Task<IActionResult> DeleteCourse(string courseId)
        {
            var result = await _coursesService.DeleteCourseAsync(courseId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpPut("{courseId}/update")]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDTO course, string courseId)
        {
            var result = await _coursesService.UpdateCourseAsync(courseId, course);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPatch]
        [Route("{courseId}")]
        // [Authorize]
        public IActionResult MarkCourseAsCompleted(string courseId, bool completed = true)
        {
            try
            {
                if (completed)
                {
                    _coursesService.SetCourseAsCompleted(courseId);
                    var response = new ResponseDto<string>
                    {
                        StatusCode = 200,
                        DisplayMessage = "Course marked as completed",
                        Result = "Success"
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ResponseDto<string>
                    {
                        StatusCode = 400,
                        DisplayMessage = "Invalid value for 'completed' parameter",
                        Result = "Failure"
                    };

                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<string>
                {
                    StatusCode = 500,
                    DisplayMessage = $"Error occurred while marking course as completed: {ex.Message}",
                    Result = "Failure"
                };

                return StatusCode(500, response);
            }
        }
        [Authorize(Roles = "Facilitator, Admin")]
        [Authorize(Policy = "can_add")]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto<AddCourseDto>>> AddCourse([FromBody] AddCourseDto addCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addCourse = await _coursesService.AddCourse(addCourseDto);
            if (addCourse.StatusCode == 200)
            {
                return Ok(addCourse);
            }
            else if (addCourse.StatusCode == 400)
            {
                return NotFound(addCourse);
            }
            else
            {
                return BadRequest(addCourse);
            }
        }
        [Authorize]
        [HttpGet("All")]
        public async Task<ActionResult> GetAllCourses()
        {
            var result = await _coursesService.GetAllCousrse();
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}