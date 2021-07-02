using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoAcademia.AcessoDados;
using GestaoAcademia.Dominio.Models;
using GestaoAcademia.AcessoDados.Interfaces;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace GestaoAcademia.Controllers
{
    [Authorize]
    public class FichasController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IFichaRepository _fichaRepository;

        public FichasController(IAlunoRepository alunoRepository, IFichaRepository fichaRepository)
        {
            _alunoRepository = alunoRepository;
            _fichaRepository = fichaRepository;
        }

        // GET: Fichas
        public async Task<IActionResult> Index(int AlunoId)
        {
            ViewBag.AlunoId = AlunoId;
            return View(await _fichaRepository.PegarTodasFichasPeloAlunoId(AlunoId));
        }

        // GET: Fichas/Details/5
        public async Task<IActionResult> Details(int FichaId)
        {
            var ficha = await _fichaRepository.PegarFichaAlunoPeloId(FichaId);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        public async Task<IActionResult> VisualizarPDF(int FichaId)
        {
            var ficha = await _fichaRepository.PegarFichaAlunoPeloId(FichaId);
            if (ficha == null)
            {
                return NotFound();
            }

            return new ViewAsPdf("PDF", ficha) { FileName = "Ficha.PDF" };
        }

        public IActionResult Create(int AlunoId)
        {
            Ficha ficha = new Ficha();
            ficha.AlunoId = AlunoId;
            return View(ficha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FichaId,Nome,Cadastro,Validade,AlunoId")] Ficha ficha)
        {
            ficha.Cadastro = DateTime.Parse(DateTime.Now.ToShortDateString());
            ficha.Validade = DateTime.Parse(DateTime.Now.AddYears(1).ToShortDateString());

            if (ModelState.IsValid)
            {
                await _fichaRepository.Inserir(ficha);
                return RedirectToAction(nameof(Index), new { AlunoId = ficha.AlunoId });
            }
            return View(ficha);
        }

        public async Task<IActionResult> Edit(int FichaId)
        {
            var ficha = await _fichaRepository.PegarPeloId(FichaId);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int FichaId, [Bind("FichaId,Nome,Cadastro,Validade,AlunoId")] Ficha ficha)
        {
            if (FichaId != ficha.FichaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _fichaRepository.Atualizar(ficha);
                return RedirectToAction(nameof(Index), new { AlunoId = ficha.AlunoId });
            }

            return View(ficha);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int FichaId)
        {
            await _fichaRepository.Excluir(FichaId);
            return Json("Ficha excluída com sucesso");
        }

        public async Task<JsonResult> FichaExiste(string Nome, int FichaId)
        {
            if (FichaId == 0)
            {
                if (await _fichaRepository.FichaExiste(Nome))
                    return Json("Ficha já cadastrada");

                return Json(true);
            }
            else
            {
                if (await _fichaRepository.FichaExiste(Nome, FichaId))
                    return Json("Ficha já cadastrada");

                return Json(true);
            }
        }
    }
}