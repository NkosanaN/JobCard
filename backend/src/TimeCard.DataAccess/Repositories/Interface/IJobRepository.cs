using TimeCard.Domain;

namespace TimeCard.DataAccess.Interface;

public interface IJobRepository
{
    Task<List<Job>> GetJobsAsync();

    Task<bool> CreateJobAsync(Job job);

    Task<List<Job>> GetJobAsync(string JobId);
}
