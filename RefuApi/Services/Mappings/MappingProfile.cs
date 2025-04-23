using AutoMapper;
using RefuApi.Models;
using RefuApi.DTOs.Users;
using RefuApi.DTOs.Schedule;
using RefuApi.DTOs.Zone;
using RefuApi.DTOs.ScheduleAssignment;

namespace RefuApi.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<UserQueryParameters, UserQueryParametersDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();

            // Schedules
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<ScheduleQueryParameters, ScheduleQueryParametersDTO>().ReverseMap();
            CreateMap<Schedule, CreateScheduleDTO>().ReverseMap();
            CreateMap<Schedule, UpdateScheduleDTO>().ReverseMap();

            // Zones
            CreateMap<Zone, ZoneDTO>().ReverseMap();
            CreateMap<Zone, CreateZoneDTO>().ReverseMap();
            CreateMap<Zone, UpdateZoneDTO>().ReverseMap();
            CreateMap<ZoneQueryParameters, ZoneQueryParametersDTO>().ReverseMap();

            // ScheduleAssignments
            CreateMap<ScheduleAssignment, ScheduleAssignmentDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.ZoneId, opt => opt.MapFrom(src => src.Schedule.Zone.Id))
                .ForMember(dest => dest.ZoneName, opt => opt.MapFrom(src => src.Schedule.Zone.Name))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Schedule.Day))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Schedule.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.Schedule.EndTime));

            CreateMap<CreateScheduleAssignmentDTO, ScheduleAssignment>().ReverseMap();
            CreateMap<ScheduleAssignmentKeyDTO, ScheduleAssignment>();
            CreateMap<ScheduleAssignmentQueryParametersDTO, ScheduleAssignmentQueryParameters>().ReverseMap();
        }
    }
}
