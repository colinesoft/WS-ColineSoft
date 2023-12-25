using FluentValidation;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class UsuarioValidator: AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Campo Id não poder ser vazio");
            
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo Descrição é obrigatório")
                .Length(25).WithMessage("O tamanho máximo para a Nome é de 25 posições");                

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Campo Email não pode ser vazio")
                .Length(100).WithMessage("O tamanho máximo para Email é de 100 posições");

            RuleFor(e => e.Senha)
                .NotEmpty().WithMessage("Campo Senha não pode ser vazio")
                .Length(32).WithMessage("O tamanho máximo para Senha é de 32 posições");

            RuleFor(e => e.Celular)
                .NotEmpty().WithMessage("Campo Celular não pode ser vazio")
                .Length(11).WithMessage("O tamanho máximo para Celular é de 11 posições");

            RuleFor(e => e.IdGrupoUsuario)
                .NotEmpty().WithMessage("Campo IdGrupoUsuario não pode ser vazio");

            RuleFor(e => e.IdStatusGeral)
                .NotEmpty().WithMessage("Campo IdStatusGeral não pode ser vazio");

            RuleFor(e => e.IdUsuarioAlteracao)
                .NotEmpty().WithMessage("Campo IdUsuarioAlteracao não pode ser vazio");

            RuleFor(e => e.DataCadastro)
                .NotEmpty().WithMessage("Campo DataCadastro não pode ser vazio");

            RuleFor(e => e.DataAlteracao)
                .NotEmpty().WithMessage("Campo DataAlteracao não pode ser vazio");
        }
    }
}
