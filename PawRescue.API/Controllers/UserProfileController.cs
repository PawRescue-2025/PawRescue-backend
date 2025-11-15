using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Users;
using PawRescue.Domain.Enum;
using PawRescue.Services.Abstraction.Users;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserProfileController(IUserProfileService userProfileService) : ControllerBase
{
    private readonly IUserProfileService userProfileService = userProfileService;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
    {
        var result = await userProfileService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("point/{id}")]
    public async Task<IActionResult> GetUserPointsAsync([FromRoute] string id)
    {
        var result = await userProfileService.GetUserPointsAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("verification-status/{id}")]
    public async Task<IActionResult> GetVerificationStatusAsync([FromRoute] string id)
    {
        var result = await userProfileService.GetVerificationStatusAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserDTO updateDto)
    {
        var result = await userProfileService.UpdateAsync(updateDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut("status")]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> UpdateStatusAsync([FromBody] StatusUserDTO statusDto)
    {
        var result = await userProfileService.UpdateStatusAsync(statusDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
    {
        var result = await userProfileService.UpdateStatusAsync(new StatusUserDTO { Id = id, Status = EntityStatus.Deleted });

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}
