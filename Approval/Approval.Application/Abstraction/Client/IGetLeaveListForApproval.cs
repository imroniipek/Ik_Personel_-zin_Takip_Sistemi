using Leaves.Leaves.Domain;
using Refit;
using Shared.ServiceResult;

namespace Approval.Approval.Application.Abstraction.Client;

public interface IGetLeaveListForApproval
{
    [Post("/api/GetLeaveListForApproval")]
    Task<ServiceResult<List<Leave>>> GetLeaveListForApproval([Body] int personelId);
}