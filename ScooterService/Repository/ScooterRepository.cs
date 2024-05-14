using Microsoft.EntityFrameworkCore;
using ScooterService.Data;
using ScooterService.Entities;

namespace ScooterService.Repository {
    public class ScooterRepository : IScooterRepository
    {
        private readonly AppDbContext _context;
        public ScooterRepository(AppDbContext context) {
            _context = context;
        }
        public async Task CreateScooterAsync(Scooter scooter)
        {
            _context.Scooters.Add(scooter);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Scooter>> GetScootersAsync()
        {
            return await _context.Scooters.ToListAsync();
        }
    }
}