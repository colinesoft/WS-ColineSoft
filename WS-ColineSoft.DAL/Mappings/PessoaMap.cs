using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public class PessoaMap: BaseMap<PessoaEntity>
    {
        public override void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoas");
            base.Configure(builder);

            builder.Property(e => e.Nome).HasColumnName("Nome").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.TipoPessoa).HasColumnName("TipoPessoa").HasColumnType("char(1)").IsRequired();
            builder.Property(e => e.DataNascimento).HasColumnName("DataNascimento").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.Obs).HasColumnName("Obs").HasColumnType("varchar(MAX)");

            //Relacionamento 1xN
            builder.HasMany(e => e.Enderecos)
                .WithOne(f => f.Pessoa)
                .HasForeignKey(f => f.IdPessoa);
                
        }
    }
}
