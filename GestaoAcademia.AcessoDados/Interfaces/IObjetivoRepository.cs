using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface IObjetivoRepository : IRepositoryGeneric<Objetivo>
    {
        Task<bool> ObjetivoExiste(string nome);
        Task<bool> ObjetivoExiste(string nome, int ObjetivoId);
    }
}
