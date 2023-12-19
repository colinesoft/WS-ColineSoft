using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WS_ColineSoft.Domain.DTO
{
    public class CorDTO
    {
        public Guid Id { get; set; }
        public string Descritivo { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }

        [JsonIgnore]
        public Guid IdStatusGeral { get; set; }
    }
}
