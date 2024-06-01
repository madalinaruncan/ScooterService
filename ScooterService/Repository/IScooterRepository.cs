using ScooterService.Entities;

namespace ScooterService.Repository {
    public interface IScooterRepository {
        Task CreateScooterAsync (Scooter scooter);
        Task<IEnumerable<Scooter>> GetScootersAsync();
        Task<Scooter> GetScooterAsync(long id);
        Task UpdateScooterAsync(Scooter scooter);
        Task<bool> ScooterExistsAsync(long id);
    }
}