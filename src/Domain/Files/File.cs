using Domain.Files.ValueObjects;
using Domain.Primitives;

namespace Domain.Files;

public sealed class File : Entity<FileId>
{
    public string Url { get; private set; }
    public string FileableType { get; private set; }
    public Guid FileableId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public File(FileId fileId, string url, string fileableType, Guid fileableId) : base(fileId)
    {
        Url = url;
        FileableType = fileableType;
        FileableId = fileableId;
    }

    public static File Create(
        string url,
        string fileableType,
        Guid fileableId
    )
    {
        return new File(
            FileId.CreateUnique(),
            url,
            fileableType,
            fileableId
        );
    }

#pragma warning disable CS8618
    private File() { }
#pragma warning restore CS8618

}