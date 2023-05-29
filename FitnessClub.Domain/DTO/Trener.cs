using System;
using System.Collections.Generic;

namespace FitnessClub.Domain.DTO;

public partial class Trener
{
    public string Dolshnost { get; set; } = null!;

    public int Identificatortrener { get; set; }

    public string Fio { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual ICollection<Raspisanie> Raspisanies { get; set; } = new List<Raspisanie>();
}
