using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefuApi.Models
{
    public class ScheduleAssignment
    {
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int ZoneId { get; set; }
        public Zone Zone { get; set; } = default!;

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = default!;
    }
}
