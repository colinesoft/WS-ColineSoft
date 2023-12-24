using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_ColineSoft.Domain.Entities
{
    public class GrupoUsuarioEntity : Entity
    {
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid IdStatusGeral { get; set; }
        public Guid? IdUsuarioAlteracao { get; set; }
        public string Descritivo {get;set;}
    }
}
