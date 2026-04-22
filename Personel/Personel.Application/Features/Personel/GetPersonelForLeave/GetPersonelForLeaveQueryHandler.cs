using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.Dtos;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetPersonelForLeave;

public class GetPersonelForLeaveQueryHandler
    : IRequestHandler<GetPersonelForLeaveQuery, ServiceResult<PersonelInfoDto>>
{
    private readonly IPersonelRepository _personelRepository;

    public GetPersonelForLeaveQueryHandler(IPersonelRepository personelRepository)
    {
        _personelRepository = personelRepository;
    }

    public async Task<ServiceResult<PersonelInfoDto>> Handle(
        GetPersonelForLeaveQuery request,
        CancellationToken cancellationToken)
    {
        var personel = await _personelRepository.GetPersonelByIdAsync(request.PersonelId);

        if (personel == null)
        {
            return ServiceResult<PersonelInfoDto>.ErrorAsNotFound();
        }

        var dto = new PersonelInfoDto
        {
            PersonelId = personel.Id,
            HireDate = personel.HireDate,
        };
            

        return ServiceResult<PersonelInfoDto>.SuccessOk(dto);
    }
}