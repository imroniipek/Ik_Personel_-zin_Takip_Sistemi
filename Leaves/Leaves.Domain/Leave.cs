using Shared;
using Shared.Entities;

namespace Leaves.Leaves.Domain;

public class Leave:BaseEntity
{
    
    public int PersonelId { get; set; }
    
    public DateOnly StartedDate { get; set; }
    
    public DateOnly EndedDate { get; set; }
    
    public LeaveStatus Status { get; set; }
}