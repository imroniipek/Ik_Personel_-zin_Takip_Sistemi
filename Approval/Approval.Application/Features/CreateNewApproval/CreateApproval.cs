using MediatR;
using Shared;
using Shared.ServiceResult;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public record CreateApproval(
    int ManagerId,
    int PersonelId,
    LeaveStatus Status,
    String?  RejectReason):IRequest<ServiceResult<CreateApprovalResponse>>{}
