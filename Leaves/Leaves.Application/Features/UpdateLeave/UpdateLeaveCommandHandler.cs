using Leaves.Leaves.Application.Abstraction.Repositories;
using MediatR;

namespace Leaves.Leaves.Application.Features.UpdateLeave;

public class UpdateLeaveCommandHandler(ILeaveRepository repository)
    : IRequestHandler<UpdateLeaveCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
    {
        var theLeave = await repository.FindTheLeaveByLeaveId(request.LeaveId);

        if (theLeave == null)
        {
            return ServiceResult.ErrorAsNoFound();
        }


        theLeave.PersonelId = request.LeaveDto.PersonelId;
        theLeave.StartedDate = request.LeaveDto.StartDate;
        theLeave.EndedDate = request.LeaveDto.EndDateTime;
        theLeave.Status = request.LeaveDto.Status;
        
        await repository.Update(theLeave);

        return ServiceResult.SuccessAsNoContent();
    }
}