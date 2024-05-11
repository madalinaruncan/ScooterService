using Microsoft.EntityFrameworkCore;
using ScooterService.Data;
using ScooterService.Entities;

namespace ScooterService.Repository
{
    public class ReparationRepository : IReparationRepository
    {
        private readonly AppDbContext _context;

        public ReparationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateReparationAsync(Reparation reparation)
        {
            _context.Reparations.Add(reparation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reparation>> GetReparationsAsync()
        {
            return await _context.Reparations
                .Include(r => r.Scooter)
                //.Include(r => r.User)
                .Include(r => r.Issues)
                .ToListAsync();
        }
    }
}
