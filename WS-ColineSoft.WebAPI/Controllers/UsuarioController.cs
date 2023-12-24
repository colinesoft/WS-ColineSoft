using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class UsuarioController : BaseController<UsuarioDTO, UsuarioEntity>
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service) : base(service)
        {
            _service = service;
        }

        /*public override IActionResult GetAll()
        {
            var v1 = _service.GetAll();
            var v2 = base.GetAll();
            return base.GetAll();
        }*/
    }
}
