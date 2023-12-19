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
    public class StatusGeralService: BaseService<StatusGeralDTO, StatusGeralEntity>
    {
        public StatusGeralService(IBaseRepository<StatusGeralEntity> repository, IMapper mapper): base(repository, mapper)
        {            
        }

        public Guid GetStatusGeralAtivo()
        {
            return _repository.GetBy(e => e.Descritivo.ToUpper() == "ATIVO")
                .FirstOrDefault().Id;
        }
    }
}
