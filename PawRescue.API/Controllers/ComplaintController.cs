using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Complaint;
using PawRescue.Services.Abstraction.Complaints;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ComplaintController(IComplaintService complaintService) : ControllerBase
{
    private readonly IComplaintService complaintService = complaintService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateComplaintDTO createDto)
    {
        var result = await complaintService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Complaint created successfully!");
    }

    [HttpPatch]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> SetStatusAsync([FromBody] StatusComplaintDTO statusComplaintDto)
    {
        var result = await complaintService.UpdateAsync(statusComplaintDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Authorize(Roles = Roles.Moderator)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await complaintService.GetAllAsync();

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await complaintService.GetByIdAsync(id);

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
        var result = await complaintService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Complaint deleted successfully!");
    }
}
