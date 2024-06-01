using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ScooterService.Entities;
using ScooterService.Service;
using ScooterService.Repository;
using ScooterService.Dtos;

namespace ScooterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
       
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto userObj)
        {
            if(userObj == null)
                return BadRequest();
            var userToLogin = _mapper.Map<User>(userObj);
            var user = _userService.LoginUser(userToLogin);
            if (user == null)
                return NotFound(new {Message = "User Not Found!"});
            return Ok(new { Message = "Login Succes!" });
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userObject)
        {
            if (userObject == null)
                return BadRequest();
            var userToAdd = _mapper.Map<User>(userObject);
            _userService.RegisterUser(userToAdd);
            return Ok(new { Message = "User Registered!" });
        }
    }
}
