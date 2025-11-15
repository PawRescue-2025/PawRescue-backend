using PawRescue.Domain.Dtos.Users;
using PawRescue.Domain.Enum;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Users;

public interface IUserProfileService
{
    Task<Result<GridUserDTO>> GetByIdAsync(string id);
    Task<Result<int>> GetUserPointsAsync(string id);
    Task<Result<VerificationStatus>> GetVerificationStatusAsync(string id);
    Task<Result<GridUserDTO>> UpdateAsync(UpdateUserDTO updateDto);
    Task<Result<GridUserDTO>> UpdateStatusAsync(StatusUserDTO statusDto);
}
