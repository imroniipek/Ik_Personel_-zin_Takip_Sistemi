using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.GetPersonelByEmail;

public static class GetPersonelByEmailEndpoint
{
    public static RouteGroupBuilder AddGetPersonelByEmailEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetPersonelByEmail/{email}", async (
            string email,
            IMediator mediator) =>
        {
            var result = await mediator.Send(new GetPersonelByEmailQuery(email));
            return result.ToResult();
        });

        return builder;
    }
}