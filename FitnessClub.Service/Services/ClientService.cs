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
    public class ClientService:IClientService
    {
        private PostgresContext context;
        public ClientService(PostgresContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            this.context = dbContext;
        }

        public Result CreateClient(Client client)
        {
            var result = new Result() { Success = true };

            try
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }

            return result;
        }

        public List<Client> GetClients()
        {
            var clientWithIncludings = context.Clients.Include(client => client.НазваниеgruppiNavigation);
                                                    
            return clientWithIncludings.ToList();
        }

        public Client? GetClientById(int id)
        {
            return context.Clients.Include(client => client.НазваниеgruppiNavigation)
                               .FirstOrDefault(order => order.Nomerabonimenta == id);
        }

        public Result UpdateClient(Client client)
        {
            var oldClient= context.Clients.Include(client => client.НазваниеgruppiNavigation)
                               .FirstOrDefault(c => c.Nomerabonimenta == client.Nomerabonimenta);
            if (oldClient == null)
                return new Result() { Success = false, Message = $"Client with id = {client.Nomerabonimenta} doesn't exists" };

            

            oldClient.Fio = client.Fio;
            oldClient.Dataroshdenia = client.Dataroshdenia;
            oldClient.Pol = client.Pol;
            oldClient.Ves = client.Ves;
            oldClient.Rost = client.Rost;
            oldClient.Nashaloabonimenta = client.Nashaloabonimenta;
            oldClient.Okonshanie = client.Okonshanie;
            oldClient.Telephone = client.Telephone;
            oldClient.Названиеgruppi = client.Названиеgruppi;
            try
            {
                context.Clients.Update(oldClient);
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
