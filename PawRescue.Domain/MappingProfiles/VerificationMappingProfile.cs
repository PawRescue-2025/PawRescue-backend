using AutoMapper;
using PawRescue.Domain.Dtos.Verification;
using PawRescue.Domain.Entities;

namespace PawRescue.Domain.MappingProfiles;

public class VerificationMappingProfile : Profile
{
    public VerificationMappingProfile()
    {
        CreateMap<CreateVerificationDTO, Verification>();

        CreateMap<UpdateVerificationDTO, Verification>();
        
        CreateMap<StatusVerificationDTO, Verification>();

        CreateMap<Verification, GridVerificationDTO>();
    }
}
