using Animals.Application.Common;
using Animals.Application.Domain.Animals.Queries.GetAnimalsByName;
using Animals.Persistence.Core.Animals.DataProvider;
using MediatR;

namespace Animals.Infrastructure.Application.Domain.Animals.Queries.GetAnimalsByName;

internal class GetAnimalsByNameQueryHandler(IAnimalsDataProvider animalsDataProvider)
    : IRequestHandler<GetAnimalsByNameQuery, PageResponse<AnimalByNameDto[]>>
{
    public async Task<PageResponse<AnimalByNameDto[]>> Handle(GetAnimalsByNameQuery request, CancellationToken cancellationToken)
    {
        var animals = await animalsDataProvider.GetAll();

        var result = animals
            .Where(a => a.Name.Contains(request.Name))
            .Select(a => new AnimalByNameDto(a.Id ,a.Name, a.Age))
            .ToArray();
        var count = result.Length;

        return new PageResponse<AnimalByNameDto[]>(count, result);
    }
}

