using FitnessClub.Domain.DTO;
using Microsoft.Extensions.Hosting;

namespace FitnessClub_Crud_App.WEB.Models
{
    public class ClientsViewModel
    {
        public ClientViewModel[] Clients { get; init; }
        public ClientsViewModel(List<Client> clientEntity)
        {
            Clients = clientEntity.Select(e => new ClientViewModel()
            {
                Nomerabonimenta=e.Nomerabonimenta,
                Fio=e.Fio,
                Dataroshdenia=e.Dataroshdenia,
                Pol=e.Pol,
                Ves=e.Ves,
                Rost=e.Rost,
                Nashaloabonimenta=e.Nashaloabonimenta,
                Okonshanie = e.Okonshanie,
                Telephone = e.Telephone,
                GruppaNames=e.НазваниеgruppiNavigation.Названиеgruppi
            }).ToArray();
        }
    }
}
