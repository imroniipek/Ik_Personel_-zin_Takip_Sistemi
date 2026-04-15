using Shared;
using Shared.Entities;

namespace Leaves.Leaves.Domain;

public class Leave:BaseEntity
{
    
    public int PersonelId { get; set; }
    
    public DateTime StartedDate { get; set; }
    
    public DateTime EndedDate { get; set; }
    
    public LeaveStatus Status { get; set; }
}