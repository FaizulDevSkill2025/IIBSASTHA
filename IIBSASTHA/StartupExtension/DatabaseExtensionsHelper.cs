using IIBSASTHA.Data;
using IIBSASTHA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IIBSASTHA.StartupExtension
{
    public static class DatabaseExtensionsHelper
    {
        public static IServiceCollection AddDatabaseExtensionHelper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(Opt =>
            {
                Opt.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"), sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure()
                ); 

            });

            services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IApplicationBuilder RunMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            return app;
        }
    }
}
