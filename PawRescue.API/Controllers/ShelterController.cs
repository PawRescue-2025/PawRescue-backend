using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Shelter;
using PawRescue.Services.Abstraction.Shelter;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ShelterController(IShelterService shelterService) : ControllerBase
{
    public IShelterService ShelterService { get; } = shelterService;

    [HttpPost]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateShelterDTO createDto)
    {
        var result = await ShelterService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Shelter created successfully!");
    }

    [HttpPut]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateShelterDTO updateDto)
    {
        var result = await ShelterService.UpdateAsync(updateDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await ShelterService.GetAllAsync();

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await ShelterService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await ShelterService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Shelter deleted successfully!");
    }
}
