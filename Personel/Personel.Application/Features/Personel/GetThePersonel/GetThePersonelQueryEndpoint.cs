using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.GetThePersonel;

public static class GetThePersonelQueryEndpoint
{
    public static RouteGroupBuilder AddGetThePersonelQueryEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/personels/{personelId}", async (int personelId, IMediator mediator) =>
        {

            var theResponse = await mediator.Send(new GetThePersonelQuery(personelId));

            return theResponse.ToResult();
        });

        return builder;
    }
}