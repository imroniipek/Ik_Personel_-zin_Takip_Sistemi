using MediatR;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetPersonelsCount;

public class GetPersonelQuery:IRequest<ServiceResult<int>> {}