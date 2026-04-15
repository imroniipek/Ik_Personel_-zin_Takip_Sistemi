using Leaves.Leaves.Domain;
using Refit;

namespace Approval.Approval.Application.Abstraction.Client;

public interface IGetLeaveListForApproval
{
    [Get("api/GetLeaveListForApproval")]

    Task<List<Leave>> GetLeaveListForApproval(List<int> personelList);

}