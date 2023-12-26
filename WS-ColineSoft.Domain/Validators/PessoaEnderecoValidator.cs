using FluentValidation;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Utils;

namespace WS_ColineSoft.Domain.Validators
{
    public class PessoaEnderecoValidator: BaseValidator<PessoaEnderecoDTO>
    {
        public PessoaEnderecoValidator(): base()
        {
            RuleFor(e => e.IdPessoa)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
            RuleFor(e => e.EnderecoDesde)
                .NotEmpty().WithMessage(DefaultFluentMessages.MandatoryValue);
        }
    }
}
