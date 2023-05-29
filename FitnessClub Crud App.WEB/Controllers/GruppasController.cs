using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Domain.DTO;

namespace FitnessClub_Crud_App.WEB.Controllers
{
    public class GruppasController : Controller
    {
        private readonly PostgresContext _context;

        public GruppasController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Gruppas
        public async Task<IActionResult> Index()
        {
              return _context.Gruppas != null ? 
                          View(await _context.Gruppas.ToListAsync()) :
                          Problem("Entity set 'PostgresContext.Gruppas'  is null.");
        }

        // GET: Gruppas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Gruppas == null)
            {
                return NotFound();
            }

            var gruppa = await _context.Gruppas
                .FirstOrDefaultAsync(m => m.Названиеgruppi == id);
            if (gruppa == null)
            {
                return NotFound();
            }

            return View(gruppa);
        }

        // GET: Gruppas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gruppas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Названиеgruppi,Примечание")] Gruppa gruppa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gruppa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gruppa);
        }

        // GET: Gruppas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Gruppas == null)
            {
                return NotFound();
            }

            var gruppa = await _context.Gruppas.FindAsync(id);
            if (gruppa == null)
            {
                return NotFound();
            }
            return View(gruppa);
        }

        // POST: Gruppas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Названиеgruppi,Примечание")] Gruppa gruppa)
        {
            if (id != gruppa.Названиеgruppi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gruppa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruppaExists(gruppa.Названиеgruppi))
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
            return View(gruppa);
        }

        // GET: Gruppas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Gruppas == null)
            {
                return NotFound();
            }

            var gruppa = await _context.Gruppas
                .FirstOrDefaultAsync(m => m.Названиеgruppi == id);
            if (gruppa == null)
            {
                return NotFound();
            }

            return View(gruppa);
        }

        // POST: Gruppas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Gruppas == null)
            {
                return Problem("Entity set 'PostgresContext.Gruppas'  is null.");
            }
            var gruppa = await _context.Gruppas.FindAsync(id);
            if (gruppa != null)
            {
                _context.Gruppas.Remove(gruppa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GruppaExists(string id)
        {
          return (_context.Gruppas?.Any(e => e.Названиеgruppi == id)).GetValueOrDefault();
        }
    }
}
