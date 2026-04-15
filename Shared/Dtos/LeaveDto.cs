namespace Shared.Dtos;

public record LeaveDto(int Id,int PersonelId,LeaveStatus Status,DateTime StartDate,DateTime EndDateTime );