using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class StatusGeralController : BaseController<StatusGeralDTO, StatusGeralEntity>
    {

        //Controller Funciona o Override
        private readonly IStatusGeralService _statusGeralService;
        public StatusGeralController(IStatusGeralService service) : base(service)
        {
            _statusGeralService = service;
        }

        public override IActionResult GetAll()
        {
            return Ok(_statusGeralService.GetAll());
        }

        public override IActionResult Get(Guid id)
        {
            return Ok(_statusGeralService.Get(id));
        }
    }
}
