using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class CorController : BaseController<CorDTO, CorEntity>
    {
        private readonly ICorService _service;
        public CorController(ICorService service) : base(service)
        {
        }
    }
}
