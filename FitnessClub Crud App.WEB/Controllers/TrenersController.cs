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
    public class TrenersController : Controller
    {
        private readonly PostgresContext _context;

        public TrenersController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Treners
        public async Task<IActionResult> Index()
        {
              return _context.Treners != null ? 
                          View(await _context.Treners.ToListAsync()) :
                          Problem("Entity set 'PostgresContext.Treners'  is null.");
        }

        // GET: Treners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Treners == null)
            {
                return NotFound();
            }

            var trener = await _context.Treners
                .FirstOrDefaultAsync(m => m.Identificatortrener == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }

        // GET: Treners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dolshnost,Identificatortrener,Fio,Telephone")] Trener trener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trener);
        }

        // GET: Treners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Treners == null)
            {
                return NotFound();
            }

            var trener = await _context.Treners.FindAsync(id);
            if (trener == null)
            {
                return NotFound();
            }
            return View(trener);
        }

        // POST: Treners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dolshnost,Identificatortrener,Fio,Telephone")] Trener trener)
        {
            if (id != trener.Identificatortrener)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrenerExists(trener.Identificatortrener))
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
            return View(trener);
        }

        // GET: Treners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Treners == null)
            {
                return NotFound();
            }

            var trener = await _context.Treners
                .FirstOrDefaultAsync(m => m.Identificatortrener == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }

        // POST: Treners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Treners == null)
            {
                return Problem("Entity set 'PostgresContext.Treners'  is null.");
            }
            var trener = await _context.Treners.FindAsync(id);
            if (trener != null)
            {
                _context.Treners.Remove(trener);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrenerExists(int id)
        {
          return (_context.Treners?.Any(e => e.Identificatortrener == id)).GetValueOrDefault();
        }
    }
}
