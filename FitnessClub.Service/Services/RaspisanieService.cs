using FitnessClub.Domain.DTO;
using FitnessClub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.Service.Services
{
    public class RaspisanieService:IRaspisanieService
    {
        private readonly PostgresContext context;
        public RaspisanieService(PostgresContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            this.context = dbContext;
        }

        public Result CreateRaspisanie(Raspisanie raspisanie)
        {
            var result = new Result() { Success = true };

            try
            {
                context.Raspisanies.Add(raspisanie);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public List<Raspisanie> GetRaspisanies()
        {
            var raspisanieWithIncludings = context.Raspisanies.Include(r => r.НазваниеgruppiNavigation).Include(r=>r.IdentificatortrenerNavigation);

            return raspisanieWithIncludings.ToList();
        }

        public Raspisanie? GetRaspisanietById(int id)
        {
            return context.Raspisanies.Include(r => r.НазваниеgruppiNavigation)
                                .Include(r=>r.IdentificatortrenerNavigation)
                               .FirstOrDefault(r => r.Identificatorraspisania == id);
        }

        public Result UpdateRaspisanie(Raspisanie raspisanie)
        {
            var oldRaspisanie = context.Raspisanies.Include(r => r.НазваниеgruppiNavigation)
                                .Include(r => r.IdentificatortrenerNavigation)
                               .FirstOrDefault(r => r.Identificatorraspisania == raspisanie.Identificatorraspisania);
            if (oldRaspisanie == null)
                return new Result() { Success = false, Message = $"Client with id = {raspisanie.Identificatorraspisania} doesn't exists" };



            oldRaspisanie.Vidzanatii = raspisanie.Vidzanatii;
            oldRaspisanie.Zal = raspisanie.Zal;
            oldRaspisanie.Nachalozanatii = raspisanie.Nachalozanatii;
            oldRaspisanie.Prodolshitelnost = raspisanie.Prodolshitelnost; 
            oldRaspisanie.Названиеgruppi = raspisanie.Названиеgruppi;
            oldRaspisanie.Identificatortrener = raspisanie.Identificatortrener;
            try
            {
                context.Raspisanies.Update(oldRaspisanie);
                context.SaveChanges();

                return new Result() { Success = true };
            }
            catch (Exception e)
            {
                return new Result()
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
