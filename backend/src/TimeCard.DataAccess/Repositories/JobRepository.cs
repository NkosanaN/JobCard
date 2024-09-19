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

    public async Task<List<Job>> GetJobAsync(string JobId)
    {
        var result = await _dataAccess.Jobs.Where(j => j.JobId == JobId)
                           .Include( jc => jc.JobCards)
                           .ToListAsync();

        //check error handling if the is no job
        //check what's the difference between IEnumarable vs ?? 

        return result;
    }

    public async Task<bool> CreateJobAsync(Job job)
    {
        bool result;

        var JobTypes = new Dictionary<int, string>
        {
            { 1, "Repair" },
            { 2, "Support" },
            { 3, "Warranty" }
        };

        //Get Seleted JobType
        var jobtype = JobTypes.Where(c => c.Key == int.Parse(job.JobType))
                              .Select(c => c.Value).FirstOrDefault();

        var GeneratedJobId = GenerateJobNo(jobtype!);

        job.JobId = GeneratedJobId;
        job.JobType = jobtype!;

        await _dataAccess.Jobs.AddAsync(job);

        result = await _dataAccess.SaveChangesAsync() > 0;

        if (result) 
        {
            return result;
        }

        return result;
    }

    private string GenerateJobNo(string jobType)
    {
        char jobTypeInitial = jobType.ToUpper()[0];

        // Retrieve the last job number for this type from the database
        string lastJobNo = _dataAccess.Jobs
            .Where(j => j.JobId.StartsWith(jobTypeInitial.ToString()))
            .OrderByDescending(j => j.JobId)
            .Select(j => j.JobId)
            .FirstOrDefault()!;

        // Initialize the next number to 1 if no previous job exists for this type
        int nextNumber = 1;

        // If a previous job exists, extract the numeric part and increment it
        if (lastJobNo != null)
        {
            string numericPart = lastJobNo.Substring(1); // Extract the number part after the first letter
            nextNumber = int.Parse(numericPart) + 1;
        }

        // Format the new job number (e.g., R00011)
        string newJobNo = $"{jobTypeInitial}{nextNumber.ToString("D5")}";

        return newJobNo;
    }


}