namespace Leaves.Leaves.Application.Abstraction.Repositories;

public interface ILeaveRepository
{
    Task<bool?>IsThePersonel(int personelId);

    Task<int> GetAllLeavesByPersonelIdForTheOneYear(int personelId);

    Task<Leaves.Domain.Leave?> AddTheLeave(Leaves.Domain.Leave leave);

    Task<List<Domain.Leave>?> GetLeavesNotApproved(int personelId);
    Task  Update(Domain.Leave requestLeave);

    Task<Domain.Leave?> FindTheLeaveByLeaveId(int leaveId);

}