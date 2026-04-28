using Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;
using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetPendingLeavesByPersenolIdQuery;

public record GetPendingLeavesByPersonelIdQuery(int PersonelId):IRequest<ServiceResult<LeaveListResponse>>{}