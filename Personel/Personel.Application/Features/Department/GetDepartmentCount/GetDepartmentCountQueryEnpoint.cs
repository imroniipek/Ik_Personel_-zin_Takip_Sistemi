using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Department.GetDepartmentCount;

public static class GetDepartmentCountQueryEnpoint
{

    public static RouteGroupBuilder GetTheDepartmentCount(this RouteGroupBuilder builder)
    {
        builder.MapGet("GetAllOfDepartmentCount", async (IMediator mediator) =>
        {
            var theQuery = new GetDepartmentCountQuery();

            var theResponse=await mediator.Send(theQuery);

           return  theResponse.ToResult();
           
        });
        return builder;
    }
}