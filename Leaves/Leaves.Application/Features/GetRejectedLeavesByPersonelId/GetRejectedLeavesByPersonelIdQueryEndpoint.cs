using MediatR;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.GetRejectedLeavesByPersonelId;

public static class GetRejectedLeavesByPersonelIdQueryEndpoint
{
    public static RouteGroupBuilder AddRejectedLeavesByPersonelIdQueryEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetRejectedLeavesByPersonelIdQuery/{personelId:int}",
            async (int personelId, IMediator mediator) =>
            {
                var query = new GetRejectedLeavesByPersonelIdQuery(personelId);

                var response = await mediator.Send(query);

                return response.ToResult();
            });

        return builder; 
    }
}