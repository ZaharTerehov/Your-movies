using AutoMapper;
using YourMovies.Application.Contracts.User;
using YourMovies.Application.Helpers;
using YourMovies.Domain.Entities;

namespace YourMovies.WebApi.MappingProfile
{
    public class UserProfiles : Profile
    {
        public UserProfiles() 
        {
            CreateMap<User, CreateUserRequest>();
            CreateMap<CreateUserRequest, User>()
                .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => HashPasswordHelper.HashPassword(entity.Password)));
        }
    }
}
