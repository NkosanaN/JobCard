using TimeCard.Domain;

namespace TimeCard.Persistence.Repositories.Interface;

public interface IJobCardRepository
{
    Task<List<JobCard>> GetJobCardsAsync();
    Task<JobCard> GetJobCardAsync(int JobCardId);
    Task<bool> CreateJobCardAsync(JobCard jobCard);

 
}
