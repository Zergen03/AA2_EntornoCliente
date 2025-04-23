namespace RefuApi.DTOs.Schedule
{
    public class ScheduleQueryParametersDTO
    {
        public DateOnly? Day { get; set; }

        public int? ZoneId { get; set; }

        public bool IncludeAssignments { get; set; } = false;
    }
}
