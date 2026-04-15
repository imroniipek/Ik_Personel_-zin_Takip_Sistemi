using Shared.Entities;

namespace Personel.Personel.Domain;

public class Personel : BaseEntity
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public DateTime HireDate { get; set; }
    
    public int DepartmentId { get; set; }
    
    public Department Department { get; set; } = null!;
    
}