using Personel.Personel.Application.Features.Department.CreateDepartment;
using Personel.Personel.Application.Features.Personel.CreatePersonel;
using Personel.Personel.Application.Features.Personel.GetPersonelForLeave;

namespace Personel.Personel.Application.Extension;

public static class EndpointExtensions
{
    public static WebApplication MapPersonelEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        group.CreateNewDepartment();
        group.CreateNewPersonelEndpoint();
        group.MapGetPersonelForLeaveEndpoint();

        return app;
    }
}