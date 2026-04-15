using MediatR;
using Shared.Dtos;

namespace Personel.Personel.Application.Features.Personel.GetPersonelForLeave;

public record GetPersonelForLeaveQuery(int PersonelId) : IRequest<ServiceResult<PersonelInfoDto>>;