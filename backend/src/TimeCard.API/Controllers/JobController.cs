using Microsoft.AspNetCore.Mvc;
using System.Net;
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

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Job>))]
    public async Task<List<Job>> GetJobsAsync()
    {
        var job = await _jobRepository.GetJobsAsync();

        _logger.LogInformation("GetJobsAsync");

        return job;
    }


    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Job>))]
    public async Task<List<Job>> GetJobAsync(string id)
    {
        var job = await _jobRepository.GetJobAsync(id);

        _logger.LogInformation("GetJobAsync");

        return job;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Job))]
    public async Task<ActionResult> CreateJobAsync([FromBody] Job job)
    {

        if(!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        await _jobRepository.CreateJobAsync(job);

        _logger.LogInformation("CreateJobAsync");

        return Ok();
    }
}
