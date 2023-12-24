using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public class StatusGeralMap : IEntityTypeConfiguration<StatusGeralEntity>
    {
        public void Configure(EntityTypeBuilder<StatusGeralEntity> builder)
        {
            builder.ToTable("StatusGeral");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValue(Guid.NewGuid())
                .IsRequired();

            builder.Property(e => e.Descritivo)
                .HasColumnName("Descritivo")
                .HasColumnType("varchar(25)")
                .IsRequired();
        }
    }
}
