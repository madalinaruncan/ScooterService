namespace ScooterService.Dtos.Admin
{
    public class MemberViewDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountStatus { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
