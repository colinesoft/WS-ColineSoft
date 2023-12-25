using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_ColineSoft.Domain.Entities
{
    public class PessoaEntity: BaseEntity
    {
        public string Nome { get; set; }
        public char TipoPessoa { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Obs { get; set; }
    }
}
