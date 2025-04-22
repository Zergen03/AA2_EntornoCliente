namespace RefuApi.DTOs.ScheduleAssignment
{
    public class ScheduleAssignmentDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = default!;

        public int ZoneId { get; set; }
        public string ZoneName { get; set; } = default!;

        public int ScheduleId { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }

}
