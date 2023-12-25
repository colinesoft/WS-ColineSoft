﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Mappings
{
    public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //builder.ToTable("Cores");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValue(Guid.NewGuid())
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
                .HasColumnName("Padrao");

            //Relacionamento 1x1
            builder.HasOne(e => e.StatusGeral)
                .WithMany()
                .HasForeignKey(e => e.IdStatusGeral);
        }
    }
}
