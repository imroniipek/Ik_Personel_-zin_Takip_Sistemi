using Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;
using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetRejectedLeavesByPersonelId;

public record GetRejectedLeavesByPersonelIdQuery(int PersonelId):IRequest<ServiceResult<LeaveListResponse>>{}