namespace Domain.Animals.Entities;

public sealed class Specie
{
    private readonly List<Breed> _breeds = [];
    public int Id { get; private set; }
    public string Value { get; private set; }
    public IReadOnlyList<Breed> Breeds => _breeds.AsReadOnly();
    private Specie(string value, List<Breed> breeds)
    {
        Value = value;
        _breeds = breeds;
    }

    public static Specie Create(string value, List<Breed> breeds)
    {
        return new Specie(value, breeds);
    }


#pragma warning disable CS8618
    private Specie() { }
#pragma warning restore CS8618
}
