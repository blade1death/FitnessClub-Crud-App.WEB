using FitnessClub.Domain.DTO;

namespace FitnessClub_Crud_App.WEB.Models
{
    public class RaspisaniesViewModel
    {
        public RaspisanieViewModel[] Raspisanie { get; init; }
        public RaspisaniesViewModel(List<Raspisanie> raspisanieEntity)
        { 
            Raspisanie=raspisanieEntity.Select(e=> new RaspisanieViewModel()
            {
                Identificatorraspisania=e.Identificatorraspisania,
                Vidzanatii=e.Vidzanatii,
                Zal=e.Zal,
                Nachalozanatii=e.Nachalozanatii,
                Prodolshitelnost = e.Prodolshitelnost,
                Названиеgruppi=e.НазваниеgruppiNavigation.Названиеgruppi,
                FioTrener=e.IdentificatortrenerNavigation.Fio

            }).ToArray();
        }
    }
}
