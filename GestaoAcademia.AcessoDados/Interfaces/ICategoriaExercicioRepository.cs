using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface ICategoriaExercicioRepository : IRepositoryGeneric<CategoriaExercicio>
    {
        Task<bool> CategoriaExiste(string categoria);
        Task<bool> CategoriaExiste(string categoria, int CategoriaExercicioId);
    }
}
