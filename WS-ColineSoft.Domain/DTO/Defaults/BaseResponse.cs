namespace WS_ColineSoft.Domain.DTO.Defaults
{
    public enum ResponseResultEnum{fail = 0, success = 1}

    /// <summary>
    /// Modelo que será utilizado para retornar os dados da API
    /// </summary>
    public class BaseResponse
    {
        public BaseResponse()
        {
            Id = Guid.NewGuid();
            Result = ResponseResultEnum.fail;
            Messages = string.Empty;
        }
        public Guid? Id { get; set; }
        public string? Messages { get; set; }
        public ResponseResultEnum Result { get; set; }
    }
}
