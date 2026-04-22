using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.CreateManager;

public static class CreateManagerEndpoint
{
    public static RouteGroupBuilder AddNewManagerByGivenDepartmentId(this RouteGroupBuilder builder)
    {
        builder.MapPost("/CreateNewManagerByGivenDepartmentId", async (CreateManagerCommand createManagerCommand, IMediator mediator) =>
            {
              var response= await mediator.Send(createManagerCommand);

              return response.ToResult();
              
            });
        return builder;
    }
}