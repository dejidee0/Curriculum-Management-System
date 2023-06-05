using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using CMS.DATA.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizesController : ControllerBase
    {
        private readonly IQuizesService _quizesService;

        public QuizesController(IQuizesService quizesService)
        {
            _quizesService = quizesService;
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllQuiz()
        {
                var result = await _quizesService.GetQuizAysnc();
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

        [HttpGet("{quizId}")]
        public async Task<ActionResult<Quiz>> GetQuizById(string quizId)
        {
          
                var result = await _quizesService.GetQuizByIdAsync(quizId);

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

        [HttpGet("lesson/{lessonId}")]
        public async Task<ActionResult<Quiz>> GetQuizByLessonId(string lessonId)
        {
           var result = await _quizesService.GetByLesson(lessonId);

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

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Quiz>> GetQuizByUserId(string userId)
        {
            
             var result = await _quizesService.GetByUser(userId);
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



        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto<AddQuizDto>>> AddQuiz([FromBody] AddQuizDto addQuizDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addQuiz = await _quizesService.AddQuiz(addQuizDto);
            if (addQuiz.StatusCode == 200)
            {
                return Ok(addQuiz);
            }
            else if (addQuiz.StatusCode == 400)
            {
                return NotFound(addQuiz);
            }
            else
            {
                return BadRequest(addQuiz);
            }
        }


        [HttpPatch("{quizId}/update")]
        public async Task<ActionResult<ResponseDto<AddQuizDto>>> UpdateQuiz(string quizId, [FromBody] UpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateQuiz = await _quizesService.UpdateQuiz(quizId, updateDto);
            if (updateQuiz.StatusCode == 200)
            {
                return Ok(updateQuiz);
            }
            else if (updateQuiz.StatusCode == 400)
            {
                return NotFound(updateQuiz);

            }
            else
            {
                return BadRequest(updateQuiz);
            }
        }

        [HttpDelete("{quizId}/delete")]
        public async Task<ActionResult<ResponseDto<bool>>> DeleteQuiz(string quizId)
        {

            var DeleteQuiz = await _quizesService.DeleteQuiz(quizId);

            if (DeleteQuiz.StatusCode == 200)
            {
                return Ok(DeleteQuiz);
            }
            else if (DeleteQuiz.StatusCode == 400)
            {
                return NotFound(DeleteQuiz);

            }
            else
            {
                return BadRequest(DeleteQuiz);
            }

        }
    }
}
