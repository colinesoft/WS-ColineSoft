using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.WebAPI.Controllers
{
    public class GrupoUsuarioController : BaseController<GrupoUsuarioDTO, GrupoUsuarioEntity>
    {
        public GrupoUsuarioController(IBaseService<GrupoUsuarioDTO, GrupoUsuarioEntity> service) : base(service)
        {
        }
    }
}
