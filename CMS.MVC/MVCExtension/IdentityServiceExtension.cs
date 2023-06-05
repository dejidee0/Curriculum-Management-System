using CMS.DATA.Context;
using CMS.DATA.Entities;
using Microsoft.AspNetCore.Identity;


namespace CMS.MVC.MVCExtension
{
    public static class IdentityServiceExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<CMSDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
