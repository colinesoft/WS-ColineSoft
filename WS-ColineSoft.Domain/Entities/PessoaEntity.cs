namespace WS_ColineSoft.Domain.Entities
{
    public class PessoaEntity: BaseEntity
    {
        public string Nome { get; set; }
        public char TipoPessoa { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Obs { get; set; }

        public IEnumerable<PessoaEnderecoEntity> Enderecos { get; set; }
    }
}
