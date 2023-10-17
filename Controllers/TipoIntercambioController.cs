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
    public class TipoIntercambioController : Controller
    {
        private readonly Contexto _context;

        public TipoIntercambioController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoIntercambio
        public async Task<IActionResult> Index()
        {
              return _context.TipoIntercambio != null ? 
                          View(await _context.TipoIntercambio.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoIntercambio'  is null.");
        }

        // GET: TipoIntercambio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoIntercambio == null)
            {
                return NotFound();
            }

            var tipoIntercambio = await _context.TipoIntercambio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoIntercambio == null)
            {
                return NotFound();
            }

            return View(tipoIntercambio);
        }

        // GET: TipoIntercambio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIntercambio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoIntercambioDescricao")] TipoIntercambio tipoIntercambio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIntercambio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIntercambio);
        }

        // GET: TipoIntercambio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoIntercambio == null)
            {
                return NotFound();
            }

            var tipoIntercambio = await _context.TipoIntercambio.FindAsync(id);
            if (tipoIntercambio == null)
            {
                return NotFound();
            }
            return View(tipoIntercambio);
        }

        // POST: TipoIntercambio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoIntercambioDescricao")] TipoIntercambio tipoIntercambio)
        {
            if (id != tipoIntercambio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIntercambio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIntercambioExists(tipoIntercambio.Id))
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
            return View(tipoIntercambio);
        }

        // GET: TipoIntercambio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoIntercambio == null)
            {
                return NotFound();
            }

            var tipoIntercambio = await _context.TipoIntercambio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoIntercambio == null)
            {
                return NotFound();
            }

            return View(tipoIntercambio);
        }

        // POST: TipoIntercambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoIntercambio == null)
            {
                return Problem("Entity set 'Contexto.TipoIntercambio'  is null.");
            }
            var tipoIntercambio = await _context.TipoIntercambio.FindAsync(id);
            if (tipoIntercambio != null)
            {
                _context.TipoIntercambio.Remove(tipoIntercambio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIntercambioExists(int id)
        {
          return (_context.TipoIntercambio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
