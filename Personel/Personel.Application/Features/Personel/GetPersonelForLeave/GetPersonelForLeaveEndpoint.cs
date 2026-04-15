using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.GetPersonelForLeave;

public static class GetPersonelForLeaveEndpoint
{
    public static RouteGroupBuilder MapGetPersonelForLeaveEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/personels/for-leave/{personelId}", async (
            [FromRoute] int personelId, IMediator mediator) =>
        {
            var query = new GetPersonelForLeaveQuery(personelId);
            var response = await mediator.Send(query);
            return response.ToResult();
        });

        return builder;
    }
}