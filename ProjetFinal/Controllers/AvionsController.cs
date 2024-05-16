using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Data;
using ProjetFinal.Models;

namespace ProjetFinal.Controllers
{
    public class AvionsController : Controller
    {
        private readonly AviationDBContext _context;

        public AvionsController(AviationDBContext context)
        {
            _context = context;
        }

        // GET: Avions
        public async Task<IActionResult> Index()
        {
            var aviationDBContext = _context.Avions.Include(a => a.ModeleAvion).Include(a => a.Performance);
            return View(await aviationDBContext.ToListAsync());
        }

        // GET: Avions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Avions == null)
            {
                return NotFound();
            }

            var avion = await _context.Avions
                .Include(a => a.ModeleAvion)
                .Include(a => a.Performance)
                .FirstOrDefaultAsync(m => m.AvionId == id);
            if (avion == null)
            {
                return NotFound();
            }

            return View(avion);
        }

        // GET: Avions/Create
        public IActionResult Create()
        {
            ViewData["ModeleAvionId"] = new SelectList(_context.ModeleAvions, "ModeleAvionId", "ModeleAvionId");
            ViewData["PerformanceId"] = new SelectList(_context.Performances, "PerformanceId", "PerformanceId");
            return View();
        }

        // POST: Avions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvionId,ModeleAvionId,PerformanceId,Nom,DateFabrication,Poids")] Avion avion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModeleAvionId"] = new SelectList(_context.ModeleAvions, "ModeleAvionId", "ModeleAvionId", avion.ModeleAvionId);
            ViewData["PerformanceId"] = new SelectList(_context.Performances, "PerformanceId", "PerformanceId", avion.PerformanceId);
            return View(avion);
        }

        // GET: Avions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Avions == null)
            {
                return NotFound();
            }

            var avion = await _context.Avions.FindAsync(id);
            if (avion == null)
            {
                return NotFound();
            }
            ViewData["ModeleAvionId"] = new SelectList(_context.ModeleAvions, "ModeleAvionId", "ModeleAvionId", avion.ModeleAvionId);
            ViewData["PerformanceId"] = new SelectList(_context.Performances, "PerformanceId", "PerformanceId", avion.PerformanceId);
            return View(avion);
        }

        // POST: Avions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvionId,ModeleAvionId,PerformanceId,Nom,DateFabrication,Poids")] Avion avion)
        {
            if (id != avion.AvionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvionExists(avion.AvionId))
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
            ViewData["ModeleAvionId"] = new SelectList(_context.ModeleAvions, "ModeleAvionId", "ModeleAvionId", avion.ModeleAvionId);
            ViewData["PerformanceId"] = new SelectList(_context.Performances, "PerformanceId", "PerformanceId", avion.PerformanceId);
            return View(avion);
        }

        // GET: Avions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Avions == null)
            {
                return NotFound();
            }

            var avion = await _context.Avions
                .Include(a => a.ModeleAvion)
                .Include(a => a.Performance)
                .FirstOrDefaultAsync(m => m.AvionId == id);
            if (avion == null)
            {
                return NotFound();
            }

            return View(avion);
        }

        // POST: Avions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Avions == null)
            {
                return Problem("Entity set 'AviationDBContext.Avions'  is null.");
            }
            var avion = await _context.Avions.FindAsync(id);
            if (avion != null)
            {
                _context.Avions.Remove(avion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvionExists(int id)
        {
          return (_context.Avions?.Any(e => e.AvionId == id)).GetValueOrDefault();
        }
    }
}
