using Shared;

namespace Approval.Approval.Domain;

public class Approval
{
    public int Id { get; set; }

    public int LeaveId { get; set; } 

    public int PersonelId { get; set; } 
    
    public int ManagerId { get; set; }   

    public LeaveStatus Status { get; set; } 

    public string? RejectionReason { get; set; }

    public DateOnly CreatedAt { get; set; }
    
}