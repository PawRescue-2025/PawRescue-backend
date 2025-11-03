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
    [Authorize(Roles = Roles.ShelterOwner)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateShelterDTO createDto)
    {
        var result = await ShelterService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Shelter created successfully!");
    }
}
