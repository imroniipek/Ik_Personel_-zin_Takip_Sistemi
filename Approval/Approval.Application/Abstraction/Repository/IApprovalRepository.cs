namespace Approval.Approval.Application.Abstraction.Repository;

public interface IApprovalRepository
{
    Task<Domain.Approval> CreateApproval(Domain.Approval approval);
    
    Task DeleteApproval(int id); 
}