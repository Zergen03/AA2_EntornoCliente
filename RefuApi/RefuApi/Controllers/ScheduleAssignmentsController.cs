using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefuApi.DTOs.ScheduleAssignment;
using RefuApi.Services.Interfaces;

namespace RefuApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ScheduleAssignmentsController : ControllerBase
    {
        private readonly IScheduleAssignmentService _scheduleAssignmentService;
        public ScheduleAssignmentsController(IScheduleAssignmentService scheduleAssignmentService)
        {
            _scheduleAssignmentService = scheduleAssignmentService;
        }

        // GET: api/ScheduleAssignments
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ScheduleAssignmentQueryParametersDTO? scheduleAssignmentQueryParametersDTO)
        {
            try
            {
                var scheduleAssignments = await _scheduleAssignmentService.GetAll(
                    scheduleAssignmentQueryParametersDTO ?? new ScheduleAssignmentQueryParametersDTO()
                );
                return Ok(scheduleAssignments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }

        // GET api/ScheduleAssignments/user/1/schedule/3
        [HttpGet("user/{userId}/schedule/{scheduleId}")]
        public async Task<IActionResult> Get(int userId, int scheduleId)
        {
            var keyDto = new ScheduleAssignmentKeyDTO
            {
                UserId = userId,
                ScheduleId = scheduleId
            };

            try
            {
                var scheduleAssignmentDto = await _scheduleAssignmentService.GetByIds(keyDto);
                return Ok(scheduleAssignmentDto);
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



        // POST api/ScheduleAssignments
        [HttpPost]
        public async Task<IActionResult> CreateScheduleAssignment([FromBody] CreateScheduleAssignmentDTO createScheduleAssignmentDTO)
        {
            try
            {
                var scheduleAssignmentDto = await _scheduleAssignmentService.Add(createScheduleAssignmentDTO);

                return CreatedAtAction(
                    nameof(Get),
                    new
                    {
                        userId = scheduleAssignmentDto.UserId,
                        scheduleId = scheduleAssignmentDto.ScheduleId
                    },
                    scheduleAssignmentDto
                );
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }



        // DELETE api/ScheduleAssignments/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteScheduleAssignment([FromBody] ScheduleAssignmentKeyDTO scheduleAssignmentKeyDTO)
        {
            try
            {
                await _scheduleAssignmentService.Delete(scheduleAssignmentKeyDTO);
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
