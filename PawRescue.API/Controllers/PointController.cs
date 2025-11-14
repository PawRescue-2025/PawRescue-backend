using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Dtos.Point;
using PawRescue.Services.Abstraction.Points;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PointController(IPointService pointService) : ControllerBase
{
    private readonly IPointService pointService = pointService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePointDTO createDto)
    {
        var result = await pointService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Point created successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await pointService.GetAllAsync();

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await pointService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("reviewer/{reviewerId}")]
    public async Task<IActionResult> GetAllByReviewerIdAsync([FromRoute] string reviewerId)
    {
        var result = await pointService.GetAllByReviewerIdAsync(reviewerId);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("recipient/{recipientId}")]
    public async Task<IActionResult> GetAllByRecipientIdAsync([FromRoute] string recipientId)
    {
        var result = await pointService.GetAllByRecipientIdAsync(recipientId);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await pointService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Point deleted successfully!");
    }
}
