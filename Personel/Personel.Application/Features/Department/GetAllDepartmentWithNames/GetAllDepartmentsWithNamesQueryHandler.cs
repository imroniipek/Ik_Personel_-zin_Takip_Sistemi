using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Department.GetAllDepartmentWithNames;

public class GetAllDepartmentsWithNamesQueryHandler(IDepartmentRepository departmentRepository):IRequestHandler<GetAllDepartmentsWithNamesQuery,ServiceResult<List<DepartmentDto>>>
{
    public async Task<ServiceResult<List<DepartmentDto>>> Handle(GetAllDepartmentsWithNamesQuery request, CancellationToken cancellationToken)
    {

       var theResult=await  departmentRepository.GetAllDepartmentsWithNamesAsync();

       return ServiceResult<List<DepartmentDto>>.SuccessOk(theResult);
       
    }
}