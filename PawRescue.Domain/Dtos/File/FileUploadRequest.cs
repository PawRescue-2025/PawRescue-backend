using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PawRescue.Domain.Dtos.File;

public class FileUploadRequest
{
    [Required]
    public IFormFile File { get; set; } = null!;
}
