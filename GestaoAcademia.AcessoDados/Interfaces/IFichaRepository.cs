using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface IFichaRepository : IRepositoryGeneric<Ficha>
    {
        Task<IEnumerable<Ficha>> PegarTodasFichasPeloAlunoId(int id);
        Task<Ficha> PegarFichaAlunoPeloId(int id);
        Task<bool> FichaExiste(string Nome);
        Task<bool> FichaExiste(string Nome, int FichaId);
    }
}
