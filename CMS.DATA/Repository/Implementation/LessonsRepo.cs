using CMS.DATA.Context;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Enum;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace CMS.DATA.Repository.Implementation
{
    public class LessonsRepo : ILessonsRepo
    {
        private readonly CMSDbContext _context;
        public LessonsRepo(CMSDbContext context)
        {
            _context = context;
        }
        public async Task<Lesson> AddLesson(Lesson lesson)
        {
            var checkUser = await _context.Users.FindAsync(lesson.AddedById);
            if (checkUser == null)
            {
                throw new Exception("User with the id not valid");
            }
            var checkCourse = await _context.Courses.FindAsync(lesson.CourseId);
            if (checkCourse == null)
            {
                throw new Exception("Course id is invalid");
            }
            var addLesson = await _context.Lessons.AddAsync(lesson);
            var result = await _context.SaveChangesAsync();
            return addLesson.Entity;
        }
        public async Task<bool> DeleteLesson(string lessonId)
        {
            var checkLesson = await _context.Lessons.FindAsync(lessonId);
            if (checkLesson == null)
            {
                throw new Exception("Lesson to delete not available");
            }
            await Task.CompletedTask;
            var deleteLesson = _context.Lessons.Remove(checkLesson);
            var response = await _context.SaveChangesAsync();
            if (response > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<LessonResponseDTO>> GetLessonByModule(Modules lessonModule)
        {
            var getLesson = await _context.Lessons
                .Where(e => e.Module == lessonModule)
                .Select(lesson => new LessonResponseDTO
                {
                    Module = lesson.Module,
                    AddedById = lesson.AddedById,
                    CompletionStatus = lesson.CompletionStatus,
                    CourseId = lesson.CourseId,
                    DateCreated = lesson.DateCreated,
                    DateUpdated = lesson.DateUpdated,
                    IsDeleted = lesson.IsDeleted,
                    Id = lesson.Id,
                    PublicId = lesson.PublicId,
                    Text = lesson.Text,
                    Topic = lesson.Topic,
                    VideoUrl = lesson.VideoUrl,
                    Weeks = lesson.Weeks,
                }).ToListAsync();
            return getLesson;
        }
        public async Task<Lesson> UpdateLesson(UpdateLessonDTO lesson, string lessonId)
        {
            var checkLesson = await _context.Lessons.FindAsync(lessonId);
            if (checkLesson == null)
            {
                throw new Exception("Lesson not found");
            }
            checkLesson.Text = lesson.Text;
            checkLesson.Weeks = lesson.Weeks;
            checkLesson.CompletionStatus = lesson.CompletionStatus;
            checkLesson.DateUpdated = DateTime.UtcNow;
            checkLesson.Topic = lesson.Topic;
            checkLesson.PublicId = lesson.PublicId;
            checkLesson.VideoUrl = lesson.VideoUrl;
            checkLesson.IsDeleted = lesson.IsDeleted;
            checkLesson.Module = lesson.Module;
            var response = await _context.SaveChangesAsync();
            if (response > 0)
            {
                return checkLesson;
            }
            throw new Exception("Lesson not updated successfully");
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(string id)
        {
             
             var result = await _context.Lessons.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsByTopicAsync(string topic)
        {
            return await _context.Lessons.Where(lesson => lesson.Topic == topic).ToListAsync();
        }
    }
}