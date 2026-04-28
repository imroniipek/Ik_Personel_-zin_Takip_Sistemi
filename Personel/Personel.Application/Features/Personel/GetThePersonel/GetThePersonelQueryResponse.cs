namespace Personel.Personel.Application.Features.Personel.GetThePersonel;

public record GetThePersonelQueryResponse(
    string FirstName,
    string LastName,
    string DepartmentName,
    string ManagerName,
    string HireDate
    );
