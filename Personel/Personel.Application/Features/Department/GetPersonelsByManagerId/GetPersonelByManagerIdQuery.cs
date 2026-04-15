using MediatR;
using Shared.Dtos;

namespace Personel.Personel.Application.Features.Department.GetPersonelsByManagerId;

public record GetPersonelByManagerIdQuery(int ManagerId):IRequest<ServiceResult<List<PersonelIdDto>>>
{}