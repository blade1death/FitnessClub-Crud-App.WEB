using FitnessClub.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.Service.Interfaces
{
    public interface ITrenerService
    {
        public List<Trener> GetTreners();
    }
}
