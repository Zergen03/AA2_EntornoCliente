using Microsoft.AspNetCore.Mvc;
using RefuApi.DTOs.Zone;
using RefuApi.Services.Interfaces;

namespace RefuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneService _zoneService;
        public ZoneController(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }
        // GET: api/Zone
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? name)
        {
            try
            {
                var zoneQueryParametersDTO = new ZoneQueryParametersDTO
                {
                    Name = name
                };

                var zones = await _zoneService.GetAll(zoneQueryParametersDTO);

                return Ok(zones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }
        // GET api/Zone/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var zoneDto = await _zoneService.GetById(id);
                return Ok(zoneDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }
        // POST api/Zone
        [HttpPost]
        public async Task<IActionResult> CreateZone([FromBody] CreateZoneDTO createZoneDTO)
        {
            try
            {
                var zoneDto = await _zoneService.Add(createZoneDTO);
                return CreatedAtAction(nameof(Get), new { id = zoneDto.Id }, zoneDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        // PUT api/Zone/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateZone(int id, [FromBody] UpdateZoneDTO updateZoneDTO)
        {
            try
            {
                var zoneDto = await _zoneService.Update(id, updateZoneDTO);
                return Ok(zoneDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        // DELETE api/Zone/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone(int id)
        {
            try
            {
                await _zoneService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }
    }
}
