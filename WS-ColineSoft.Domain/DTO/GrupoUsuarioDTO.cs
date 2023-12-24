using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.Domain.DTO
{
    public class GrupoUsuarioDTO
    {
        public Guid Id { get; set; }
        public string Descritivo { get; set; }
        public string DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
        public Guid IdStatusGeral { get; set; }
        public Guid? IdUsuarioAlteracao { get; set; }
        public bool? Padrao { get; set; }
    }
}
