using Domain.Animals.ValueObjects;
using Domain.Primitives;

namespace Domain.Animals.Entities;

public sealed class Breed : Entity<BreedId>
{
    public string Name { get; }
    private Breed(BreedId BreedId, string name) : base(BreedId)
    {
        Name = name;
    }

    public static Breed Create(string name)
    {
        return new Breed(
            BreedId.CreateUnique(),
            name
        );
    }
}
