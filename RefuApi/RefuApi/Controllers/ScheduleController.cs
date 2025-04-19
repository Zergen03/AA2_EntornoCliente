using Microsoft.AspNetCore.Mvc;
using RefuApi.DTOs.Schedule;
using RefuApi.Services.Interfaces;

namespace RefuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: api/Schedule
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DateOnly? day)
        {
            try
            {
                var scheduleQueryParametersDTO = new ScheduleQueryParametersDTO
                {
                    Day = day
                };

                var schedules = await _scheduleService.GetAll(scheduleQueryParametersDTO);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        // GET api/Schedule/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var scheduleDto = await _scheduleService.GetById(id);
                return Ok(scheduleDto);

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

        // POST api/Schedule
        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleDTO createScheduleDTO)
        {
            try
            {
                var schedule = await _scheduleService.Add(createScheduleDTO);
                return CreatedAtAction(nameof(Get), new { id = schedule.Id }, schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        // PUT api/Schedule/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateScheduleDTO updateScheduleDTO)
        {
            try
            {
                var schedule = await _scheduleService.Update(id, updateScheduleDTO);
                return Ok(schedule);
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


        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _scheduleService.Delete(id);
                if (!isDeleted)
                {
                    return NotFound(new { message = $"Schedule with ID {id} not found." });
                }
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
