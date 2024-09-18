using TimeCard.Domain;

namespace TimeCard.Persistence.Repositories.Interface;

public interface IJobCardRepository
{
    Task<List<JobCard>> GetJobCardsAsync();

    Task CreateJobCardAsync(JobCard jobCard);

    Task<JobCard> GetJobCardAsync(int JobCardId);
}
