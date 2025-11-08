using PawRescue.Domain.Dtos.Complaint;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Complaints;

public interface IComplaintService
{
    Task<Result> CreateAsync(CreateComplaintDTO createDto);
    Task<Result> DeleteAsync(int id);
    Task<Result<IEnumerable<GridComplaintDTO>>> GetAllAsync();
    Task<Result<GridComplaintDTO>> GetByIdAsync(int id);
    Task<Result<GridComplaintDTO>> UpdateAsync(StatusComplaintDTO statusComplaintDTO);
}
