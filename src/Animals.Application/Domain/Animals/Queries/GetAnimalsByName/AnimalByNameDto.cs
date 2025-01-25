namespace Animals.Application.Domain.Animals.Queries.GetAnimalsByName;

public record AnimalByNameDto(
    Guid Id,
    string Name,
    int Age);
