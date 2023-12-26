using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public class PessoaEnderecoMap : BaseMap<PessoaEnderecoEntity>
    {
        public override void Configure(EntityTypeBuilder<PessoaEnderecoEntity> builder)
        {
            builder.ToTable("PessoasEnderecos");
            base.Configure(builder);

            builder.Property(e => e.IdPessoa).HasColumnName("IdPessoa").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(e => e.Cep).HasColumnName("Cep").HasColumnType("varchar(8)").IsRequired();
            builder.Property(e => e.Logradouro).HasColumnName("Logradouro").HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Numero).HasColumnName("Numero").HasColumnType("varchar(10)");
            builder.Property(e => e.Complemento).HasColumnName("Complemento").HasColumnType("varchar(100)");
            builder.Property(e => e.CodigoMunicipio).HasColumnName("CodigoMunicipio").HasColumnType("int");
            builder.Property(e => e.Obs).HasColumnName("Obs").HasColumnType("varchar(MAX)");
            builder.Property(e => e.EnderecoDesde).HasColumnName("EnderecoDesde").HasColumnType("datetime").IsRequired();
            builder.Property(e => e.AosCuidadosDe).HasColumnName("AosCuidadosDe").HasColumnType("varchar(50)");
            builder.Property(e => e.Latitude).HasColumnName("Latitude").HasColumnType("decimal");
            builder.Property(e => e.Longitude).HasColumnName("Longitude").HasColumnType("decimal");
        }
    }
}
