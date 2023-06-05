using CMS.API.Profiles;
using CMS.API.Services;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Repository.Implementation;
using CMS.DATA.Repository.RepositoryInterface;

namespace CMS.API.Extensions
{
    public static class RegisteredExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
          

            services.AddAutoMapper(typeof(CMSProfile));
            services.AddScoped<IActivitiesRepo, ActivitiesRepo>();
            services.AddScoped<IActivitiesService, ActivitiesService>();
            services.AddScoped<ICoursesRepo, CoursesRepo>();
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<ILessonsRepo, LessonsRepo>();
            services.AddScoped<ILessonsService, LessonsService>();
            services.AddScoped<IPermissionsRepo, PermissionsRepo>();
            services.AddScoped<IQuizesRepo, QuizesRepo>();
            services.AddScoped<IQuizesService, QuizesService>();
            services.AddScoped<IStacksRepo, StacksRepo>();
            services.AddScoped<IStacksService, StacksService>();
            


        }
    }
}