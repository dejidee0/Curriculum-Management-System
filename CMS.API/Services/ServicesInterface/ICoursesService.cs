using CMS.API.Models;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface ICoursesService
    {
        Task<ResponseDto<Course>> AddCourse(AddCourseDto addCoourseDto);
        Task<ResponseDto<IEnumerable<Course>>> GetAllCousrse();
        Task<ResponseDTO<Course>> GetCourseById(string courseId);
        Task<ResponseDTO<Course>> UpdateCourseAsync(string courseId, UpdateCourseDTO course);
        Task<ResponseDTO<bool>> DeleteCourseAsync(string courseId);
        void SetCourseAsCompleted(string courseId);
    }
}