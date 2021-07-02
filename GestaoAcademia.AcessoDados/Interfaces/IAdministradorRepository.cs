using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoAcademia.AcessoDados.Interfaces
{
    public interface IAdministradorRepository : IRepositoryGeneric<Administrador>
    {
        bool AdministradorExiste(string email, string senha);
    }
}
