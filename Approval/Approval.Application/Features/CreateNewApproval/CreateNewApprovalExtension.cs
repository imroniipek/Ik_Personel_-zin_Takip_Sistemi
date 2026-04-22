using MediatR;
using Shared.ServiceResult.Extensions;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public static class CreateNewApprovalExtension
{

    public static RouteGroupBuilder AddCreateExtension(this RouteGroupBuilder builder)
    {
        builder.MapPost("/createNewApproval", async (CreateApproval approvalRequest, IMediator mediator) =>
        {

            var theResponse=await mediator.Send(approvalRequest);

            return theResponse.ToResult();
            
        });
        return builder;
        
    }
}