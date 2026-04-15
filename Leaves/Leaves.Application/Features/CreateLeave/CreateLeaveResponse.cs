using Leaves.Leaves.Domain;
using Shared;

namespace Leaves.Leaves.Application.Features.CreateLeave;

public record CreateLeaveResponse(
    int LeaveId,
    int PersonelId,
    DateTime StartedDate,
    DateTime EndedDate,
    LeaveStatus Status
);