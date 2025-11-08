using AutoMapper;
using PawRescue.Domain.Dtos.UsefulLink;
using PawRescue.Domain.Entities;

namespace PawRescue.Domain.MappingProfiles;

public class UsefulLinkMappingProfile : Profile
{
    public UsefulLinkMappingProfile()
    {
        CreateMap<CreateUsefulLinkDTO, UsefulLink>();

        CreateMap<UpdateUsefulLinkDTO, UsefulLink>();

        CreateMap<UsefulLink, GridUsefulLinkDTO>();
    }
}
