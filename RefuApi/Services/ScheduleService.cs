using RefuApi.Services.Interfaces;
using RefuApi.Data.Interfaces;
using AutoMapper;
using RefuApi.DTOs.Schedule;
using RefuApi.Models;

namespace Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;
        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ScheduleDTO>> GetAll(ScheduleQueryParametersDTO scheduleQueryParametersDTO)
        {
            try
            {
                var scheduleQueryParameters = _mapper.Map<ScheduleQueryParameters>(scheduleQueryParametersDTO);
                var schedules = await _scheduleRepository.GetAll(scheduleQueryParameters);
                return _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedules", ex);
            }
        }
        public async Task<ScheduleDTO?> GetById(int id)
        {
            try
            {
                var schedule = await _scheduleRepository.GetById(id);
                if (schedule == null)
                {
                    throw new KeyNotFoundException($"Schedule with ID {id} not found.");
                }
                return _mapper.Map<ScheduleDTO>(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving schedule with id {id}", ex);
            }
        }
        public async Task<ScheduleDTO> Add(CreateScheduleDTO scheduleDTO)
        {
            try
            {
                var schedule = _mapper.Map<Schedule>(scheduleDTO);
                await _scheduleRepository.Add(schedule);
                await _scheduleRepository.SaveChangesAsync();

                return _mapper.Map<ScheduleDTO>(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding schedule", ex);
            }
        }
        public async Task<ScheduleDTO> Update(int id, UpdateScheduleDTO scheduleDTO)
        {
            try
            {
                var schedule = await _scheduleRepository.GetById(id);
                if (schedule == null)
                {
                    throw new KeyNotFoundException($"Schedule with ID {id} not found.");
                }
                _mapper.Map(scheduleDTO, schedule);
                await _scheduleRepository.Update(schedule);
                await _scheduleRepository.SaveChangesAsync();

                return _mapper.Map<ScheduleDTO>(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating schedule with id {id}", ex);
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var schedule = await _scheduleRepository.GetById(id);
                if (schedule == null)
                {
                    throw new KeyNotFoundException($"Schedule with ID {id} not found.");
                }
                await _scheduleRepository.Delete(schedule);
                await _scheduleRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting schedule with id {id}", ex);
            }
        }
        public async Task SaveChangesAsync()
        {
            await _scheduleRepository.SaveChangesAsync();
        }
    }
}
