using RefuApi.Models;

namespace RefuApi.Data.Interfaces
{
    public interface IZoneRepository
    {
        Task<IEnumerable<Zone>> GetAll(ZoneQueryParameters? zoneQueryParameter);
        Task<Zone?> GetById(int id);
        Task Add(Zone zone);
        Task Update(Zone zone);
        Task Delete(Zone zone);
        Task SaveChangesAsync();
    }
}
