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

        public async Task<IEnumerable<Schedule>> GetAll(ScheduleQueryParameters? scheduleQueryParameters)
        {
            var query = _context.Schedules.AsQueryable();
            if (scheduleQueryParameters != null)
            {
                if (scheduleQueryParameters?.Day.HasValue == true)
                {
                    query = query.Where(s => s.Day == scheduleQueryParameters.Day.Value);
                }
            }
            var result = await query.ToListAsync();
            return result;
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
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
