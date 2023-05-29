using FitnessClub.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.Service.Interfaces
{
    public interface IGruppaService
    {
        public List<Gruppa> GetGruppas();
    }
}
