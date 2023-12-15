using System.ComponentModel.DataAnnotations;

namespace WS_ColineSoft.Domain.Entities
{
    public class TesteEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
    }
}
