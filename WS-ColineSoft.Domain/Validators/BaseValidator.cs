using FluentValidation;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Utils;

namespace WS_ColineSoft.Domain.Validators
{
    public class BaseValidator<TModel>: AbstractValidator<TModel> where TModel : BaseDTO
    {
        public BaseValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
            RuleFor(e => e.DataAlteracao)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
            RuleFor(e => e.DataCadastro)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
            RuleFor(e => e.IdStatusGeral)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
            RuleFor(e => e.IdUsuarioAlteracao)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
        }
    }
}
