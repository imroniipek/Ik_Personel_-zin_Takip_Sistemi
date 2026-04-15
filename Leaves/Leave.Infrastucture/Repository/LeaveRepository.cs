using Leaves.Leave.Infrastucture.Context;
using Leaves.Leaves.Application.Abstraction.Repositories;
using Leaves.Leaves.Domain;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Leaves.Leave.Infrastucture.Repository;

public class LeaveRepository(LeaveDbContext context):ILeaveRepository
{
    public async Task<bool?> IsThePersonel(int personelId)
    {
        return await context.Leaves.AsNoTracking().AnyAsync(x => x.PersonelId == personelId);
    }
    
    public async Task<int> GetAllLeavesByPersonelIdForTheOneYear(int personelId)
    {
        var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
        var startOfNextYear = startOfYear.AddYears(1);

        var theLeaveList=await context.Leaves
            .AsNoTracking()
            .Where(x => x.PersonelId == personelId &&
                        x.StartedDate >= startOfYear &&
                        x.StartedDate < startOfNextYear)
            .ToListAsync();

        return theLeaveList.Count;
    }

    public async Task<Leaves.Domain.Leave?> AddTheLeave(Leaves.Domain.Leave leave)
    {
        var theLeaveEntity=await context.Leaves.AddAsync(leave);

        await context.SaveChangesAsync();

        return theLeaveEntity.Entity;

    }

    public async Task<List<Leaves.Domain.Leave>?> GetLeavesNotApproved(List<int> personelIdList)
    {
        return await context.Leaves
            .AsNoTracking()
            .Where(x => personelIdList.Contains(x.PersonelId) && x.Status == LeaveStatus.Pending)
            .ToListAsync();
    }

    public async Task Update(Leaves.Domain.Leave requestLeave)
    {
        context.Update(requestLeave);

        await context.SaveChangesAsync();
        
    }

    public async Task<Leaves.Domain.Leave?> FindTheLeaveByLeaveId(int leaveId)
    {
        return await context.Leaves.FirstOrDefaultAsync(x => x.Id == leaveId);
    }
}