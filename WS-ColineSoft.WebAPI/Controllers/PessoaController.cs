using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class PessoaController : BaseController<PessoaDTO, PessoaEntity>
    {
        public PessoaController(IPessoaService service) : base(service)
        {

        }
    }
}
