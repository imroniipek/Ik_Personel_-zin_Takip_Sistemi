using MediatR;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.GetPendingLeavesByPersenolIdQuery;

public static class GetPendingLeavesByPersonelIdQueryEndpoint
{
    public static RouteGroupBuilder AddGetPendingLeavesByPersonelIdQueryEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetPendingLeavesByPersonelIdQuery/{personelId:int}",
            async (int personelId, IMediator mediator) =>
            {
                var response = await mediator.Send(
                    new GetPendingLeavesByPersenolIdQuery.GetPendingLeavesByPersonelIdQuery(personelId)
                );

                return response.ToResult();
            });

        return builder;
    }
}