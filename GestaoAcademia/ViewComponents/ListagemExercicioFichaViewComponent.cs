using GestaoAcademia.AcessoDados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoAcademia.ViewComponents
{
    public class ListagemExercicioFichaViewComponent : ViewComponent
    {
        private readonly MyDbContext _context;

        public ListagemExercicioFichaViewComponent(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FichaId)
        {
            return View(await _context.ListasExercicios.Include(l => l.Exercicio).Where(l => l.FichaId == FichaId).ToListAsync());
        }
    }
}
