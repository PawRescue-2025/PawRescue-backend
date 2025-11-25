using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Verification;
using PawRescue.Services.Abstraction.Verifications;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VerificationController(IVerificationService verificationService) : ControllerBase
{
    private readonly IVerificationService verificationService = verificationService;

    [HttpPost]
    [Authorize(Roles = $"{Roles.Volunteer},{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateVerificationDTO createDto)
    {
        var result = await verificationService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut]
    [Authorize(Roles = $"{Roles.Volunteer},{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateVerificationDTO updateDto)
    {
        var result = await verificationService.UpdateAsync(updateDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPatch]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> SetStatusAsync([FromBody] StatusVerificationDTO statusVerificationDTO)
    {
        var result = await verificationService.UpdateAsync(statusVerificationDTO);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await verificationService.GetAllAsync();

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await verificationService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("user/{id}")]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> GetByUserIdAsync([FromRoute] string id)
    {
        var result = await verificationService.GetByUserIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await verificationService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Verification deleted successfully!");
    }
}
