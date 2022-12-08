using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DOCENTESCRUD.Models;

namespace DOCENTESCRUD.Controllers
{
    public class ModulosController : Controller
    {
        private readonly DocentesContext _context;

        public ModulosController(DocentesContext context)
        {
            _context = context;
        }

        // GET: Modulos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Modulos.ToListAsync());
        }

        // GET: Modulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulos
                .FirstOrDefaultAsync(m => m.IdModulo == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // GET: Modulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdModulo,Programa,NombreModulo,Creditos,Precio")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modulo);
        }

        // GET: Modulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }
            return View(modulo);
        }

        // POST: Modulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdModulo,Programa,NombreModulo,Creditos,Precio")] Modulo modulo)
        {
            if (id != modulo.IdModulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuloExists(modulo.IdModulo))
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
            return View(modulo);
        }

        // GET: Modulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modulos == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulos
                .FirstOrDefaultAsync(m => m.IdModulo == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // POST: Modulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modulos == null)
            {
                return Problem("Entity set 'DocentesContext.Modulos'  is null.");
            }
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo != null)
            {
                _context.Modulos.Remove(modulo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuloExists(int id)
        {
          return _context.Modulos.Any(e => e.IdModulo == id);
        }
    }
}
