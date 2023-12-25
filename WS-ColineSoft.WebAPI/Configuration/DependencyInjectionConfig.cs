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
            services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddTransient<IStatusGeralService, StatusGeralService>();
            services.AddTransient<ICorService, CorService>();
            services.AddTransient<IGrupoUsuarioService, GrupoUsuarioService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPessoaService, PessoaService>();
            return services;
        }
        public static IServiceCollection ResolveDependenciesRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IStatusGeralRepository, StatusGeralRepository>();
            services.AddTransient<ICorRepository, CorRepository>();
            services.AddTransient<IGrupoUsuarioRepository, GrupoUsuarioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            return services;
        }
    }
}
