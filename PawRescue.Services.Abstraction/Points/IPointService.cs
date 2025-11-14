using PawRescue.Domain.Dtos.Point;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Points;

public interface IPointService
{
    Task<Result> CreateAsync(CreatePointDTO createDto);
    Task<Result> DeleteAsync(int id);
    Task<Result<IEnumerable<GridPointDTO>>> GetAllAsync();
    Task<Result<GridPointDTO>> GetByIdAsync(int id);
    Task<Result<IEnumerable<GridPointDTO>>> GetAllByRecipientIdAsync(string recipientId);
    Task<Result<IEnumerable<GridPointDTO>>> GetAllByReviewerIdAsync(string reviewerId);
}
