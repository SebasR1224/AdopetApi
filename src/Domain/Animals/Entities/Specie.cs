using Domain.Animals.ValueObjects;
using Domain.Primitives;

namespace Domain.Animals.Entities;

public sealed class Specie : Entity<SpecieId>
{
    public string Name { get; }
    private Specie(SpecieId especieId, string name) : base(especieId)
    {
        Name = name;
    }

    public static Specie Create(string name)
    {
        return new Specie(
            SpecieId.CreateUnique(),
            name
        );
    }
}
