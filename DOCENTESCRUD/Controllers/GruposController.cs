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
    public class GruposController : Controller
    {
        private readonly DocentesContext _context;

        public GruposController(DocentesContext context)
        {
            _context = context;
        }

        // GET: Grupos
        public async Task<IActionResult> Index()
        {
            var docentesContext = _context.Grupos.Include(g => g.IdDocenteNavigation).Include(g => g.IdModuloNavigation);
            return View(await docentesContext.ToListAsync());
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdDocenteNavigation)
                .Include(g => g.IdModuloNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente");
            ViewData["IdModulo"] = new SelectList(_context.Modulos, "IdModulo", "IdModulo");
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,FechaInicio,NroEstudiantes,Jornada,IdModulo,IdDocente")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", grupo.IdDocente);
            ViewData["IdModulo"] = new SelectList(_context.Modulos, "IdModulo", "IdModulo", grupo.IdModulo);
            return View(grupo);
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", grupo.IdDocente);
            ViewData["IdModulo"] = new SelectList(_context.Modulos, "IdModulo", "IdModulo", grupo.IdModulo);
            return View(grupo);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,FechaInicio,NroEstudiantes,Jornada,IdModulo,IdDocente")] Grupo grupo)
        {
            if (id != grupo.IdGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.IdGrupo))
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
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", grupo.IdDocente);
            ViewData["IdModulo"] = new SelectList(_context.Modulos, "IdModulo", "IdModulo", grupo.IdModulo);
            return View(grupo);
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos
                .Include(g => g.IdDocenteNavigation)
                .Include(g => g.IdModuloNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grupos == null)
            {
                return Problem("Entity set 'DocentesContext.Grupos'  is null.");
            }
            var grupo = await _context.Grupos.FindAsync(id);
            if (grupo != null)
            {
                _context.Grupos.Remove(grupo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
          return _context.Grupos.Any(e => e.IdGrupo == id);
        }
    }
}
