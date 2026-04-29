using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.GetPersonelsByManagerId;

public static class GetPersonelsByManagerIdEndpoint
{
    public static RouteGroupBuilder GetPersonelsByManagerIdRoute(this RouteGroupBuilder builder)
    {
        builder.MapGet("/getPersonelByManagerId", async (int managerId, IMediator mediator) =>
        {
            var query = new GetPersonelByManagerIdQuery(managerId);
            var response = await mediator.Send(query);

            return response.ToResult();
        });

        return builder;
    }
}