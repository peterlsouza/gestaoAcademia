using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoAcademia.AcessoDados.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(p => p.AlunoId);

            builder.Property(p => p.NomeCompleto).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Idade).IsRequired();
            builder.Property(p => p.Peso).IsRequired();
            builder.Property(p => p.FrequenciaSemanal).IsRequired();


            builder.HasOne(p => p.Objetivo).WithMany(p => p.Alunos).HasForeignKey(a => a.ObjetivoId);
            builder.HasOne(p => p.Professor).WithMany(p => p.Alunos).HasForeignKey(a => a.ProfessorId);
            
            builder.HasMany(a => a.Fichas).WithOne(a => a.Aluno).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Alunos");
        }
    }
}
 