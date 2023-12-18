using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public class TesteMap : IEntityTypeConfiguration<TesteEntity>
    {
        public void Configure(EntityTypeBuilder<TesteEntity> builder)
        {
            builder.ToTable("Teste");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueindentifier")
                .HasDefaultValue(Guid.NewGuid())
                .IsRequired();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome")
                .HasColumnType("Varchar(100)");

            builder.Property(e => e.Tamanho)
                .IsRequired()
                .HasColumnName("Tamanho")
                .HasColumnType("int")
                .HasDefaultValue(0);
        }
    }
}
