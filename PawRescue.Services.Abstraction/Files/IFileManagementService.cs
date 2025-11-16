
namespace PawRescue.Services.Abstraction.Files;

public interface IFileManagementService
{
    Task DeleteAsync(string blobName);
    Task<(Stream? Content, string? ContentType)> DownloadAsync(string blobName);
    Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
}
