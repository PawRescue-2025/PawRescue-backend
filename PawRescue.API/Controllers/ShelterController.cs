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
    public IActionResult CreateAsync([FromBody] CreateShelterDTO createDto)
    {
        return Ok();
    }
}
