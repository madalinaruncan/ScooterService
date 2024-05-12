using ScooterService.Entities;

namespace ScooterService.Repository
{
    public interface IReparationRepository
    {
        Task CreateReparationAsync(Reparation reparation);
        Task<IEnumerable<Reparation>> GetReparationsAsync();
        Task<Reparation> GetReparationAsync(long id);
    }
}
