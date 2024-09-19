using Microsoft.EntityFrameworkCore;
using TimeCard.DataAccess;
using TimeCard.Domain;
using TimeCard.Persistence.Repositories.Interface;

namespace TimeCard.Persistence.Repositories;

public class JobCardRepository : IJobCardRepository
{
    private readonly DataContext _dataAccess;
    public JobCardRepository(DataContext dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<List<JobCard>> GetJobCardsAsync()
    {
        return await _dataAccess.JobCards.AsNoTracking()
                    .Include(j => j.Job)
                    .Include(e => e.Employee)
                    .ToListAsync();
    }

    public async Task<bool> CreateJobCardAsync(JobCard jobCard)
    {
        bool result;

        var jobCardModel = new JobCard
        {
            EmployeeId = jobCard.EmployeeId,
            JobId = jobCard.JobId,
            DateWorked = jobCard.DateWorked,            
            HoursWorked = jobCard.HoursWorked
        };

        await _dataAccess.JobCards.AddAsync(jobCardModel);

        result = await _dataAccess.SaveChangesAsync() > 0;

        if (result)
        {
            return result;
        }

        return result;
    }
    
    public async Task<JobCard> GetJobCardAsync(int JobCardId)
    {
        var result = await _dataAccess.JobCards.FindAsync(JobCardId);

        return result!;
    }

}
