using MediatR;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.GetLeavesForApproval;

public static class GetLeavesEndpoint
{
    public static RouteGroupBuilder AddGetLeavesForApproval(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetLeaveListForApproval", async (
            [AsParameters] GetLeavesForApprovalQuery query,
            IMediator mediator) =>
        {
            var thequery = new GetLeavesForApprovalQuery(query.PersonelIdList);

            var response = await mediator.Send(thequery);

            return response.ToResult();
        });

        return builder;
    }
}

