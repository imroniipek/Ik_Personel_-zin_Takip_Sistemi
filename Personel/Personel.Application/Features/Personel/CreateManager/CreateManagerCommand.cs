using MediatR;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.CreateManager;

public record CreateManagerCommand(int DepartmentId,int ManagerId):IRequest<ServiceResult<CreateManagerResponse>>{}
     