using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;

public record GetAcceptedLeavesByPersonelIdQuery(int PersonelId):IRequest<ServiceResult<LeaveListResponse>>{}