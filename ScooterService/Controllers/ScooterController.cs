using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScooterService.Dtos;
using ScooterService.Entities;
using ScooterService.Service;

namespace ScooterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IScooterService _scooterService;
        public ScooterController(IMapper mapper, IScooterService scooterService) {
            _mapper = mapper;
            _scooterService = scooterService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateScooter([FromBody] ScooterAddDto scooter) {
            var scooterToAdd = _mapper.Map<Scooter>(scooter);
            await _scooterService.CreateScooterAsync(scooterToAdd);

            return NoContent();
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scooter>>> GetAll()
        {
            var scooters = await _scooterService.GetScootersAsync();

            return Ok(scooters);
        }
    }
}