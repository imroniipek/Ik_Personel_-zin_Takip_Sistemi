using MediatR;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.CreatePersonel;

public record CreatePersonelCommand(
    string FirstName, string LastName,string Email,int DepartmentId,DateOnly? HireDate) 
    : IRequest<ServiceResult<CreatePersonelResponse>>;