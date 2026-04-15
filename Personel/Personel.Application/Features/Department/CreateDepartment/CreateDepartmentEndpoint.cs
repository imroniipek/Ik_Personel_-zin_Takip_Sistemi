using MediatR;
using Microsoft.AspNetCore.Routing;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Department.CreateDepartment;

public static class CreateDepartmentEndpoint
{
    public static RouteGroupBuilder CreateNewDepartment(this RouteGroupBuilder builder)
    {
        builder.MapPost("/CreateNewDepartment", async (CreateDepartmentCommand command, IMediator mediator) =>
        {
            var theResponse = await mediator.Send(command);

            return theResponse.ToResult();

        });

        return builder;
    }
}