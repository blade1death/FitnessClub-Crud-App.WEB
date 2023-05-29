using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessClub_Crud_App.WEB.Models
{
    public class NewRaspisanieViewModel
    {
        public string Vidzanatii { get; set; } = null!;

        public string? Zal { get; set; }

        public DateOnly Nachalozanatii { get; set; }

        public int Prodolshitelnost { get; set; }

        public string Названиеgruppi { get; set; } = null!;
        public int Identificatortrener { get; set; }
        [ValidateNever]
        public List<SelectListItem> GruppaNames { get; set; }
        [ValidateNever]
        public List<SelectListItem> TrenerFio { get; set; }
    }
}
