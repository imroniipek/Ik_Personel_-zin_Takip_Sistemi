using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.Dtos;

namespace Personel.Personel.Application.Features.Department.GetPersonelsByManagerId;

public class GetPersonelByManagerIdQueryHandler(IDepartmentRepository repository)
    : IRequestHandler<GetPersonelByManagerIdQuery, ServiceResult<List<PersonelIdDto>>>
{
    public async Task<ServiceResult<List<PersonelIdDto>>> Handle(GetPersonelByManagerIdQuery request, CancellationToken cancellationToken)
    {
        var personelList=await repository.GetPersonelsByManagerIdAsync(request.ManagerId);

        var personelDtoList = new List<PersonelIdDto>();

        foreach (var personel in personelList)
        {
            var dto = new PersonelIdDto(personel.Id);
            
            personelDtoList.Add(dto);
        }
        
        return ServiceResult<List<PersonelIdDto>>.SuccessOk(personelDtoList);
    }
}