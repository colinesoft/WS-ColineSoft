using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public class GrupoUsuarioMap : IEntityTypeConfiguration<GrupoUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<GrupoUsuarioEntity> builder)
        {
            builder.ToTable("GruposUsuarios");
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValue(Guid.NewGuid())
                .IsRequired();

            builder.Property(e => e.Descritivo)
                .HasColumnName("Descritivo")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(e => e.IdStatusGeral)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("IdStatusGeral")
                .IsRequired();

            builder.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(e => e.DataAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("DataAlteracao")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(e => e.IdUsuarioAlteracao)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("IdUsuarioAlteracao");

            builder.Property(e => e.Padrao)
                .HasColumnType("bit")
                .HasColumnName("Padrao");

            //Relacionamento 1x1
            builder.HasOne(e => e.StatusGeral)
                .WithMany()
                .HasForeignKey(e => e.IdStatusGeral);
        }
    }
}
