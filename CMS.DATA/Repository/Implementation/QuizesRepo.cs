using CMS.DATA.Context;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace CMS.DATA.Repository.Implementation
{
    public class QuizesRepo : IQuizesRepo
    {
        private readonly CMSDbContext _context;

        public QuizesRepo(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizAsync()
        {
            return await _context.Quizs.ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(string quizId)
        {
            return await _context.Quizs.FirstOrDefaultAsync(e => e.Id == quizId);
        }
   

        public async Task<IEnumerable<Quiz>> GetQuizByLessonAsync(string lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson == null)
                throw new Exception("Lesson does not exist");

            return await _context.Quizs.Where(x => x.LessonId == lessonId).ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> GetQuizByUserAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User does not exist");

            return await _context.Quizs.Where(x => x.AddedById == userId).ToListAsync();
        }

        public async Task<Quiz> AddQuiz(Quiz entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Quizs.AddAsync(entity);
            var Status = await _context.SaveChangesAsync();

            if (Status > 0)
                return entity;

            return null;
        }
        
        public async Task<Quiz> DeleteQuizAsync(Quiz entity)
        {
            _context.Quizs.Remove(entity);
            var status = await _context.SaveChangesAsync();

            if (status > 0)
                return entity;

            return null;
        }

        public async Task<Quiz> UpdateQuiz(Quiz entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Quizs.Update(entity);
            var status = await _context.SaveChangesAsync();

            if (status > 0)
                return entity;

            return null;
        }
        
    }
}
