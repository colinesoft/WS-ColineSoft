using System.Text.Json.Serialization;

namespace WS_ColineSoft.Domain.DTO
{
    public class GrupoUsuarioDTO
    {
        public Guid Id { get; set; }
        public string Descritivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        [JsonIgnore]
        public Guid IdStatusGeral { get; set; }
        public Guid? IdUsuarioAlteracao { get; set; }
        public bool? Padrao { get; set; }
        public StatusGeralDTO StatusGeral { get; set; }
    }
}
