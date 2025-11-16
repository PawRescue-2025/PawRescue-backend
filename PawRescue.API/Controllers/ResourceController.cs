using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Resource;
using PawRescue.Services.Abstraction.Resources;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResourceController(IResourceService resourceService) : ControllerBase
{
    private readonly IResourceService resourceService = resourceService;

    [HttpPost]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateResourceDTO createDto)
    {
        var result = await resourceService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> UpdateDescriptionAsync([FromBody] DescriptionResourceDTO updateDto)
    {
        var result = await resourceService.UpdateDescriptionAsync(updateDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> ChangeIsPresentAsync([FromRoute] int id)
    {
        var result = await resourceService.ToggleIsPresentAsync(id);

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
        var result = await resourceService.GetAllAsync();

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("shelter/{shelterId}")]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> GetAllByShelterIdAsync([FromRoute] int shelterId)
    {
        var result = await resourceService.GetAllByShelterIdAsync(shelterId);

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
        var result = await resourceService.GetByIdAsync(id);

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
        var result = await resourceService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Resource deleted successfully");
    }
}
