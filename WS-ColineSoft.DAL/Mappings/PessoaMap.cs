using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public class PessoaMap: BaseMap<PessoaEntity>
    {
        public override void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoas");
            base.Configure(builder);
        }
    }
}
