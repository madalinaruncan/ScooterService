using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScooterService.Dtos.Admin;
using ScooterService.Entities;

namespace ScooterService.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("members")]
        public async Task<ActionResult<IEnumerable<MemberViewDto>>> GetMembers()
        {
            List<MemberViewDto> members = new List<MemberViewDto>();
            var users = await _userManager.Users
                .Where(x => x.Email != SD.AdminEmail)
                .ToListAsync();

            foreach (var user in users)
            {
                var memberToAdd = new MemberViewDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Name = user.Name,
                    DateCreated = user.DateCreated,
                    AccountStatus = user.AccountStatus,
                    Roles = await _userManager.GetRolesAsync(user)
                };

                members.Add(memberToAdd);
            }

            return Ok(members);
        }

        [HttpDelete("delete-member/{id}")]
        public async Task<IActionResult> DeleteMember(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (IsAdminUserId(id))
            {
                return BadRequest("Admin deletion is not allowed.");
            }

            await _userManager.DeleteAsync(user);
            return NoContent();
        }

        [HttpPost("confirm-account/{id}")]
        public async Task<ActionResult> ConfirmAccount(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(); 

            user.AccountStatus = "Confirmed"; 
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok(new JsonResult(new { message = "Account confirmed successfully" }));
            else
                return BadRequest(new JsonResult(new { message = "Failed to confirm account" }));
        }

        [HttpPost("reject-account/{id}")]
        public async Task<ActionResult> RejectAccount(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            user.AccountStatus = "Rejected";
            var result = await _userManager.UpdateAsync(user);


            if (result.Succeeded)
                return Ok(new JsonResult(new { message = "Account rejected successfully" }));
            else
                return BadRequest(new JsonResult(new {message = "Failed to reject account" }));
        }

        private bool IsAdminUserId(string userId)
        {
            return _userManager.FindByIdAsync(userId).GetAwaiter().GetResult().Email.Equals(SD.AdminEmail);
        }

    }
}
