using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TModel> : Controller
    {
        protected readonly IBaseService<TModel> service;
        public BaseController(IBaseService<TModel> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(service.Get(id));
        }
    }
}
