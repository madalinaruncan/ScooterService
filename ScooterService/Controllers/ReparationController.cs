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

        [HttpGet("{id}")]
        public async Task<ActionResult<Reparation>> GetOne(long id)
        {
            var reparation = await _reparationService.GetReparationAsync(id);

            return Ok(reparation);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReparation([FromBody] ReparationAddDto reparation)
        {
            var reparationToAdd = _mapper.Map<Reparation>(reparation);
            await _reparationService.CreateReparationAsync(reparationToAdd);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Reparation>> UpdateReparation(ReparationUpdateDto reparation)
        {
            var reparationToUpdate = _mapper.Map<Reparation>(reparation);
            await _reparationService.UpdateReparationAsync(reparationToUpdate);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Reparation>> DeleteReparation(long id)
        {
            try
            {
                await _reparationService.DeleteReparationAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
