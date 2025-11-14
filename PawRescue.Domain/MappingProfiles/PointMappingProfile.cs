using AutoMapper;
using PawRescue.Domain.Dtos.Point;
using PawRescue.Domain.Entities;

namespace PawRescue.Domain.MappingProfiles;

public class PointMappingProfile : Profile
{
    public PointMappingProfile()
    {
        CreateMap<CreatePointDTO, Point>();

        CreateMap<Point, GridPointDTO>();
    }
}
