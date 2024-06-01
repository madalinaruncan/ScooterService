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
               public async Task UpdateScooterAsync(Scooter scooter)
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ScooterExistsAsync(long id)
        {
            return await _context.Scooters.AnyAsync(r => r.Id == id);
        }

        public async Task<Scooter> GetScooterAsync(long id)
        {
           return await _context.Scooters
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();
        }
    }
}