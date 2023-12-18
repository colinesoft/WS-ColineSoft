using FluentValidation;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Validators;

namespace WS_ColineSoft.WebAPI.Configuration
{
    public static class ValidatorsConfig
    {
        public static IServiceCollection ResolveValidators(this IServiceCollection service)
        {
            service.AddTransient<IValidator<TesteDTO>, TesteValidator>();
            return service;
        }

    }
}
