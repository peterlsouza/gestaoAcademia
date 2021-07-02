using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface IProfessorRepository : IRepositoryGeneric<Professor>
    {
        Task<bool> ProfessorExiste(string nome);
        Task<bool> ProfessorExiste(string nome, int ProfessorId);
    }
}
