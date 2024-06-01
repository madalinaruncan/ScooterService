using ScooterService.Entities;

namespace ScooterService.Service {
    public interface IScooterService {
        Task CreateScooterAsync(Scooter scooter);
        Task<IEnumerable<Scooter>> GetScootersAsync();
        Task<Scooter> GetScooterAsync(long id);
        Task UpdateScooterAsync(Scooter scooter);
    }
}