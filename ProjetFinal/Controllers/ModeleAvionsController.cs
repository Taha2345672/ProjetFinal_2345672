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
    public class ModeleAvionsController : Controller
    {
        private readonly AviationDBContext _context;

        public ModeleAvionsController(AviationDBContext context)
        {
            _context = context;
        }

        // GET: ModeleAvions
        public async Task<IActionResult> Index()
        {
            var aviationDBContext = _context.ModeleAvions.Include(m => m.Marque);
            return View(await aviationDBContext.ToListAsync());
        }

        // GET: ModeleAvions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModeleAvions == null)
            {
                return NotFound();
            }

            var modeleAvion = await _context.ModeleAvions
                .Include(m => m.Marque)
                .FirstOrDefaultAsync(m => m.ModeleAvionId == id);
            if (modeleAvion == null)
            {
                return NotFound();
            }

            return View(modeleAvion);
        }

        // GET: ModeleAvions/Create
        public IActionResult Create()
        {
            ViewData["MarqueId"] = new SelectList(_context.Marques, "MarqueId", "MarqueId");
            return View();
        }

        // POST: ModeleAvions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModeleAvionId,MarqueId,NomModele,AnneeLancement,CapacitePassagers,Longueur")] ModeleAvion modeleAvion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeleAvion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarqueId"] = new SelectList(_context.Marques, "MarqueId", "MarqueId", modeleAvion.MarqueId);
            return View(modeleAvion);
        }

        // GET: ModeleAvions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModeleAvions == null)
            {
                return NotFound();
            }

            var modeleAvion = await _context.ModeleAvions.FindAsync(id);
            if (modeleAvion == null)
            {
                return NotFound();
            }
            ViewData["MarqueId"] = new SelectList(_context.Marques, "MarqueId", "MarqueId", modeleAvion.MarqueId);
            return View(modeleAvion);
        }

        // POST: ModeleAvions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModeleAvionId,MarqueId,NomModele,AnneeLancement,CapacitePassagers,Longueur")] ModeleAvion modeleAvion)
        {
            if (id != modeleAvion.ModeleAvionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeleAvion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeleAvionExists(modeleAvion.ModeleAvionId))
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
            ViewData["MarqueId"] = new SelectList(_context.Marques, "MarqueId", "MarqueId", modeleAvion.MarqueId);
            return View(modeleAvion);
        }

        // GET: ModeleAvions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModeleAvions == null)
            {
                return NotFound();
            }

            var modeleAvion = await _context.ModeleAvions
                .Include(m => m.Marque)
                .FirstOrDefaultAsync(m => m.ModeleAvionId == id);
            if (modeleAvion == null)
            {
                return NotFound();
            }

            return View(modeleAvion);
        }

        // POST: ModeleAvions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModeleAvions == null)
            {
                return Problem("Entity set 'AviationDBContext.ModeleAvions'  is null.");
            }
            var modeleAvion = await _context.ModeleAvions.FindAsync(id);
            if (modeleAvion != null)
            {
                _context.ModeleAvions.Remove(modeleAvion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeleAvionExists(int id)
        {
          return (_context.ModeleAvions?.Any(e => e.ModeleAvionId == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> VueNombreAvionsParMarque()
        {

            var vueNombreAvionsParMarque = await _context.VueNombreAvionsParMarques.ToListAsync();
            return View(vueNombreAvionsParMarque);
        }
    }
}
