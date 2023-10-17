using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaIntercambioFinal.Models;

namespace SistemaIntercambioFinal.Controllers
{
    public class DuracaoIntercambioController : Controller
    {
        private readonly Contexto _context;

        public DuracaoIntercambioController(Contexto context)
        {
            _context = context;
        }

        // GET: DuracaoIntercambio
        public async Task<IActionResult> Index()
        {
              return _context.DuracaoIntercambio != null ? 
                          View(await _context.DuracaoIntercambio.ToListAsync()) :
                          Problem("Entity set 'Contexto.DuracaoIntercambio'  is null.");
        }

        // GET: DuracaoIntercambio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DuracaoIntercambio == null)
            {
                return NotFound();
            }

            var duracaoIntercambio = await _context.DuracaoIntercambio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duracaoIntercambio == null)
            {
                return NotFound();
            }

            return View(duracaoIntercambio);
        }

        // GET: DuracaoIntercambio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuracaoIntercambio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DuracaoIntercambioDescricao")] DuracaoIntercambio duracaoIntercambio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duracaoIntercambio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duracaoIntercambio);
        }

        // GET: DuracaoIntercambio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DuracaoIntercambio == null)
            {
                return NotFound();
            }

            var duracaoIntercambio = await _context.DuracaoIntercambio.FindAsync(id);
            if (duracaoIntercambio == null)
            {
                return NotFound();
            }
            return View(duracaoIntercambio);
        }

        // POST: DuracaoIntercambio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DuracaoIntercambioDescricao")] DuracaoIntercambio duracaoIntercambio)
        {
            if (id != duracaoIntercambio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duracaoIntercambio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuracaoIntercambioExists(duracaoIntercambio.Id))
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
            return View(duracaoIntercambio);
        }

        // GET: DuracaoIntercambio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DuracaoIntercambio == null)
            {
                return NotFound();
            }

            var duracaoIntercambio = await _context.DuracaoIntercambio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duracaoIntercambio == null)
            {
                return NotFound();
            }

            return View(duracaoIntercambio);
        }

        // POST: DuracaoIntercambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DuracaoIntercambio == null)
            {
                return Problem("Entity set 'Contexto.DuracaoIntercambio'  is null.");
            }
            var duracaoIntercambio = await _context.DuracaoIntercambio.FindAsync(id);
            if (duracaoIntercambio != null)
            {
                _context.DuracaoIntercambio.Remove(duracaoIntercambio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuracaoIntercambioExists(int id)
        {
          return (_context.DuracaoIntercambio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
