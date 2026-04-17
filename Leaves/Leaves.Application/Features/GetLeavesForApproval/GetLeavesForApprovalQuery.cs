using MediatR;
using Shared.ServiceResult;

namespace Leaves.Leaves.Application.Features.GetLeavesForApproval;

public record GetLeavesForApprovalQuery(int PersonelId) : IRequest<ServiceResult<List<Domain.Leave>>>;