using Contracts;
using Implementations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TheGlobeServer.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            // choose between Transient, Singleton, Scoped later
            services.AddTransient<ILoginService, LoginService>();
            return services;
        }
    }

}
