using System.ComponentModel.DataAnnotations;

namespace RefuApi.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly Day { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
