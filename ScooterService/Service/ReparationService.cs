using ScooterService.Entities;
using ScooterService.Enums;
using ScooterService.Repository;

namespace ScooterService.Service
{
    public class ReparationService : IReparationService
    {
        private readonly IReparationRepository _reparationRepository;

        public ReparationService(IReparationRepository reparationRepository)
        {
            _reparationRepository = reparationRepository;
        }

        public async Task CreateReparationAsync(Reparation reparation)
        {
            reparation.Status = ReparationStatus.Pending;
            reparation.UserId = 1;
            await _reparationRepository.CreateReparationAsync(reparation);

        }

        public async Task<Reparation> GetReparationAsync(long id)
        {
            return await _reparationRepository.GetReparationAsync(id);
        }

        public async Task<IEnumerable<Reparation>> GetReparationsAsync()
        {
            return await _reparationRepository.GetReparationsAsync();
        }

        public async Task UpdateReparationAsync(Reparation reparation)
        {
            if (!await _reparationRepository.ReparationExistsAsync(reparation.Id))
            {
                throw new KeyNotFoundException("Reparation not found");
            }

            var reparationToReplaceTask = _reparationRepository.GetReparationAsync(reparation.Id);
            if (reparationToReplaceTask == null)
            {
                throw new KeyNotFoundException("Reparation not found");
            }
            var reparationToReplace = await reparationToReplaceTask;
            reparationToReplace.Status = reparation.Status;
            await _reparationRepository.UpdateReparationAsync(reparation);
        }

        public async Task DeleteReparationAsync(long id)
        {
            await _reparationRepository.DeleteReparationAsync(id);
        }
    }
}
