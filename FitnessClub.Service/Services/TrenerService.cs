using FitnessClub.Domain.DTO;
using FitnessClub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FitnessClub.Service.Services
{
    public class TrenerService : ITrenerService
    {
        private PostgresContext context;
        public TrenerService(PostgresContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            this.context = dbContext;
        }
        public List<Trener> GetTreners()
        {
            return context.Treners.ToList();
        }
    }
}
