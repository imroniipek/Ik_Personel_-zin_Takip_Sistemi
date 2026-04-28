using MediatR;
using Shared.ServiceResult;

namespace Personel.Personel.Application.Features.Personel.GetPersonelByEmail;

public record GetPersonelByEmailQuery(string Email):IRequest<ServiceResult<GetPersonelByEmailResponse>>{}