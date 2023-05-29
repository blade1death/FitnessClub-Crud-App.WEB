using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessClub_Crud_App.WEB.Models
{
    public class ClientViewModel
    {
        public int Nomerabonimenta { get; set; }
        public string Fio { get; set; } = null!;
        public DateOnly? Dataroshdenia { get; set; }

        public string? Pol { get; set; }

        public int? Ves { get; set; }

        public int? Rost { get; set; }

        public DateOnly Nashaloabonimenta { get; set; }

        public DateOnly Okonshanie { get; set; }

        public string Telephone { get; set; } = null!;
        public string GruppaNames { get; set; }
    }
}
