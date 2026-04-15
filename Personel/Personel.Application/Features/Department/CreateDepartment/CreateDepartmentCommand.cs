using MediatR;

namespace Personel.Personel.Application.Features.Department.CreateDepartment;

public record CreateDepartmentCommand(String Name):IRequest<ServiceResult<CreateDepartmentResponse>>{}