namespace Leaves.Leaves.Application.Features.GetPersonelsLeaveInfo;

public record GetPersonelLeaveInfoDto(int PersonelId, int TotalLeaveRight, int UsedLeaveDays, int RemainingLeaveDays );