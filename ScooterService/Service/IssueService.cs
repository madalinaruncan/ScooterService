using ScooterService.Entities;
using ScooterService.Repository;
using ScooterService.Enums;



namespace ScooterService.Service
{
    public class IssueServiceImpl : IIssueService 

    {
        private readonly IIssueRepository _issueRepository;
        public IssueServiceImpl(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task CreateIssueAsync(Issue issue)
        {
            await _issueRepository.CreateIssueAsync(issue);
        }

        public async Task<IEnumerable<Issue>> GetIssuesAsync()
        {
            return await _issueRepository.GetIssuesAsync();
        }

        public async Task<Issue> GetIssueAsync(long id)
        {
            return await _issueRepository.GetIssueAsync(id);
        }

        public async Task UpdateIssueAsync(Issue issue)
        {
            if (!await _issueRepository.IssueExistsAsync(issue.Id))
            {
                throw new KeyNotFoundException("Issue not found");
            }

            var issueToReplaceTask = _issueRepository.IssueExistsAsync(issue.Id);
            if (issueToReplaceTask == null)
            {
                throw new KeyNotFoundException("Issue not found");
            }
            var issueToReplace = await issueToReplaceTask;
         
            await _issueRepository.UpdateIssueAsync(issue);
        }

        public async Task DeleteIssueAsync(long id)
        {
            await _issueRepository.DeleteIssueAsync(id);
        }



    }
}
