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
    public class AlunoRepository : RepositoryGeneric<Aluno>, IAlunoRepository
    {
        private readonly MyDbContext _context;

        public AlunoRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AlunoExiste(string NomeCompleto)
        {
            return await _context.Alunos.AnyAsync(a => a.NomeCompleto == NomeCompleto);
        }

        public async Task<bool> AlunoExiste(string NomeCompleto, int AlunoId)
        {
            return await _context.Alunos.AnyAsync(a => a.NomeCompleto == NomeCompleto && a.AlunoId != AlunoId);
        }

        public async Task<Aluno> PegarDadosAlunoPeloId(int AlunoId)
        {
            return await _context.Alunos.Include(a => a.Objetivo).Include(a => a.Professor).Where(a => a.AlunoId == AlunoId).FirstAsync();
        }

        public string PegarNomeAlunoPeloId(int id)
        {
            return _context.Alunos.Where(a => a.AlunoId == id).Select(a => a.NomeCompleto).First();
        }

        public new async Task<IEnumerable<Aluno>> PegarTodos()
        {
            return await _context.Alunos.Include(a => a.Objetivo).Include(a => a.Professor).ToListAsync();
        }
    }
}