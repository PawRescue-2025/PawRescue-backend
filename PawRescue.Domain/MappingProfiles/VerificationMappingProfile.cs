using AutoMapper;
using PawRescue.Domain.Dtos.Verification;
using PawRescue.Domain.Entities;
using System.Text.Json;

namespace PawRescue.Domain.MappingProfiles;

public class VerificationMappingProfile : Profile
{
    public VerificationMappingProfile()
    {
        CreateMap<CreateVerificationDTO, Verification>()
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Documents, (JsonSerializerOptions)null)
            ));

        CreateMap<UpdateVerificationDTO, Verification>()
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Documents, (JsonSerializerOptions)null)
            ));

        CreateMap<StatusVerificationDTO, Verification>();

        CreateMap<Verification, GridVerificationDTO>()
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                !string.IsNullOrEmpty(src.Documents)
                ? JsonSerializer.Deserialize<List<string>>(src.Documents, (JsonSerializerOptions)null)
                : new List<string>()
            ));
    }
}