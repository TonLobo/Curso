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
    public class MensalidadesController : Controller
    {
        private readonly AvaliacaoMvcContext _context;

        public MensalidadesController(AvaliacaoMvcContext context)
        {
            _context = context;
        }

        // GET: Mensalidades
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            var mensal = from m in _context.CadAluno select m; //select * from movie

            if (startDate.HasValue)
            {
                mensal = mensal.Where(s => s.DiaPagto >= startDate.Value); // where ReleaseDate >= startDate
            }
            if (endDate.HasValue)
            {
                mensal = mensal.Where(s => s.DiaPagto <= endDate.Value); // where ReleaseDate >= endDate
            }

            return View(await mensal.ToListAsync());
        }

        // GET: Mensalidades/Details/5
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

        // GET: Mensalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mensalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadAlunoID,Nome,Idade,Endereco,Cep,Turma,Mensalidade,DiaPagto")] CadAluno cadAluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadAluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadAluno);
        }

        // GET: Mensalidades/Edit/5
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

        // POST: Mensalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadAlunoID,Nome,Idade,Endereco,Cep,Turma,Mensalidade,DiaPagto")] CadAluno cadAluno)
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

        // GET: Mensalidades/Delete/5
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

        // POST: Mensalidades/Delete/5
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
