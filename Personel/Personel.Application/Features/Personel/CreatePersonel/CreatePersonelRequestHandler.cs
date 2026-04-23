using MediatR;
using Personel.Personel.Application.Abstraction;
using Personel.Personel.Application.Features.Personel.Dtos;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.CreatePersonel;

public class CreatePersonelRequestHandler(
    IPersonelRepository personelRepository
) : IRequestHandler<CreatePersonelCommand, ServiceResult<PersonelDto>>
{
    public async Task<ServiceResult<PersonelDto>> Handle(
        CreatePersonelCommand request,
        CancellationToken cancellationToken)
    {
        var thePersonel = new Domain.Personel
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email=request.Email,
            DepartmentId = request.DepartmentId
        };

        if (request.HireDate == null)
        {
            thePersonel.HireDate = DateOnly.FromDateTime(DateTime.Now);
            
        }
        else
        {
            thePersonel.HireDate = (DateOnly)request.HireDate;
        }
        var createdPersonel = await personelRepository.CreateNewPersonelAsync(thePersonel);

        return ServiceResult<PersonelDto>.SuccessCreatedOk(
            new PersonelDto(createdPersonel),
            $"/api/personels/{createdPersonel.Id}"
        );
    }
}