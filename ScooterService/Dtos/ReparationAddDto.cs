namespace ScooterService.Dtos
{
    public class ReparationAddDto
    {
        public ScooterAddDto Scooter { get; set; }

        public IEnumerable<IssueAddDto> Issues { get; set; }
    }
}
