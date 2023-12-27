using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.DAL.Context;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class TesteController : ControllerBase
    {
        private readonly ColineSoftContext _colineSoftContext;
        private readonly ILogger<TesteController> _logger;
        public TesteController(ColineSoftContext colineSoftContext, ILogger<TesteController> logger)
        {
            _colineSoftContext = colineSoftContext;
            _logger = logger;

        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            _logger.LogInformation("Information LOG");
            _logger.LogError("Error LOG");
            _logger.LogCritical("Critical LOG");
            _logger.LogDebug("Debugger LOG");
            _logger.LogTrace("Trace LOG");
            _logger.LogWarning("Warning LOG");
            //var v1 =_colineSoftContext.Usuarios;
            return Ok(_colineSoftContext.Teste);
        }
    }
}
