using Amazon.S3;
using Amazon.S3.Transfer;
using Application.Common.Interfaces.Upload;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Upload.Aws;

public class S3FileStorageService : IFileStorageService
{
    private readonly AWSSettings _settings;
    private readonly string _bucketName;
    private readonly IAmazonS3 _s3Client;

    public S3FileStorageService(IAmazonS3 s3Client, IOptions<AWSSettings> settings)
    {
        _s3Client = s3Client;
        _settings = settings.Value;
        _bucketName = _settings.BucketName;
    }

    public async Task<string> UploadFileAsync(string fileName, Stream stream)
    {
        var uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = stream,
            Key = fileName,
            BucketName = _bucketName,
            ContentType = "image/jpeg"
        };

        var transferUtility = new TransferUtility(_s3Client);
        await transferUtility.UploadAsync(uploadRequest);

        return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
    }
}