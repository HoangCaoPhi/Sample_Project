using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Implements;
using Sample.Application.Interfaces;

namespace Sample.Application
{
    public static class ApplicationFactory
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
        }

        public static void InjectMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ApplicationFactory).Assembly));
        }
    }
}
