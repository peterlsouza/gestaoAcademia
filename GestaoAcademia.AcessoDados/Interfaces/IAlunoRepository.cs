using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface IAlunoRepository : IRepositoryGeneric<Aluno>
    {
        new Task<IEnumerable<Aluno>> PegarTodos();

        string PegarNomeAlunoPeloId(int id);

        Task<Aluno> PegarDadosAlunoPeloId(int AlunoId);

        Task<bool> AlunoExiste(string NomeCompleto);

        Task<bool> AlunoExiste(string NomeCompleto, int AlunoId);
    }
}
