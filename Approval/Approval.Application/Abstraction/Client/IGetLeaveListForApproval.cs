using Leaves.Leaves.Domain;
using Refit;

namespace Approval.Approval.Application.Abstraction.Client;

public interface IGetLeaveListForApproval
{
    [Get("/api/GetLeaveListForApproval/{personelId}")]
    Task<List<Leave>> GetLeaveListForApproval(int personelId);
}