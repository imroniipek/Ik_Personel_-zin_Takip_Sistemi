using MediatR;
using Personel.Personel.Application.Abstraction;

namespace Personel.Personel.Application.Features.Department.CreateDepartment;

public class CreateDepartmentCommandHandler
    : IRequestHandler<CreateDepartmentCommand, ServiceResult<CreateDepartmentResponse>>
{
    private readonly IDepartmentRepository _repository;

    public CreateDepartmentCommandHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<CreateDepartmentResponse>> Handle(
        CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var theDepartment = new Domain.Department
        {
            Name = request.Name
        };

        var createdDepartment = await _repository.CreateNewDepartmentAsync(theDepartment);

        var response = new CreateDepartmentResponse(createdDepartment.Id);
        

        return ServiceResult<CreateDepartmentResponse>.SuccessCreatedOk(
            response,
            $"/api/departments/{createdDepartment.Id}"
        );
    }
}
