namespace FitnessClub_Crud_App.WEB.Models
{
    public class RaspisanieViewModel
    {
        public int Identificatorraspisania { get; set; }

        public string Vidzanatii { get; set; } = null!;

        public string? Zal { get; set; }

        public DateOnly Nachalozanatii { get; set; }

        public int Prodolshitelnost { get; set; }

        public string Названиеgruppi { get; set; } = null!;

        public string FioTrener { get; set; }
    }
}
