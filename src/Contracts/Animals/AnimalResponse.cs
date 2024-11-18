namespace Contracts.Animals;

public record AnimalResponse(
    string Id,
    string Name,
    string Description,
    int? Age,
    string CoatColor,
    double? Weight,
    string Specie,
    string? Breed,
    string Status,
    string Gender,
    List<string> Images
);