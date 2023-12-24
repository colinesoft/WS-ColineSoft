using System.Text.Json.Serialization;

namespace WS_ColineSoft.Domain.DTO
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }
        public string DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
        [JsonIgnore]
        public Guid IdStatusGeral { get; set; }
        [JsonIgnore]
        public Guid IdUsuarioAlteracao { get; set; }
        public bool Padrao { get; set; }

        public StatusGeralDTO StatusGeral { get; set; }
        public UsuarioDTO UsuarioAlteracao { get; set; }
    }
}
