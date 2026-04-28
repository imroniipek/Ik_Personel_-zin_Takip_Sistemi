using MediatR;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.GetPersonelsLeaveInfo;

public static class GetPersonelLeaveInfoEndpoint
{
    public static RouteGroupBuilder AddGetPersonelLeaveInfoEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetPersonelLeaveInfo/{personelId:int}", async (int personelId, IMediator mediator) =>
        {
            var thequery = new GetpersonelLeaveInfoQuery(personelId);

            var response = await mediator.Send(thequery);

            return response.ToResult();
        });
        return builder;
    }
}