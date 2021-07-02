using GestaoAcademia.AcessoDados.Interfaces;
using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Repositories
{
    public class CategoriaExercicioRepository : RepositoryGeneric<CategoriaExercicio>, ICategoriaExercicioRepository
    {
        private readonly MyDbContext _context;

        public CategoriaExercicioRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CategoriaExiste(string categoria)
        {
            return await _context.CategoriasExercicios.AnyAsync(ce => ce.Nome == categoria);
        }

        public async Task<bool> CategoriaExiste(string categoria, int CategoriaExercicioId)
        {
            return await _context.CategoriasExercicios.AnyAsync(ce => ce.Nome == categoria && ce.CategoriaExercicioId != CategoriaExercicioId);
        }
    }
}
