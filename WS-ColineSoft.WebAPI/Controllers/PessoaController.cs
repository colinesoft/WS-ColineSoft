using FluentValidation.Internal;
using Microsoft.AspNetCore.Authorization;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    [Authorize(Roles = "SYSOP")]
    public class PessoaController : BaseController<PessoaDTO, PessoaEntity>
    {
        public PessoaController(IPessoaService service) : base(service)
        {

        }
    }
}
