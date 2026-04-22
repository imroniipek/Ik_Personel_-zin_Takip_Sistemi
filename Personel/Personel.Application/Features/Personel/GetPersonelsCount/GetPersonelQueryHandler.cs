using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetPersonelsCount;

public class GetPersonelQueryHandler(IPersonelRepository personelRepository):IRequestHandler<GetPersonelQuery,ServiceResult<int>>
{
    public async Task<ServiceResult<int>> Handle(GetPersonelQuery query, CancellationToken cancellationToken)
    {
        int theCount=await personelRepository.GetAllPersonelsCountAsync();

        return ServiceResult<int>.SuccessOk(theCount);
    }
}