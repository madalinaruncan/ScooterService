using ScooterService.Entities;
using ScooterService.Repository;


namespace ScooterService.Service
{
    public interface IIssueService
    {
        Task CreateIssueAsync(Issue issue);
        Task<IEnumerable<Issue>> GetIssuesAsync();
        Task<Issue> GetIssueAsync(long id);
        Task UpdateReparationAsync(Reparation reparation);
        Task DeleteReparationAsync(long id);

    }
}
