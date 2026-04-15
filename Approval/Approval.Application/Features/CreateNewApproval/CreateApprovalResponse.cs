using Approval.Approval.Domain;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public record CreateApprovalResponse(int PersonelId,int LeaveId,ApprovalStatus Status);