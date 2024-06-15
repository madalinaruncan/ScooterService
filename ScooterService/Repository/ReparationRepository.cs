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

        public async Task<Reparation> GetReparationAsync(long id)
        {
            return await _context.Reparations
                .Where(r => r.Id == id)
                .Include(r => r.Scooter)
                //.Include(r => r.User)
                .Include(r => r.Issues)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reparation>> GetReparationsAsync()
        {
            return await _context.Reparations
                .Include(r => r.Scooter)
                .Include(r => r.User)
                .Include(r => r.Issues)
                .ToListAsync();
        }

        public async Task<bool> ReparationExistsAsync(long id)
        {
            return await _context.Reparations.AnyAsync(r => r.Id == id);
        }

        public async Task UpdateReparationAsync(Reparation reparation)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReparationAsync(long id)
        {
            var reparation = await _context.Reparations
                .Where(r => r.Id == id)
                .Include(r => r.Scooter)
                .Include(r => r.User)
                .Include(r => r.Issues)
                .FirstOrDefaultAsync(r => r.Id == id);
             
            if (reparation == null)
            {
                throw new KeyNotFoundException("Reparation not found");
            }

            _context.Reparations.Remove(reparation);
            await _context.SaveChangesAsync();
        }
    }
}
