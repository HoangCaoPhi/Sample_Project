using Microsoft.Extensions.DependencyInjection;

namespace Sample.Application
{
    public static class ApplicationFactory
    {
        public static void InjectServices(this IServiceCollection services)
        {

        }

        public static void InjectMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ApplicationFactory).Assembly));
        }
    }
}
