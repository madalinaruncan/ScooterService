using ScooterService.Enums;

namespace ScooterService.Dtos
{
    public class ReparationUpdateDto
    {
        public long Id { get; set; }
        public ReparationStatus Status { get; set; }
    }
}
