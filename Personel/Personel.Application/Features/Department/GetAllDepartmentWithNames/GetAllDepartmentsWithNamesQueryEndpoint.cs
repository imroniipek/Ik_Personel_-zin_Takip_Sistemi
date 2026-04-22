using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Department.GetAllDepartmentWithNames;

public static  class GetAllDepartmentsWithNamesQueryEndpoint
{
    public static RouteGroupBuilder AddGetAllDepartmentsWithNamesQueryEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("/GetAllDepartmentWithDepartmentName", async (IMediator mediator) =>
        {
            var theResponse=await mediator.Send(new GetAllDepartmentsWithNamesQuery());

            return theResponse.ToResult();
        });
        return builder;
    }
}