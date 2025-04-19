using System.ComponentModel.DataAnnotations;

namespace RefuApi.DTOs.Schedules
{
    public class ScheduleDTO
    {
        [Required]
        public DateOnly Day { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
