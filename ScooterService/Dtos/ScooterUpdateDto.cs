using ScooterService.Enums;

namespace ScooterService.Dtos
{
    public class ScooterUpdateDto
    {
        public string ScooterOwner { get; set; }
        public string IssueDescription { get; set; }
    }
}