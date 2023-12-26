namespace WS_ColineSoft.Domain.DTO
{
    public class PessoaEnderecoDTO: BaseDTO
    {
        public Guid IdPessoa { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public int? CodigoMunicipio { get; set; }
        public string? Obs { get; set; }
        public DateTime EnderecoDesde { get; set; }
        public string? AosCuidadosDe { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public PessoaDTO Pessoa { get; set; }

    }
}
