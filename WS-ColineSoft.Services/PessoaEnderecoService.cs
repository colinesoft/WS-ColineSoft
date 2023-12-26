using AutoMapper;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.Services
{
    public class PessoaEnderecoService : BaseService<PessoaEnderecoDTO, PessoaEnderecoEntity>, IPessoaEnderecoService
    {
        public PessoaEnderecoService(IPessoaEnderecoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
