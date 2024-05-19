using ScooterService.Entities;

namespace ScooterService.Repository
{
    public interface IIssueRepository
    {
        Task CreateIssueAsync(Issue issue);
        Task<IEnumerable<Issue>> GetIssuesAsync();
        Task<Issue> GetIssueAsync(long id);
        Task UpdateIssueAsync(Issue issue);
        Task DeleteIssueAsync(long id);
        Task<bool> IssueExistsAsync(long id);
    }
}
