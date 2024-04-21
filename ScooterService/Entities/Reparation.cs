using ScooterService.Enums;

namespace ScooterService.Entities
{
    public class Reparation
    {
        public long Id { get; set; }
        public ReparationStatus Status { get; set; }
        public long ScooterId { get; set; }
        public Scooter Scooter { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Issue> Issues { get; set; }
    }
}
