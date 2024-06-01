using ScooterService.Entities;

namespace ScooterService.Repository
{
    public interface IReparationRepository
    {
        Task CreateReparationAsync(Reparation reparation);
        Task<IEnumerable<Reparation>> GetReparationsAsync();
        Task<Reparation> GetReparationAsync(long id);
        Task UpdateReparationAsync(Reparation reparation);
        Task DeleteReparationAsync(long id);
        Task<bool> ReparationExistsAsync(long id);
    }
}
