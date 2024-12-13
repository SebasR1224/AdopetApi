namespace Contracts.Species;

public record SpeciesResponse(
    int Id,
    string Value,
    List<BreedResponse> Breeds
);

public record BreedResponse(
    int Id,
    string Value
);
