using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Domain.Interfaces;
using Sample.Persistence.Repositories;

namespace Sample.Persistence
{
    public static class PersistenceFactory
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGroupRepo, GroupRepo>();
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ICourseRepo, CourseRepo>();
        }

        public static void InjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var appConnection = configuration.GetConnectionString("AppDbConnectionString");
            if (appConnection != null)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseMySQL(appConnection));
            }
            else
            {
                throw new Exception("AppDbConnectionString config missing!");
            }
        }
    }
}
