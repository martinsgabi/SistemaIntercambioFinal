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
    public class DestinoIntercambioController : Controller
    {
        private readonly Contexto _context;

        public DestinoIntercambioController(Contexto context)
        {
            _context = context;
        }

        // GET: DestinoIntercambio
        public async Task<IActionResult> Index()
        {
              return _context.DestinoIntercambio != null ? 
                          View(await _context.DestinoIntercambio.ToListAsync()) :
                          Problem("Entity set 'Contexto.DestinoIntercambio'  is null.");
        }

        // GET: DestinoIntercambio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DestinoIntercambio == null)
            {
                return NotFound();
            }

            var destinoIntercambio = await _context.DestinoIntercambio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinoIntercambio == null)
            {
                return NotFound();
            }

            return View(destinoIntercambio);
        }

        // GET: DestinoIntercambio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DestinoIntercambio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DestinoIntercambioDescricao")] DestinoIntercambio destinoIntercambio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinoIntercambio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinoIntercambio);
        }

        // GET: DestinoIntercambio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DestinoIntercambio == null)
            {
                return NotFound();
            }

            var destinoIntercambio = await _context.DestinoIntercambio.FindAsync(id);
            if (destinoIntercambio == null)
            {
                return NotFound();
            }
            return View(destinoIntercambio);
        }

        // POST: DestinoIntercambio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DestinoIntercambioDescricao")] DestinoIntercambio destinoIntercambio)
        {
            if (id != destinoIntercambio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinoIntercambio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoIntercambioExists(destinoIntercambio.Id))
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
            return View(destinoIntercambio);
        }

        // GET: DestinoIntercambio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DestinoIntercambio == null)
            {
                return NotFound();
            }

            var destinoIntercambio = await _context.DestinoIntercambio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinoIntercambio == null)
            {
                return NotFound();
            }

            return View(destinoIntercambio);
        }

        // POST: DestinoIntercambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DestinoIntercambio == null)
            {
                return Problem("Entity set 'Contexto.DestinoIntercambio'  is null.");
            }
            var destinoIntercambio = await _context.DestinoIntercambio.FindAsync(id);
            if (destinoIntercambio != null)
            {
                _context.DestinoIntercambio.Remove(destinoIntercambio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoIntercambioExists(int id)
        {
          return (_context.DestinoIntercambio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
