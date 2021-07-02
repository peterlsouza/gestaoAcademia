using GestaoAcademia.AcessoDados.Interfaces;
using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Repositories
{
    public class ExercicioRepository : RepositoryGeneric<Exercicio>, IExercicioRepository
    {
        private readonly MyDbContext _context;

        public ExercicioRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> ExercicioExiste(string nome)
        {
            return _context.Exercicios.AnyAsync(e => e.Nome == nome);
        }

        public Task<bool> ExercicioExiste(string nome, int ExercicioId)
        {
            return _context.Exercicios.AnyAsync(e => e.Nome == nome && e.ExercicioId != ExercicioId);
        }

        public new async Task<IEnumerable<Exercicio>> PegarTodos()
        {
            return await _context.Exercicios.Include(e => e.CategoriaExercicio).ToListAsync();
        }
    }
}
