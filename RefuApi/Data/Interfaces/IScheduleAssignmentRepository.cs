using RefuApi.Models;

namespace RefuApi.Data.Interfaces
{
    public interface IScheduleAssignmentRepository
    {
        Task<IEnumerable<ScheduleAssignment>> GetAll(ScheduleAssignmentQueryParameters scheduleAssignmentQueryParameters);
        Task<ScheduleAssignment?> GetByIds(int userId, int scheduleId);
        Task Add(ScheduleAssignment scheduleAssignment);
        Task Delete(ScheduleAssignment scheduleAssignment);
        Task SaveChangesAsync();
    }

}
