using GestaoAcademia.AcessoDados.Interfaces;
using GestaoAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoAcademia.AcessoDados.Repositories
{
    public class AdministradorRepository : RepositoryGeneric<Administrador>, IAdministradorRepository
    {
        private readonly MyDbContext _context;

        public AdministradorRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public bool AdministradorExiste(string email, string senha)
        {
            return _context.Administradores.Any(a => a.Email == email && a.Senha == senha);

        }
    }
}
