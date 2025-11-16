using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using PawRescue.Services.Abstraction.Files;

namespace PawRescue.Services.Files;

public class FileManagementService(BlobServiceClient blobServiceClient) : IFileManagementService
{
    private readonly BlobServiceClient blobServiceClient = blobServiceClient;
    private readonly string containerName = "files";

    public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);

        var extension = Path.GetExtension(fileName);
        var blobName = $"{Guid.NewGuid()}{extension}";

        var blobClient = containerClient.GetBlobClient(blobName);

        var headers = new BlobHttpHeaders
        {
            ContentType = contentType
        };

        await blobClient.UploadAsync(
            fileStream,
            new BlobUploadOptions { HttpHeaders = headers });

        return blobName;
    }

    public async Task<(Stream? Content, string? ContentType)> DownloadAsync(string blobName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);

        var blobClient = containerClient.GetBlobClient(blobName);

        if (!await blobClient.ExistsAsync())
            return (null, null);

        var response = await blobClient.DownloadStreamingAsync();
        return (response.Value.Content, response.Value.Details.ContentType);
    }

    public async Task DeleteAsync(string blobName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);

        await containerClient.DeleteBlobIfExistsAsync(blobName);
    }
}
