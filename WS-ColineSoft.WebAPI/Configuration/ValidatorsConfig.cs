using FluentValidation;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Validators;

namespace WS_ColineSoft.WebAPI.Configuration
{
    public static class ValidatorsConfig
    {
        public static IServiceCollection ResolveValidators(this IServiceCollection service)
        {
            service.AddTransient<IValidator<TesteDTO>, TesteValidator>();
            service.AddTransient<IValidator<CorDTO>, CorValidator>();
            service.AddTransient<IValidator<StatusGeralDTO>, StatusGeralValidator>();
            return service;
        }
    }
}
