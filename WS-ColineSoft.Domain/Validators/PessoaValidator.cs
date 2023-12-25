using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Validators
{
    public class PessoaValidator: BaseValidator<PessoaDTO>
    {
        public PessoaValidator():base()
        {
            
        }
    }
}
