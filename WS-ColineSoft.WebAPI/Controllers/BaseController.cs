using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TModel, TEntity> : ControllerBase
    {
        protected readonly IBaseService<TModel, TEntity> _service;
        public BaseController(IBaseService<TModel, TEntity> service)
        {
            this._service = service;
        }

        [HttpGet("GetAll")]
        public virtual IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("GetById/{id}")]
        public virtual IActionResult Get(Guid id)
        {
            return Ok(_service.Get(id));
        }

        [HttpPost("Insert")]
        public virtual IActionResult Insert([FromBody] TModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest("Erro de requisição");

            _service.Insert(obj);
            _service.SaveChange();
            return Ok("Sucesso");
        }
        
        [HttpPost("InsertRange")]
        public virtual IActionResult InsertRange([FromBody] IEnumerable<TModel> objs)
        {
            _service.Insert(objs);
            _service.SaveChange();
            return Ok("Sucesso");
        }

        [HttpDelete("Delete/{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            _service.SaveChange();
            return Ok("Sucesso");
        }

        [HttpDelete("Delete")]
        public virtual IActionResult Delete([FromBody] TModel obj)
        {
            _service.Delete(obj);
            _service.SaveChange();
            return Ok("Sucesso");
        }
        [HttpDelete("DeleteRange")]
        public virtual IActionResult Delete([FromBody] IEnumerable<TModel> objs)
        {
            _service.Delete(objs);
            _service.SaveChange();
            return Ok("Sucesso");
        }

        [HttpPut("Update")]
        public virtual IActionResult Update([FromBody] TModel obj)
        {
            _service.Update(obj);
            _service.SaveChange();
            return Ok("Sucesso");
        }

        [HttpPut("UpdateRange")]
        public virtual IActionResult UpdateRange([FromBody] IEnumerable<TModel> objs)
        {
            _service.Update(objs);
            _service.SaveChange();
            return Ok("Sucesso");
        }
    }
}
