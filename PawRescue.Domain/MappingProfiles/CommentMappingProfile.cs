using AutoMapper;
using PawRescue.Domain.Dtos.Comment;
using PawRescue.Domain.Entities;

namespace PawRescue.Domain.MappingProfiles;

public class CommentMappingProfile : Profile
{
    public CommentMappingProfile()
    {
        CreateMap<CreateCommentDTO, Comment>();

        CreateMap<StatusCommentDTO, Comment>();

        CreateMap<Comment, GridCommentDTO>();
    }
}
