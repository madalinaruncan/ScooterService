using ScooterService.Entities;

namespace ScooterService.Service {
    public interface IScooterService {
        Task CreateScooterAsync(Scooter scooter);
        Task<IEnumerable<Scooter>> GetScootersAsync();
    }
}