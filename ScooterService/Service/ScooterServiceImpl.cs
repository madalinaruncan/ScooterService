using ScooterService.Entities;
using ScooterService.Repository;

namespace ScooterService.Service {
    public class ScooterServiceImpl : IScooterService
    {
        private readonly IScooterRepository _scooterRepository;
        public ScooterServiceImpl (IScooterRepository scooterRepository) {
            _scooterRepository = scooterRepository;
        }
        public async Task CreateScooterAsync(Scooter scooter)
        {
            await _scooterRepository.CreateScooterAsync(scooter);
        }

        public async Task<IEnumerable<Scooter>> GetScootersAsync()
        {
            return await _scooterRepository.GetScootersAsync();
        }
        public async Task UpdateScooterAsync(Scooter scooter)
        {
            if (!await _scooterRepository.ScooterExistsAsync(scooter.Id))
            {
                throw new KeyNotFoundException("Scooter not found");
            }

            var scooterToReplaceTask = _scooterRepository.GetScooterAsync(scooter.Id);
            if (scooterToReplaceTask == null)
            {
                throw new KeyNotFoundException("Scooter not found");
            }
            var scooterToReplace = await scooterToReplaceTask;
            scooterToReplace.ScooterOwner = scooter.ScooterOwner;
            scooterToReplace.IssueDescription = scooter.IssueDescription;
            await _scooterRepository.UpdateScooterAsync(scooter);
        }

        public async Task<Scooter> GetScooterAsync(long id)
        {
            return await _scooterRepository.GetScooterAsync(id);
        }
    }
}