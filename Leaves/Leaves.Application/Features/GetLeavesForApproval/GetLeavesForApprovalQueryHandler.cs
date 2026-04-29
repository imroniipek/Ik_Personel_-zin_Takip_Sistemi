using Leaves.Leaves.Application.Abstraction.Repositories;
using MediatR;
using Shared.ServiceResult;
namespace Leaves.Leaves.Application.Features.GetLeavesForApproval;
public class GetLeavesForApprovalQueryHandler(ILeaveRepository repository)
    : IRequestHandler<GetLeavesForApprovalQuery, ServiceResult<List<Domain.Leave>>>
{
    public async Task<ServiceResult<List<Domain.Leave>>> Handle(
        GetLeavesForApprovalQuery request,
        CancellationToken cancellationToken)
    {
        var leaves = await repository.GetLeavesNotApproved(request.PersonelId);
        return ServiceResult<List<Domain.Leave>>.SuccessOk(leaves!);
    }
}