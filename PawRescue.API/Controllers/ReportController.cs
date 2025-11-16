using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Const;
using PawRescue.Domain.Dtos.Report;
using PawRescue.Services.Abstraction.Reports;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReportController(IReportService reportService) : ControllerBase
{
    private readonly IReportService reportService = reportService;

    [HttpPost]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator}, {Roles.Volunteer}")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateReportDTO createDto)
    {
        var result = await reportService.CreateAsync(createDto);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await reportService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = $"{Roles.ShelterOwner},{Roles.Moderator},{Roles.Volunteer}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await reportService.DeleteAsync(id);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok("Report deleted successfully!");
    }
}
