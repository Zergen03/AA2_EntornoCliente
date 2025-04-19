using AutoMapper;
using RefuApi.Models;
using RefuApi.DTOs;
using RefuApi.DTOs.Users;

namespace RefuApi.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<UserQueryParameters, UserQueryParametersDTO>().ReverseMap();
        }
    }
}
