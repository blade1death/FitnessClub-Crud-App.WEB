using System;
using System.Collections.Generic;

namespace FitnessClub.Domain.DTO;

public partial class Raspisanie
{
    public int Identificatorraspisania { get; set; }

    public string Vidzanatii { get; set; } = null!;

    public string? Zal { get; set; }

    public DateOnly Nachalozanatii { get; set; }

    public int Prodolshitelnost { get; set; }

    public string Названиеgruppi { get; set; } = null!;

    public int Identificatortrener { get; set; }

    public virtual Trener IdentificatortrenerNavigation { get; set; } = null!;

    public virtual Gruppa НазваниеgruppiNavigation { get; set; } = null!;
}
