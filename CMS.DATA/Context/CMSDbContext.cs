using CMS.DATA.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.DATA.Context;

public class CMSDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Quiz> Quizs { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Invite> Invites { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<QuizOption> QuizOptions { get; set; }
    public DbSet<Stack> Stacks { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public DbSet<UserQuizTaken> UserQuizTaken { get; set; }
    public DbSet<UserStack> UserStack { get; set; }

    public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
    {
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker.Entries<BaseEntity>())
        {
            switch (item.State)
            {
                case EntityState.Modified:
                    item.Entity.DateUpdated = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    item.Entity.IsDeleted = true;
                    break;

                case EntityState.Added:
                    item.Entity.Id = Guid.NewGuid().ToString();
                    item.Entity.DateCreated = DateTime.UtcNow;
                    break;

                default:
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}