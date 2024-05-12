﻿using ScooterService.Entities;
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

        public async Task<IEnumerable<Reparation>> GetReparationsAsync()
        {
            return await _reparationRepository.GetReparationsAsync();
        }
    }
}