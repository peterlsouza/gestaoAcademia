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
    public class AlunosController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IObjetivoRepository _objetivoRepository;
        private readonly IProfessorRepository _professorRepository;

        public AlunosController(IAlunoRepository alunoRepository, IObjetivoRepository objetivoRepository, IProfessorRepository professorRepository)
        {
            _alunoRepository = alunoRepository;
            _objetivoRepository = objetivoRepository;
            _professorRepository = professorRepository;
        }


        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _alunoRepository.PegarTodos());
        }

        public IActionResult Create()
        {
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "ObjetivoId", "Nome");
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "ProfessorId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoId,NomeCompleto,Idade,Peso,ObjetivoId,ProfessorId,FrequenciaSemanal")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                await _alunoRepository.Inserir(aluno);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "ObjetivoId", "Nome", aluno.ObjetivoId);
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "ProfessorId", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _alunoRepository.PegarPeloId(id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "ObjetivoId", "Nome", aluno.ObjetivoId);
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "ProfessorId", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlunoId,NomeCompleto,Idade,Peso,ObjetivoId,ProfessorId,FrequenciaSemanal")] Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _alunoRepository.Atualizar(aluno);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjetivoId"] = new SelectList(_objetivoRepository.PegarTodos(), "ObjetivoId", "Nome", aluno.ObjetivoId);
            ViewData["ProfessorId"] = new SelectList(_professorRepository.PegarTodos(), "ProfessorId", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _alunoRepository.Excluir(id);
            return Json("Aluno excluído com sucesso");
        }

        public async Task<JsonResult> AlunoExiste(string NomeCompleto, int AlunoId)
        {
            if (AlunoId == 0)
            {
                if (await _alunoRepository.AlunoExiste(NomeCompleto))
                    return Json("Aluno já existe");

                return Json(true);
            }
            else
            {
                if (await _alunoRepository.AlunoExiste(NomeCompleto, AlunoId))
                    return Json("Aluno já existe");

                return Json(true);
            }
        }
    }
}
