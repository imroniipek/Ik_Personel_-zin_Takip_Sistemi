using Approval.Approval.Domain;
using MediatR;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public record CreateApproval(int ManagerId,
    int PersonelId,
    ApprovalStatus Status,
    String?  RejectReason):IRequest<ServiceResult<CreateApprovalResponse>>{}
