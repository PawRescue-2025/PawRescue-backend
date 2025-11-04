using AutoMapper;
using PawRescue.Domain.Dtos.Shelter;
using PawRescue.Domain.Entities;

namespace PawRescue.Domain.MappingProfiles;

public class ShelterMappingProfile : Profile
{
    public ShelterMappingProfile()
    {
        CreateMap<CreateShelterDTO, Shelter>();

        CreateMap<UpdateShelterDTO, Shelter>();

        CreateMap<Shelter, GridShelterDTO>();
    }
}
