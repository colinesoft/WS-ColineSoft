using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class TesteController : BaseController<TesteEntity>
    {
        public TesteController(IBaseService<TesteEntity> service) : base(service)
        {
        }
    }
}
