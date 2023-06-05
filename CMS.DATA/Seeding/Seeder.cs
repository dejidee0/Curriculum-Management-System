using CMS.DATA.Context;
using CMS.DATA.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CMS.DATA.Seeding
{
    public class Seeder
    {
        public static async Task SeedData(IApplicationBuilder app)
        {
            var baseDir = Directory.GetCurrentDirectory();
            //Get db context
            var dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CMSDbContext>();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
            if (!dbContext.Users.Any())
            {
                await dbContext.Database.EnsureCreatedAsync();
                //Get Usermanager and rolemanager from IoC container
                var userManager = app.ApplicationServices.CreateScope()
                                              .ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var roleManager = app.ApplicationServices.CreateScope()
                                                .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //Creating list of roles

                List<string> roles = new() { "Facilitator", "Admin", "Student" };

                //Creating roles
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }

                var users = new List<ApplicationUser> {
                //Instantiating i User and it properties
                new ApplicationUser
                {
                    Id = "36e318aa-6d02-46d9-8048-3e2a8182a6c3",
                    FirstName = "Francis",
                    LastName = "Facilitator",
                    UserName = "cdSpark",
                    Email = "cmssq014@gmail.com",
                    PhoneNumber = "08162292349",
                    SquadNumber = "003",
                    PhoneNumberConfirmed = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EmailConfirmed = true
                },

                 new ApplicationUser
                {
                    Id = "4ce8e96f-b3f9-4510-8e8c-02d099e1f3bd",
                    FirstName = "Ayooluwa",
                    LastName = "Thomas",
                    UserName = "kimbill",
                    Email = "daj@gmail.com",
                    PhoneNumber = "08162292377",
                    SquadNumber = "001",
                    PhoneNumberConfirmed = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EmailConfirmed = true
                },

                 new ApplicationUser
                {
                    Id = "311c0cf1-7c88-e221-c4ff-38ce6418a005",
                    FirstName = "Abdulhafiz",
                    LastName = "Suleiman",
                    UserName = "geekz",
                    Email = "suleiman@gmail.com",
                    PhoneNumber = "08162292349",
                    SquadNumber = "001",
                    PhoneNumberConfirmed = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    EmailConfirmed = true
                } };

                for (int i = 0; i < users.Count; i++)
                {
                    await userManager.CreateAsync(users[i], "Password@123");
                    await userManager.AddToRoleAsync(users[i], roles[i]);
                }
            }

            //if (!dbContext.Invites.Any())
            //{
            //    var invitePath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Invite.json"));
            //    var cmsInvite = JsonConvert.DeserializeObject<List<Invite>>(invitePath);
            //    await dbContext.Invites.AddRangeAsync(cmsInvite);
            //}
            if (!dbContext.Courses.Any())
            {
                var coursePath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Course.json"));
                var cmsCourse = JsonConvert.DeserializeObject<List<Course>>(coursePath);
                await dbContext.Courses.AddRangeAsync(cmsCourse);

                var modules = dbContext.Lessons.Where(x => x.CourseId == "").Select(x => x.Module).ToList();
            }
            //if (!dbContext.Lessons.Any())
            //{
            //    var lessonPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Lesson.json"));
            //    var cmsLesson = JsonConvert.DeserializeObject<List<Lesson>>(lessonPath);
            //    await dbContext.Lessons.AddRangeAsync(cmsLesson);
            //}
            //if (!dbContext.Quizs.Any())
            //{
            //    var quizPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Quiz.json"));
            //    var cmsQuiz = JsonConvert.DeserializeObject<List<Quiz>>(quizPath);
            //    await dbContext.Quizs.AddRangeAsync(cmsQuiz);
            //}
            //if (!dbContext.QuizOptions.Any())
            //{
            //    var quizOptionPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/QuizOption.json"));
            //    var cmsQuizOption = JsonConvert.DeserializeObject<List<QuizOption>>(quizOptionPath);
            //    await dbContext.QuizOptions.AddRangeAsync(cmsQuizOption);
            //}

            if (!dbContext.Stacks.Any())
            {
                var stackPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/Stack.json"));
                var cmsStack = JsonConvert.DeserializeObject<List<Stack>>(stackPath);
                await dbContext.Stacks.AddRangeAsync(cmsStack);
            }

            //if (!dbContext.UserCourses.Any())
            //{
            //    var userCoursePath = File.ReadAllText(FilePath(baseDir, "JsonFiles/UserCourse.json"));
            //    var cmsUserCourse = JsonConvert.DeserializeObject<List<UserCourse>>(userCoursePath);
            //    await dbContext.UserCourses.AddRangeAsync(cmsUserCourse);
            //}

            //if (!dbContext.UserQuizTaken.Any())
            //{
            //    var userQuizTakenPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/QuizTaken.json"));
            //    var cmsUserQuizTaken = JsonConvert.DeserializeObject<List<UserQuizTaken>>(userQuizTakenPath);
            //    await dbContext.UserQuizTaken.AddRangeAsync(cmsUserQuizTaken);
            //}

            if (!dbContext.UserStack.Any())
            {
                var userStackPath = File.ReadAllText(FilePath(baseDir, "JsonFiles/UserStack.json"));
                var cmsUserStack = JsonConvert.DeserializeObject<List<UserStack>>(userStackPath);
                await dbContext.UserStack.AddRangeAsync(cmsUserStack);
            }
            //Saving everything into the database
            await dbContext.SaveChangesAsync();
        }

        //Defining method to get file paths
        private static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}