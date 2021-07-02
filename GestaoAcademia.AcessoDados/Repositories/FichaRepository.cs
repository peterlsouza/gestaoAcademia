using GestaoAcademia.AcessoDados.Interfaces;
using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Repositories
{
    public class FichaRepository : RepositoryGeneric<Ficha>, IFichaRepository
    {
        public readonly MyDbContext _context;

        public FichaRepository(MyDbContext contexto) : base(contexto)
        {
            _context = contexto;
        }

        public async Task<bool> FichaExiste(string Nome)
        {
            return await _context.Fichas.AnyAsync(f => f.Nome == Nome);
        }

        public async Task<bool> FichaExiste(string Nome, int FichaId)
        {
            return await _context.Fichas.AnyAsync(f => f.Nome == Nome && f.FichaId != FichaId);
        }

        public async Task<Ficha> PegarFichaAlunoPeloId(int id)
        {
            return await _context.Fichas.Include(f => f.Aluno).FirstOrDefaultAsync(f => f.FichaId == id);
        }

        public async Task<IEnumerable<Ficha>> PegarTodasFichasPeloAlunoId(int id)
        {
            return await _context.Fichas.Include(f => f.Aluno).ThenInclude(f => f.Objetivo).Where(f => f.AlunoId == id).ToListAsync();
        }
    }
}
   