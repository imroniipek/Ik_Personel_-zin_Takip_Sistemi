using MediatR;
using Shared;
using Shared.ServiceResult;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public record CreateApproval(
    int ManagerId,
    int PersonelId,
    int LeaveId,
    LeaveStatus Status,
    String?  RejectReason):IRequest<ServiceResult<CreateApprovalResponse>>{}
