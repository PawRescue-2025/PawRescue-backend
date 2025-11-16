using Microsoft.AspNetCore.Mvc;
using PawRescue.Domain.Dtos.File;
using PawRescue.Services.Abstraction.Files;

namespace PawRescue.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileManagementController(IFileManagementService blobStorageService) : ControllerBase
{
    private readonly IFileManagementService blobStorageService = blobStorageService;

    [HttpPost("upload")]
    [RequestSizeLimit(20_000_000)]
    public async Task<IActionResult> Upload([FromForm] FileUploadRequest request)
    {
        var file = request.File;

        if (file == null || file.Length == 0)
            return BadRequest("File is empty");

        using var stream = file.OpenReadStream();

        var blobName = await blobStorageService.UploadAsync(
            stream,
            file.FileName,
            file.ContentType ?? "application/octet-stream");

        return Ok(new { blobName });
    }

    [HttpGet("{blobName}")]
    public async Task<IActionResult> Download(string blobName)
    {
        var (content, contentType) = await blobStorageService.DownloadAsync(blobName);

        if (content == null)
            return NotFound();

        return File(content, contentType ?? "application/octet-stream");
    }

    [HttpDelete("{blobName}")]
    public async Task<IActionResult> Delete(string blobName)
    {
        await blobStorageService.DeleteAsync(blobName);
        return NoContent();
    }
}
