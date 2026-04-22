namespace Personel.Personel.Application.Features.Personel.GetAllPersonel;

public class PersonelDto
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public DateOnly HireDate { get; set; }
    
    public string DepartmentName { get; set; } = null!;

}