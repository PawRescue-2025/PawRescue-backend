using AutoMapper;
using PawRescue.Domain.Dtos.Complaint;
using PawRescue.Domain.Entities;

namespace PawRescue.Domain.MappingProfiles;

public class ComplaintMappingProfile : Profile
{
    public ComplaintMappingProfile()
    {
        CreateMap<CreateComplaintDTO, Complaint>();

        CreateMap<StatusComplaintDTO, Complaint>();

        CreateMap<Complaint, GridComplaintDTO>();
    }
}
