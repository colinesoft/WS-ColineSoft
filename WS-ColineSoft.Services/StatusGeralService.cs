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
    public class StatusGeralService: BaseService<StatusGeralDTO, StatusGeralEntity>, IStatusGeralService
    {
        public StatusGeralService(IStatusGeralRepository repository, IMapper mapper): base(repository, mapper)
        {
        }

        public override IEnumerable<StatusGeralDTO> GetAll()
        {
            var v1 = _repository.GetAll();
            return base.GetAll();
        }

        public override StatusGeralDTO? Get(Guid id)
        {
            return base.Get(id);
        }

        #region RETORNO STATUS
        private Guid GetStatusGeralPorDescritivo(string descritivo)
        {
            return _repository.GetBy(e => e.Descritivo.ToUpper() == descritivo)
                .FirstOrDefault()?.Id ?? Guid.Empty;
        }
        public Guid GetStatusGeralAtivo()
        {
            return GetStatusGeralPorDescritivo("ATIVO");
        }
        public Guid GetStatusGeralAguardando()
        {
            return GetStatusGeralPorDescritivo("AGUARDANDO");
        }

        public Guid GetStatusGeralBloqueado()
        {
            return GetStatusGeralPorDescritivo("BLOQUEADO");
        }

        public Guid GetStatusGeralInativo()
        {
            return GetStatusGeralPorDescritivo("INATIVO");
        }

        public Guid GetStatusGeralRevisado()
        {
            return GetStatusGeralPorDescritivo("REVISADO");
        }
        #endregion
    }
}
