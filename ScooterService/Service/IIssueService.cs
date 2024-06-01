using ScooterService.Entities;
using ScooterService.Repository;


namespace ScooterService.Service
{
    public interface IIssueService
    {
        Task CreateIssueAsync(Issue issue);
        Task<IEnumerable<Issue>> GetIssuesAsync();
        Task<Issue> GetIssueAsync(long id);
        Task UpdateIssueAsync(Issue issue);
        Task DeleteIssueAsync(long id);

    }
}
