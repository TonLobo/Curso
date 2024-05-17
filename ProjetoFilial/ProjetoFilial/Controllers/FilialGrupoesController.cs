using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFilial.Data;
using ProjetoFilial.Models;

namespace ProjetoFilial.Controllers
{
    public class FilialGrupoesController : Controller
    {
        private readonly ProjetoFilialContext _context;

        public FilialGrupoesController(ProjetoFilialContext context)
        {
            _context = context;
        }

        // GET: FilialGrupoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilialGrupo.ToListAsync());
        }

        // GET: FilialGrupoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filialGrupo = await _context.FilialGrupo
                .FirstOrDefaultAsync(m => m.FilialGrupoID == id);
            if (filialGrupo == null)
            {
                return NotFound();
            }

            return View(filialGrupo);
        }

        // GET: FilialGrupoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilialGrupoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilialGrupoID,Nome,GerenteFilial,Endereco,Cep,Estado,Faturamento")] FilialGrupo filialGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filialGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filialGrupo);
        }

        // GET: FilialGrupoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filialGrupo = await _context.FilialGrupo.FindAsync(id);
            if (filialGrupo == null)
            {
                return NotFound();
            }
            return View(filialGrupo);
        }

        // POST: FilialGrupoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilialGrupoID,Nome,GerenteFilial,Endereco,Cep,Estado,Faturamento")] FilialGrupo filialGrupo)
        {
            if (id != filialGrupo.FilialGrupoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filialGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialGrupoExists(filialGrupo.FilialGrupoID))
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
            return View(filialGrupo);
        }

        // GET: FilialGrupoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filialGrupo = await _context.FilialGrupo
                .FirstOrDefaultAsync(m => m.FilialGrupoID == id);
            if (filialGrupo == null)
            {
                return NotFound();
            }

            return View(filialGrupo);
        }

        // POST: FilialGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filialGrupo = await _context.FilialGrupo.FindAsync(id);
            if (filialGrupo != null)
            {
                _context.FilialGrupo.Remove(filialGrupo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialGrupoExists(int id)
        {
            return _context.FilialGrupo.Any(e => e.FilialGrupoID == id);
        }
    }
}
