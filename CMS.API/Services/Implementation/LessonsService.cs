using AutoMapper;
using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Enum;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Services
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepo _lessonsRepo;
       private readonly IMapper _mapper;

        public LessonsService(ILessonsRepo lessonsRepo, IMapper mapper)
        {
            _lessonsRepo = lessonsRepo;
            _mapper = mapper;
        }

        public async Task<ResponseDto<LessonResponseDTO>> AddLessonNew(AddLessonDTO addLesson)
        {
            var responseDto = new ResponseDto<LessonResponseDTO>();
            try
            {
                var lessonToAdd = new Lesson();
                lessonToAdd.DateCreated = DateTime.UtcNow;
                lessonToAdd.DateUpdated = DateTime.UtcNow;
                var newlesson = _mapper.Map(addLesson, lessonToAdd);
                var result = await _lessonsRepo.AddLesson(newlesson);
                var addlessonDto = _mapper.Map(result, new LessonResponseDTO());
                responseDto.DisplayMessage = "Successsful";
                responseDto.StatusCode = StatusCodes.Status200OK;
                responseDto.Result = addlessonDto;
                return responseDto;
            }
            catch (Exception ex)
            {
                responseDto.StatusCode = StatusCodes.Status400BadRequest;
                responseDto.DisplayMessage = "Error";
                responseDto.ErrorMessages = new List<string> { ex.Message };
                return responseDto;
            }

        }

        public async Task<ResponseDto<string>> DeleteLessonbyid(string lessonid)
        {
            var response = new ResponseDto<string>();
            try
            {
                var result = await _lessonsRepo.DeleteLesson(lessonid);
                if (result == false)
                {
                    response.DisplayMessage = "Lesson was not deleted";
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    return response;
                }
                response.DisplayMessage = "Successsful";
                response.StatusCode = StatusCodes.Status200OK;
                return response;

            }
            catch (Exception ex)
            {

                response.DisplayMessage = ex.Message;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }
        }


        public async Task<ResponseDto<IEnumerable<LessonResponseDTO>>> GetLessonByModuleAsync(Modules lessonModule)
        {
            var response = new ResponseDto<IEnumerable<LessonResponseDTO>>();
            try
            {
                var result = await _lessonsRepo.GetLessonByModule(lessonModule);
                if (result.Count() == 0)
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.DisplayMessage = "lesson with the module not found";
                    return response;
                }
                response.DisplayMessage = "Successful";
                response.Result = result;
                response.StatusCode = StatusCodes.Status200OK;
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

        public async Task<ResponseDto<LessonResponseDTO>> UpdateLesson(UpdateLessonDTO lesson, string lessonId)
        {
            var responseDto = new ResponseDto<LessonResponseDTO>();
            try
            {
                var result = await _lessonsRepo.UpdateLesson(lesson, lessonId);
                var updateResultlesson = _mapper.Map(result, new LessonResponseDTO());
                responseDto.DisplayMessage = "Successful";
                responseDto.StatusCode = StatusCodes.Status200OK;
                responseDto.Result = updateResultlesson;
                return responseDto;

            }
            catch (Exception ex)
            {
                responseDto.StatusCode = StatusCodes.Status400BadRequest;
                responseDto.DisplayMessage = "Error";
                responseDto.ErrorMessages = new List<string> { ex.Message };
                return responseDto;

            }
        }

        public async Task<ResponseDto<IEnumerable<Lesson>>> GetAllLessons()
        {
            var response = new ResponseDto<IEnumerable<Lesson>>();
            try
            {
                var result = await _lessonsRepo.GetAllLessonsAsync();
               
                if (result != null)
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.DisplayMessage = "Operation Successful";
                    response.Result = result;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.DisplayMessage = "Error";
                }
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

        public async Task<ResponseDto<Lesson>> GetLessonById(string id)
        {
            var response = new ResponseDto<Lesson>();
            try
            {
                var result = await _lessonsRepo.GetLessonByIdAsync(id);
                if(result != null)
                {
                    response.StatusCode= StatusCodes.Status200OK;
                    response.DisplayMessage= "Successful";
                    response.Result = result;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.DisplayMessage = "Lesson not Found";
                }
                return response;

            }
            catch (Exception ex)
            {

                response.DisplayMessage = ex.Message;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return response;
            }
        }
        public async Task<ResponseDto<IEnumerable<Lesson>>> GetLessonsByTopic(string topic)
        {
            var response = new ResponseDto<IEnumerable<Lesson>>();
            try
            {
                var result = await _lessonsRepo.GetLessonsByTopicAsync(topic);
                if (result != null)
                {
                    response.StatusCode = StatusCodes.Status200OK;
                    response.DisplayMessage = "Successful";
                    response.Result = result;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.DisplayMessage = "Topic not Found";
                }
                return response;

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