namespace Leaves.Leaves.Application.Features.GetAcceptedLeavesByPersonelId;

public record LeaveListResponse(int CountList, List<Domain.Leave> LeavesList);
