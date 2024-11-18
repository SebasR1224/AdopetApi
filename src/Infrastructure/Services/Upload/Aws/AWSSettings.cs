namespace Infrastructure.Services.Upload.Aws;

public class AWSSettings
{
    public const string SectionName = "AWS";

    public string BucketName { get; init; } = string.Empty;
    public string AccessKey { get; init; } = string.Empty;
    public string SecretKey { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
}