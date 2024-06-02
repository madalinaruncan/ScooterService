using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScooterService.Dtos;
using ScooterService.Entities;
using ScooterService.Service;



namespace ScooterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIssueService _issueService;

        public IssueController(IMapper mapper, IIssueService issueService)
        {
            _mapper = mapper;
            _issueService = issueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetAll()
        {
            var issues = await _issueService.GetIssuesAsync();

            return Ok(issues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetOne(long id)
        {
            var issue = await _issueService.GetIssueAsync(id);

            return Ok(issue);
        }

        [HttpPost]
        public async Task<ActionResult> CreateIssue([FromBody] IssueAddDto issue)
        {
            var issueToAdd = _mapper.Map<Issue>(issue);
            await _issueService.CreateIssueAsync(issueToAdd);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Issue>> UpdateIssue(IssueUpdateDto issue)
        {
            var issueToUpdate = _mapper.Map<Issue>(issue);
            await _issueService.UpdateIssueAsync(issueToUpdate);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> DeleteIssue(long id)
        {
            try
            {
                await _issueService.DeleteIssueAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
