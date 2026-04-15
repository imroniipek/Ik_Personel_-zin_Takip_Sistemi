using Refit;
using Shared.Dtos;

namespace Approval.Approval.Application.Abstraction.Client;

public interface IPutLeaveAfterApproval
{

    [Put("/api/UpdateTheLeaveAfterApproval/{leaveId}")]
    Task UpdateTheLeave(int leaveId, [Body] LeaveDto leaveDto);
    
}