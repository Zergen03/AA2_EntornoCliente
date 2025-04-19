using RefuApi.DTOs.Schedule;

namespace RefuApi.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDTO>> GetAll(ScheduleQueryParametersDTO scheduleQueryParameters);
        Task<ScheduleDTO?> GetById(int id);
        Task<ScheduleDTO> Add(CreateScheduleDTO schedule);
        Task<ScheduleDTO> Update(int id, UpdateScheduleDTO schedule);
        Task<bool> Delete(int id);
        Task SaveChangesAsync();
    }
}
