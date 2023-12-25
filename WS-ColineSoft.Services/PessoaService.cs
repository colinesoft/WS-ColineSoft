using AutoMapper;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.Services
{
    public class PessoaService : BaseService<PessoaDTO, PessoaEntity>, IPessoaService
    {
        public PessoaService(IPessoaRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
