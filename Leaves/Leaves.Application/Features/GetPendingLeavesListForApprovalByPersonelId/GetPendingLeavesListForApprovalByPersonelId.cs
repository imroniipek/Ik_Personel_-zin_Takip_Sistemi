using MediatR;
using Shared.Dtos;

namespace Leaves.Leaves.Application.Features.GetPendingLeavesListForApprovalByPersonelId;

public record GetPendingLeavesListForApprovalByPersonelId(
    List<PersonelIdDto> PersonelIdDtoList
) : IRequest<List<Domain.Leave>>;