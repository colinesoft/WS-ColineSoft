using FluentValidation;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class GrupoUsuarioValidator: AbstractValidator<GrupoUsuarioDTO>
    {
        public GrupoUsuarioValidator()
        {
            RuleFor(e => e.Descritivo)
                .NotEmpty().WithMessage("O campo Descrição é obrigatório")
                .Length(15).WithMessage("O tamanho máximo para a descrição é de 15 posições");            
        }
    }
}
