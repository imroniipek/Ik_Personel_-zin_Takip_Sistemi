using System.Net;
using Leaves.Leaves.Application.Abstraction.Repositories;
using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;

public class GetAcceptedLeavesByPersonelIdQueryHandler(ILeaveRepository leaveRepository):IRequestHandler<GetAcceptedLeavesByPersonelIdQuery,ServiceResult<LeaveListResponse>>
{
    public async Task<ServiceResult<LeaveListResponse>> Handle(GetAcceptedLeavesByPersonelIdQuery request, CancellationToken cancellationToken)
    {

        var theLeaveListResponse = await leaveRepository.GetApprovedLeavesByPersonelId(request.PersonelId);
        
        if (theLeaveListResponse.LeavesList.Count > 0)
        {
            return ServiceResult<LeaveListResponse>.SuccessOk(theLeaveListResponse);
        }

        return ServiceResult<LeaveListResponse>.Error("Empty Fault", "Listede Eleman Yok", HttpStatusCode.BadRequest);
    }
}