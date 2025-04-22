using RefuApi.Data.Interfaces;
using RefuApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RefuApi.Data
{
    public class ScheduleAssignmentRepository : IScheduleAssignmentRepository
    {
        private readonly RefuApiContext _context;
        public ScheduleAssignmentRepository(RefuApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ScheduleAssignment>> GetAll(ScheduleAssignmentQueryParameters scheduleAssignmentQueryParameters)
        {
            var query = _context.ScheduleAssignments
                .Include(sa => sa.User)
                .Include(sa => sa.Zone)
                .Include(sa => sa.Schedule)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(scheduleAssignmentQueryParameters.UserName))
                query = query.Where(sa => sa.User.Name.Contains(scheduleAssignmentQueryParameters.UserName));

            if (!string.IsNullOrWhiteSpace(scheduleAssignmentQueryParameters.ZoneName))
                query = query.Where(sa => sa.Zone.Name.Contains(scheduleAssignmentQueryParameters.ZoneName));

            if (scheduleAssignmentQueryParameters.Day.HasValue)
                query = query.Where(sa => sa.Schedule.Day == scheduleAssignmentQueryParameters.Day);

            if (scheduleAssignmentQueryParameters.StartTime.HasValue)
                query = query.Where(sa => sa.Schedule.StartTime == scheduleAssignmentQueryParameters.StartTime);

            if (scheduleAssignmentQueryParameters.EndTime.HasValue)
                query = query.Where(sa => sa.Schedule.EndTime == scheduleAssignmentQueryParameters.EndTime);

            return await query.ToListAsync();
        }
        public async Task<ScheduleAssignment?> GetByIds(int userId, int zoneId, int scheduleId)
        {
            return await _context.ScheduleAssignments
                .Include(sa => sa.User)
                .Include(sa => sa.Zone)
                .Include(sa => sa.Schedule)
                .FirstOrDefaultAsync(sa =>
                    sa.UserId == userId &&
                    sa.ZoneId == zoneId &&
                    sa.ScheduleId == scheduleId);
        }
        public async Task Add(ScheduleAssignment scheduleAssignment)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == scheduleAssignment.UserId);
            var zoneExists = await _context.Zones.AnyAsync(z => z.Id == scheduleAssignment.ZoneId);
            var scheduleExists = await _context.Schedules.AnyAsync(s => s.Id == scheduleAssignment.ScheduleId);

            if (!userExists || !zoneExists || !scheduleExists)
                throw new InvalidOperationException("User, Zone or Schedule not found.");

            await _context.ScheduleAssignments.AddAsync(scheduleAssignment);
        }
        public Task Delete(ScheduleAssignment scheduleAssignment)
        {
            _context.ScheduleAssignments.Remove(scheduleAssignment);
            return Task.CompletedTask;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
