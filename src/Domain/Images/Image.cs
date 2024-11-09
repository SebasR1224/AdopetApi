using Domain.Images.ValueObjects;
using Domain.Primitives;

namespace Domain.Images;

public sealed class Image : Entity<ImageId>
{
    public string Url { get; private set; }
    public string ImageableType { get; private set; }
    public Guid ImageableId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public Image(ImageId imageId, string url, string imageableType, Guid imageableId) : base(imageId)
    {
        Url = url;
        ImageableType = imageableType;
        ImageableId = imageableId;
    }

    public static Image Create(
        string url,
        string imageableType,
        Guid imageableId
    )
    {
        return new Image(
            ImageId.CreateUnique(),
            url,
            imageableType,
            imageableId
        );
    }

#pragma warning disable CS8618
    private Image() { }
#pragma warning restore CS8618

}