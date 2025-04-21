using RefuApi.DTOs.Zone;

namespace RefuApi.Services.Interfaces
{
    public interface IZoneService
    {
        Task<IEnumerable<ZoneDTO>> GetAll(ZoneQueryParametersDTO zoneQueryParameters);
        Task<ZoneDTO?> GetById(int id);
        Task<ZoneDTO> Add(CreateZoneDTO zone);
        Task<ZoneDTO> Update(int id, UpdateZoneDTO zone);
        Task<bool> Delete(int id);
        Task SaveChangesAsync();
    }
}
