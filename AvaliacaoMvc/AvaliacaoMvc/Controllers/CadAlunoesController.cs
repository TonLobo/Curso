using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvaliacaoMvc.Data;
using AvaliacaoMvc.Models;

namespace AvaliacaoMvc.Controllers
{
    public class CadAlunoesController : Controller
    {
        private readonly AvaliacaoMvcContext _context;

        public CadAlunoesController(AvaliacaoMvcContext context)
        {
            _context = context;
        }

        // GET: CadAlunoes
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.CadAluno == null)
            {
                return Problem("Tabela Inexistente");
            }

            var aluno = from cad in _context.CadAluno select cad;

            if (!String.IsNullOrEmpty(searchString))
            {
                aluno = aluno.Where(s => s.Nome!.Contains(searchString));
            }
            return View(await aluno.ToListAsync());
            //return View(await _context.CadAluno.ToListAsync());
        }

        // GET: CadAlunoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadAluno = await _context.CadAluno
                .FirstOrDefaultAsync(m => m.CadAlunoID == id);
            if (cadAluno == null)
            {
                return NotFound();
            }

            return View(cadAluno);
        }

        // GET: CadAlunoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadAlunoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadAlunoID,Nome,Idade,Endereco,Cep,Turma")] CadAluno cadAluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadAluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadAluno);
        }

        // GET: CadAlunoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadAluno = await _context.CadAluno.FindAsync(id);
            if (cadAluno == null)
            {
                return NotFound();
            }
            return View(cadAluno);
        }

        // POST: CadAlunoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadAlunoID,Nome,Idade,Endereco,Cep,Turma")] CadAluno cadAluno)
        {
            if (id != cadAluno.CadAlunoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadAluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadAlunoExists(cadAluno.CadAlunoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadAluno);
        }

        // GET: CadAlunoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadAluno = await _context.CadAluno
                .FirstOrDefaultAsync(m => m.CadAlunoID == id);
            if (cadAluno == null)
            {
                return NotFound();
            }

            return View(cadAluno);
        }

        // POST: CadAlunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadAluno = await _context.CadAluno.FindAsync(id);
            if (cadAluno != null)
            {
                _context.CadAluno.Remove(cadAluno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadAlunoExists(int id)
        {
            return _context.CadAluno.Any(e => e.CadAlunoID == id);
        }
    }
}
