using RefuApi.Data.Interfaces;
using RefuApi.Models;
using Schedule = RefuApi.Models.Schedule;
using Microsoft.EntityFrameworkCore;

namespace RefuApi.Data
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly RefuApiContext _context;
        public ScheduleRepository(RefuApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Schedule>> GetAll()
        {
            return await _context.Schedules.ToListAsync();
        }
        public async Task<Schedule?> GetById(int id)
        {
            return await _context.Schedules.FindAsync(id);
        }
        public async Task Add(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
        }
        public Task Update(Schedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public Task Delete(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
            return Task.CompletedTask;
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
