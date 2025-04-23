namespace RefuApi.DTOs.ScheduleAssignment
{
    public class ScheduleAssignmentQueryParametersDTO
    {
        public int? UserId { get; set; }
        public int? ScheduleId { get; set; }

        public string? UserName { get; set; }
        public string? ZoneName { get; set; }
        public DateOnly? Day { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
}
