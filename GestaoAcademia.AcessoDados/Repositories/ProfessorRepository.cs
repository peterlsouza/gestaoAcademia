using GestaoAcademia.AcessoDados.Interfaces;
using GestaoAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Repositories
{
    public class ProfessorRepository : RepositoryGeneric<Professor>, IProfessorRepository
    {
        private readonly MyDbContext _context;

        public ProfessorRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> ProfessorExiste(string Nome)
        {
            return await _context.Professores.AnyAsync(p => p.Nome == Nome);
        }

        public async Task<bool> ProfessorExiste(string Nome, int ProfessorId)
        {
            return await _context.Professores.AnyAsync(p => p.Nome == Nome && p.ProfessorId != ProfessorId);
        }

    }
}
