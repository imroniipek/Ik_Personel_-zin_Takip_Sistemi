using MediatR;
using Shared.ServiceResult.Extensions;

namespace Personel.Personel.Application.Features.Personel.GetAllPersonelsByDepartmentId;

public static  class GetAllPersonelByDepartmentIdEnpoint
{
    public static RouteGroupBuilder AddGetAllPersonelByDepartmentIdEnpoint(this RouteGroupBuilder builder)
    {

        builder.MapGet("/GetAllPersonelByDepartmentId", async (int departmentId, IMediator mediator) =>
        {
           var theResponse=await  mediator.Send(new GetAllPersonelsByDepartmentId(departmentId));
           return theResponse.ToResult();
        });

        return builder;
    }
}