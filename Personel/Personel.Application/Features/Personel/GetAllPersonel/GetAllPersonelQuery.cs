using MediatR;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetAllPersonel;

public class GetAllPersonelQuery : IRequest<ServiceResult<List<PersonelDto>>>
{
}