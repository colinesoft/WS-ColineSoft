using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_ColineSoft.Domain.Entities
{
    public class UsuarioEntity: BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set;}
        public string Senha { get; set;}
        public string Celular { get; set;}
        public Guid IdGrupoUsuario { get; set; }

        public GrupoUsuarioEntity GrupoUsuario { get; set; }
    }
}
