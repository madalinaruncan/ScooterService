using ScooterService.Entities;

namespace ScooterService.Service
{
    public interface IIssueService
    {
        Task CreateIssueAsync(Issue issue);
        Task<IEnumerable<Issue>> GetIssuesAsync();
    }
}
