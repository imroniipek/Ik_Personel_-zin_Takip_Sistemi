using Leaves.Leaves.Application.Abstraction.Repositories;
using Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;
using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetPendingLeavesByPersenolIdQuery;

public class GetPendingLeavesByPersonelIdQueryHandler(ILeaveRepository leaveRepository):IRequestHandler<GetPendingLeavesByPersonelIdQuery,ServiceResult<LeaveListResponse>>
{

    public async Task<ServiceResult<LeaveListResponse>> Handle(GetPendingLeavesByPersonelIdQuery request, CancellationToken cancellationToken)
    {
        var theLeaveListResponse = await leaveRepository.GetPendingLeavesByPersonelId(request.PersonelId);
        
        return ServiceResult<LeaveListResponse>.SuccessOk(theLeaveListResponse);
    }
}