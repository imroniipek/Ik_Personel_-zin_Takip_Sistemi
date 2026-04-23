using MediatR;
using Personel.Personel.Application.Abstraction;
using Personel.Personel.Application.Features.Personel.Dtos;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetAllPersonel;

public class GetAllPersonelQueryHandler
    : IRequestHandler<GetAllPersonelQuery, ServiceResult<List<PersonelDto>>>
{
    private readonly IPersonelRepository _repository;

    public GetAllPersonelQueryHandler(IPersonelRepository repository)
    {
        this._repository = repository;
    }

    public async Task<ServiceResult<List<PersonelDto>>> Handle(GetAllPersonelQuery request, CancellationToken cancellationToken)
    {
        var theList = await _repository.GetAllPersonelsAsync();

        var result = theList.Select(x => new PersonelDto(x)).ToList();
        
        return ServiceResult<List<PersonelDto>>.SuccessOk(result);
    }
}