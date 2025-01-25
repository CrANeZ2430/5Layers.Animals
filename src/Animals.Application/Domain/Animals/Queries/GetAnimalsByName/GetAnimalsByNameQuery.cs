using Animals.Application.Common;
using Animals.Application.Domain.Animals.Queries.GetAnimals;
using MediatR;

namespace Animals.Application.Domain.Animals.Queries.GetAnimalsByName;

public record GetAnimalsByNameQuery(string Name) : IRequest<PageResponse<AnimalByNameDto[]>>;