using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.Services
{
    public class GrupoUsuarioService : BaseService<GrupoUsuarioDTO, GrupoUsuarioEntity>, IGrupoUsuarioService
    {
        public GrupoUsuarioService(IGrupoUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
