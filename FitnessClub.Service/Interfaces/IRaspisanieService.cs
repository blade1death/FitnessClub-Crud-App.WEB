using FitnessClub.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.Service.Interfaces
{
    public interface IRaspisanieService
    {
        public Raspisanie? GetRaspisanietById(int id);
        public Result CreateRaspisanie(Raspisanie raspisanie);
        public Result UpdateRaspisanie(Raspisanie raspisanie);
        public List<Raspisanie> GetRaspisanies();
    }
}
