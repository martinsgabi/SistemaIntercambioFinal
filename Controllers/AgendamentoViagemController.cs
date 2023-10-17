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
    public class AgendamentoViagemController : Controller
    {
        private readonly Contexto _context;

        public AgendamentoViagemController(Contexto context)
        {
            _context = context;
        }

        // GET: AgendamentoViagem
        public async Task<IActionResult> Index()
        {
            var contexto = _context.AgendamentoViagem.Include(a => a.CompanhiaAerea);
            return View(await contexto.ToListAsync());
        }

        // GET: AgendamentoViagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AgendamentoViagem == null)
            {
                return NotFound();
            }

            var agendamentoViagem = await _context.AgendamentoViagem
                .Include(a => a.CompanhiaAerea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoViagem == null)
            {
                return NotFound();
            }

            return View(agendamentoViagem);
        }

        // GET: AgendamentoViagem/Create
        public IActionResult Create()
        {
            ViewData["CompanhiaAereaId"] = new SelectList(_context.CompanhiaAerea, "Id", "Id");
            return View();
        }

        // POST: AgendamentoViagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataAgendamentoViagem,HoraAgendamentoViagem,CompanhiaAereaId")] AgendamentoViagem agendamentoViagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamentoViagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanhiaAereaId"] = new SelectList(_context.CompanhiaAerea, "Id", "Id", agendamentoViagem.CompanhiaAereaId);
            return View(agendamentoViagem);
        }

        // GET: AgendamentoViagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AgendamentoViagem == null)
            {
                return NotFound();
            }

            var agendamentoViagem = await _context.AgendamentoViagem.FindAsync(id);
            if (agendamentoViagem == null)
            {
                return NotFound();
            }
            ViewData["CompanhiaAereaId"] = new SelectList(_context.CompanhiaAerea, "Id", "Id", agendamentoViagem.CompanhiaAereaId);
            return View(agendamentoViagem);
        }

        // POST: AgendamentoViagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataAgendamentoViagem,HoraAgendamentoViagem,CompanhiaAereaId")] AgendamentoViagem agendamentoViagem)
        {
            if (id != agendamentoViagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamentoViagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoViagemExists(agendamentoViagem.Id))
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
            ViewData["CompanhiaAereaId"] = new SelectList(_context.CompanhiaAerea, "Id", "Id", agendamentoViagem.CompanhiaAereaId);
            return View(agendamentoViagem);
        }

        // GET: AgendamentoViagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AgendamentoViagem == null)
            {
                return NotFound();
            }

            var agendamentoViagem = await _context.AgendamentoViagem
                .Include(a => a.CompanhiaAerea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoViagem == null)
            {
                return NotFound();
            }

            return View(agendamentoViagem);
        }

        // POST: AgendamentoViagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AgendamentoViagem == null)
            {
                return Problem("Entity set 'Contexto.AgendamentoViagem'  is null.");
            }
            var agendamentoViagem = await _context.AgendamentoViagem.FindAsync(id);
            if (agendamentoViagem != null)
            {
                _context.AgendamentoViagem.Remove(agendamentoViagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoViagemExists(int id)
        {
          return (_context.AgendamentoViagem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
