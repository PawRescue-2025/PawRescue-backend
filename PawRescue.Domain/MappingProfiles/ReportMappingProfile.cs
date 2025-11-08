using AutoMapper;
using PawRescue.Domain.Dtos.Report;
using PawRescue.Domain.Entities;
using System.Text.Json;

namespace PawRescue.Domain.MappingProfiles;

public class ReportMappingProfile : Profile
{
    public ReportMappingProfile()
    {
        CreateMap<CreateReportDTO, Report>()
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Documents, (JsonSerializerOptions)null)
            ))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Photos, (JsonSerializerOptions)null)
            ));

        CreateMap<Report, GridReportDTO>()
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                !string.IsNullOrEmpty(src.Documents)
                ? JsonSerializer.Deserialize<List<string>>(src.Documents, (JsonSerializerOptions)null)
                : new List<string>()
            ))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src =>
                !string.IsNullOrEmpty(src.Photos)
                ? JsonSerializer.Deserialize<List<string>>(src.Photos, (JsonSerializerOptions)null)
                : new List<string>()
            ));
    }
}
