using Microsoft.Extensions.DependencyInjection;

namespace Sample.Application.Common
{
    public class StartupParamater
    {
        private static IServiceProvider _currentServiceProvider;
        public static IServiceProvider CurrentServiceProvider
        {
            get
            {
                return _currentServiceProvider;
            }
            set
            {
                _currentServiceProvider = value;
            }
        }

        public static T GetServiceInstanceByType<T>()
        {
            return _currentServiceProvider != null ? _currentServiceProvider.GetService<T>() : default;
        }
    }
}
