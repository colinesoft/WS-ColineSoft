using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(25)");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Celular)
                .IsRequired()
                .HasColumnName("Celular")
                .HasColumnType("varchar(11)");

            builder.Property(e => e.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("varchar(32)");

            builder.Property(e => e.DataCadastro)
                .IsRequired()
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Property(e => e.DataAlteracao)
                .IsRequired()
                .HasColumnName("DataAlteracao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Property(e => e.IdStatusGeral)
                .IsRequired()
                .HasColumnName("IdStatusGeral")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IdUsuarioAlteracao)
                .IsRequired()
                .HasColumnName("IdUsuarioAlteracao")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IdGrupoUsuario)
                .IsRequired()
                .HasColumnName("IdGrupoUsuario")
                .HasColumnType("uniqueidentifier");

            //Relacionamento de 1x1
            builder.HasOne(e => e.GrupoUsuario)
                .WithMany()
                .HasForeignKey(e => e.IdGrupoUsuario);

            builder.HasOne(e => e.StatusGeral)
                .WithMany()
                .HasForeignKey(e => e.IdStatusGeral);
        }
    }
}
