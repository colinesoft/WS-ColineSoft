using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class CorValidator: AbstractValidator<CorDTO>
    {
        public CorValidator()
        {
            RuleFor(e => e.Descritivo)
                .NotEmpty().WithMessage("O campo descrição é obrigatório")
                .Length(30).WithMessage("O tamanho máximo para a descrição é de 30 posições");
            RuleFor(e => e.DataAlteracao)
                .NotEmpty().WithMessage("O campo DataAlteração é obrigatório");
            RuleFor(e => e.DataCadastro)
                .NotEmpty().WithMessage("O campo DataAlteração é obrigatório");
            RuleFor(e => e.Status)
                .NotEmpty().WithMessage("O campo Status é obrigatório");
            RuleFor(e => e.UsuarioAlteracao)
                .NotEmpty().WithMessage("O campo UsuarioAlteracao é obrigatório");
        }
    }
}
