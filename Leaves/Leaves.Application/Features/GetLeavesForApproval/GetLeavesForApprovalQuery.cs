using MediatR;

namespace Leaves.Leaves.Application.Features.GetLeavesForApproval;

public record GetLeavesForApprovalQuery(List<int> PersonelIdList):IRequest<ServiceResult<List<Domain.Leave>>>
{}
