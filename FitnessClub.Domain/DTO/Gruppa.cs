using System;
using System.Collections.Generic;

namespace FitnessClub.Domain.DTO;

public partial class Gruppa
{
    public string Названиеgruppi { get; set; } = null!;

    public string? Примечание { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Raspisanie> Raspisanies { get; set; } = new List<Raspisanie>();
}
