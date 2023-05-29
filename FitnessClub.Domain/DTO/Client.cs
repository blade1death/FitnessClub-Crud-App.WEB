using System;
using System.Collections.Generic;

namespace FitnessClub.Domain.DTO;

public partial class Client
{
    public string Fio { get; set; } = null!;

    public int Nomerabonimenta { get; set; }

    public DateOnly? Dataroshdenia { get; set; }

    public string? Pol { get; set; }

    public int? Ves { get; set; }

    public int? Rost { get; set; }

    public DateOnly Nashaloabonimenta { get; set; }

    public DateOnly Okonshanie { get; set; }

    public string Telephone { get; set; } = null!;

    public string Названиеgruppi { get; set; } = null!;

    public virtual Gruppa НазваниеgruppiNavigation { get; set; } = null!;
}
