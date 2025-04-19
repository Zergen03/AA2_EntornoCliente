using RefuApi.Models;

namespace RefuApi.Data.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAll();
        Task<Schedule?> GetById(int id);
        Task Add(Schedule schedule);
        Task Update(Schedule schedule);
        Task Delete(Schedule schedule);
        Task SaveChangesAsync();
    }
}
