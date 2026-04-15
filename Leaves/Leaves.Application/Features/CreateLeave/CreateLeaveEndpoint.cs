using MediatR;
using Shared.ServiceResult.Extensions;

namespace Leaves.Leaves.Application.Features.CreateLeave;

public static class CreateLeaveEndpoint
{

    public static RouteGroupBuilder AddCreateLeaveEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapPost("/createNewLeave", async (CreateLeaveCommand createdLeaveCommand, IMediator mediator) =>
        {
            var theResponse=await mediator.Send(createdLeaveCommand);
            return theResponse.ToResult();
        });
        return builder;
    }
    
}