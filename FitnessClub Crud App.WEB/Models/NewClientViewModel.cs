using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessClub_Crud_App.WEB.Models
{
    public class NewClientViewModel
    {

        public string Fio { get; set; } = null!;
        public DateOnly? Dataroshdenia { get; set; }

        public string? Pol { get; set; }

        public int? Ves { get; set; }

        public int? Rost { get; set; }

        public DateOnly Nashaloabonimenta { get; set; }

        public DateOnly Okonshanie { get; set; }

        public string Telephone { get; set; } = null!;
        public string Названиеgruppi { get; set; } = null!;
        [ValidateNever]
        public List<SelectListItem> GruppaNames { get; set; }
    }
}
