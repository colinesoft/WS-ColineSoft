using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.Domain.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        [JsonIgnore]
        public Guid IdGrupoUsuario { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        [JsonIgnore]
        public Guid IdStatusGeral { get; set; }
        [JsonIgnore]
        public Guid IdUsuarioAlteracao { get; set; }

        public bool? Padrao { get; set; }

        //SUBTABELAS
        public GrupoUsuarioDTO GrupoUsuario { get; set; }
        public StatusGeralDTO StatusGeral { get; set; }
    }
}
