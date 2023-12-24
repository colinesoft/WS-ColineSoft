using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class BaseValidator<TModel>: AbstractValidator<TModel> where TModel : BaseDTO
    {
        public BaseValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório");
            RuleFor(e => e.DataAlteracao)
                .NotEmpty().WithMessage("O campo DataAlteração é obrigatório");
            RuleFor(e => e.DataCadastro)
                .NotEmpty().WithMessage("O campo DataAlteração é obrigatório");
            /*RuleFor(e => e.StatusGeral)
                .NotEmpty().WithMessage("O StatusGeral é obrigatório");
            RuleFor(e => e.UsuarioAlteracao)
                .NotEmpty().WithMessage("O UsuarioAlteração é obrigatório");*/

        }
    }
}
