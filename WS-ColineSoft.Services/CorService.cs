using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.Services
{
    public class CorService : BaseService<CorDTO, CorEntity>
    {
        public CorService(IBaseRepository<CorEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
