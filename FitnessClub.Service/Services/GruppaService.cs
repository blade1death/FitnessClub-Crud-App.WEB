using FitnessClub.Domain.DTO;
using FitnessClub.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub.Service.Services
{
    public class GruppaService:IGruppaService
    {

        private PostgresContext context;
        public GruppaService(PostgresContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            this.context = dbContext;
        }
        public List<Gruppa> GetGruppas()
        {
            return context.Gruppas.ToList();
        }

    }
}
