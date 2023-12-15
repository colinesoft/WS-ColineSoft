using WS_ColineSoft.DAL.Repositories;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;
using WS_ColineSoft.Services;

namespace WS_ColineSoft.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependenciesServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            return services;
        }
        public static IServiceCollection ResolveDependenciesRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
