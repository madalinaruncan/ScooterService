using ScooterService.Entities;

namespace ScooterService.Repository {
    public interface IScooterRepository {
        Task CreateScooterAsync (Scooter scooter);
        Task<IEnumerable<Scooter>> GetScootersAsync();
    }
}