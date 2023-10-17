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
    public class AgendamentoProfissionalController : Controller
    {
        private readonly Contexto _context;

        public AgendamentoProfissionalController(Contexto context)
        {
            _context = context;
        }

        // GET: AgendamentoProfissional
        public async Task<IActionResult> Index()
        {
              return _context.AgendamentoProfissional != null ? 
                          View(await _context.AgendamentoProfissional.ToListAsync()) :
                          Problem("Entity set 'Contexto.AgendamentoProfissional'  is null.");
        }

        // GET: AgendamentoProfissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AgendamentoProfissional == null)
            {
                return NotFound();
            }

            var agendamentoProfissional = await _context.AgendamentoProfissional
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoProfissional == null)
            {
                return NotFound();
            }

            return View(agendamentoProfissional);
        }

        // GET: AgendamentoProfissional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgendamentoProfissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataAgendamento,HoraAgendamento")] AgendamentoProfissional agendamentoProfissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamentoProfissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agendamentoProfissional);
        }

        // GET: AgendamentoProfissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AgendamentoProfissional == null)
            {
                return NotFound();
            }

            var agendamentoProfissional = await _context.AgendamentoProfissional.FindAsync(id);
            if (agendamentoProfissional == null)
            {
                return NotFound();
            }
            return View(agendamentoProfissional);
        }

        // POST: AgendamentoProfissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataAgendamento,HoraAgendamento")] AgendamentoProfissional agendamentoProfissional)
        {
            if (id != agendamentoProfissional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamentoProfissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoProfissionalExists(agendamentoProfissional.Id))
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
            return View(agendamentoProfissional);
        }

        // GET: AgendamentoProfissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AgendamentoProfissional == null)
            {
                return NotFound();
            }

            var agendamentoProfissional = await _context.AgendamentoProfissional
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoProfissional == null)
            {
                return NotFound();
            }

            return View(agendamentoProfissional);
        }

        // POST: AgendamentoProfissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AgendamentoProfissional == null)
            {
                return Problem("Entity set 'Contexto.AgendamentoProfissional'  is null.");
            }
            var agendamentoProfissional = await _context.AgendamentoProfissional.FindAsync(id);
            if (agendamentoProfissional != null)
            {
                _context.AgendamentoProfissional.Remove(agendamentoProfissional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoProfissionalExists(int id)
        {
          return (_context.AgendamentoProfissional?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
