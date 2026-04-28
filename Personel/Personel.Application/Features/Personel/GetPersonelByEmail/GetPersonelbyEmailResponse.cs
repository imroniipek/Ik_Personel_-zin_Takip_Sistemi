namespace Personel.Personel.Application.Features.Personel.GetPersonelByEmail;

public record GetPersonelByEmailResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email
);