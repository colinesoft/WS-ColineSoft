using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class StatusGeralController : BaseController<StatusGeralDTO, StatusGeralEntity>
    {
        public StatusGeralController(IBaseService<StatusGeralDTO, StatusGeralEntity> service) :base(service)
        {
            
        }
    }
}
