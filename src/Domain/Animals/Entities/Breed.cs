namespace Domain.Animals.Entities;

public sealed class Breed
{
    public int Id { get; }
    public string Value { get; }
    private Breed(string value)
    {
        Value = value;
    }

    public static Breed Create(string value)
    {
        return new Breed(value);
    }
}
