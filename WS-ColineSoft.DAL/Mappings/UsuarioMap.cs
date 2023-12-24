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
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValue(Guid.NewGuid())
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(32)")
                .IsRequired();

            builder.Property(e => e.Celular)
                .HasColumnName("Celular")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(e => e.IdGrupoUsuario)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("IdGrupoUsuario")
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
                .HasColumnName("IdUsuarioAlteracao")
                .IsRequired();

            builder.Property(e => e.Padrao)
                .HasColumnType("bit")
                .HasColumnName("Padrao")
                .HasDefaultValue(false);
            
            //Relacionamento de 1x1
            builder.HasOne(e => e.GrupoUsuario)
                .WithMany()
                .HasForeignKey(e => e.IdGrupoUsuario);

            builder.HasOne(e => e.StatusGeral)
                .WithMany()
                .HasForeignKey(e => e.IdStatusGeral);

            builder.HasOne(e => e.UsuarioAlteracao)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioAlteracao);
        }
    }
}
