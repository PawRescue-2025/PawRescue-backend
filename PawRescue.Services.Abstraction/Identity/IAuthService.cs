using Microsoft.AspNetCore.Identity;
using PawRescue.Domain.Dtos.Identity;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Identity;

public interface IAuthService
{
    Task<Result> RegisterAsync(RegisterDTO registerDto);
    Task<Result<AuthResponseDto>> LoginAsync(LoginDTO loginDto);
    Task<Result<AuthResponseDto>> RefreshTokenAsync(string accessToken, string refreshToken);
}
