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
    public async Task CreateJobCardAsync(JobCard jobCard)
    {
        await _dataAccess.JobCards.AddAsync(jobCard);
    }

    public async Task<JobCard> GetJobCardAsync(int JobCardId)
    {
        var result = await _dataAccess.JobCards.Where(j => j.JobCardId == JobCardId).FirstOrDefaultAsync();

        //check error handling if the is no job
        //check what's the difference between IEnumarable vs ?? 

        return result;
    }

    public async Task<List<JobCard>> GetJobCardsAsync()
    {
      return  await _dataAccess.JobCards.Include(j => j.Job).ToListAsync();
    }
}
