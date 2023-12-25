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
    public class PessoaService : BaseService<PessoaDTO, PessoaEntity>, IPessoaService
    {
        public PessoaService(IPessoaRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
