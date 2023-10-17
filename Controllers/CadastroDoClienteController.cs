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
    public class CadastroDoClienteController : Controller
    {
        private readonly Contexto _context;

        public CadastroDoClienteController(Contexto context)
        {
            _context = context;
        }

        // GET: CadastroDoCliente
        public async Task<IActionResult> Index()
        {
              return _context.CadastroDoCliente != null ? 
                          View(await _context.CadastroDoCliente.ToListAsync()) :
                          Problem("Entity set 'Contexto.CadastroDoCliente'  is null.");
        }

        // GET: CadastroDoCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadastroDoCliente == null)
            {
                return NotFound();
            }

            var cadastroDoCliente = await _context.CadastroDoCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroDoCliente == null)
            {
                return NotFound();
            }

            return View(cadastroDoCliente);
        }

        // GET: CadastroDoCliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroDoCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompletoCliente,IdadeCliente,DataDeNascimentoCliente,EmailCliente,CpfCliente,RgCliente,TelefoneCliente,SexoCliente")] CadastroDoCliente cadastroDoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroDoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroDoCliente);
        }

        // GET: CadastroDoCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadastroDoCliente == null)
            {
                return NotFound();
            }

            var cadastroDoCliente = await _context.CadastroDoCliente.FindAsync(id);
            if (cadastroDoCliente == null)
            {
                return NotFound();
            }
            return View(cadastroDoCliente);
        }

        // POST: CadastroDoCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompletoCliente,IdadeCliente,DataDeNascimentoCliente,EmailCliente,CpfCliente,RgCliente,TelefoneCliente,SexoCliente")] CadastroDoCliente cadastroDoCliente)
        {
            if (id != cadastroDoCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroDoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroDoClienteExists(cadastroDoCliente.Id))
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
            return View(cadastroDoCliente);
        }

        // GET: CadastroDoCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadastroDoCliente == null)
            {
                return NotFound();
            }

            var cadastroDoCliente = await _context.CadastroDoCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroDoCliente == null)
            {
                return NotFound();
            }

            return View(cadastroDoCliente);
        }

        // POST: CadastroDoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadastroDoCliente == null)
            {
                return Problem("Entity set 'Contexto.CadastroDoCliente'  is null.");
            }
            var cadastroDoCliente = await _context.CadastroDoCliente.FindAsync(id);
            if (cadastroDoCliente != null)
            {
                _context.CadastroDoCliente.Remove(cadastroDoCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroDoClienteExists(int id)
        {
          return (_context.CadastroDoCliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
