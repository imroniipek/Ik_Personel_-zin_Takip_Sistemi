using Leaves.Leaves.Domain;
using Shared;

namespace Leaves.Leaves.Application.Features.CreateLeave;

public record CreateLeaveResponse(
    int LeaveId,
    int PersonelId,
    DateOnly StartedDate,
    DateOnly EndedDate,
    LeaveStatus Status
);