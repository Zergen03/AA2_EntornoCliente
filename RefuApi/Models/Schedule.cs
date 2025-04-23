using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefuApi.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ZoneId")]
        public int ZoneId { get; set; }
        public Zone Zone { get; set; } = default!;

        [Required]
        public DateOnly Day { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
        public string? Report { get; set; }

        public ICollection<ScheduleAssignment> ScheduleAssignments { get; set; } = new List<ScheduleAssignment>();

        public Schedule() { }
        public Schedule(int zoneId, DateOnly day, TimeOnly startTime, TimeOnly endTime)
        {
            ZoneId = zoneId;
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
        }
        public override string ToString()
        {
            return $"Id: {Id}, ZoneId: {ZoneId}, Day: {Day}, StartTime: {StartTime}, EndTime: {EndTime}";
        }
    }
}
