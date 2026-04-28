using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.ServiceResult;
using System.Net;

namespace Personel.Personel.Application.Features.Personel.GetPersonelByEmail;

public class GetPersonelByEmailQueryHandler(IPersonelRepository repository) : IRequestHandler<GetPersonelByEmailQuery, ServiceResult<GetPersonelByEmailResponse>>
{
   
    public async Task<ServiceResult<GetPersonelByEmailResponse>> Handle(
        GetPersonelByEmailQuery request,
        CancellationToken cancellationToken)
    {
        var personel = await repository.GetPersonelByEmailAsync(request.Email);

        if (personel is null)
        {
            return ServiceResult<GetPersonelByEmailResponse>.Error(
                "Personel bulunamadı",
                "Bu email ile kayıtlı personel bulunamadı.",
                HttpStatusCode.NotFound
            );
        }

        var response = new GetPersonelByEmailResponse(
            personel.Id,
            personel.FirstName,
            personel.LastName,
            personel.Email
        );

        return ServiceResult<GetPersonelByEmailResponse>.SuccessOk(response);
    }
}