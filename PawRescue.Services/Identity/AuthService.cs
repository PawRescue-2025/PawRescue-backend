using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PawRescue.Domain.Dtos.Identity;
using PawRescue.Domain.Dtos.Users;
using PawRescue.Domain.Entities.Identity;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace PawRescue.Services.Identity;

public class AuthService(UserManager<AppUser> userManager, IConfiguration configuration) : IAuthService
{
    private readonly UserManager<AppUser> userManager = userManager;

    public async Task<Result> RegisterAsync(RegisterDTO registerDto)
    {
        var userExists = await userManager.FindByEmailAsync(registerDto.Email);
        if (userExists != null)
        {
            var error = new Error("Auth.DuplicateEmail", "User with this email already exists.");
            return Result.Failure(error);
        }

        var user = new AppUser
        {
            Email = registerDto.Email,
            UserName = registerDto.Username,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var identityResult = await userManager.CreateAsync(user, registerDto.Password);

        if (!identityResult.Succeeded)
        {
            var error = new Error("Auth.CreationFailed", identityResult.Errors.First().Description);
            return Result.Failure(error);
        }

        return Result.Success();
    }

    public async Task<Result<AuthResponseDto>> LoginAsync(LoginDTO loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);

        if (user is null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return Result<AuthResponseDto>.Failure(new Error("Auth.InvalidCredentials", "Invalid email or password."));
        }

        var userRoles = await userManager.GetRolesAsync(user);

        var accessToken = GenerateJwtToken(user, userRoles);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await userManager.UpdateAsync(user);

        var userDto = new UserDTO(user.Id, user.Email, userRoles);
        var expiresIn = (int)TimeSpan.FromMinutes(15).TotalSeconds;

        var response = new AuthResponseDto(accessToken, expiresIn, refreshToken, userDto);

        return Result<AuthResponseDto>.Success(response);
    }

    public async Task<Result<AuthResponseDto>> RefreshTokenAsync(string accessToken, string refreshToken)
    {
        var principal = GetPrincipalFromExpiredToken(accessToken);
        if (principal?.Identity?.Name is null)
        {
            return Result<AuthResponseDto>.Failure(new Error("Auth.InvalidToken", "Invalid Access Token."));
        }

        var user = await userManager.FindByNameAsync(principal.Identity.Name);

        if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return Result<AuthResponseDto>.Failure(new Error("Auth.InvalidRefreshToken", "Invalid Refresh Token."));
        }

        var userRoles = await userManager.GetRolesAsync(user);
        var newAccessToken = GenerateJwtToken(user, userRoles);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await userManager.UpdateAsync(user);

        var userDto = new UserDTO(user.Id, user.Email, userRoles);
        var expiresIn = (int)TimeSpan.FromMinutes(15).TotalSeconds;

        var response = new AuthResponseDto(newAccessToken, expiresIn, newRefreshToken, userDto);
        return Result<AuthResponseDto>.Success(response);
    }

    private string GenerateJwtToken(AppUser user, IList<string> roles)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            expires: DateTime.Now.AddMinutes(60),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            return null;
        }
        return principal;
    }
}
