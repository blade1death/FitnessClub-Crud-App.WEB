using FitnessClub.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.Service.Interfaces
{
    public interface IClientService
    {
        public Client? GetClientById(int id);
        public Result CreateClient (Client client);
        public Result UpdateClient(Client client);
        public List<Client> GetClients();
    }
}
