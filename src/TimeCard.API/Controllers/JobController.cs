using Microsoft.AspNetCore.Mvc;
using TimeCard.DataAccess.Interface;
using TimeCard.Domain;

namespace TimeCard.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly ILogger<JobController> _logger;

    private readonly IJobRepository _jobRepository;

    public JobController(ILogger<JobController> logger, IJobRepository jobRepository)
    {
        _logger = logger;
        _jobRepository = jobRepository;
    }

    // must include Dto
    //[HttpGet(Name = "GetJobCard")]
    [HttpGet]
    public async Task<ActionResult<JobCard>> GetJobCard()
    {
        var jobCard = await _jobRepository.GetJobsAsync();

        _logger.LogInformation("GetJobCard");

        return Ok(jobCard);
    }
}
