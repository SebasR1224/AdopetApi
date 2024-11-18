namespace Application.Common.Interfaces.Services.Upload;

public interface IFileStorageService
{
    Task<string> UploadFileAsync(string fileName, Stream stream);
}