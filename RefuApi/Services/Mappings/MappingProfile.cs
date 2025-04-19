using AutoMapper;
using RefuApi.Models;
using RefuApi.DTOs.Users;
using RefuApi.DTOs.Schedule;

namespace RefuApi.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<UserQueryParameters, UserQueryParametersDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();
            //Schedules
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<ScheduleQueryParameters, ScheduleQueryParametersDTO>().ReverseMap();
            CreateMap<Schedule, CreateScheduleDTO>().ReverseMap();
            CreateMap<Schedule, UpdateScheduleDTO>().ReverseMap();
        }
    }
}
