using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface IExercicioRepository : IRepositoryGeneric<Exercicio>
    {
        new Task<IEnumerable<Exercicio>> PegarTodos();
        Task<bool> ExercicioExiste(string nome);
        Task<bool> ExercicioExiste(string nome, int ExercicioId);
    }
}
