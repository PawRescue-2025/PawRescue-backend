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
    public IAnimalService AnimalService { get; } = animalService;

    [HttpPost]
    [Authorize(Roles = Roles.ShelterOwner)]
    public IActionResult CreateAsync([FromBody] CreateAnimalDTO createDto)
    {
        return Ok();
    }
}
