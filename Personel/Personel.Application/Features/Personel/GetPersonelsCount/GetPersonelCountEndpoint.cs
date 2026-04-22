using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.GetPersonelsCount;

public static class GetPersonelCountEndpoint
{
    public static RouteGroupBuilder MapGetAllPersonelCountEndpoint(this RouteGroupBuilder builder)
    {

        builder.MapGet("/GetAllOfPersonelCount", async (IMediator mediator) =>
        {
            var theRequest = new GetPersonelQuery();
            var theResponse=await mediator.Send(theRequest);

            return theResponse.ToResult();
        });

        return builder;
        
    }
}