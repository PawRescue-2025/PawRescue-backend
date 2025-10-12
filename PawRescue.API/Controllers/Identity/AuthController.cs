using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Dtos.Identity;
using PawRescue.Services.Abstraction.Identity;

namespace PawRescue.API.Controllers.Identity;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        var result = await authService.RegisterAsync(registerDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("User created successfully!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var result = await authService.LoginAsync(loginDto);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO requestDto)
    {
        var result = await authService.RefreshTokenAsync(requestDto.AccessToken, requestDto.RefreshToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        return Ok(result.Value);
    }
}
