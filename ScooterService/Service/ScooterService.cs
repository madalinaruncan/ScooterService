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
    }
}