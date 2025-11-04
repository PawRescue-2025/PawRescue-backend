using PawRescue.Domain.Dtos.Verification;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Verifications;

public interface IVerificationService
{
    Task<Result> CreateAsync(CreateVerificationDTO createDto);
    Task<Result<GridVerificationDTO>> UpdateAsync(UpdateVerificationDTO updateDto);
    Task<Result<GridVerificationDTO>> UpdateAsync(StatusVerificationDTO statusVerificationDTO);
    Task<Result<IEnumerable<GridVerificationDTO>>> GetAllAsync();
    Task<Result<GridVerificationDTO>> GetByIdAsync(int id);
    Task<Result<GridVerificationDTO>> GetByUserIdAsync(string userId);
    Task<Result> DeleteAsync(int id);
}
