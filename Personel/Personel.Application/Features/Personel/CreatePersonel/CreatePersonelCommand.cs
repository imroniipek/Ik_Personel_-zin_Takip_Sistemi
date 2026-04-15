using MediatR;

namespace Personel.Personel.Application.Features.Personel.CreatePersonel;

public record CreatePersonelCommand(
    string FirstName, string LastName,string Email,int DepartmentId,DateTime? HireDate) 
    : IRequest<ServiceResult<CreatePersonelResponse>>;