using Shared;

namespace Approval.Approval.Application.Features.CreateNewApproval;

public record CreateApprovalResponse(int PersonelId,int LeaveId,LeaveStatus Status);