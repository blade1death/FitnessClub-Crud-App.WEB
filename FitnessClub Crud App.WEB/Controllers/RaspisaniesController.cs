using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Domain.DTO;
using FitnessClub.Service.Interfaces;
using FitnessClub.Service.Services;
using FitnessClub_Crud_App.WEB.Models;

namespace FitnessClub_Crud_App.WEB.Controllers
{
    public class RaspisaniesController : Controller
    {
        private readonly PostgresContext _context;
        private readonly IGruppaService GruppaService;
        private readonly ITrenerService TrenerService;
        private readonly IRaspisanieService RaspisanieService;


        public RaspisaniesController(PostgresContext context, IGruppaService gruppaService, ITrenerService trenerService, IRaspisanieService raspisanieService)
        {
            ArgumentNullException.ThrowIfNull(gruppaService, nameof(gruppaService));
            ArgumentNullException.ThrowIfNull(trenerService, nameof(trenerService));
            ArgumentNullException.ThrowIfNull(raspisanieService, nameof(raspisanieService));
            _context = context;
            GruppaService = gruppaService;
            TrenerService= trenerService;
            RaspisanieService = raspisanieService;
        }

        // GET: Raspisanies
        public async Task<IActionResult> Index()
        {
            var postgresContext = _context.Raspisanies.Include(r => r.IdentificatortrenerNavigation).Include(r => r.НазваниеgruppiNavigation);
            return View(await postgresContext.ToListAsync());
        }

        // GET: Raspisanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Raspisanies == null)
            {
                return NotFound();
            }

            var raspisanie = await _context.Raspisanies
                .Include(r => r.IdentificatortrenerNavigation)
                .Include(r => r.НазваниеgruppiNavigation)
                .FirstOrDefaultAsync(m => m.Identificatorraspisania == id);
            if (raspisanie == null)
            {
                return NotFound();
            }

            return View(raspisanie);
        }

        // GET: Raspisanies/Create
        public IActionResult Create()
        {
            var model = new NewRaspisanieViewModel
            {
                GruppaNames = GetGruppaNameSelectList(GruppaService),
                TrenerFio= GetTrenerFioNameSelectList(TrenerService)
            };
            return View(model);
        }

        // POST: Raspisanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] NewRaspisanieViewModel model)
        {
            model.GruppaNames = GetGruppaNameSelectList(GruppaService);
            model.TrenerFio = GetTrenerFioNameSelectList(TrenerService);
            if (!ModelState.IsValid)
                return View(model);
            var result = RaspisanieService.CreateRaspisanie(new Raspisanie()
            {

                Vidzanatii = model.Vidzanatii,
                Zal = model.Zal,
                Nachalozanatii = model.Nachalozanatii,
                Prodolshitelnost = model.Prodolshitelnost,
                Названиеgruppi = model.Названиеgruppi,
                Identificatortrener = model.Identificatortrener
                
                
            });
            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        // GET: Raspisanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Raspisanies == null)
            {
                return NotFound();
            }

            var raspisanie = await _context.Raspisanies.FindAsync(id);
            if (raspisanie == null)
            {
                return NotFound();
            }
            ViewData["Identificatortrener"] = new SelectList(_context.Treners, "Identificatortrener", "Dolshnost", raspisanie.Identificatortrener);
            ViewData["Названиеgruppi"] = new SelectList(_context.Gruppas, "Названиеgruppi", "Названиеgruppi", raspisanie.Названиеgruppi);
            return View(raspisanie);
        }

        // POST: Raspisanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificatorraspisania,Vidzanatii,Zal,Nachalozanatii,Prodolshitelnost,Названиеgruppi,Identificatortrener")] Raspisanie raspisanie)
        {
            if (id != raspisanie.Identificatorraspisania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raspisanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaspisanieExists(raspisanie.Identificatorraspisania))
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
            ViewData["Identificatortrener"] = new SelectList(_context.Treners, "Identificatortrener", "Dolshnost", raspisanie.Identificatortrener);
            ViewData["Названиеgruppi"] = new SelectList(_context.Gruppas, "Названиеgruppi", "Названиеgruppi", raspisanie.Названиеgruppi);
            return View(raspisanie);
        }

        // GET: Raspisanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Raspisanies == null)
            {
                return NotFound();
            }

            var raspisanie = await _context.Raspisanies
                .Include(r => r.IdentificatortrenerNavigation)
                .Include(r => r.НазваниеgruppiNavigation)
                .FirstOrDefaultAsync(m => m.Identificatorraspisania == id);
            if (raspisanie == null)
            {
                return NotFound();
            }

            return View(raspisanie);
        }

        // POST: Raspisanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Raspisanies == null)
            {
                return Problem("Entity set 'PostgresContext.Raspisanies'  is null.");
            }
            var raspisanie = await _context.Raspisanies.FindAsync(id);
            if (raspisanie != null)
            {
                _context.Raspisanies.Remove(raspisanie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private static List<SelectListItem> GetGruppaNameSelectList(IGruppaService service)
        {
            var gruppa = service.GetGruppas();
            return gruppa.Select(gruppa => new SelectListItem(gruppa.Названиеgruppi, gruppa.Названиеgruppi.ToString())).ToList();
        }
        private static List<SelectListItem> GetTrenerFioNameSelectList(ITrenerService service)
        {
            var trenerFio = service.GetTreners();
            return trenerFio.Select(t => new SelectListItem(t.Fio, t.Identificatortrener.ToString())).ToList();
        }
        private bool RaspisanieExists(int id)
        {
          return (_context.Raspisanies?.Any(e => e.Identificatorraspisania == id)).GetValueOrDefault();
        }
    }
}
