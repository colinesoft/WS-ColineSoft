using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

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
