using AutoMapper;
using PawRescue.Domain.Dtos.Resource;
using PawRescue.Domain.Entities;

namespace PawRescue.Domain.MappingProfiles;

public class ResourceMappingProfile : Profile
{
    public ResourceMappingProfile()
    {
        CreateMap<CreateResourceDTO, Resource>();

        CreateMap<DescriptionResourceDTO, Resource>();

        CreateMap<Resource, GridResourceDTO>();
    }
}
