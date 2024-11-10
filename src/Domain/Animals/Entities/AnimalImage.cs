using Domain.Animals.ValueObjects;
using Domain.Primitives;

namespace Domain.Animals.Entities;

public sealed class AnimalImage : Entity<AnimalImageId>
{
    public string Url { get; private set; }

    private AnimalImage(AnimalImageId animalImageId, string url)
        : base(animalImageId)
    {
        Url = url;
    }

    public static AnimalImage Create(string url)
    {
        return new AnimalImage(AnimalImageId.CreateUnique(), url);
    }

#pragma warning disable CS8618
    private AnimalImage()
    {
    }
#pragma warning restore CS8618
}

