using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Department.GetDepartmentCount;

public class GetDepartmentCountQueryHandler(IDepartmentRepository departmentRepository):IRequestHandler<GetDepartmentCountQuery,ServiceResult<int>>
{
    public async Task<ServiceResult<int>> Handle(GetDepartmentCountQuery request, CancellationToken cancellationToken)
    {

        int theDepartmentCount=await departmentRepository.GetDepartmentCountAsync();

        return ServiceResult<int>.SuccessOk(theDepartmentCount);
        
    }
}