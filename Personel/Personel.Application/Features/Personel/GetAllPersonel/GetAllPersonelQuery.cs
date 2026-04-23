using MediatR;
using Personel.Personel.Application.Features.Personel.Dtos;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetAllPersonel;

public class GetAllPersonelQuery : IRequest<ServiceResult<List<PersonelDto>>>
{
}