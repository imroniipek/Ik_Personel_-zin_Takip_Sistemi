
using MediatR;
using Shared.Dtos;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.UpdateLeave;

public static class UpdateLeaveEndpoint
{

    public static RouteGroupBuilder AddUpdateLeaveEndpoint(this RouteGroupBuilder builder)
    {

        builder.MapPut("/UpdateTheLeaveAfterApproval/{leaveId}", async (int leaveId,LeaveDto leaveDto, IMediator mediator) =>
        {  var thequery = new UpdateLeaveCommand(leaveId,leaveDto);

            var response = await mediator.Send(thequery);

            return response.ToResult();
        });

        return builder;
    }
}