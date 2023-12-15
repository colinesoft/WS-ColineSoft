namespace WS_ColineSoft.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TModel> : Controller
    {
        private readonly IBaseService<TModel> service;
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
