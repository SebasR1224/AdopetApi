namespace Application.Common.Interfaces.Upload;

public interface IFileStorageService
{
    Task<string> UploadFileAsync(string fileName, Stream stream);
}