using MediatR;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;

public static class GetAcceptedLeavesByPersonelIdQueryEndpoint
{
    public static RouteGroupBuilder AddGetAcceptedLeavesByPersonelIdQueryEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetAcceptedLeavesByPersonelIdQuery/{personelId:int}",
            async (int personelId, IMediator mediator) =>
            {
                var query = new GetAcceptedLeavesByPersonelIdQuery(personelId);

                var response = await mediator.Send(query);

                return response.ToResult();
            });

        return builder; 
    }
}