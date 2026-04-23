using MediatR;
using Personel.Personel.Application.Abstraction;
using Personel.Personel.Application.Features.Personel.Dtos;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetAllPersonelsByDepartmentId;

public class GetAllPersonelByDepartmentIdHandler(IPersonelRepository personelRepository):IRequestHandler<GetAllPersonelsByDepartmentId,ServiceResult<List<PersonelDto>>>
{
    public async Task<ServiceResult<List<PersonelDto>>> Handle(GetAllPersonelsByDepartmentId request, CancellationToken cancellationToken)
    {
       var thePersonelList=await  personelRepository.GetAllPersonelsByDepartmentIdAsync(request.DepartmentId);

       var thePersonelDtoList=thePersonelList.Select(x => new PersonelDto(x)).ToList();

       return ServiceResult<List<PersonelDto>>.SuccessOk(thePersonelDtoList);
       
    }
}