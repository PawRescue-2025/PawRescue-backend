using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Comment;
using PawRescue.Services.Abstraction.Comments;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CommentController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService commentService = commentService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCommentDTO createDto)
    {
        var result = await commentService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPatch]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> SetStatusAsync([FromBody] StatusCommentDTO statusCommentDto)
    {
        var result = await commentService.UpdateAsync(statusCommentDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await commentService.GetAllAsync();

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await commentService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetByShelterIdAsync([FromRoute] int postId)
    {
        var result = await commentService.GetAllByPostIdAsync(postId);

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
        var result = await commentService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Comment deleted successfully!");
    }
}
