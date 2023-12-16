using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;
using WS_ColineSoft.Functions;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class TesteController : BaseController<TesteEntity>
    {
        public TesteController(IBaseService<TesteEntity> service) : base(service)
        {
        }

        [HttpGet("GetByExpression")]
        public IActionResult GetByExpression()
        {
            var teste = service.GetBy(e => e.Tamanho >= 3).ToList();
            return Ok(teste);
        }
        [HttpGet("GetCripto")]
        public IActionResult GetCripto()
        {
            decimal d = 11532.67M;
            return Ok(d.Extenso());
        }
    }
}
