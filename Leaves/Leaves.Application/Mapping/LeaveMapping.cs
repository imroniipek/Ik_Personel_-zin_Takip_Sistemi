using AutoMapper;
using Leaves.Leaves.Application.Features.CreateLeave;

namespace Leaves.Leaves.Application.Mapping;

public class LeaveMapping : Profile
{
    public LeaveMapping()
    {
        CreateMap<Domain.Leave, CreateLeaveResponse>().ReverseMap();
    }
}