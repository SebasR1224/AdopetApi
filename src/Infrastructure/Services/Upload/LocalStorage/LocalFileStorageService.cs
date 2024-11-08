using Application.Common.Interfaces.Upload;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Upload.LocalStorage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string _storagePath;
    private readonly string _baseUrl;

    public LocalFileStorageService(IConfiguration configuration)
    {
        _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "public");
        _baseUrl = configuration.GetValue<string>("FileStorage:BaseUrl") ?? "http://localhost:5000";

        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public async Task<string> UploadFileAsync(string fileName, Stream stream)
    {
        var filePath = Path.Combine(_storagePath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream);
        }

        return $"{_baseUrl}/public/{fileName.Replace("\\", "/")}";
    }
}