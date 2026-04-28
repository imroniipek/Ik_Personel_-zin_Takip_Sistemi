using Leaves.Leaves.Application.Abstraction.Repositories;
using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;

public class GetAcceptedLeavesByPersonelIdQueryHandler(ILeaveRepository leaveRepository):IRequestHandler<GetAcceptedLeavesByPersonelIdQuery,ServiceResult<LeaveListResponse>>
{
    public async Task<ServiceResult<LeaveListResponse>> Handle(GetAcceptedLeavesByPersonelIdQuery request, CancellationToken cancellationToken)
    {

        var theLeaveListResponse = await leaveRepository.GetApprovedLeavesByPersonelId(request.PersonelId);
        
        return ServiceResult<LeaveListResponse>.SuccessOk(theLeaveListResponse);
    }
}