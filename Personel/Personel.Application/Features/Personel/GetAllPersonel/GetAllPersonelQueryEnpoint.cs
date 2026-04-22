using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.GetAllPersonel;

public static class GetAllPersonelQueryEndpoint
{
    public static RouteGroupBuilder AddGetAllPersonelQueryEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetAllOfPersonel", async (IMediator mediator) =>
        {
            var theResponse = await mediator.Send(new GetAllPersonelQuery());
            return theResponse.ToResult();
        });

        return builder;
    }
}