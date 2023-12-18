using FluentValidation;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class TesteValidator: AbstractValidator<TesteDTO>
    {
        public TesteValidator() 
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .Length(5, 100).WithMessage("O tamanho mínimo para o nome é de 5 caracteres");

            RuleFor(e => e.TamanhoExtenso)
                .NotEmpty().WithMessage("O Tamanho precisa ser informado");

            RuleFor(e => e)
                .Must(validaNome).WithMessage("Nome nunca pode ser LUGAS");
        }

        private bool validaNome(TesteDTO arg)
        {
            return arg.Nome != "LUGAS";
        }
    }
}
