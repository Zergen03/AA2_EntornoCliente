using RefuApi.DTOs.ScheduleAssignment;

namespace RefuApi.Services.Interfaces
{
    public interface IScheduleAssignmentService
    {
        Task<IEnumerable<ScheduleAssignmentDTO>> GetAll(ScheduleAssignmentQueryParametersDTO scheduleAssignmentQueryParameters);
        Task<ScheduleAssignmentDTO?> GetByIds(ScheduleAssignmentKeyDTO scheduleAssignmentKeyDTO);
        Task<ScheduleAssignmentDTO> Add(CreateScheduleAssignmentDTO scheduleAssignment);
        Task Delete(ScheduleAssignmentKeyDTO scheduleAssignmentKeyDTO);
        Task SaveChangesAsync();
    }
}
