namespace Personel.Personel.Application.Features.Personel.GetAllPersonelsByDepartmentId;

public record class GetPersonelByDepartmentIdDto(int PersonelId,string FirstName,string LastName,string Email,string HireDate,string DepartmentName);