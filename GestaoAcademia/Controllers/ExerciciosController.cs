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
    public class ExerciciosController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
        private readonly ICategoriaExercicioRepository _categoriaExercicioRepository;
        private readonly IListaExercicioRepository _listaExercicioRepository;

        public ExerciciosController(IExercicioRepository exercicioRepository, ICategoriaExercicioRepository categoriaExercicioRepository, IListaExercicioRepository listaExercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
            _categoriaExercicioRepository = categoriaExercicioRepository;
            _listaExercicioRepository = listaExercicioRepository;
        }

        // GET: Exercicios
        public async Task<IActionResult> Index()
        {

            return View(await _exercicioRepository.PegarTodos());
        }

        public async Task<IActionResult> Listagem(int FichaId, int AlunoId)
        {
            ViewData["FichaId"] = FichaId;
            ViewData["AlunoId"] = AlunoId;

            return View(await _exercicioRepository.PegarTodos());
        }


        public async Task<IActionResult> AdicionarExercicio(int exercicioId, int frequencia, int repeticoes, int carga, int fichaId)
        {
            if (await _listaExercicioRepository.ExercicioExisteNaFicha(exercicioId, fichaId))
                return Json(false);

            ListaExercicio listaExercicio = new ListaExercicio
            {
                ExercicioId = exercicioId,
                Frequencia = frequencia,
                Repeticoes = repeticoes,
                Carga = carga,
                FichaId = fichaId
            };

            if (ModelState.IsValid)
            {
                await _listaExercicioRepository.Inserir(listaExercicio);
                return Json(true);
            }
            else return Json(false);
        }


        public async Task<IActionResult> Create()
        {
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "CategoriaExercicioId", "Nome");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExercicioId,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                await _exercicioRepository.Inserir(exercicio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var exercicio = await _exercicioRepository.PegarPeloId(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExercicioId,Nome,CategoriaExercicioId")] Exercicio exercicio)
        {
            if (id != exercicio.ExercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _exercicioRepository.Atualizar(exercicio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaExercicioId"] = new SelectList(_categoriaExercicioRepository.PegarTodos(), "CategoriaExercicioId", "Nome", exercicio.CategoriaExercicioId);
            return View(exercicio);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _exercicioRepository.Excluir(id);
            return Json("Exercício excluído com sucesso");
        }

        public async Task<JsonResult> ExercicioExiste(string nome, int ExercicioId)
        {
            if (ExercicioId == 0)
            {
                if (await _exercicioRepository.ExercicioExiste(nome))
                    return Json("Exercício já existe");

                return Json(true);
            }
            else
            {
                if (await _exercicioRepository.ExercicioExiste(nome, ExercicioId))
                    return Json("Exercício já existe");

                return Json(true);
            }
        }
    }
}