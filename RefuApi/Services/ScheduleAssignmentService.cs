using RefuApi.Services.Interfaces;
using RefuApi.Data.Interfaces;
using AutoMapper;
using RefuApi.DTOs.ScheduleAssignment;
using RefuApi.Models;
using System.Data;

namespace RefuApi.Services
{
    public class ScheduleAssignmentService : IScheduleAssignmentService
    {
        private readonly IScheduleAssignmentRepository _scheduleAssignmentRepository;
        private readonly IMapper _mapper;
        public ScheduleAssignmentService(IScheduleAssignmentRepository scheduleAssignmentRepository, IMapper mapper)
        {
            _scheduleAssignmentRepository = scheduleAssignmentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ScheduleAssignmentDTO>> GetAll(ScheduleAssignmentQueryParametersDTO scheduleAssignmentQueryParametersDTO)
        {
            try
            {
                var scheduleAssignmentQueryParameters = _mapper.Map<ScheduleAssignmentQueryParameters>(scheduleAssignmentQueryParametersDTO);
                var scheduleAssignments = await _scheduleAssignmentRepository.GetAll(scheduleAssignmentQueryParameters);
                return _mapper.Map<IEnumerable<ScheduleAssignmentDTO>>(scheduleAssignments);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving schedule assignments {ex.Message}", ex);
            }
        }
        public async Task<ScheduleAssignmentDTO?> GetByIds(ScheduleAssignmentKeyDTO scheduleAssignmentKeyDTO)
        {
            try
            {
                var scheduleAssignment = await _scheduleAssignmentRepository.GetByIds(
                    scheduleAssignmentKeyDTO.UserId, scheduleAssignmentKeyDTO.ScheduleId
                    );
                if (scheduleAssignment == null)
                {
                    throw new KeyNotFoundException($"Schedule assignment not found.");
                }
                return _mapper.Map<ScheduleAssignmentDTO>(scheduleAssignment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving schedule assignment", ex);
            }
        }
        public async Task<ScheduleAssignmentDTO> Add(CreateScheduleAssignmentDTO scheduleAssignmentDTO)
        {
            try
            {
                // Verificar si ya existe la asignación
                var existing = await _scheduleAssignmentRepository.GetByIds(
                    scheduleAssignmentDTO.UserId,
                    scheduleAssignmentDTO.ScheduleId
                );

                if (existing != null)
                    throw new InvalidOperationException("This schedule assignment already exists.");

                var scheduleAssignment = _mapper.Map<ScheduleAssignment>(scheduleAssignmentDTO);
                await _scheduleAssignmentRepository.Add(scheduleAssignment);
                await SaveChangesAsync();

                // Cargar la versión completa con relaciones
                var fullAssignment = await _scheduleAssignmentRepository.GetByIds(
                    scheduleAssignment.UserId,
                    scheduleAssignment.ScheduleId
                );

                return _mapper.Map<ScheduleAssignmentDTO>(fullAssignment);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding schedule assignment", ex);
            }
        }
        public async Task Delete(ScheduleAssignmentKeyDTO scheduleAssignmentKeyDTO)
        {
            try
            {
                var assignment = await _scheduleAssignmentRepository.GetByIds(
                    scheduleAssignmentKeyDTO.UserId, scheduleAssignmentKeyDTO.ScheduleId
                    );
                if (assignment == null)
                    throw new KeyNotFoundException("Assignment not found.");

                await _scheduleAssignmentRepository.Delete(assignment);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting schedule assignment", ex);
            }
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _scheduleAssignmentRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving changes", ex);
            }
        }
    }
}
