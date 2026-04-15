using AutoMapper;
using MediatR;
using Personel.Personel.Application.Abstraction;

namespace Personel.Personel.Application.Features.Personel.CreatePersonel;

public class CreatePersonelRequestHandler(
    IPersonelRepository personelRepository
) : IRequestHandler<CreatePersonelCommand, ServiceResult<CreatePersonelResponse>>
{
    public async Task<ServiceResult<CreatePersonelResponse>> Handle(
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
            thePersonel.HireDate = DateTime.Now;
        }
        else
        {
            thePersonel.HireDate = (DateTime)request.HireDate;
        }
        var createdPersonel = await personelRepository.CreateNewPersonelAsync(thePersonel);

        return ServiceResult<CreatePersonelResponse>.SuccessCreatedOk(
            new CreatePersonelResponse(createdPersonel.Id),
            $"/api/personels/{createdPersonel.Id}"
        );
    }
}