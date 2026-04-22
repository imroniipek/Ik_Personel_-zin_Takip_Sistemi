using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.Dtos;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Department.GetPersonelsByManagerId;

public class GetPersonelByManagerIdQueryHandler(IDepartmentRepository repository)
    : IRequestHandler<GetPersonelByManagerIdQuery, ServiceResult<List<PersonelIdDto>>>
{
    public async Task<ServiceResult<List<PersonelIdDto>>> Handle(
        GetPersonelByManagerIdQuery request,
        CancellationToken cancellationToken)
    {
        var personelList = await repository.GetPersonelsByManagerIdAsync(request.ManagerId);

        var personelDtoList = personelList
            .Select(x => new PersonelIdDto(x.Id))
            .ToList();

        return ServiceResult<List<PersonelIdDto>>.SuccessOk(personelDtoList);
    }
}