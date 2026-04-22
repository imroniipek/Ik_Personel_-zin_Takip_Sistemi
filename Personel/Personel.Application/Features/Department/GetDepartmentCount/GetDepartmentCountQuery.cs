using MediatR;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Department.GetDepartmentCount;

public class GetDepartmentCountQuery:IRequest<ServiceResult<int>> {}