namespace RefuApi.DTOs.Schedule
{
    public class ScheduleDTO
    {
        public int Id { get; set; }

        public int ZoneId { get; set; }

        public DateOnly Day { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

        public string? ZoneName { get; set; }
    }
}
