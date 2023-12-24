using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_ColineSoft.Domain.DTO
{
    public class UsuarioDTO: BaseDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public Guid IdGrupoUsuario { get; set; }


        public virtual GrupoUsuarioDTO GrupoUsuario { get; set; }
    }
}
