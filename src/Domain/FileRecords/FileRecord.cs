using Domain.FileRecords.ValueObjects;
using Domain.Primitives;

namespace Domain.FileRecords;

public class FileRecord : AggregateRoot<FileRecordId>
{
    public string FileName { get; private set; }
    public string Url { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private FileRecord(
        FileRecordId id,
        string fileName,
        string url
    ) : base(id)
    {
        FileName = fileName;
        Url = url;
    }

    public static FileRecord Create(string fileName, string url)
    {
        return new FileRecord(
            FileRecordId.CreateUnique(),
            fileName,
            url
        );
    }
#pragma warning disable CS8618
    private FileRecord() { }
#pragma warning restore CS8618
}
