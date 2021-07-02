using GestaoAcademia.AcessoDados.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoAcademia.ViewComponents
{
    public class DadosAlunoViewComponent : ViewComponent
    {
        private readonly IAlunoRepository _alunoRepository;

        public DadosAlunoViewComponent(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(int AlunoId)
        {
            return View(await _alunoRepository.PegarDadosAlunoPeloId(AlunoId));
        }
    }
}
