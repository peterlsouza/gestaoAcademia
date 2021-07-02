using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoAcademia.AcessoDados.Mappings
{
    public class ObjetivoMapping : IEntityTypeConfiguration<Objetivo>
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder.HasKey(p => p.ObjetivoId);

            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(300).IsRequired();

            builder.HasMany(p => p.Alunos).WithOne(p => p.Objetivo);

            builder.ToTable("Objetivos");
        }
    }
}
 