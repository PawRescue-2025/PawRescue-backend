using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Post;
using PawRescue.Services.Abstraction.Posts;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PostController(IPostService postService) : ControllerBase
{
    private readonly IPostService postService = postService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePostDTO createDto)
    {
        var result = await postService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Post created successfully!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePostDTO updateDto)
    {
        var result = await postService.UpdateAsync(updateDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPatch]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> SetStatusAsync([FromBody] StatusPostDTO statusPostDto)
    {
        var result = await postService.UpdateAsync(statusPostDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> SetHelpRequestAsync([FromRoute] int id)
    {
        var result = await postService.SetHelpRequestAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await postService.GetAllAsync();

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await postService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByShelterIdAsync([FromRoute] string userId)
    {
        var result = await postService.GetAllByUserIdAsync(userId);

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
        var result = await postService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Post deleted successfully!");
    }
}
