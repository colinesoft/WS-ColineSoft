using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.Domain.Interfaces.Services
{
    public interface IStatusGeralService: IBaseService<StatusGeralDTO, StatusGeralEntity>
    {

        #region Métodos exclusivos 
        public Guid GetStatusGeralAtivo();
        public Guid GetStatusGeralAguardando();
        public Guid GetStatusGeralBloqueado();
        public Guid GetStatusGeralRevisado();
        public Guid GetStatusGeralInativo();
        #endregion
    }
}
