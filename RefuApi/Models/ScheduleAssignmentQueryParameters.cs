namespace RefuApi.Models
{
    public class ScheduleAssignmentQueryParameters
    {
        public string? UserName { get; set; }
        public string? ZoneName { get; set; }
        public DateOnly? Day { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
}
