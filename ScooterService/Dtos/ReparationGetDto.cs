using ScooterService.Entities;
using ScooterService.Enums;

namespace ScooterService.Dtos
{
    public class ReparationGetDto
    {
        public long Id { get; set; }
        public ReparationStatus Status { get; set; }
        public Scooter Scooter { get; set; }
        public UserGetDto User { get; set; }
        public IEnumerable<Issue> Issues { get; set; }
    }
}
