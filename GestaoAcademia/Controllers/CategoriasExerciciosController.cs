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
    public class CategoriasExerciciosController : Controller
    {
        private readonly ICategoriaExercicioRepository _categoriaExercicioRepository;

        public CategoriasExerciciosController(ICategoriaExercicioRepository categoriaExercicioRepository)
        {
            _categoriaExercicioRepository = categoriaExercicioRepository;
        }


        // GET: CategoriasExercicios
        public async Task<IActionResult> Index()
        {
            return View(_categoriaExercicioRepository.PegarTodos());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaExercicioId,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (ModelState.IsValid)
            {
                await _categoriaExercicioRepository.Inserir(categoriaExercicio);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoriaExercicio = await _categoriaExercicioRepository.PegarPeloId(id);
            if (categoriaExercicio == null)
            {
                return NotFound();
            }
            return View(categoriaExercicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaExercicioId,Nome")] CategoriaExercicio categoriaExercicio)
        {
            if (id != categoriaExercicio.CategoriaExercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoriaExercicioRepository.Atualizar(categoriaExercicio);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaExercicio);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _categoriaExercicioRepository.Excluir(id);
            return Json("Categoria excluída com sucesso");
        }

        public async Task<JsonResult> CategoriaExiste(string nome, int CategoriaExercicioId)
        {
            if (CategoriaExercicioId == 0)
            {
                if (await _categoriaExercicioRepository.CategoriaExiste(nome))
                    return Json("Categoria já existe");

                return Json(true);
            }

            else
            {
                if (await _categoriaExercicioRepository.CategoriaExiste(nome, CategoriaExercicioId))
                    return Json("Categoria já existe");

                return Json(true);
            }
        }
    }
}