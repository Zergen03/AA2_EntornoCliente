using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs.ScheduleAssignment
{
    public class CreateScheduleAssignmentDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ScheduleId { get; set; }
    }
}
