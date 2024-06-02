using ScooterService.Entities;

namespace ScooterService.Service
{
    public interface IReparationService
    {
        Task CreateReparationAsync(Reparation reparation);
        Task<IEnumerable<Reparation>> GetReparationsAsync();
        Task<Reparation> GetReparationAsync(long id);
        Task UpdateReparationAsync(Reparation reparation);
        Task DeleteReparationAsync(long id);

    }
}
