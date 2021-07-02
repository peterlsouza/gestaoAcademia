using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface IListaExercicioRepository : IRepositoryGeneric<ListaExercicio>
    {
        Task<bool> ExercicioExisteNaFicha(int exercicioId, int fichaId);
    }
}