using CMS.DATA.Enum;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.API.Models;

namespace CMS.API.Services.ServicesInterface
{
    public interface ILessonsService
    {
        Task<ResponseDto<LessonResponseDTO>> AddLessonNew(AddLessonDTO addLesson);
        Task<ResponseDto<string>> DeleteLessonbyid(string lessonid);
        Task<ResponseDto<IEnumerable<LessonResponseDTO>>> GetLessonByModuleAsync(Modules lessonModule);
        Task<ResponseDto<LessonResponseDTO>> UpdateLesson(UpdateLessonDTO lesson, string lessonId);
        Task<ResponseDto<IEnumerable<Lesson>>> GetAllLessons();
        Task<ResponseDto<Lesson>> GetLessonById(string id);

        Task<ResponseDto<IEnumerable<Lesson>>> GetLessonsByTopic(string topic);
    }
}