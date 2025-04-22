using RefuApi.Data.Interfaces;
using RefuApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RefuApi.Data
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly RefuApiContext _context;
        public ZoneRepository(RefuApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zone>> GetAll(ZoneQueryParameters? zoneQueryParameter)
        {
            var query = _context.Zones.AsQueryable();
            if (zoneQueryParameter != null)
            {
                if (!string.IsNullOrEmpty(zoneQueryParameter.Name))
                {
                    query = query.Where(z => z.Name.Contains(zoneQueryParameter.Name));
                }
            }
            var result = await query.ToListAsync();
            return result;
        }
        public async Task<Zone?> GetById(int id)
        {
            return await _context.Zones.FindAsync(id);
        }
        public async Task Add(Zone zone)
        {
            await _context.Zones.AddAsync(zone);
        }
        public Task Update(Zone zone)
        {
            _context.Zones.Update(zone);
            return Task.CompletedTask;
        }
        public Task Delete(Zone zone)
        {
            _context.Zones.Remove(zone);
            return Task.CompletedTask;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
