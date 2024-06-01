using Microsoft.EntityFrameworkCore;
using ScooterService.Data;
using ScooterService.Entities;

namespace ScooterService.Repository
{
    public class IssueRepository : IIssueRepository
    {
        private readonly AppDbContext _context;
        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateIssueAsync(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<Issue>> GetIssuesAsync()
        {
            return await _context.Issues.ToListAsync();
        }

        public async Task<Issue> GetIssueAsync(long id)
        {
            return _context.Issues
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public async Task<bool> IssueExistsAsync(long id)
        {
            return await _context.Issues.AnyAsync(i => i.Id == id);
        }

        public async Task UpdateIssueAsync(Issue issue)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIssueAsync(long id)
        {
            var issue = await _context.Issues
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (issue == null)
            {
                throw new KeyNotFoundException("Issue not found");
            }

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
        }


    }
}
