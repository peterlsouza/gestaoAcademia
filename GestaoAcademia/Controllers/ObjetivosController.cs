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
using Microsoft.AspNetCore.Authorization;

namespace GestaoAcademia.Controllers
{
    [Authorize]
    public class ObjetivosController : Controller
    {
        private readonly IObjetivoRepository _objetivoRepository;

        public ObjetivosController(IObjetivoRepository objetivoRepository)
        {
            _objetivoRepository = objetivoRepository;
        }

        // GET: Objetivos
        public async Task<IActionResult> Index()
        {
            return View(await _objetivoRepository.PegarTodos().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjetivoId,Nome,Descricao")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                await _objetivoRepository.Inserir(objetivo);
                return RedirectToAction(nameof(Index));
            }
            return View(objetivo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _objetivoRepository.PegarPeloId(id);
            if (objetivo == null)
            {
                return NotFound();
            }
            return View(objetivo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjetivoId,Nome,Descricao")] Objetivo objetivo)
        {
            if (id != objetivo.ObjetivoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _objetivoRepository.Atualizar(objetivo);
                return RedirectToAction(nameof(Index));
            }

            return View(objetivo);
        }


        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _objetivoRepository.Excluir(id);
            return Json("Objetivo excluído com sucesso");
        }

        public async Task<JsonResult> ObjetivoExiste(string Nome, int ObjetivoId)
        {
            if (ObjetivoId == 0)
            {
                if (await _objetivoRepository.ObjetivoExiste(Nome))
                    return Json("Objetivo já existe");

                return Json(true);
            }

            else
            {
                if (await _objetivoRepository.ObjetivoExiste(Nome, ObjetivoId))
                    return Json("Objetivo já existe");

                return Json(true);
            }
        }
    }
}
