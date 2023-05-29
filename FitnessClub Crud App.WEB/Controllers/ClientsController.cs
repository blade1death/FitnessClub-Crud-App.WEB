using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Domain.DTO;
using FitnessClub.Service.Interfaces;
using FitnessClub_Crud_App.WEB.Models;

namespace FitnessClub_Crud_App.WEB.Controllers
{
    public class ClientsController : Controller
    {
        private readonly PostgresContext _context;
        private readonly IGruppaService GruppaService;
        private readonly IClientService ClientService;

        public ClientsController(PostgresContext context,  IGruppaService gruppaService, IClientService clientService)
        {
            ArgumentNullException.ThrowIfNull(gruppaService, nameof(gruppaService));
            ArgumentNullException.ThrowIfNull(clientService, nameof(clientService));
            _context = context;
            GruppaService = gruppaService;
            ClientService = clientService;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var postgresContext = _context.Clients.Include(c => c.НазваниеgruppiNavigation);
            return View(await postgresContext.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.НазваниеgruppiNavigation)
                .FirstOrDefaultAsync(m => m.Nomerabonimenta == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            var model = new NewClientViewModel
            {
                GruppaNames=GetGruppaNameSelectList(GruppaService)
            };
            return View(model);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] NewClientViewModel model)
        {
            model.GruppaNames = GetGruppaNameSelectList(GruppaService);
            if (!ModelState.IsValid)
                return View(model);
            var result = ClientService.CreateClient(new Client()
            {

                Fio = model.Fio,
                Dataroshdenia = model.Dataroshdenia,
                Pol = model.Pol,
                Ves = model.Ves,
                Rost = model.Rost,
                Nashaloabonimenta = model.Nashaloabonimenta,
                Okonshanie = model.Okonshanie,
                Telephone = model.Telephone,
                Названиеgruppi=model.Названиеgruppi
            });
            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = ClientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            var editClientViewModel = new EditClientViewModel()
            {
                Nomerabonimenta=client.Nomerabonimenta,
                Fio = client.Fio,
                Dataroshdenia = client.Dataroshdenia,
                Pol = client.Pol,
                Ves = client.Ves,
                Rost = client.Rost,
                Nashaloabonimenta = client.Nashaloabonimenta,
                Okonshanie = client.Okonshanie,
                Telephone = client.Telephone,
                Названиеgruppi = client.Названиеgruppi,
                GruppaNames= GetGruppaNameSelectList(GruppaService)
            };

            
            return View(editClientViewModel);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditClientViewModel client)
        {
            client.GruppaNames = GetGruppaNameSelectList(GruppaService);

            if (!ModelState.IsValid)
                return View(client);

            var result = ClientService.UpdateClient(new Client()
            {
                Nomerabonimenta = client.Nomerabonimenta,
                Fio = client.Fio,
                Dataroshdenia = client.Dataroshdenia,
                Pol = client.Pol,
                Ves = client.Ves,
                Rost = client.Rost,
                Nashaloabonimenta = client.Nashaloabonimenta,
                Okonshanie = client.Okonshanie,
                Telephone = client.Telephone,
                Названиеgruppi = client.Названиеgruppi,
            });

            if (!result.Success)
                ModelState.AddModelError("", result.Message);

            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.НазваниеgruppiNavigation)
                .FirstOrDefaultAsync(m => m.Nomerabonimenta == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'PostgresContext.Clients'  is null.");
            }
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private static List<SelectListItem> GetGruppaNameSelectList(IGruppaService service)
        {
            var gruppa = service.GetGruppas();
            return gruppa.Select(gruppa => new SelectListItem(gruppa.Названиеgruppi, gruppa.Названиеgruppi.ToString())).ToList();
        }
        private bool ClientExists(int id)
        {
          return (_context.Clients?.Any(e => e.Nomerabonimenta == id)).GetValueOrDefault();
        }
    }
}
