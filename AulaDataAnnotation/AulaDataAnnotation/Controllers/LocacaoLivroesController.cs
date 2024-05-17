using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AulaDataAnnotation.Data;
using AulaDataAnnotation.Models;

namespace AulaDataAnnotation.Controllers
{
    public class LocacaoLivroesController : Controller
    {
        private readonly AulaDataAnnotationContext _context;

        public LocacaoLivroesController(AulaDataAnnotationContext context)
        {
            _context = context;
        }

        // GET: LocacaoLivroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocacaoLivro.ToListAsync());
        }

        // GET: LocacaoLivroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacaoLivro = await _context.LocacaoLivro
                .FirstOrDefaultAsync(m => m.LocacaoLivroID == id);
            if (locacaoLivro == null)
            {
                return NotFound();
            }

            return View(locacaoLivro);
        }

        // GET: LocacaoLivroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocacaoLivroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocacaoLivroID,NomeLivro,Tipo,Nome,CPF,DtSaida,DtRetorno")] LocacaoLivro locacaoLivro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locacaoLivro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locacaoLivro);
        }

        // GET: LocacaoLivroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacaoLivro = await _context.LocacaoLivro.FindAsync(id);
            if (locacaoLivro == null)
            {
                return NotFound();
            }
            return View(locacaoLivro);
        }

        // POST: LocacaoLivroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocacaoLivroID,NomeLivro,Tipo,Nome,CPF,DtSaida,DtRetorno")] LocacaoLivro locacaoLivro)
        {
            if (id != locacaoLivro.LocacaoLivroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacaoLivro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocacaoLivroExists(locacaoLivro.LocacaoLivroID))
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
            return View(locacaoLivro);
        }

        // GET: LocacaoLivroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacaoLivro = await _context.LocacaoLivro
                .FirstOrDefaultAsync(m => m.LocacaoLivroID == id);
            if (locacaoLivro == null)
            {
                return NotFound();
            }

            return View(locacaoLivro);
        }

        // POST: LocacaoLivroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locacaoLivro = await _context.LocacaoLivro.FindAsync(id);
            if (locacaoLivro != null)
            {
                _context.LocacaoLivro.Remove(locacaoLivro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocacaoLivroExists(int id)
        {
            return _context.LocacaoLivro.Any(e => e.LocacaoLivroID == id);
        }
    }
}
