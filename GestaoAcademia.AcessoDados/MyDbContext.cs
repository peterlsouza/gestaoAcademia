using GestaoAcademia.AcessoDados.Mappings;
using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoAcademia.AcessoDados
{
    public class MyDbContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<CategoriaExercicio> CategoriasExercicios { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<ListaExercicio> ListasExercicios { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<Professor> Professores { get; set; }


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdministradorMapping());
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new CategoriaExercicioMapping());
            modelBuilder.ApplyConfiguration(new ExercicioMapping());
            modelBuilder.ApplyConfiguration(new FichaMapping());
            modelBuilder.ApplyConfiguration(new ListaExercicioMapping());
            modelBuilder.ApplyConfiguration(new ObjetivoMapping());
            modelBuilder.ApplyConfiguration(new ProfessorMapping());
        }
    }
}
