using GestaoAcademia.AcessoDados.Interfaces;
using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Repositories
{
    public class ListaExercicioRepository : RepositoryGeneric<ListaExercicio>, IListaExercicioRepository
    {
        private readonly MyDbContext _context;

        public ListaExercicioRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExercicioExisteNaFicha(int exercicioId, int fichaId)
        {
            return await _context.ListasExercicios.AnyAsync(e => e.ExercicioId == exercicioId && e.FichaId == fichaId);
        }
    }
}