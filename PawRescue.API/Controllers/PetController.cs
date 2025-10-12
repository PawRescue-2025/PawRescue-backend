using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PetController : ControllerBase
{
    [HttpGet]
    public IActionResult TestAsync()
    {
        return Ok();
    }
}
