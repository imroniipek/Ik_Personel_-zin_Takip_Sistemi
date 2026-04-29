using MediatR;
using Shared.ServiceResult.Extensions;

namespace Approval.Approval.Application.Features.GetAllPersonelPendingListByManagerId;

public static class GetAllPersonelPendingListByManagerIdEndpoint
{
    public static RouteGroupBuilder AddGetAllPersonelPendingListByManagerIdEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetPendingLeavesListForApprovalByPersonelIdQuery", async (int managerId, IMediator mediator) =>
        {
            var theResponse=await mediator.Send(new GetAllPersonelPendingListByManagerId(managerId));

            return theResponse.ToResult();
        });
        return builder;
    }
}