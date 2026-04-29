using System.Net;
using Leaves.Leaves.Application.Abstraction.Repositories;
using Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;
using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetRejectedLeavesByPersonelId;

public class GetRejectedLeavesByPersonelIdQueryHandler(ILeaveRepository leaveRepository)
    : IRequestHandler<GetRejectedLeavesByPersonelIdQuery, ServiceResult<LeaveListResponse>>
{
    public async Task<ServiceResult<LeaveListResponse>> Handle(
        GetRejectedLeavesByPersonelIdQuery request,
        CancellationToken cancellationToken)
    {
        var response = await leaveRepository.GetRejectedLeavesByPersonelId(request.PersonelId);

        if (response.LeavesList.Count > 0)
        {
            return ServiceResult<LeaveListResponse>.SuccessOk(response);
        }

        return ServiceResult<LeaveListResponse>.Error(
            "Empty Fault",
            "Listede eleman yok",
            HttpStatusCode.BadRequest
        );
    }
}