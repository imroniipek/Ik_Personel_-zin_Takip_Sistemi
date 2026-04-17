using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.GetLeavesForApproval;

public static class GetLeavesEndpoint
{
    public static RouteGroupBuilder AddGetLeavesForApproval(this RouteGroupBuilder builder)
    {
        builder.MapPost("/GetLeaveListForApproval", async (
            [FromBody] int personelId,
            IMediator mediator) =>
        {
            var thequery = new GetLeavesForApprovalQuery(personelId);

            var response = await mediator.Send(thequery);

            return response.ToResult();
        });
        return builder;
    }
}

