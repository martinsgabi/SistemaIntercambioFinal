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
    public class CompanhiaAereaController : Controller
    {
        private readonly Contexto _context;

        public CompanhiaAereaController(Contexto context)
        {
            _context = context;
        }

        // GET: CompanhiaAerea
        public async Task<IActionResult> Index()
        {
              return _context.CompanhiaAerea != null ? 
                          View(await _context.CompanhiaAerea.ToListAsync()) :
                          Problem("Entity set 'Contexto.CompanhiaAerea'  is null.");
        }

        // GET: CompanhiaAerea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompanhiaAerea == null)
            {
                return NotFound();
            }

            var companhiaAerea = await _context.CompanhiaAerea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companhiaAerea == null)
            {
                return NotFound();
            }

            return View(companhiaAerea);
        }

        // GET: CompanhiaAerea/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanhiaAerea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanhiaAereaDescricao")] CompanhiaAerea companhiaAerea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companhiaAerea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companhiaAerea);
        }

        // GET: CompanhiaAerea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompanhiaAerea == null)
            {
                return NotFound();
            }

            var companhiaAerea = await _context.CompanhiaAerea.FindAsync(id);
            if (companhiaAerea == null)
            {
                return NotFound();
            }
            return View(companhiaAerea);
        }

        // POST: CompanhiaAerea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanhiaAereaDescricao")] CompanhiaAerea companhiaAerea)
        {
            if (id != companhiaAerea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companhiaAerea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanhiaAereaExists(companhiaAerea.Id))
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
            return View(companhiaAerea);
        }

        // GET: CompanhiaAerea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompanhiaAerea == null)
            {
                return NotFound();
            }

            var companhiaAerea = await _context.CompanhiaAerea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companhiaAerea == null)
            {
                return NotFound();
            }

            return View(companhiaAerea);
        }

        // POST: CompanhiaAerea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CompanhiaAerea == null)
            {
                return Problem("Entity set 'Contexto.CompanhiaAerea'  is null.");
            }
            var companhiaAerea = await _context.CompanhiaAerea.FindAsync(id);
            if (companhiaAerea != null)
            {
                _context.CompanhiaAerea.Remove(companhiaAerea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanhiaAereaExists(int id)
        {
          return (_context.CompanhiaAerea?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
