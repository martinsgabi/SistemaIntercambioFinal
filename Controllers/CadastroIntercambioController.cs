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
    public class CadastroIntercambioController : Controller
    {
        private readonly Contexto _context;

        public CadastroIntercambioController(Contexto context)
        {
            _context = context;
        }

        // GET: CadastroIntercambio
        public async Task<IActionResult> Index()
        {
            var contexto = _context.CadastroIntercambio.Include(c => c.DestinoIntercambio).Include(c => c.DuracaoIntercambio).Include(c => c.TipoIntercambio);
            return View(await contexto.ToListAsync());
        }

        // GET: CadastroIntercambio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadastroIntercambio == null)
            {
                return NotFound();
            }

            var cadastroIntercambio = await _context.CadastroIntercambio
                .Include(c => c.DestinoIntercambio)
                .Include(c => c.DuracaoIntercambio)
                .Include(c => c.TipoIntercambio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroIntercambio == null)
            {
                return NotFound();
            }

            return View(cadastroIntercambio);
        }

        // GET: CadastroIntercambio/Create
        public IActionResult Create()
        {
            ViewData["DestinoIntercambioId"] = new SelectList(_context.DestinoIntercambio, "Id", "DestinoIntercambioDescricao");
            ViewData["DuracaoIntercambioId"] = new SelectList(_context.DuracaoIntercambio, "Id", "DuracaoIntercambioDescricao");
            ViewData["TipoIntercambioId"] = new SelectList(_context.TipoIntercambio, "Id", "TipoIntercambioDescricao");
            return View();
        }

        // POST: CadastroIntercambio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DestinoIntercambioId,TipoIntercambioId,DuracaoIntercambioId")] CadastroIntercambio cadastroIntercambio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroIntercambio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoIntercambioId"] = new SelectList(_context.DestinoIntercambio, "Id", "DestinoIntercambioDescricao", cadastroIntercambio.DestinoIntercambioId);
            ViewData["DuracaoIntercambioId"] = new SelectList(_context.DuracaoIntercambio, "Id", "DuracaoIntercambioDescricao", cadastroIntercambio.DuracaoIntercambioId);
            ViewData["TipoIntercambioId"] = new SelectList(_context.TipoIntercambio, "Id", "TipoIntercambioDescricao", cadastroIntercambio.TipoIntercambioId);
            return View(cadastroIntercambio);
        }

        // GET: CadastroIntercambio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadastroIntercambio == null)
            {
                return NotFound();
            }

            var cadastroIntercambio = await _context.CadastroIntercambio.FindAsync(id);
            if (cadastroIntercambio == null)
            {
                return NotFound();
            }
            ViewData["DestinoIntercambioId"] = new SelectList(_context.DestinoIntercambio, "Id", "DestinoIntercambioDescricao", cadastroIntercambio.DestinoIntercambioId);
            ViewData["DuracaoIntercambioId"] = new SelectList(_context.DuracaoIntercambio, "Id", "DuracaoIntercambioDescricao", cadastroIntercambio.DuracaoIntercambioId);
            ViewData["TipoIntercambioId"] = new SelectList(_context.TipoIntercambio, "Id", "TipoIntercambioDescricao", cadastroIntercambio.TipoIntercambioId);
            return View(cadastroIntercambio);
        }

        // POST: CadastroIntercambio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DestinoIntercambioId,TipoIntercambioId,DuracaoIntercambioId")] CadastroIntercambio cadastroIntercambio)
        {
            if (id != cadastroIntercambio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroIntercambio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroIntercambioExists(cadastroIntercambio.Id))
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
            ViewData["DestinoIntercambioId"] = new SelectList(_context.DestinoIntercambio, "Id", "DestinoIntercambioDescricao", cadastroIntercambio.DestinoIntercambioId);
            ViewData["DuracaoIntercambioId"] = new SelectList(_context.DuracaoIntercambio, "Id", "DuracaoIntercambioDescricao", cadastroIntercambio.DuracaoIntercambioId);
            ViewData["TipoIntercambioId"] = new SelectList(_context.TipoIntercambio, "Id", "TipoIntercambioDescricao", cadastroIntercambio.TipoIntercambioId);
            return View(cadastroIntercambio);
        }

        // GET: CadastroIntercambio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadastroIntercambio == null)
            {
                return NotFound();
            }

            var cadastroIntercambio = await _context.CadastroIntercambio
                .Include(c => c.DestinoIntercambio)
                .Include(c => c.DuracaoIntercambio)
                .Include(c => c.TipoIntercambio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroIntercambio == null)
            {
                return NotFound();
            }

            return View(cadastroIntercambio);
        }

        // POST: CadastroIntercambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadastroIntercambio == null)
            {
                return Problem("Entity set 'Contexto.CadastroIntercambio'  is null.");
            }
            var cadastroIntercambio = await _context.CadastroIntercambio.FindAsync(id);
            if (cadastroIntercambio != null)
            {
                _context.CadastroIntercambio.Remove(cadastroIntercambio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroIntercambioExists(int id)
        {
          return (_context.CadastroIntercambio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
