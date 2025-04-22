using RefuApi.Services.Interfaces;
using RefuApi.Data.Interfaces;
using AutoMapper;
using RefuApi.DTOs.Zone;
using RefuApi.Models;

namespace RefuApi.Services
{
    public class ZoneService : IZoneService
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;
        public ZoneService(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ZoneDTO>> GetAll(ZoneQueryParametersDTO zoneQueryParametersDTO)
        {
            try
            {
                var zoneQueryParameters = _mapper.Map<ZoneQueryParameters>(zoneQueryParametersDTO);
                var zones = await _zoneRepository.GetAll(zoneQueryParameters);
                return _mapper.Map<IEnumerable<ZoneDTO>>(zones);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving zones", ex);
            }
        }

        public async Task<ZoneDTO?> GetById(int id)
        {
            try
            {
                var zone = await _zoneRepository.GetById(id);
                if (zone == null)
                {
                    throw new KeyNotFoundException($"Zone with ID {id} not found.");
                }
                return _mapper.Map<ZoneDTO>(zone);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving zone with id {id}", ex);
            }
        }

        public async Task<ZoneDTO> Add(CreateZoneDTO zoneDTO)
        {
            try
            {
                var zone = _mapper.Map<Zone>(zoneDTO);
                await _zoneRepository.Add(zone);
                await SaveChangesAsync();
                return _mapper.Map<ZoneDTO>(zone);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding zone", ex);
            }
        }

        public async Task<ZoneDTO> Update(int id, UpdateZoneDTO zoneDTO)
        {
            try
            {
                var zone = await _zoneRepository.GetById(id);
                if (zone == null)
                {
                    throw new KeyNotFoundException($"Zone with ID {id} not found.");
                }
                _mapper.Map(zoneDTO, zone);
                await _zoneRepository.Update(zone);
                await SaveChangesAsync();
                return _mapper.Map<ZoneDTO>(zone);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating zone with id {id}", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var zone = await _zoneRepository.GetById(id);
                if (zone == null)
                {
                    throw new KeyNotFoundException($"Zone with ID {id} not found.");
                }
                await _zoneRepository.Delete(zone);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting zone with id {id}", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _zoneRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving changes", ex);
            }
        }
    }
}
