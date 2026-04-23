using Personel.Personel.Application.Features.Department.CreateDepartment;
using Personel.Personel.Application.Features.Department.GetAllDepartmentWithNames;
using Personel.Personel.Application.Features.Department.GetDepartmentCount;
using Personel.Personel.Application.Features.Department.GetPersonelsByManagerId;
using Personel.Personel.Application.Features.Personel.CreateManager;
using Personel.Personel.Application.Features.Personel.CreatePersonel;
using Personel.Personel.Application.Features.Personel.GetAllPersonel;
using Personel.Personel.Application.Features.Personel.GetAllPersonelsByDepartmentId;
using Personel.Personel.Application.Features.Personel.GetPersonelForLeave;
using Personel.Personel.Application.Features.Personel.GetPersonelsCount;

namespace Personel.Personel.Application.Extension;

public static class EndpointExtensions
{
    public static WebApplication MapPersonelEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        group.CreateNewDepartment();
        group.CreateNewPersonelEndpoint();
        group.AddNewManagerByGivenDepartmentId();
        group.AddGetAllPersonelQueryEndpoint();
        group.MapGetPersonelForLeaveEndpoint();
        group.GetPersonelsByManagerIdRoute();
        group.MapGetAllPersonelCountEndpoint();
        group.GetTheDepartmentCount();
        group.AddGetAllDepartmentsWithNamesQueryEndpoint();
        group.AddGetAllPersonelByDepartmentIdEnpoint();

        return app;
    }
}