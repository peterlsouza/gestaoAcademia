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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace GestaoAcademia.Controllers
{
    [Authorize]
    public class ProfessoresController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProfessoresController(IProfessorRepository professorRepository, IHostingEnvironment hostingEnvironment)
        {
            _professorRepository = professorRepository;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: Professores
        public async Task<IActionResult> Index()
        {
            return View(await _professorRepository.PegarTodos().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorId,Nome,Foto,Telefone,Turno")] Professor professor, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Imagens");

                if (arquivo != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        professor.Foto = "~/Imagens/" + arquivo.FileName;
                    }
                }

                await _professorRepository.Inserir(professor);
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var professor = await _professorRepository.PegarPeloId(id);
            if (professor == null)
            {
                return NotFound();
            }

            TempData["Professor"] = professor.Foto;

            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorId,Nome,Foto,Telefone,Turno")] Professor professor, IFormFile arquivo)
        {
            if (id != professor.ProfessorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Imagens");

                if (arquivo != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        professor.Foto = "~/Imagens/" + arquivo.FileName;
                    }
                }

                else professor.Foto = TempData["Professor"].ToString();

                await _professorRepository.Atualizar(professor);

                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _professorRepository.Excluir(id);
            return Json("Professor excluído com sucesso");
        }

        public async Task<JsonResult> ProfessorExiste(string Nome, int ProfessorId)
        {
            if (ProfessorId == 0)
            {
                if (await _professorRepository.ProfessorExiste(Nome))
                    return Json("Professor já existe");

                return Json(true);
            }

            else
            {
                if (await _professorRepository.ProfessorExiste(Nome, ProfessorId))
                    return Json("Professor já existe");

                return Json(true);
            }
        }
    }
}
