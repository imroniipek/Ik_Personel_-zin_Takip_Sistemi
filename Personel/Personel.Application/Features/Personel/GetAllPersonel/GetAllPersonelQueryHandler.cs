using System.ComponentModel.DataAnnotations;
using MediatR;
using Personel.Personel.Application.Abstraction;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetAllPersonel;

public class GetAllPersonelQueryHandler
    : IRequestHandler<GetAllPersonelQuery, ServiceResult<List<PersonelDto>>>
{
    private readonly IPersonelRepository repository;

    public GetAllPersonelQueryHandler(IPersonelRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ServiceResult<List<PersonelDto>>> Handle(GetAllPersonelQuery request, CancellationToken cancellationToken)
    {
        var theList = await repository.GetAllPersonelsAsync();

        var result = theList.Select(x => new PersonelDto
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email=x.Email,
            HireDate=x.HireDate,
            DepartmentName = x.Department.Name
        }).ToList();
        
        return ServiceResult<List<PersonelDto>>.SuccessOk(result);
    }
}