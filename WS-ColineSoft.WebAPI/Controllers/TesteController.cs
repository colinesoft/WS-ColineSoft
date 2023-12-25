using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.DAL.Context;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class TesteController : ControllerBase
    {
        private ColineSoftContext _colineSoftContext;
        public TesteController(ColineSoftContext colineSoftContext)
        {
            _colineSoftContext = colineSoftContext;

        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            //var v1 =_colineSoftContext.Usuarios;
            return Ok(_colineSoftContext.Teste);
        }
    }
}
