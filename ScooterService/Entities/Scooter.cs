namespace ScooterService.Entities
{
    public class Scooter
    {
        public long Id { get; set; }
        public string ScooterOwner { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public string IssueDescription { get; set; }
    }
}
