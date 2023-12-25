using FluentValidation;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class CorValidator: BaseValidator<CorDTO>
    {
        public CorValidator()
        {
            RuleFor(e => e.Descritivo)
                .NotEmpty().WithMessage("O campo descrição é obrigatório")
                .Length(30).WithMessage("O tamanho máximo para a descrição é de 30 posições");
        }
    }
}
