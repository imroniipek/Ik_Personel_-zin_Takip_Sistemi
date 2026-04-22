using MediatR;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Department.GetAllDepartmentWithNames;

public class GetAllDepartmentsWithNamesQuery:IRequest<ServiceResult<List<DepartmentDto>>>{}

