using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetPersonelsLeaveInfo;

public record GetpersonelLeaveInfoQuery(int PersonelId):IRequest<ServiceResult<GetPersonelLeaveInfoDto>> {}