using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Entities
{
    public abstract class BaseEntity: Entity
    {
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid IdStatusGeral { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }

        public StatusGeralEntity StatusGeral { get; set; }
        public UsuarioEntity UsuarioAlteracao { get; set; }
    }
}
