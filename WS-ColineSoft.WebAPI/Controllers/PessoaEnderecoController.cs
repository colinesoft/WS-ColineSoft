using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class PessoaEnderecoController : BaseController<PessoaEnderecoDTO, PessoaEnderecoEntity>
    {
        public PessoaEnderecoController(IPessoaEnderecoService service) : base(service)
        {
        }
    }
}
