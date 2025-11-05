using AutoMapper;
using PawRescue.Domain.Dtos.Animal;
using PawRescue.Domain.Entities;
using System.Text.Json;

namespace PawRescue.Domain.MappingProfiles;

public class AnimalMappingProfile : Profile
{
    public AnimalMappingProfile()
    {
        CreateMap<CreateAnimalDTO, Animal>()
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Documents, (JsonSerializerOptions)null)
            ))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Photos, (JsonSerializerOptions)null)
            ));

        CreateMap<UpdateAnimalDTO, Animal>()
            .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Documents, (JsonSerializerOptions)null)
            ))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Photos, (JsonSerializerOptions)null)
            ));

        CreateMap<Animal, GridAnimalDTO>()
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
