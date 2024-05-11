using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScooterService.Dtos;
using ScooterService.Entities;
using ScooterService.Service;

namespace ScooterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReparationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReparationService _reparationService;

        public ReparationController(IMapper mapper, IReparationService reparationService)
        {
            _mapper = mapper;
            _reparationService = reparationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reparation>>> GetAll()
        {
            var reparations = await _reparationService.GetReparationsAsync();

            return Ok(reparations);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReparation([FromBody] ReparationAddDto reparation)
        {
            var reparationToAdd = _mapper.Map<Reparation>(reparation);
            await _reparationService.CreateReparationAsync(reparationToAdd);

            return NoContent();
        }


    }
}
