using MediatR;
using Shared.Dtos;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetPersonelForLeave;

public record GetPersonelForLeaveQuery(int PersonelId) : IRequest<ServiceResult<PersonelInfoDto>>;