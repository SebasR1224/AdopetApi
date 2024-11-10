using Domain.Abandonments.ValueObjects;
using Domain.Primitives;

namespace Domain.Abandonments.Entities;

public sealed class ReportAbandonmentImage : Entity<ReportAbandonmentImageId>
{
    public string Url { get; private set; }

    private ReportAbandonmentImage(ReportAbandonmentImageId ReportAbandonmentImageId, string url)
        : base(ReportAbandonmentImageId)
    {
        Url = url;
    }

    public static ReportAbandonmentImage Create(string url)
    {
        return new ReportAbandonmentImage(ReportAbandonmentImageId.CreateUnique(), url);
    }

#pragma warning disable CS8618
    private ReportAbandonmentImage()
    {
    }
#pragma warning restore CS8618
}

