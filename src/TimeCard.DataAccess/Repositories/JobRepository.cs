using Microsoft.EntityFrameworkCore;
using TimeCard.DataAccess;
using TimeCard.DataAccess.Interface;
using TimeCard.Domain;

namespace TimeCard.Persistence.Repositories;

public class JobRepository : IJobRepository
{
    private readonly DataContext _dataAccess;
    public JobRepository(DataContext dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<List<Job>> GetJobsAsync()
    {
        return await _dataAccess.Jobs.ToListAsync();
    }

    public async Task CreateJobAsync(Job job)
    {
        await _dataAccess.Jobs.AddAsync(job);
    }

    public async Task<Job> GetJobAsync(string JobId)
    {
        var result = await _dataAccess.Jobs.Where(j => j.JobId == JobId).FirstOrDefaultAsync();

        //check error handling if the is no job
        //check what's the difference between IEnumarable vs ?? 

        return result;
    }
}