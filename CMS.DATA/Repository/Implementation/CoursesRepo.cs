using CMS.DATA.Context;
using Microsoft.EntityFrameworkCore;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.AspNetCore.Http;

namespace CMS.DATA.Repository.Implementation
{
    public class CoursesRepo : ICoursesRepo
    {
        private readonly CMSDbContext _context;

        public CoursesRepo(CMSDbContext context)
        {
            _context = context;
        }
         public async Task<ResponseDTO<Course>> GetCourseById(string courseId)
        {
            var response = new ResponseDTO<Course>();
            var result = await _context.Courses.FindAsync(courseId);
            if (result == null)
            {
                response.ErrorMessages = new List<string>() { "Course not available" };
                response.DisplayMessage = "Error";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }
            response.Result = result;
            response.StatusCode = StatusCodes.Status200OK;
            response.DisplayMessage = "Successfull";
            return response;

        }
        public async Task<ResponseDTO<Course>> UpdateCourseAsync(string courseId, UpdateCourseDTO course)
        {
            var response = new ResponseDTO<Course>();
            var checkcourse = await _context.Courses.FindAsync(courseId);
            if (checkcourse == null)
            {
                response.DisplayMessage = "Error";
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ErrorMessages = new List<string>() { "Course not available" };
                return response;
            }
            checkcourse.Name = course.Name;
            checkcourse.DateUpdated = DateTime.UtcNow;
            var changes = await _context.SaveChangesAsync();
            if (changes > 0)
            {
                response.Result = checkcourse;
                response.StatusCode = StatusCodes.Status200OK;
                response.DisplayMessage = "Successfull";
                return response;
            }
            response.DisplayMessage = "Error";
            response.StatusCode = StatusCodes.Status501NotImplemented;
            response.ErrorMessages = new List<string>() { "Course not updated successfully" };
            return response;
        }
        public async Task<ResponseDTO<bool>> DeleteCourseAsync(string courseId)
        {
            var response = new ResponseDTO<bool>();
            var checkcourse = await _context.Courses.FindAsync(courseId);
            if (checkcourse == null)
            {
                response.DisplayMessage = "Error";
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ErrorMessages = new List<string>() { "Course not available" };
                return response;
            }
            var delete = _context.Courses.Remove(checkcourse);
            var changes = await _context.SaveChangesAsync();
            if (changes > 0)
            {
                response.Result = true;
                response.StatusCode = StatusCodes.Status200OK;
                response.DisplayMessage = "Successfull";
                return response;
            }
            response.DisplayMessage = "Error";
            response.StatusCode = StatusCodes.Status501NotImplemented;
            response.ErrorMessages = new List<string>() { "Course not deleted successfully" };
            return response;
        }

        public void SetCourseAsCompleted(string courseId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                course.IsCompleted = true;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Course with ID {courseId} does not exist.");
            }
        }
       public async Task<Course> AddCourse(Course entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var User = await _context.Users.FindAsync(entity.AddedById);
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }
            await _context.Courses.AddAsync(entity);
            var Status = await _context.SaveChangesAsync();

            if (Status > 0)
            {
                return entity;
            }
            return null;
        }
        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}