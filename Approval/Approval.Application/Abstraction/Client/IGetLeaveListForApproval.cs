using System.Collections;
using Leaves.Leaves.Domain;
using Refit;

namespace Approval.Approval.Application.Abstraction.Client;

public interface IGetLeaveListForApproval : IEnumerable
{
    [Get("api/GetLeaveListForApproval")]

    Task<List<Leave>> GetLeaveListForApproval(List<Personel.Personel.Domain.Personel> personelList);

}