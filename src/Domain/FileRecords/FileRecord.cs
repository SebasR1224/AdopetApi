using Domain.FileRecords.ValueObjects;
using Domain.Primitives;

namespace Domain.FileRecords;

public class FileRecord : AggregateRoot<FileRecordId>
{
    public string FileName { get; }
    public string Url { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private FileRecord(
        FileRecordId id,
        string fileName,
        string url,
        DateTime createdDateTime,
        DateTime updatedDateTime
    ) : base(id)
    {
        FileName = fileName;
        Url = url;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static FileRecord Create(string fileName, string url)
    {
        return new FileRecord(
            FileRecordId.CreateUnique(),
            fileName,
            url,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
