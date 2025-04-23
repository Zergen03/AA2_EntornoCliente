namespace RefuApi.Models;

public class ScheduleAssignment
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; } = default!;

    public ScheduleAssignment() { }

    public ScheduleAssignment(int userId, int scheduleId)
    {
        UserId = userId;
        ScheduleId = scheduleId;
    }

    public override string ToString()
    {
        return $"UserId: {UserId}, ScheduleId: {ScheduleId}";
    }
}
