using AutoMapper;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.Services
{
    public class CorService : BaseService<CorDTO, CorEntity>, ICorService
    {
        public CorService(ICorRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
