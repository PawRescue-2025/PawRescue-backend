using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Services.Abstraction.Users;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserProfileController(IUserProfileService userProfileService) : ControllerBase
{
    private readonly IUserProfileService userProfileService = userProfileService;



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
    {
        return Ok("User deleted successfully!");
    }
}
