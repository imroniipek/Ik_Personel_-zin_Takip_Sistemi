using System.Net;
using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.CreateManager;

public class CreateManagerHandler(
    IPersonelRepository repository,
    IDepartmentRepository departmentRepository)
    : IRequestHandler<CreateManagerCommand, ServiceResult<CreateManagerResponse>>
{
    public async Task<ServiceResult<CreateManagerResponse>> Handle(
        CreateManagerCommand request,
        CancellationToken cancellationToken)
    {
        bool isExistingId = await departmentRepository.IsExistAsync(request.DepartmentId);

        if (!isExistingId)
        {
            return ServiceResult<CreateManagerResponse>.Error(
                title: "Not Found DepartmentId",
                description: "The department does not exist",
                httpStatusCode: HttpStatusCode.NotFound);
        }

        var theManager = await repository.GetPersonelByIdAsync(request.ManagerId);

        if (theManager is null)
        {
            return ServiceResult<CreateManagerResponse>.ErrorAsNotFound();
        }

        var theDepartment = await departmentRepository.GetDepartmentByDepartmentIdAsync(request.DepartmentId);

        if (theDepartment is null)
        {
            return ServiceResult<CreateManagerResponse>.ErrorAsNotFound();
        }
        

        theDepartment.ManagerId = request.ManagerId;
        theDepartment.Manager = theManager;

        await departmentRepository.Update(theDepartment);

        var response = new CreateManagerResponse(request.DepartmentId, theDepartment.Name, request.ManagerId,
            $"{theManager.FirstName} {theManager.LastName}");

        return ServiceResult<CreateManagerResponse>.SuccessCreatedOk(
            response,
            $"/api/departments/{request.DepartmentId}/manager"
        );
    }
}