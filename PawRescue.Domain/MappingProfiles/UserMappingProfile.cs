using AutoMapper;
using PawRescue.Domain.Dtos.Users;
using PawRescue.Domain.Entities.Identity;

namespace PawRescue.Domain.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<AppUser, GridUserDTO>();

        CreateMap<UpdateUserDTO, AppUser>();

        CreateMap<StatusUserDTO, AppUser>();
    }
}
