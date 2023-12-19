using FluentValidation;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class StatusGeralValidator: AbstractValidator<StatusGeralDTO>
    {
        public StatusGeralValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório");
            RuleFor(e => e.Descritivo)
                .NotEmpty().WithMessage("O campo Descritivo é obrigatório");
        }
    }
}
