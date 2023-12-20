using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class TesteController : BaseController<TesteDTO, TesteEntity>
    {
        private readonly IBaseRepository<TesteEntity> _repository;
        private readonly IStatusGeralService _statusGeralService;
        private readonly IMapper _mapper;
        public TesteController(IBaseService<TesteDTO, TesteEntity> service, IBaseRepository<TesteEntity> repository, IMapper mapper, IStatusGeralService statusGeralService) : base(service)
        {
            _repository = repository;
            _mapper = mapper;
            _statusGeralService = statusGeralService;
            _statusGeralService = statusGeralService;
        }

        [HttpGet("ENTITYDTO")]
        public IActionResult GetByExpression()
        {
            var ret = _repository.GetBy(e => e.Tamanho >= 3).ToList();
            IEnumerable<TesteDTO> retorno = _mapper.Map<IEnumerable<TesteDTO>>(ret);
            return Ok(retorno);
        }

        [HttpGet("DTOENTITY")]
        public IActionResult GetByExpression2()
        {
            var ret = _service.GetAll().ToList();
            List<TesteEntity> retorno = _mapper.Map<List<TesteEntity>>(ret);
            return Ok(retorno);
        }
        [HttpGet("GetCripto")]
        public IActionResult GetCripto()
        {
            return Ok(_statusGeralService.GetStatusGeralAtivo());
        }
    }
}
