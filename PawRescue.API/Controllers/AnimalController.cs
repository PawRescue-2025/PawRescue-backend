using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Animal;
using PawRescue.Services.Abstraction.Animal;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AnimalController(IAnimalService animalService) : ControllerBase
{
    private readonly IAnimalService animalService = animalService;

    [HttpPost]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAnimalDTO createDto)
    {
        var result = await animalService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPut]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnimalDTO updateDto)
    {
        var result = await animalService.UpdateAsync(updateDto);

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
        var result = await animalService.GetAllAsync();

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
        var result = await animalService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("shelter/{id}")]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}")]
    public async Task<IActionResult> GetByShelterIdAsync([FromRoute] int shelterId)
    {
        var result = await animalService.GetByShelterIdAsync(shelterId);

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
        var result = await animalService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Animal deleted successfully!");
    }
}
