using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class UsuarioValidator: BaseValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório")
                .Length(25).WithMessage("O tamanho máximo para o nome é de 25 posições");
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("O campo email é obrigatório")
                .Length(100).WithMessage("O tamanho máximo para o email é de 100 posições");
            RuleFor(e => e.Senha)
                .NotEmpty().WithMessage("O campo senha é obrigatório")
                .Length(32).WithMessage("O tamanho máximo para a senha é de 32 posições");
            RuleFor(e => e.Celular)
                .NotEmpty().WithMessage("O campo celular é obrigatório")
                .Length(11).WithMessage("O tamanho máximo para a Celular é de 11 posições");
        }
    }
}
