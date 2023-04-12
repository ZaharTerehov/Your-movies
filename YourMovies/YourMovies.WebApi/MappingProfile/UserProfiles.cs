using AutoMapper;
using YourMovies.Application.Contracts.User;
using YourMovies.Domain.Entities;

namespace YourMovies.WebApi.MappingProfile
{
    public class UserProfiles : Profile
    {
        public UserProfiles() 
        {
            CreateMap<User, CreateUserRequest>();
            CreateMap<CreateUserRequest, User>();
        }
    }
}
