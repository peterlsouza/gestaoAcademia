using GestaoAcademia.AcessoDados.Interfaces;
using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Repositories
{
    public class ObjetivoRepository : RepositoryGeneric<Objetivo>, IObjetivoRepository
    {
        private readonly MyDbContext _context;

        public ObjetivoRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ObjetivoExiste(string Nome)
        {
            return await _context.Objetivos.AnyAsync(o => o.Nome == Nome);
        }

        public async Task<bool> ObjetivoExiste(string Nome, int ObjetivoId)
        {
            return await _context.Objetivos.AnyAsync(o => o.Nome == Nome && o.ObjetivoId != ObjetivoId);
        }
    }
}
