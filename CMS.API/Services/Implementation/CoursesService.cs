using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepo _coursesRepo;
        private readonly ILogger<CoursesService> Log;

        public CoursesService(ICoursesRepo coursesRepo, ILogger<CoursesService> Log)
        {
            _coursesRepo = coursesRepo;
            this.Log = Log;
        }

        public async Task<ResponseDTO<bool>> DeleteCourseAsync(string courseId)
        {
            try
            {
                var courseResponse = await _coursesRepo.DeleteCourseAsync(courseId);
                return courseResponse;
            }
            catch (Exception ex)
            {

                return new ResponseDTO<bool>()
                {
                    DisplayMessage = "Error",
                    StatusCode = 500,
                    ErrorMessages = new List<string> { "Error deleting course" }
                };
            }
        }
        public async Task<ResponseDTO<Course>> GetCourseById(string courseId)
        {
            try
            {
                var courseResponse = await _coursesRepo.GetCourseById(courseId);
                return courseResponse;
            }
            catch (Exception ex)
            {

                return new ResponseDTO<Course>()
                {
                    DisplayMessage = "Error",
                    StatusCode = 500,
                    ErrorMessages = new List<string> { "Error getting course" }
                };
            }
        }
      public void SetCourseAsCompleted(string courseId)
            {
            try
            {
                _coursesRepo.SetCourseAsCompleted(courseId);
            }
            catch (Exception ex)
            {
                Log.LogError(ex, $"Error occurred while marking course {courseId} as completed");
            }
        }

        public async Task<ResponseDTO<Course>> UpdateCourseAsync(string courseId, UpdateCourseDTO course)
        {
            try
            {
                var courseResponse = await _coursesRepo.UpdateCourseAsync(courseId, course);
                return courseResponse;
            }
            catch (Exception ex)
            {
                return new ResponseDTO<Course>()
                {
                    DisplayMessage = "Error",
                    StatusCode = 500,
                    ErrorMessages = new List<string> { "Error updating course" }

                };
            }
        }
        public async Task<ResponseDto<Course>> AddCourse(AddCourseDto addCoourseDto)
        {
            var response = new ResponseDto<Course>();
            try
            {
                var NewCourse = new Course
                {
                    Name = addCoourseDto.Name,
                    AddedById = addCoourseDto.UserId
                };
                var QuizResult = await _coursesRepo.AddCourse(NewCourse);
                if (QuizResult != null)
                {
                    response.StatusCode = 200;
                    response.DisplayMessage = "You have successfully added a course";
                    response.Result = QuizResult;
                    return response;
                }
                response.ErrorMessages = new List<string> { "Error trying to add a course" };
                response.StatusCode = 404;
                response.Result = null;
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessages = new List<string> { "Error trying to add a course" };
                response.StatusCode = 400;
                return response;
            }
        }

        public async Task<ResponseDto<IEnumerable<Course>>> GetAllCousrse()
        {
            var response = new ResponseDto<IEnumerable<Course>>();
            try
            {
                var result = await _coursesRepo.GetAllCourse();
                if (result != null && result.Any())
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.DisplayMessage = "Successful";
                    response.Result = result;
                    return response;
                }
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.DisplayMessage = "Not Successful";
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.DisplayMessage = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
                return response;
            }
        }
    }
}
