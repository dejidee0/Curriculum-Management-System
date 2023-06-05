using CMS.DATA.Context;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Extensions
{
    public static class DBRegistryExtension
    {
        private static string GetRenderConnectionString()
        {
            // Get the Database URL from the ENV variables in Render
            string connectionUrl = $"postgres://cms_ptio_user:94aYd1E0SlZ2iNxoIrt5FU3wFZIqJbiE@dpg-chil4pt269v2e2a5k0m0-a.oregon-postgres.render.com/cms_ptio";

            // parse the connection string
            var databaseUri = new Uri(connectionUrl);
            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var x = $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port=5432;" +
                   $"Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
            return x;
        }

        public static void AddDbContextAndConfigurations(this IServiceCollection services, IWebHostEnvironment env, IConfiguration config)
        {
            var ConnectionString = GetRenderConnectionString();
            services.AddDbContextPool<CMSDbContext>(options =>
            {
                string connStr;

                if (env.IsDevelopment())
                {
                    connStr = GetRenderConnectionString();
                    // options.UseNpgsql(connStr);
                    connStr = config.GetConnectionString("DefaultConnection");
                    options.UseNpgsql(connStr);
                }
                else
                {
                    connStr = config.GetConnectionString("ProdDb");
                    options.UseNpgsql(connStr);
                }
            });
        }
    }
}