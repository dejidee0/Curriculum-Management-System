using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Enum;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface ILessonsRepo
    {
        Task<Lesson> AddLesson(Lesson lesson);
        Task<bool> DeleteLesson(string lessonId);
        Task<IEnumerable<LessonResponseDTO>> GetLessonByModule(Modules lessonModule);
        Task<Lesson> UpdateLesson(UpdateLessonDTO lesson, string lessonId);
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        Task<Lesson> GetLessonByIdAsync(string id);
        Task<IEnumerable<Lesson>> GetLessonsByTopicAsync(string topic);
    }
}