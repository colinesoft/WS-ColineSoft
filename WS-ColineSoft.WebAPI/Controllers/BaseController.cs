using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.Domain.DTO.Defaults;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TModel, TEntity> : ControllerBase where TEntity : Entity
    {
        protected readonly IBaseService<TModel, TEntity> _service;
        public BaseController(IBaseService<TModel, TEntity> service)
        {
            this._service = service;
        }

        #region CONSULTAS
        [HttpGet("GetAll")]
        public virtual IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (ArgumentException e)
            {
                return NotFound(e);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetById/{id}")]
        public virtual IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (ArgumentException e)
            {
                return NotFound(e);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion

        #region CRUD
        [HttpPost("Insert")]
        public virtual IActionResult Insert([FromBody] TModel obj)
        {
            var ret = _service.Insert(obj);
            BaseResponse response = _service.SaveChange();
            if (response.Result == ResponseResultEnum.success)
            {
                response.Id = ret.Id;
                response.Messages = "Registro adicionado com sucesso";
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [HttpPost("InsertRange")]
        public virtual IActionResult InsertRange([FromBody] List<TModel> objs)
        {
            _service.Insert(objs);
            BaseResponse response = _service.SaveChange();
            if (response.Result == ResponseResultEnum.success)
            {
                response.Id = Guid.NewGuid();
                response.Messages = "Registros adicionado com sucesso";
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            var ret = _service.Delete(id);
            BaseResponse response = _service.SaveChange();
            if (response.Result == ResponseResultEnum.success)
            {
                response.Id = ret.Id;
                response.Messages = "Registro apagado com sucesso";
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Delete")]
        public virtual IActionResult Delete([FromBody] TModel obj)
        {
            var ret = _service.Delete(obj);
            BaseResponse response = _service.SaveChange();
            if (response.Result == ResponseResultEnum.success)
            {
                response.Id = ret.Id;
                response.Messages = "Registro apagado com sucesso";
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpDelete("DeleteRange")]
        public virtual IActionResult Delete([FromBody] IEnumerable<TModel> objs)
        {
            _service.Delete(objs);
            BaseResponse response = _service.SaveChange();
            if (response.Result == ResponseResultEnum.success)
            {
                response.Id = Guid.NewGuid();
                response.Messages = "Registros apagados com sucesso";
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("Update")]
        public virtual IActionResult Update([FromBody] TModel obj)
        {
            var ret = _service.Update(obj);
            BaseResponse response = _service.SaveChange();
            if (response.Result == ResponseResultEnum.success)
            {
                response.Id = ret.Id;
                response.Messages = "Registro atualizado com sucesso";
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("UpdateRange")]
        public virtual IActionResult UpdateRange([FromBody] IEnumerable<TModel> objs)
        {
            _service.Update(objs);
            BaseResponse response = _service.SaveChange();
            if (response.Result == ResponseResultEnum.success)
            {
                response.Id = Guid.NewGuid();
                response.Messages = "Registros atualizados com sucesso";
                return Ok(response);
            }
            return BadRequest(response);
        }
        #endregion
    }
}
