using TimeCard.Domain;

namespace TimeCard.DataAccess.Interface;

public interface IJobRepository
{
    Task<List<Job>> GetJobsAsync();

    Task CreateJobAsync(Job job);

    Task<Job> GetJobAsync(string JobId);
}
