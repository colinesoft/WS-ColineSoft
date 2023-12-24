using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.DTO;

namespace WS_ColineSoft.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool? Padrao { get; set; } //Quando padrão for true, não é permitido a exclusão
    }
}
