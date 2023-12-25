namespace WS_ColineSoft.Domain.DTO
{
    public class PessoaDTO: BaseDTO
    {
        public string Nome { get; set; }
        public char TipoPessoa { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Obs { get; set; }
    }
}
