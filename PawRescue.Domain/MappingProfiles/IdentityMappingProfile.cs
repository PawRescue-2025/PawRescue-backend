using AutoMapper;
using PawRescue.Domain.Dtos.Identity;
using PawRescue.Domain.Entities.Identity;

namespace PawRescue.Domain.MappingProfiles;

public class IdentityMappingProfile : Profile
{
    public IdentityMappingProfile()
    {
        CreateMap<RegisterDTO, AppUser>()
            .ForMember(x => x.SecurityStamp, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));
    }
}
