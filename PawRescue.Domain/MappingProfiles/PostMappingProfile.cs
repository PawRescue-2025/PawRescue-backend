using AutoMapper;
using PawRescue.Domain.Dtos.Post;
using PawRescue.Domain.Dtos.Verification;
using PawRescue.Domain.Entities;
using System.Text.Json;

namespace PawRescue.Domain.MappingProfiles;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<CreatePostDTO, Post>()
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src =>
                JsonSerializer.Serialize(src.Photos, (JsonSerializerOptions)null)
            ));

        CreateMap<UpdatePostDTO, Post>();

        CreateMap<StatusPostDTO, Post>();

        CreateMap<Post, GridPostDTO>()
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src =>
                !string.IsNullOrEmpty(src.Photos)
                ? JsonSerializer.Deserialize<List<string>>(src.Photos, (JsonSerializerOptions)null)
                : new List<string>()
            ));
    }
}
